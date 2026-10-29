using Mono.Cecil;
using MonoMod;
using MonoMod.Cil;
using MonoMod.InlineRT;
using MonoMod.Utils;
using Quintessential;
using System;

#pragma warning disable IDE1006
#pragma warning disable IDE0051

class patch_Sim
{
    [MonoModPublic]
    [MonoModIgnore]
    public float simDeltaTime;

    [MonoModILInject("RunCycleGlyphs")]
    public static void PatchDisposal(MethodDefinition method, CustomAttribute attribute)
    {
        // throw if method body is empty; nothing to check!
        if (!method.HasBody)
        {
            throw new Exception("Unable to patch wasActivated reset. (no body)");
        }

        ILCursor cursor = new(new ILContext(method));

        // go to ~ IL_1656: `else if (referredPart.part.GetType() == PartTypes.disposalGlyph) {...}` in `RunCycleGlyphs`
        cursor.TryGotoNext(MoveType.After,
            instr => instr.MatchLdfld("ReferredPart", "part"),
            instr => instr.MatchCallvirt("Part", "GetType"),
            instr => instr.MatchLdsfld("PartTypes", "disposalGlyph"),
            instr => instr.MatchBneUn(out ILLabel _)
        );

        // get local value where the atomReference is (stack pos may vary)
        int atomReference = 0;
        cursor.TryGotoNext(MoveType.After,
            instr => instr.MatchLdloc0(),
            instr => instr.MatchLdcI4(0),
            instr => instr.MatchCallvirt("Sim", "GetAtomReference"),
            instr => instr.MatchLdloca(out atomReference)
        );
        if (atomReference == 0) throw new SystemException("Origami: Failed to find atomReference stack position. If you are seeing this, scream at me (hi30), please!!!!");

        // go to ~ IL_16b5: `ldstr "om:indisposable"`
        cursor.TryGotoNext(MoveType.After,
            instr => instr.MatchLdstr("om:indisposable")
        );

        // go to ~ IL_16cd: `brtrue IL_1a0f`
        cursor.TryGotoNext(MoveType.After,
            instr => instr.MatchLdloc(atomReference),
            instr => instr.MatchCallvirt("Quintessential.AtomTag", "HasAtom"),
            instr => instr.MatchBrtrue(out ILLabel _)
        );

        // push params
        cursor.EmitLdarg0();
        cursor.EmitLdloc(atomReference); // push the atomReference of the disposed atom to the eval stack

        // call local method that does the rest of the logic :3
        TypeDefinition sim = MonoModRule.Modder.FindType("Sim").Resolve();
        cursor.EmitCallvirt(sim.FindMethod("Origami_OnDisposal"));
    }

    private static void Origami_OnDisposal(Sim sim, AtomReference trashedAtomReference) {
        if (trashedAtomReference.atomType.Equals(Origami.Atoms.homonculum))
        {
            SolutionEditorScreen p_ses = (SolutionEditorScreen) sim.solutionEditor;
            p_ses.HandleSimulationError(
                ((patch_Sim)(object)sim).simDeltaTime,
                Origami.Origami.Instance.Translate("parts.disposal_error"),
                [HexGrid.standardGrid.ToPixelCoords(trashedAtomReference.pos)]
            );
        }
    }
}

#pragma warning restore IDE1006
#pragma warning restore IDE0051
