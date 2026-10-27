using Quintessential;
using System;
using System.Collections.Generic;

namespace Origami;

internal static class Wheels
{
    public static PartType FlemmingsWheel;

    public static void AddWheelTypes()
    {
        FlemmingsWheel = new PartType
        {
            baseTexture = AssetLoaderHelper.LoadTexture("textures/parts/Hi30MC/Origami/flemming_icon"), // Panel icon
            hoverTexture = AssetLoaderHelper.LoadTexture("textures/parts/Hi30MC/Origami/flemming_icon"), // Hovered panel icon
            cost = 25,
            isUnique = true,
            layer = PartTypeLayer.Top,
            isProgrammable = true,
            attachedAtoms = new Dictionary<HexIndex, AtomType>
            {
                {new HexIndex(0, 1), Atoms.rei},
                {new HexIndex(1, 0), Atoms.iaso},
                {new HexIndex(1, -1), Atoms.tano},
                {new HexIndex(0, -1), Atoms.rei},
                {new HexIndex(-1, 0), Atoms.iaso},
                {new HexIndex(-1, 1), Atoms.tano}
            },
            canRotateInSimulation = true,
            permissionCategory = PuzzlePermissions.None,
            CustomPermissionCheck = perms => perms.Contains(Origami.Instance.GetIdentifier("flemmings_wheel"))
        };
        QApi.AddPartTypeToPanel(FlemmingsWheel, PartTypes.ravarisWheel);
        Origami.Instance.AddPartType(FlemmingsWheel, "flemmings_wheel", (part, pos, editor, renderer) => { });
        Origami.Instance.AddPuzzlePermission("flemmings_wheel");
    }
}
