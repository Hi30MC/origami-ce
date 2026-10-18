using System;
using Quintessential;
using Util;

namespace Parts;

internal static class LowRegenerationGlyph {
    public static readonly HexIndex LowRegenerationBowlA = new(-1, 0);
    public static readonly HexIndex LowRegenerationBowlB = new(0, 0);
    public static readonly HexIndex LowRegenerationOutput = new(-1, 1);
    public static readonly Texture LowRegenerationBase = AssetLoaderHelper.LoadTexture("textures/parts/Hi30MC/Origami/triple_base");

    public static void Render(Part part, Vector2 pos, SolutionEditorBase editor, PartRenderer renderer)
    {
        PartSimState pss = editor.GetSimulation().GetSimState(part);
        IntermediatePartState uco = editor.GetIntermState(part, pos);
        float time = editor.GetCycleTime();

        Vector2 centre = LowRegenerationBase.GetHalfSizeRounded();
        renderer.RenderBase(LowRegenerationBase, new Vector2(-1, -1), centre, 0f);

        renderer.RenderRotating(Assets.textures.parts.calcinator_bowl, LowRegenerationBowlA, Vector2.Zero);
        renderer.RenderRotating(Assets.textures.parts.calcinator_bowl, LowRegenerationBowlB, Vector2.Zero);

        int IrisFrame = 15;
        bool AfterIrisOpens = false;
        Molecule RisingAtom = null;
        Vector2 RisingOffset = uco.pos + HexGrid.standardGrid.ToPixelCoords(LowRegenerationOutput).Rotated(uco.rotation);
        renderer.RenderRotating(Assets.textures.parts.animismus.output_under_iris, LowRegenerationOutput, Vector2.Zero);

        if (pss.isProcessing)
        {
            IrisFrame = Utils.Clamp((int)(Utils.InterpolateLinear(1f, -1f, time) * 16f), 0, 15);
            AfterIrisOpens = time > 0.5f;
            RisingAtom = Molecule.CreateMonoatomic(pss.processingAtoms[0]);
            if (!AfterIrisOpens)
            {
                Editor.RenderMolecule(RisingAtom, RisingOffset, new HexIndex(0, 0), 0f, 1f, time, 1f, false, null);
            }
        }

        renderer.RenderUpright(Assets.textures.parts.iris_full[IrisFrame], LowRegenerationOutput, Vector2.Zero);
        renderer.RenderRotating(Assets.textures.parts.animismus.output_above_iris, LowRegenerationOutput, Vector2.Zero);

        if (pss.isProcessing && AfterIrisOpens)
        {
            Editor.RenderMolecule(RisingAtom, RisingOffset, new HexIndex(0, 0), 0f, 1f, time, 1f, false, null);
        }
    }

    public static bool OnCyle(Sim sim, Part part, PartSimState pss, GlyphRecipe recipe, bool first)
    {
        if (first)
        {
            HexIndex iris = part.InFrontBy(LowRegenerationOutput);

            if (sim.FindAtom(iris).HasValue())
            { //iris full
                return false;
            }
            if (!sim.GetAtomReference(part, LowRegenerationBowlA, [], true).GetOrDefault(out AtomReference bowlAtomA))
            { // bowl A empty
                return false;
            }
            if (!sim.GetAtomReference(part, LowRegenerationBowlB, [], true).GetOrDefault(out AtomReference bowlAtomB))
            { // bowl B empty
                return false;
            }

            if (!GlyphLUT.LowRegenerationLUT.TryGetValue(new Tuple<AtomType, AtomType>(bowlAtomA.atomType, bowlAtomB.atomType), out AtomType output))
            {
                return false;
            }

            sim.SpawnColliderRelative(part, iris);

            pss.isProcessing = true;
            pss.processingAtoms = new AtomType[] { output };
        }
        else if (pss.isProcessing)
        {
            sim.SpawnAtomRelative(pss.processingAtoms[0], part, LowRegenerationOutput);
        }

        return false;
    }
}
