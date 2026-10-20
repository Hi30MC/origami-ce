using OrigamiParts;
using Quintessential;
using static Quintessential.PartCycleDelegate;

namespace Origami;

internal static class Parts {

    public static PartType Composition, AugmentedComposition, HighRegeneration, LowRegeneration, Translation, Sacrifice;

    public static void AddPartTypes() {
        Composition = new()
        {
            cost = 15,
            isFullHexCover = true,
            glowTexture = AssetLoaderHelper.LoadTexture("textures/select/Hi30MC/Origami/bent_glow"),
            strokeTexture = AssetLoaderHelper.LoadTexture("textures/select/Hi30MC/Origami/bent_stroke"),
            baseTexture = AssetLoaderHelper.LoadTexture("textures/parts/Hi30MC/Origami/composition_icon"),
            hoverTexture = AssetLoaderHelper.LoadTexture("textures/parts/Hi30MC/Origami/composition_icon"),
            glyphHexes = new HexIndex[]
            {
                CompositionGlyph.CompositionInputA,
                CompositionGlyph.CompositionInputB,
                CompositionGlyph.CompositionOutput
            },
            permissionCategory = PuzzlePermissions.None,
            CustomPermissionCheck = perms => perms.Contains(Origami.Instance.GetIdentifier("composition"))
        };

        AugmentedComposition = new()
        {
            cost = 20,
            isFullHexCover = true,
            glowTexture = AssetLoaderHelper.LoadTexture("textures/select/Hi30MC/Origami/lowc_glow"),
            strokeTexture = AssetLoaderHelper.LoadTexture("textures/select/Hi30MC/Origami/lowc_stroke"),
            baseTexture = AssetLoaderHelper.LoadTexture("textures/parts/Hi30MC/Origami/augmented_comp_icon"),
            hoverTexture = AssetLoaderHelper.LoadTexture("textures/parts/Hi30MC/Origami/augmented_comp_icon"),
            glyphHexes = new HexIndex[]
            {
                AugmentedCompositionGlyph.AugmentedCompBowl,
                AugmentedCompositionGlyph.AugmentedCompInputA,
                AugmentedCompositionGlyph.AugmentedCompInputB,
                AugmentedCompositionGlyph.AugmentedCompOutput
            },
            permissionCategory = PuzzlePermissions.None,
            CustomPermissionCheck = perms => perms.Contains(Origami.Instance.GetIdentifier("augmented_composition"))
        };

        HighRegeneration = new()
        {
            cost = 20,
            isFullHexCover = true,
            glowTexture = AssetLoaderHelper.LoadTexture("textures/select/Hi30MC/Origami/highc_glow"),
            strokeTexture = AssetLoaderHelper.LoadTexture("textures/select/Hi30MC/Origami/highc_stroke"),
            baseTexture = AssetLoaderHelper.LoadTexture("textures/parts/Hi30MC/Origami/high_regeneration_icon"),
            hoverTexture = AssetLoaderHelper.LoadTexture("textures/parts/Hi30MC/Origami/high_regeneration_icon"),
            glyphHexes = new HexIndex[]
            {
                HighRegenerationGlyph.HighRegenerationBowlA,
                HighRegenerationGlyph.HighRegenerationBowlB,
                HighRegenerationGlyph.HighRegenerationBowlC,
                HighRegenerationGlyph.HighRegenerationOutput
            },
            permissionCategory = PuzzlePermissions.None,
            CustomPermissionCheck = perms => perms.Contains(Origami.Instance.GetIdentifier("high_regeneration")),
            isUnique = true
        };

        LowRegeneration = new()
        {
            cost = 15,
            isFullHexCover = true,
            glowTexture = AssetLoaderHelper.LoadTexture("textures/select/Hi30MC/Origami/triple_glow"),
            strokeTexture = AssetLoaderHelper.LoadTexture("textures/select/Hi30MC/Origami/triple_stroke"),
            baseTexture = AssetLoaderHelper.LoadTexture("textures/parts/Hi30MC/Origami/low_regeneration_icon"),
            hoverTexture = AssetLoaderHelper.LoadTexture("textures/parts/Hi30MC/Origami/low_regeneration_icon"),
            glyphHexes = new HexIndex[]
            {
                LowRegenerationGlyph.LowRegenerationBowlA,
                LowRegenerationGlyph.LowRegenerationBowlB,
                LowRegenerationGlyph.LowRegenerationOutput
            },
            permissionCategory = PuzzlePermissions.None,
            CustomPermissionCheck = perms => perms.Contains(Origami.Instance.GetIdentifier("low_regeneration")),
            isUnique = true,
        };

        Translation = new()
        {
            cost = 10,
            isFullHexCover = true,
            glowTexture = AssetLoaderHelper.LoadTexture("textures/select/Hi30MC/Origami/single_glow"),
            strokeTexture = AssetLoaderHelper.LoadTexture("textures/select/Hi30MC/Origami/single_stroke"),
            baseTexture = AssetLoaderHelper.LoadTexture("textures/parts/Hi30MC/Origami/translation_icon"),
            hoverTexture = AssetLoaderHelper.LoadTexture("textures/parts/Hi30MC/Origami/translation_icon"),
            glyphHexes = new HexIndex[]
            {
                TranslationGlyph.TranslationBowl
            },
            permissionCategory = PuzzlePermissions.None,
            CustomPermissionCheck = perms => perms.Contains(Origami.Instance.GetIdentifier("translation"))
        };

        Sacrifice = new()
        {
            cost = 50,
            isFullHexCover = true,
            glowTexture = AssetLoaderHelper.LoadTexture("textures/select/Hi30MC/Origami/double_glow"),
            strokeTexture = AssetLoaderHelper.LoadTexture("textures/select/Hi30MC/Origami/double_stroke"),
            baseTexture = AssetLoaderHelper.LoadTexture("textures/parts/Hi30MC/Origami/sacrifice_icon"),
            hoverTexture = AssetLoaderHelper.LoadTexture("textures/parts/Hi30MC/Origami/sacrifice_icon"),
            glyphHexes = new HexIndex[]
            {
                SacrificeGlyph.SacrificeArm,
                SacrificeGlyph.SacrificeIO
            },
            permissionCategory = PuzzlePermissions.None,
            CustomPermissionCheck = perms => perms.Contains(Origami.Instance.GetIdentifier("sacrifice")),
            isProgrammable = true,
            // isUnique = true, // not sure if I want only one on the board at a time
        };

        Origami.Instance.AddPartType(Composition, "composition", CompositionGlyph.Render);
        Origami.Instance.AddPartType(AugmentedComposition, "augmented_composition", AugmentedCompositionGlyph.Render);
        Origami.Instance.AddPartType(HighRegeneration, "high_regeneration", HighRegenerationGlyph.Render);
        Origami.Instance.AddPartType(LowRegeneration, "low_regeneration", LowRegenerationGlyph.Render);
        Origami.Instance.AddPartType(Sacrifice, "sacrifice", SacrificeGlyph.Render);

        QApi.AddPartTypeToPanel(Composition, PartTypes.triplexBonder);
        QApi.AddPartTypeToPanel(AugmentedComposition, Composition);
        QApi.AddPartTypeToPanel(HighRegeneration, AugmentedComposition);
        QApi.AddPartTypeToPanel(LowRegeneration, HighRegeneration);
        QApi.AddPartTypeToPanel(Sacrifice, Translation);

        Origami.Instance.AddPuzzlePermission("composition");
        Origami.Instance.AddPuzzlePermission("augmented_composition");
        Origami.Instance.AddPuzzlePermission("high_regeneration");
        Origami.Instance.AddPuzzlePermission("low_regeneration");
        Origami.Instance.AddPuzzlePermission("sacrifice");

        QApi.BindGlyphCycle(Composition, new(PartCycleExecutionType.Normal, CompositionGlyph.OnCyle));
        QApi.BindGlyphCycle(AugmentedComposition, new(PartCycleExecutionType.Normal, AugmentedCompositionGlyph.OnCyle));
        QApi.BindGlyphCycle(HighRegeneration, new(PartCycleExecutionType.Normal, HighRegenerationGlyph.OnCyle));
        QApi.BindGlyphCycle(LowRegeneration, new(PartCycleExecutionType.Normal, LowRegenerationGlyph.OnCyle));
        QApi.BindGlyphCycle(Sacrifice, new(PartCycleExecutionType.Normal, SacrificeGlyph.OnCyle));

        Origami.Instance.AddRecipe(new(), Composition.Id, Composition.Id);
        Origami.Instance.AddRecipe(new(), AugmentedComposition.Id, AugmentedComposition.Id);
        Origami.Instance.AddRecipe(new(), HighRegeneration.Id, HighRegeneration.Id);
        Origami.Instance.AddRecipe(new(), LowRegeneration.Id, LowRegeneration.Id);
        Origami.Instance.AddRecipe(new(), Sacrifice.Id, Sacrifice.Id);
    }
}
