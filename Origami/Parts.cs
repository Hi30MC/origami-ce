using Parts;
using Quintessential;
using static Quintessential.PartCycleDelegate;

namespace Origami;

internal static class Parts {

    public static PartType Composition;

    public static void AddPartTypes() {
        Composition = new()
        {
            cost = 15,
            isFullHexCover = true,
            glowTexture = AssetLoaderHelper.LoadTexture("textures/select/Hi30MC/Origami/bent_glow"),
            strokeTexture = AssetLoaderHelper.LoadTexture("textures/select/Hi30MC/Origami/bent_stroke"),
            baseTexture = AssetLoaderHelper.LoadTexture("textures/parts/Hi30MC/Origami/composition_icon"),
            hoverTexture = AssetLoaderHelper.LoadTexture("textures/select/Hi30MC/Origami/composition_icon"),
            glyphHexes = new HexIndex[] { CompositionGlyph.CompositionInputA, CompositionGlyph.CompositionInputB, CompositionGlyph.CompositionOutput },
            permissionCategory = PuzzlePermissions.None,
            CustomPermissionCheck = perms => perms.Contains(Origami.Instance.GetIdentifier("composition"))
        };

        Origami.Instance.AddPartType(Composition, "composition", CompositionGlyph.Render);

        QApi.AddPartTypeToPanel(Composition, PartTypes.triplexBonder);

        Origami.Instance.AddPuzzlePermission("composition");

        QApi.BindGlyphCycle(Composition, new(PartCycleExecutionType.Normal, CompositionGlyph.OnCyle));

        Origami.Instance.AddRecipe(new(), Composition.Id, Composition.Id);
    }
}
