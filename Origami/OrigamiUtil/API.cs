using MonoMod.ModInterop;
using Quintessential;
using System;
using System.Linq;

namespace OrigamiUtil;

class ImportManager
{

    public static bool IsModLoaded(string otherModId)
    {
        return Enumerable.Any(QuintessentialLoader.Mods, mod => mod.ModId == otherModId);
    }

    public static void ImportAll()
    {
        ImportNeuvolics();
        ImportSennmetals();
    }

    public static void ImportNeuvolics()
    {
        typeof(NeuvolicsAtoms).ModInterop();
    }

    public static void ImportSennmetals() {
        typeof(SennmetalsAtoms).ModInterop();
    }

    [ModImportName("Neuvolics.Atoms")]
    public static class NeuvolicsAtoms
    {
        public static Func<AtomType> GetAzulum;
        public static Func<AtomType> GetTaceum;
        public static Func<AtomType> GetIridium;
        public static Func<AtomType> GetMitrum;
        public static Func<AtomType> GetZephiron;
    }

    [ModImportName("Sennmetals.Atoms")]
    public static class SennmetalsAtoms {
        public static Func<AtomType> GetTyphor;
        public static Func<AtomType> GetSordi;
        public static Func<AtomType> GetEitros;
        public static Func<AtomType> GetRofor;
        public static Func<AtomType> GetSerket;
    }
}
