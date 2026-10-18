using System.Collections.Generic;
using System;
using Origami;

namespace Util;

public static class GlyphLUT {
    public static Dictionary<Tuple<AtomType, AtomType>, AtomType> CompositionLUT = [];
    public static Dictionary<Tuple<AtomType, AtomType, AtomType>, AtomType> HighRegenerationLUT = [];
    public static Dictionary<Tuple<AtomType, AtomType>, AtomType> LowRegenerationLUT = [];
    public static Dictionary<AtomType, AtomType> TranslationLUT = [];

    public static void GenerateLUTs()
    {
        GenerateCompositionLUT();
        GenerateHighRegenerationLUT();
        GenerateLowRegenerationLUT();
        GenerateTranslationLUT();
    }

    public static void GenerateCompositionLUT() {
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.rei, Atoms.rei),        Atoms.rei);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.rei, Atoms.nazum),      Atoms.nazum);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.rei, Atoms.reyja),      Atoms.reyja);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.rei, Atoms.chronos),    Atoms.chronos);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.rei, Atoms.zaryan),     Atoms.zaryan);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.rei, Atoms.iaso),       Atoms.iaso);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.rei, Atoms.tano),       Atoms.tano);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.rei, Atoms.maru),       Atoms.maru);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.rei, Atoms.homonculum), Atoms.homonculum);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.rei, Atoms.lono),       Atoms.lono);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.rei, Atoms.lua),        Atoms.lua);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.rei, Atoms.tao),        Atoms.tao);

        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.nazum, Atoms.rei),        Atoms.nazum);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.nazum, Atoms.nazum),      Atoms.reyja);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.nazum, Atoms.reyja),      Atoms.rei);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.nazum, Atoms.chronos),    Atoms.iaso);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.nazum, Atoms.zaryan),     Atoms.chronos);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.nazum, Atoms.iaso),       Atoms.zaryan);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.nazum, Atoms.tano),       Atoms.maru);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.nazum, Atoms.maru),       Atoms.homonculum);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.nazum, Atoms.homonculum), Atoms.tano);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.nazum, Atoms.lono),       Atoms.tao);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.nazum, Atoms.lua),        Atoms.lono);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.nazum, Atoms.tao),        Atoms.lua);

        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.reyja, Atoms.rei),        Atoms.reyja);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.reyja, Atoms.nazum),      Atoms.rei);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.reyja, Atoms.reyja),      Atoms.nazum);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.reyja, Atoms.chronos),    Atoms.zaryan);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.reyja, Atoms.zaryan),     Atoms.iaso);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.reyja, Atoms.iaso),       Atoms.chronos);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.reyja, Atoms.tano),       Atoms.homonculum);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.reyja, Atoms.maru),       Atoms.tano);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.reyja, Atoms.homonculum), Atoms.maru);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.reyja, Atoms.lono),       Atoms.lua);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.reyja, Atoms.lua),        Atoms.tao);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.reyja, Atoms.tao),        Atoms.lono);

        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.chronos, Atoms.rei),        Atoms.chronos);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.chronos, Atoms.nazum),      Atoms.tano);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.chronos, Atoms.reyja),      Atoms.lono);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.chronos, Atoms.chronos),    Atoms.rei);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.chronos, Atoms.zaryan),     Atoms.maru);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.chronos, Atoms.iaso),       Atoms.lua);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.chronos, Atoms.tano),       Atoms.nazum);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.chronos, Atoms.maru),       Atoms.zaryan);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.chronos, Atoms.homonculum), Atoms.tao);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.chronos, Atoms.lono),       Atoms.reyja);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.chronos, Atoms.lua),        Atoms.iaso);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.chronos, Atoms.tao),        Atoms.homonculum);

        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.zaryan, Atoms.rei),        Atoms.zaryan);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.zaryan, Atoms.nazum),      Atoms.homonculum);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.zaryan, Atoms.reyja),      Atoms.lua);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.zaryan, Atoms.chronos),    Atoms.reyja);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.zaryan, Atoms.zaryan),     Atoms.tano);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.zaryan, Atoms.iaso),       Atoms.tao);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.zaryan, Atoms.tano),       Atoms.rei);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.zaryan, Atoms.maru),       Atoms.iaso);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.zaryan, Atoms.homonculum), Atoms.lono);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.zaryan, Atoms.lono),       Atoms.nazum);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.zaryan, Atoms.lua),        Atoms.chronos);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.zaryan, Atoms.tao),        Atoms.maru);

        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.iaso, Atoms.rei),        Atoms.iaso);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.iaso, Atoms.nazum),      Atoms.maru);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.iaso, Atoms.reyja),      Atoms.tao);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.iaso, Atoms.chronos),    Atoms.nazum);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.iaso, Atoms.zaryan),     Atoms.homonculum);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.iaso, Atoms.iaso),       Atoms.lono);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.iaso, Atoms.tano),       Atoms.reyja);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.iaso, Atoms.maru),       Atoms.chronos);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.iaso, Atoms.homonculum), Atoms.lua);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.iaso, Atoms.lono),       Atoms.rei);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.iaso, Atoms.lua),        Atoms.zaryan);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.iaso, Atoms.tao),        Atoms.tano);

        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.tano, Atoms.rei),        Atoms.tano);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.tano, Atoms.nazum),      Atoms.lono);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.tano, Atoms.reyja),      Atoms.chronos);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.tano, Atoms.chronos),    Atoms.lua);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.tano, Atoms.zaryan),     Atoms.rei);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.tano, Atoms.iaso),       Atoms.maru);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.tano, Atoms.tano),       Atoms.zaryan);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.tano, Atoms.maru),       Atoms.tao);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.tano, Atoms.homonculum), Atoms.nazum);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.tano, Atoms.lono),       Atoms.homonculum);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.tano, Atoms.lua),        Atoms.reyja);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.tano, Atoms.tao),        Atoms.iaso);

        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.maru, Atoms.rei),        Atoms.maru);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.maru, Atoms.nazum),      Atoms.tao);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.maru, Atoms.reyja),      Atoms.iaso);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.maru, Atoms.chronos),    Atoms.lono);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.maru, Atoms.zaryan),     Atoms.nazum);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.maru, Atoms.iaso),       Atoms.homonculum);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.maru, Atoms.tano),       Atoms.chronos);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.maru, Atoms.maru),       Atoms.lua);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.maru, Atoms.homonculum), Atoms.reyja);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.maru, Atoms.lono),       Atoms.tano);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.maru, Atoms.lua),        Atoms.rei);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.maru, Atoms.tao),        Atoms.zaryan);

        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.homonculum, Atoms.rei),        Atoms.homonculum);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.homonculum, Atoms.nazum),      Atoms.lua);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.homonculum, Atoms.reyja),      Atoms.zaryan);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.homonculum, Atoms.chronos),    Atoms.tao);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.homonculum, Atoms.zaryan),     Atoms.reyja);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.homonculum, Atoms.iaso),       Atoms.tano);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.homonculum, Atoms.tano),       Atoms.iaso);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.homonculum, Atoms.maru),       Atoms.lono);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.homonculum, Atoms.homonculum), Atoms.rei);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.homonculum, Atoms.lono),       Atoms.maru);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.homonculum, Atoms.lua),        Atoms.nazum);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.homonculum, Atoms.tao),        Atoms.chronos);

        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.lono, Atoms.rei),        Atoms.lono);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.lono, Atoms.nazum),      Atoms.chronos);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.lono, Atoms.reyja),      Atoms.tano);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.lono, Atoms.chronos),    Atoms.maru);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.lono, Atoms.zaryan),     Atoms.lua);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.lono, Atoms.iaso),       Atoms.rei);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.lono, Atoms.tano),       Atoms.tao);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.lono, Atoms.maru),       Atoms.nazum);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.lono, Atoms.homonculum), Atoms.zaryan);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.lono, Atoms.lono),       Atoms.iaso);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.lono, Atoms.lua),        Atoms.homonculum);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.lono, Atoms.tao),        Atoms.reyja);

        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.lua, Atoms.rei),        Atoms.lua);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.lua, Atoms.nazum),      Atoms.zaryan);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.lua, Atoms.reyja),      Atoms.homonculum);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.lua, Atoms.chronos),    Atoms.tano);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.lua, Atoms.zaryan),     Atoms.tao);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.lua, Atoms.iaso),       Atoms.reyja);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.lua, Atoms.tano),       Atoms.lono);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.lua, Atoms.maru),       Atoms.rei);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.lua, Atoms.homonculum), Atoms.iaso);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.lua, Atoms.lono),       Atoms.chronos);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.lua, Atoms.lua),        Atoms.maru);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.lua, Atoms.tao),        Atoms.nazum);

        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.tao, Atoms.rei),        Atoms.tao);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.tao, Atoms.nazum),      Atoms.iaso);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.tao, Atoms.reyja),      Atoms.maru);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.tao, Atoms.chronos),    Atoms.homonculum);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.tao, Atoms.zaryan),     Atoms.lono);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.tao, Atoms.iaso),       Atoms.nazum);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.tao, Atoms.tano),       Atoms.lua);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.tao, Atoms.maru),       Atoms.reyja);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.tao, Atoms.homonculum), Atoms.chronos);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.tao, Atoms.lono),       Atoms.zaryan);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.tao, Atoms.lua),        Atoms.tano);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.tao, Atoms.tao),        Atoms.rei);
    }

    public static void GenerateHighRegenerationLUT() {
        // chronos, homonculum, tao
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.chronos, Atoms.homonculum, Atoms.tao), Atoms.rei);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.chronos, Atoms.tao, Atoms.homonculum), Atoms.rei);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.homonculum, Atoms.chronos, Atoms.tao), Atoms.rei);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.homonculum, Atoms.tao, Atoms.chronos), Atoms.rei);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.tao, Atoms.homonculum, Atoms.chronos), Atoms.rei);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.tao, Atoms.chronos, Atoms.homonculum), Atoms.rei);

        // rei, homonculum, tao
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.rei, Atoms.homonculum, Atoms.tao), Atoms.chronos);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.rei, Atoms.tao, Atoms.homonculum), Atoms.chronos);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.homonculum, Atoms.rei, Atoms.tao), Atoms.chronos);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.homonculum, Atoms.tao, Atoms.rei), Atoms.chronos);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.tao, Atoms.homonculum, Atoms.rei), Atoms.chronos);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.tao, Atoms.rei, Atoms.homonculum), Atoms.chronos);

        // rei, chronos, tao
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.rei, Atoms.chronos, Atoms.tao), Atoms.homonculum);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.rei, Atoms.tao, Atoms.chronos), Atoms.homonculum);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.chronos, Atoms.rei, Atoms.tao), Atoms.homonculum);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.chronos, Atoms.tao, Atoms.rei), Atoms.homonculum);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.tao, Atoms.chronos, Atoms.rei), Atoms.homonculum);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.tao, Atoms.rei, Atoms.chronos), Atoms.homonculum);

        // rei, chronos, homonculum
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.rei, Atoms.homonculum, Atoms.chronos), Atoms.tao);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.rei, Atoms.chronos, Atoms.homonculum), Atoms.tao);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.homonculum, Atoms.rei, Atoms.chronos), Atoms.tao);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.homonculum, Atoms.chronos, Atoms.rei), Atoms.tao);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.chronos, Atoms.homonculum, Atoms.rei), Atoms.tao);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.chronos, Atoms.rei, Atoms.homonculum), Atoms.tao);
    }

    public static void GenerateLowRegenerationLUT() {
        // rei, nazum, reyja
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.rei, Atoms.nazum), Atoms.reyja);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.nazum, Atoms.rei), Atoms.reyja);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.rei, Atoms.reyja), Atoms.nazum);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.reyja, Atoms.rei), Atoms.nazum);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.reyja, Atoms.nazum), Atoms.rei);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.nazum, Atoms.reyja), Atoms.rei);

        // rei, zaryan, tano
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.rei, Atoms.zaryan), Atoms.tano);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.zaryan, Atoms.rei), Atoms.tano);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.rei, Atoms.tano), Atoms.zaryan);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.tano, Atoms.rei), Atoms.zaryan);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.tano, Atoms.zaryan), Atoms.rei);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.zaryan, Atoms.tano), Atoms.rei);

        // rei, iaso, lono
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.rei, Atoms.iaso), Atoms.lono);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.iaso, Atoms.rei), Atoms.lono);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.rei, Atoms.lono), Atoms.iaso);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.lono, Atoms.rei), Atoms.iaso);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.lono, Atoms.iaso), Atoms.rei);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.iaso, Atoms.lono), Atoms.rei);

        // rei, maru, lua
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.rei, Atoms.maru), Atoms.lua);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.maru, Atoms.rei), Atoms.lua);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.rei, Atoms.lua), Atoms.maru);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.lua, Atoms.rei), Atoms.maru);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.lua, Atoms.maru), Atoms.rei);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.maru, Atoms.lua), Atoms.rei);
    }

    public static void GenerateTranslationLUT() {
//         if (Origami.NeuvolicsLoaded)
//         {
//             TranslationLUT.Add(ImportManager.NeuvolicsAtoms.GetIridium(), Atoms.reyja);
//             TranslationLUT.Add(ImportManager.NeuvolicsAtoms.GetMitrum(), Atoms.nazum);
//             TranslationLUT.Add(ImportManager.NeuvolicsAtoms.GetTaceum(), Atoms.lua);
//             TranslationLUT.Add(ImportManager.NeuvolicsAtoms.GetAzulum(), Atoms.lono);
//             TranslationLUT.Add(ImportManager.NeuvolicsAtoms.GetZephiron(), Atoms.rei);
//             TranslationLUT.Add(Atoms.reyja, ImportManager.NeuvolicsAtoms.GetIridium());
//             TranslationLUT.Add(Atoms.nazum, ImportManager.NeuvolicsAtoms.GetMitrum());
//             TranslationLUT.Add(Atoms.lua, ImportManager.NeuvolicsAtoms.GetTaceum());
//             TranslationLUT.Add(Atoms.maru, ImportManager.NeuvolicsAtoms.GetAzulum());
//             TranslationLUT.Add(Atoms.rei, ImportManager.NeuvolicsAtoms.GetZephiron());
//         }
//
//         if (Origami.SennmetalsLoaded) {
//             TranslationLUT.Add(ImportManager.SennmetalsAtoms.GetEitros(), Atoms.tano);
//             TranslationLUT.Add(ImportManager.SennmetalsAtoms.GetSordi(), Atoms.zaryan);
//             TranslationLUT.Add(ImportManager.SennmetalsAtoms.GetRofor(), Atoms.lono);
//             TranslationLUT.Add(ImportManager.SennmetalsAtoms.GetSerket(), Atoms.iaso);
//             TranslationLUT.Add(Atoms.tano, ImportManager.SennmetalsAtoms.GetEitros());
//             TranslationLUT.Add(Atoms.zaryan, ImportManager.SennmetalsAtoms.GetSordi());
//             TranslationLUT.Add(Atoms.lono, ImportManager.SennmetalsAtoms.GetRofor());
//             TranslationLUT.Add(Atoms.iaso, ImportManager.SennmetalsAtoms.GetSerket());
//         }
    }
}
