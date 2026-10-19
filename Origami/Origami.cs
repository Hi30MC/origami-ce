using Quintessential;

namespace Origami;

internal class Origami : QuintessentialMod {
    public override string ModId => "origami";
    public static Origami Instance { get; }

    public override void Load() {
        Logger.Log("Origami: Paper ready to fold!");
    }

    public override void LoadContent() {
        Atoms.LoadAtoms();
        Util.GlyphLUT.GenerateLUTs();
        Parts.AddPartTypes();
        Wheels.AddWheelTypes();
        Logger.Log("Origami: one thousand cranes folded!");
    }
    public override void LoadCompatContent() { }
    public override void FinaliseContent() { }

    public override void PostLoad() { }
    public override void Unload() {
        Logger.Log("Origami: Paper stored for later use.");
    }
}
