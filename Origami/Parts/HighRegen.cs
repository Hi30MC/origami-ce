using System;
using Quintessential;
using Util;

namespace Parts;

internal static class HighRegenerationGlyph {

    public static readonly HexIndex HighRegenerationBowlA = new(0, 0);
    public static readonly HexIndex HighRegenerationBowlB = new(-1, 2);
    public static readonly HexIndex HighRegenerationBowlC = new(-2, 2);
    public static readonly HexIndex HighRegenerationOutput = new(0, 1);
    public static readonly Texture HighRegenerationBase = AssetLoaderHelper.LoadTexture("textures/parts/Hi30MC/Origami/highc_base");

    public static void Render(Part part, Vector2 pos, SolutionEditorBase editor, PartRenderer renderer)
    {
        PartSimState pss = editor.GetSimulation().GetSimState(part);
        IntermediatePartState uco = editor.GetIntermState(part, pos);
        float time = editor.GetCycleTime();

        Vector2 centre = HighRegenerationBase.GetHalfSizeRounded();
        renderer.RenderBase(HighRegenerationBase, new Vector2(-1, -1), centre, 0f);

        renderer.RenderRotating(Assets.textures.parts.calcinator_bowl, HighRegenerationBowlA, Vector2.Zero);
        renderer.RenderRotating(Assets.textures.parts.calcinator_bowl, HighRegenerationBowlB, Vector2.Zero);
        renderer.RenderRotating(Assets.textures.parts.calcinator_bowl, HighRegenerationBowlC, Vector2.Zero);

        int IrisFrame = 15;
        bool AfterIrisOpens = false;
        Molecule RisingAtom = null;
        Vector2 RisingOffset = uco.pos + HexGrid.standardGrid.ToPixelCoords(HighRegenerationOutput).Rotated(uco.rotation);
        renderer.RenderRotating(Assets.textures.parts.animismus.output_under_iris, HighRegenerationOutput, Vector2.Zero);

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

        renderer.RenderUpright(Assets.textures.parts.iris_full[IrisFrame], HighRegenerationOutput, Vector2.Zero);
        renderer.RenderRotating(Assets.textures.parts.animismus.output_above_iris, HighRegenerationOutput, Vector2.Zero);

        if (pss.isProcessing && AfterIrisOpens)
        {
            Editor.RenderMolecule(RisingAtom, RisingOffset, new HexIndex(0, 0), 0f, 1f, time, 1f, false, null);
        }
    }

    public static bool OnCyle(Sim sim, Part part, PartSimState pss, GlyphRecipe recipe, bool first)
    {
        if (first)
        {
            HexIndex bowlA = part.InFrontBy(HighRegenerationBowlA);
            HexIndex bowlB = part.InFrontBy(HighRegenerationBowlB);
            HexIndex bowlC = part.InFrontBy(HighRegenerationBowlC);
            HexIndex iris = part.InFrontBy(HighRegenerationOutput);

            if (sim.FindAtom(iris).HasValue())
            { //iris full
                return false;
            }
            if (!sim.GetAtomReference(part, bowlA, [], true).GetOrDefault(out AtomReference bowlAtomA))
            { // bowl A empty
                Logger.Log("no A found");
                return false;
            }
            if (!sim.GetAtomReference(part, bowlB, [], true).GetOrDefault(out AtomReference bowlAtomB))
            { // bowl B empty
                Logger.Log("no B found");
                return false;
            }
            if (!sim.GetAtomReference(part, bowlC, [], true).GetOrDefault(out AtomReference bowlAtomC))
            { // bowl C empty
                Logger.Log("no C found");
                return false;
            }
            Logger.Log("ABC found");

            if (!GlyphLUT.HighRegenerationLUT.TryGetValue(new Tuple<AtomType, AtomType, AtomType>(bowlAtomA.atomType, bowlAtomB.atomType, bowlAtomC.atomType), out AtomType output))
            {
                return false;
            }

            sim.SpawnColliderRelative(part, iris);

            pss.isProcessing = true;
            pss.processingAtoms = new AtomType[] { output };
        }
        else if (pss.isProcessing)
        {
            sim.SpawnAtomRelative(pss.processingAtoms[0], part, HighRegenerationOutput);
        }
        return false;
    }
}
