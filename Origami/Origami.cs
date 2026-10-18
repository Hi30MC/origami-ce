using Quintessential;

namespace Origami;

internal class Origami : QuintessentialMod {
    public override string ModId => "origami";
    public static Origami Instance { get; }

    public override void Load() { }

    public override void LoadContent() {
        Atoms.LoadAtoms();
        Util.GlyphLUT.GenerateLUTs();
        Parts.AddPartTypes();
    }
    public override void LoadCompatContent() { }
    public override void FinaliseContent() { }

    public override void PostLoad() { }
    public override void Unload() { }
}
