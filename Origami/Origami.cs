using OrigamiParts;
using Quintessential;
using OrigamiUtil;
using static Quintessential.PartCycleDelegate;

namespace Origami;

internal class Origami : QuintessentialMod {
    public override string ModId => "origami";
    public static Origami Instance { get; }

    public override void Load() {
        Logger.Log("Origami: Paper ready to fold!");
    }

    public override void LoadContent() {
        Atoms.LoadAtoms();
        Parts.AddPartTypes();
        Wheels.AddWheelTypes();
        Logger.Log("Origami: One thousand cranes folded!");
    }
    public override void LoadCompatContent() {
        bool NeuvolicsLoaded = QuintessentialLoader.IsModPresent("neuvolics");
        bool SennmetalsLoaded = QuintessentialLoader.IsModPresent("sennmetals");

        if (NeuvolicsLoaded || SennmetalsLoaded)
        {
            Instance.AddPartType(Parts.Translation, "translation", TranslationGlyph.Render);
            QApi.AddPartTypeToPanel(Parts.Translation, Parts.LowRegeneration);
            Instance.AddPuzzlePermission("translation");
            QApi.BindGlyphCycle(Parts.Translation, new(PartCycleExecutionType.Normal, TranslationGlyph.OnCyle));
            Instance.AddRecipe(new(), Parts.Translation.Id, Parts.Translation.Id);
        }
        if (NeuvolicsLoaded)
        {
            Logger.Log("Origami: Found Neuvolics");
            ImportManager.ImportNeuvolics();
            Parts.Translation.description = Translations.Translate("Translates between orineuvolic pairs");
        }
        if (SennmetalsLoaded)
        {
            Logger.Log("Origami: Found Sennmetals");
            ImportManager.ImportSennmetals();
            Parts.Translation.description = Translations.Translate("Translates between orisennmetallic pairs");
        }
        if (NeuvolicsLoaded && SennmetalsLoaded) Parts.Translation.description = Translations.Translate("Translates between orisenneuvolic pairs");
        GlyphLUT.GenerateLUTs();
        Logger.Log("Origami: Paper types diversified.");
    }
    public override void FinaliseContent() { }

    public override void PostLoad() { }
    public override void Unload() {
        Logger.Log("Origami: Paper stored for later use.");
    }
}
