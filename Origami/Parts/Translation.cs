//tbd
using System;
using Quintessential;
using Util;

namespace Parts;

internal static class TranslationGlyph {
    public static readonly HexIndex TranslationBowl = new(0, 0);
    public static readonly Texture TranslationBase = AssetLoaderHelper.LoadTexture("textures/parts/Hi30MC/Origami/single_base");

    public static void Render(Part part, Vector2 pos, SolutionEditorBase editor, PartRenderer renderer)
    {
        PartSimState pss = editor.GetSimulation().GetSimState(part);
        IntermediatePartState uco = editor.GetIntermState(part, pos);
        float time = editor.GetCycleTime();

        Vector2 centre = TranslationBase.GetHalfSizeRounded();
        renderer.RenderBase(TranslationBase, new Vector2(-1, -1), centre, 0f);

        renderer.RenderShadowCircle(Assets.textures.parts.calcinator_bowl, TranslationBowl, 0);
    }

    public static bool OnCyle(Sim sim, Part part, PartSimState pss, GlyphRecipe recipe, bool first)
    {
        if (!first)
        {
            HexIndex bowl = part.InFrontBy(TranslationBowl);
            if (!sim.FindAtom(bowl).GetOrDefault(out AtomReference bowlAtom))
            { //empty bowl
                return false;
            }
            if (!GlyphLUT.TranslationLUT.TryGetValue(bowlAtom.atomType, out AtomType output))
            {
                return false;
            }

            bowlAtom.molecule.ReplaceAtom(output, bowlAtom.pos);
            bowlAtom.atom.transmutationEffect = new TransmutationEffect(sim.solutionEditor, (TransmutationEffectRenderMode) 1, bowlAtom.atomType, Assets.textures.atoms.projection_effect, 30f);
        }
        return false;
    }
}
