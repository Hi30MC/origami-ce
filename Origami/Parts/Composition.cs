using System;
using Quintessential;
using Util;

namespace Parts;

internal static class CompositionGlyph {
    public static readonly HexIndex CompositionInputA = new(-1, 0);
    public static readonly HexIndex CompositionInputB = new(0, 0);
    public static readonly HexIndex CompositionOutput = new(0, 1);
    public static readonly Texture CompositionBase = AssetLoaderHelper.LoadTexture("textures/parts/Hi30MC/Origami/bent_base");

    public static void Render(Part part, Vector2 pos, SolutionEditorBase editor, PartRenderer renderer)
    {
        PartSimState pss = editor.GetSimulation().GetSimState(part);
        IntermediatePartState uco = editor.GetIntermState(part, pos);
        float time = editor.GetCycleTime();

        // draw base
        Vector2 centre = CompositionBase.GetHalfSizeRounded();
        renderer.RenderBase(CompositionBase, new Vector2(-1, -1), centre, 0f);
        // draw inputs
        renderer.RenderShadowCircle(Assets.textures.parts.projection_glyph.quicksilver_input, CompositionInputA, 0);
        renderer.RenderShadowCircle(Assets.textures.parts.projection_glyph.quicksilver_input, CompositionInputB, 0);

        // standard iris code
        int IrisFrame = 15;
        bool AfterIrisOpens = false;
        Molecule RisingAtom = null;
        Vector2 RisingOffset = uco.pos + HexGrid.standardGrid.ToPixelCoords(CompositionOutput).Rotated(uco.rotation);

        //output under iris
        renderer.RenderRotating(Assets.textures.parts.animismus.output_under_iris, CompositionOutput, Vector2.Zero);

        // if ejecting, animate iris
        if (pss.isProcessing)
        {
            // LERP at double speed (from 1 to 0 is closed to open, but double the range for double speed).
            IrisFrame = Utils.Clamp((int)(Utils.InterpolateLinear(1f, -1f, time) * 16f), 0, 15);
            AfterIrisOpens = time > 0.5f;
            RisingAtom = Molecule.CreateMonoatomic(pss.processingAtoms[0]);
            if (!AfterIrisOpens)
            {
                // if before iris opened halfway, draw rising atom under
                Editor.RenderMolecule(RisingAtom, RisingOffset, new HexIndex(0, 0), 0f, 1f, time, 1f, false, null);
            }
        }

        //iris, then lip above
        renderer.RenderUpright(Assets.textures.parts.iris_full[IrisFrame], CompositionOutput, Vector2.Zero);
        renderer.RenderRotating(Assets.textures.parts.animismus.output_above_iris, CompositionOutput, Vector2.Zero);

        // if iris half open, draw rising atom on top
        if (pss.isProcessing && AfterIrisOpens)
        {
            Editor.RenderMolecule(RisingAtom, RisingOffset, new HexIndex(0, 0), 0f, 1f, time, 1f, false, null);
        }
    }

    public static bool OnCyle(Sim sim, Part part, PartSimState pss, GlyphRecipe recipe, bool first)
    {
        SolutionEditorBase seb = sim.solutionEditor;
        if (first) //first half-cycle
        {
            HexIndex holeA = part.InFrontBy(CompositionInputA);
            HexIndex holeB = part.InFrontBy(CompositionInputB);
            HexIndex iris = part.InFrontBy(CompositionOutput);
            if (sim.FindAtom(iris).HasValue())
            { //iris full
                return false;
            }
            if (!sim.FindAtom(holeA).GetOrDefault(out AtomReference inputAtomA) || inputAtomA.inMultiAtomMolecule || inputAtomA.isHeldByArm)
            { // no atom over hole, atom over hole is part of molecule (is bonded), or atom is held
                return false;
            }

            if (!sim.FindAtom(holeB).GetOrDefault(out AtomReference inputAtomB) || inputAtomB.inMultiAtomMolecule || inputAtomB.isHeldByArm)
            { // no atom over hole, atom over hole is part of molecule (is bonded), or atom is held
                return false;
            }

            if (!GlyphLUT.CompositionLUT.TryGetValue(new Tuple<AtomType, AtomType>(inputAtomA.atomType, inputAtomB.atomType), out AtomType output))
            {  // no matching (key, value) pair in the look-up table (LUT)
                return false;
            }

            // if all checks pass, remove input atoms
            inputAtomA.molecule.RemoveAtom(inputAtomA.pos);
            seb.DrawFallingAtom(inputAtomA);
            inputAtomB.molecule.RemoveAtom(inputAtomB.pos);
            seb.DrawFallingAtom(inputAtomB);

            sim.SpawnColliderRelative(part, iris);

            // mark glyph to render and what to output
            pss.isProcessing = true;
            pss.processingAtoms = new AtomType[] { output };
            return true;
        }
        else if (pss.isProcessing)
        {   // add atom to sim on the second half-cycle
            sim.SpawnAtomRelative(pss.processingAtoms[0], part, CompositionOutput);
            return true;
        }
        return false;
    }
}
