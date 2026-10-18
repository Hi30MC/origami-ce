using Quintessential;

namespace Origami;

internal static class Atoms {
    public static AtomType rei, nazum, reyja, chronos, zaryan, iaso, tano, maru, homonculum, lono, lua, tao;

    public static void LoadAtoms()
    {
        rei = new() {
            symbol = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/rei_symbol"),
            shadow = Assets.textures.atoms.shadow,
            matteTextures = new() {
                diffuse = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/copper_diffuse"),
                shade = Assets.textures.atoms.salt_shade
            }
        };
        nazum = new()
        {
            symbol = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/nazum_symbol"),
            shadow = Assets.textures.atoms.shadow,
            matteTextures = new()
            {
                diffuse = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/copper_diffuse"),
                shade = Assets.textures.atoms.salt_shade
            }
        };
        reyja = new()
        {
            symbol = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/reyja_symbol"),
            shadow = Assets.textures.atoms.shadow,
            matteTextures = new()
            {
                diffuse = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/copper_diffuse"),
                shade = Assets.textures.atoms.salt_shade
            }
        };
        chronos = new()
        {
            symbol = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/chronos_symbol"),
            shadow = Assets.textures.atoms.shadow,
            matteTextures = new()
            {
                diffuse = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/copper_diffuse"),
                shade = Assets.textures.atoms.salt_shade
            }
        };
        zaryan = new()
        {
            symbol = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/zaryan_symbol"),
            shadow = Assets.textures.atoms.shadow,
            matteTextures = new()
            {
                diffuse = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/copper_diffuse"),
                shade = Assets.textures.atoms.salt_shade
            }
        };
        iaso = new()
        {
            symbol = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/iaso_symbol"),
            shadow = Assets.textures.atoms.shadow,
            matteTextures = new()
            {
                diffuse = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/copper_diffuse"),
                shade = Assets.textures.atoms.salt_shade
            }
        };
        tano = new()
        {
            symbol = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/tano_symbol"),
            shadow = Assets.textures.atoms.shadow,
            matteTextures = new()
            {
                diffuse = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/copper_diffuse"),
                shade = Assets.textures.atoms.salt_shade
            }
        };
        maru = new()
        {
            symbol = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/maru_symbol"),
            shadow = Assets.textures.atoms.shadow,
            matteTextures = new()
            {
                diffuse = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/copper_diffuse"),
                shade = Assets.textures.atoms.salt_shade
            }
        };
        homonculum = new()
        {
            symbol = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/homonculum_symbol"),
            shadow = Assets.textures.atoms.shadow,
            matteTextures = new()
            {
                diffuse = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/copper_diffuse"),
                shade = Assets.textures.atoms.salt_shade
            }
        };
        lono = new()
        {
            symbol = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/lono_symbol"),
            shadow = Assets.textures.atoms.shadow,
            matteTextures = new()
            {
                diffuse = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/copper_diffuse"),
                shade = Assets.textures.atoms.salt_shade
            }
        };
        lua = new()
        {
            symbol = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/lua_symbol"),
            shadow = Assets.textures.atoms.shadow,
            matteTextures = new()
            {
                diffuse = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/copper_diffuse"),
                shade = Assets.textures.atoms.salt_shade
            }
        };
        tao = new()
        {
            symbol = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/tao_symbol"),
            shadow = Assets.textures.atoms.shadow,
            matteTextures = new()
            {
                diffuse = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/copper_diffuse"),
                shade = Assets.textures.atoms.salt_shade
            }
        };

        Origami.Instance.AddAtomType(rei, "rei");
        Origami.Instance.AddAtomType(nazum, "nazum");
        Origami.Instance.AddAtomType(reyja, "reyja");
        Origami.Instance.AddAtomType(chronos, "chronos");
        Origami.Instance.AddAtomType(zaryan, "zaryan");
        Origami.Instance.AddAtomType(iaso, "iaso");
        Origami.Instance.AddAtomType(tano, "tano");
        Origami.Instance.AddAtomType(maru, "naru");
        Origami.Instance.AddAtomType(homonculum, "homonculum");
        Origami.Instance.AddAtomType(lono, "lono");
        Origami.Instance.AddAtomType(lua, "lua");
        Origami.Instance.AddAtomType(tao, "tao");
    }
}
