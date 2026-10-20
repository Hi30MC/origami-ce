using System.Linq;
using MonoMod.Utils;
using Quintessential;
using OrigamiUtil;

namespace OrigamiParts;

internal static class SacrificeGlyph {

    public static readonly HexIndex SacrificeArm = new(0, 0);
    public static readonly HexIndex SacrificeIO = new(1, 0);
    public static readonly Texture SacrificeBase = AssetLoaderHelper.LoadTexture("textures/parts/Hi30MC/Origami/double_base");
    public static readonly string SacrificeStateField = "origami_sacrifice_state";
    public static readonly string SacrificeStateCycle = "origami_sacrifice_cycle";

    // one of the worst reverse-engineerings that I have done (in terms of difficulty). please use this code for your sump-type things...
    public static void Render(Part part, Vector2 pos, SolutionEditorBase editor, PartRenderer renderer)
    {
        PartSimState pss = editor.GetSimulation().GetSimState(part);
        IntermediatePartState uco = editor.GetIntermState(part, pos);
        float time = editor.GetCycleTime();

        // get current cycle
        var currentCycle = 0;
        if (editor.GetSimPlayState() != SimPlayState.Stopped && editor.GetType() == typeof(SolutionEditorScreen))
        {
            var maybeSim = new DynamicData(editor).Get<Maybe<Sim>>("simulation");
            if (maybeSim.HasValue())
            {
                currentCycle = maybeSim.GetValue().GetCycle();
            }
        }

        // init dyn
        var pss_dyn = new DynamicData(pss);
        var stateOb = pss_dyn.Get(SacrificeStateField);
        var prevCycleOb = pss_dyn.Get(SacrificeStateCycle);

        SacrificeState state = new(0b11000000);
        int prevCycle = 0;
        if (stateOb != null)
        {
            state = (SacrificeState)stateOb;
        }
        if (prevCycleOb != null)
        {
            prevCycle = (int)prevCycleOb;
        }

        // update state and dyn
        if (currentCycle > prevCycle || time > 0.5)
        {
            state.Update();
            pss_dyn.Set(SacrificeStateCycle, currentCycle);
        }

        // currState: has an atom over top of it (or is about to have one above) -> false (open)
        HexIndex key = part.InFrontBy(SacrificeIO);
        state.CurrState = !pss.isProcessing; // if we are about to spit a Hom., default is false (open), else true (closed)

        // forces false if any one-atom molecules are over the IO
        state.CurrState &= !editor.GetSimulation().GetMolecules() // set.GetMolecules()
                           .Any(x => x.GetAtoms().Count == 1 // one-atom molecule
                                  && x.GetAtoms().ContainsKey(key)); // atom at IO
        pss_dyn.Set(SacrificeStateField, state); // update dyn with new currState

        bool animate = state.PrevState != state.CurrState; // animate iris if the state has changed; else draw static iris

        // get iris frames
        int irisFrame = 15; // 15 is closed, 00 is open
        if (animate)
        { // transition from closed to open
            // state.CurrState true: go from 0 to 2 (end closed)
            // state.CurrState false: go from 1 to -1 (end open)
            // normally would go from 0 -> 1 and 1 -> 0 but need double speed in standard sim speed, so we extend our LERP to cover double length in the same time.
            irisFrame = Utils.Clamp((int)(Utils.InterpolateLinear(state.CurrState ? 0f : 1f, state.CurrState ? 2f : -1f, time) * 16f), 0, 15);
        }
        else
        {
            irisFrame = state.CurrState ? 15 : 0; // if true, closed (15), if false open (0)
        }

        //draw everything!!
        Molecule RisingHomonculum = Molecule.CreateMonoatomic(Origami.Atoms.homonculum);
        Molecule RisingMors = Molecule.CreateMonoatomic(AtomTypes.mors);
        Vector2 RisingOffset = uco.pos + HexGrid.standardGrid.ToPixelCoords(SacrificeIO).Rotated(uco.rotation);

        // draw base
        Vector2 centre = SacrificeBase.GetHalfSizeRounded();
        renderer.RenderBase(SacrificeBase, new Vector2(-1, -1), centre, 0f);

        // draw arm, todo: change to indicator
        renderer.RenderRotating(Assets.textures.parts.piston.hub, SacrificeArm, Vector2.Zero);
        // byte MorsCount = state.MorsCount;

        // underiris
        renderer.RenderRotating(Assets.textures.parts.animismus.output_under_iris, SacrificeIO, Vector2.Zero); //draw output under iris

        bool AfterIrisOpens = false;
        if (pss.isProcessing)
        {
            AfterIrisOpens = time >= 0.5f;
        }

        // for times before iris is half open, draw rising atom before iris
        if (!AfterIrisOpens)
        { // iris not yet open. For the case of both drawing simultaenously, draw mors on top of hom. for first half...
            if (pss.isProcessing) Editor.RenderMolecule(RisingHomonculum, RisingOffset, new HexIndex(0, 0), 0f, 1f, time, 1f, false, null); // drawRisingAtom below iris if needed
            if (state.ConsumingMors) Editor.RenderMolecule(RisingMors, RisingOffset, new HexIndex(0, 0), 0f, 1f, 1f - time, 1f, false, null); // drawRisingAtom in reverse after iris
        }

        renderer.RenderUpright(Assets.textures.parts.iris_full[irisFrame], SacrificeIO, Vector2.Zero); //draw iris with correct frame
        renderer.RenderRotating(Assets.textures.parts.animismus.output_above_iris, SacrificeIO, Vector2.Zero); //draw output ring above iris

        // for times before iris is half open, draw rising atom before iris
        if (AfterIrisOpens)
        { // ...and draw hom. on top of mors for the second half.
            if (state.ConsumingMors) Editor.RenderMolecule(RisingMors, RisingOffset, new HexIndex(0, 0), 0f, 1f, 1f - time, 1f, false, null); //drawRisingAtom in reverse after iris
            if (pss.isProcessing) Editor.RenderMolecule(RisingHomonculum, RisingOffset, new HexIndex(0, 0), 0f, 1f, time, 1f, false, null); // drawRisingAtom after iris if needed
        }
    }

    public static bool OnCyle(Sim sim, Part part, PartSimState pss, GlyphRecipe recipe, bool first)
    {
        HexIndex io = part.InFrontBy(SacrificeIO);

        // init dyn
        var pss_dyn = new DynamicData(pss);
        var stateOb = pss_dyn.Get(SacrificeStateField);
        SacrificeState state = new(0b11000000);
        if (stateOb != null)
        {
            state = (SacrificeState)stateOb;
        }

        int MorsCount = state.MorsCount;
        state.ConsumingMors = false;
        if (first)
        {
            // check mors consume
            if (sim.FindAtom(io).GetOrDefault(out AtomReference ioAtom)) // if atom above...
            {
                if (ioAtom.atomType == AtomTypes.mors // ...is mors...
                    && !ioAtom.inMultiAtomMolecule // ...and not bonded...
                    && !ioAtom.isHeldByArm) // ...and not held
                {
                    if (MorsCount < 6) MorsCount++;
                    ioAtom.molecule.RemoveAtom(ioAtom.pos);
                    state.ConsumingMors = true; // mark renderer to render mors consumption
                }
            }
            // check sacrifice
            if (!sim.FindAtom(io).HasValue() // if no atom above...
                && MorsCount == 6 // ... and sufficient souls ...
                && sim.GetProgram().GetInstructionForPart(sim.GetCycle(), part, out Maybe<int> _).category == (InstructionCategory) 5) // ... and curr instr is grab or drop...
            {
                // Logger.Log("sacrifice your loved ones");
                MorsCount = 0;
                pss.isProcessing = true;
                sim.SpawnColliderRelative(part, SacrificeIO);
            }

            // update state
            state.MorsCount = (byte)MorsCount;
            pss_dyn.Set(SacrificeStateField, state);
        }
        else if (pss.isProcessing)
        {
            sim.SpawnAtomRelative(Origami.Atoms.homonculum, part, SacrificeIO);
        }
        return false;
    }
}
