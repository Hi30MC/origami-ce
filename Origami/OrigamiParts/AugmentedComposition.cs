using System;
using Quintessential;
using OrigamiUtil;

namespace OrigamiParts;

internal static class AugmentedCompositionGlyph {

    public static readonly HexIndex AugmentedCompInputA = new(-1, 0);
    public static readonly HexIndex AugmentedCompInputB = new(0, 0);
    public static readonly HexIndex AugmentedCompBowl = new(-1, 2);
    public static readonly HexIndex AugmentedCompOutput = new(0, 1);
    public static readonly Texture AugmentedCompBase = AssetLoaderHelper.LoadTexture("textures/parts/Hi30MC/Origami/lowc_base");

    public static void Render(Part part, Vector2 pos, SolutionEditorBase editor, PartRenderer renderer)
    {
        PartSimState pss = editor.GetSimulation().GetSimState(part);
        IntermediatePartState uco = editor.GetIntermState(part, pos);
        float time = editor.GetCycleTime();

        Vector2 centre = AugmentedCompBase.GetHalfSizeRounded();
        renderer.RenderBase(AugmentedCompBase, new Vector2(-1, -1), centre, 0f);

        renderer.RenderShadowCircle(Assets.textures.parts.projection_glyph.quicksilver_input, AugmentedCompInputA, 0);
        renderer.RenderShadowCircle(Assets.textures.parts.projection_glyph.quicksilver_input, AugmentedCompInputB, 0);

        renderer.RenderRotating(Assets.textures.parts.calcinator_bowl, AugmentedCompBowl, Vector2.Zero);

        int IrisFrame = 15;
        bool AfterIrisOpens = false;
        Molecule RisingAtom = null;
        Vector2 RisingOffset = uco.pos + HexGrid.standardGrid.ToPixelCoords(AugmentedCompOutput).Rotated(uco.rotation);

        renderer.RenderRotating(Assets.textures.parts.animismus.output_under_iris, AugmentedCompOutput, Vector2.Zero);

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

        renderer.RenderUpright(Assets.textures.parts.iris_full[IrisFrame], AugmentedCompOutput, Vector2.Zero);
        renderer.RenderRotating(Assets.textures.parts.animismus.output_above_iris, AugmentedCompOutput, Vector2.Zero);

        if (pss.isProcessing && AfterIrisOpens)
        {
            Editor.RenderMolecule(RisingAtom, RisingOffset, new HexIndex(0, 0), 0f, 1f, time, 1f, false, null);
        }
    }

    public static bool OnCyle(Sim sim, Part part, PartSimState pss, GlyphRecipe recipe, bool first)
    {
        SolutionEditorBase seb = sim.solutionEditor;

        if (first)
        {
            HexIndex holeA = part.InFrontBy(AugmentedCompInputA);
            HexIndex holeB = part.InFrontBy(AugmentedCompInputB);
            HexIndex iris = part.InFrontBy(AugmentedCompOutput);
            AtomType bowlAtomType;

            if (sim.FindAtom(iris).HasValue())
            { //iris full
                return false;
            }

            if (!sim.FindAtom(holeA).GetOrDefault(out AtomReference inputAtomA) || inputAtomA.inMultiAtomMolecule || inputAtomA.isHeldByArm)
            {  //invalid holeA
                return false;
            }

            if (!sim.FindAtom(holeB).GetOrDefault(out AtomReference inputAtomB) || inputAtomB.inMultiAtomMolecule || inputAtomB.isHeldByArm)
            { //invalid holeB
                return false;
            }

            bowlAtomType = sim.GetAtomReference(part, AugmentedCompBowl, [], true).GetOrDefault(out AtomReference temp) ? temp.atomType : Origami.Atoms.rei; // get bowl atom type, if any.
            if (!GlyphLUT.CompositionLUT.TryGetValue(new Tuple<AtomType, AtomType>(inputAtomB.atomType, bowlAtomType), out AtomType temp2))
            {
                return false;
            }

            if (!GlyphLUT.CompositionLUT.TryGetValue(new Tuple<AtomType, AtomType>(inputAtomA.atomType, temp2), out AtomType output))
            {
                return false;
            }

            inputAtomA.molecule.RemoveAtom(inputAtomA.pos);
            seb.DrawFallingAtom(inputAtomA);
            inputAtomB.molecule.RemoveAtom(inputAtomB.pos);
            seb.DrawFallingAtom(inputAtomB);

            sim.SpawnColliderRelative(part, iris);

            pss.isProcessing = true;
            pss.processingAtoms = new AtomType[] { output };
            return true;
        }
        else if (pss.isProcessing)
        {
            sim.SpawnAtomRelative(pss.processingAtoms[0], part, AugmentedCompOutput);
            return true;
        }
        return false;
    }
}
