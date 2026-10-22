using Quintessential;

namespace Origami;

internal static class Atoms {
    public static AtomType rei, nazum, reyja, chronos, zaryan, iaso, tano, maru, homonculum, lono, lua, tao;

    public static void LoadAtoms()
    {
        rei = new() {
            symbol = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/rei/symbol"),
            shadow = Assets.textures.atoms.shadow,
            matteTextures = new()
            {
                diffuse = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/rei/diffuse"),
                shade = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/rei/shade"),
            }
        };
        nazum = new()
        {
            symbol = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/nazum/symbol"),
            shadow = Assets.textures.atoms.shadow,
            matteTextures = new()
            {
                diffuse = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/nazum/diffuse"),
                shade = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/nazum/shade"),
            }
        };
        reyja = new()
        {
            symbol = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/reyja/symbol"),
            shadow = Assets.textures.atoms.shadow,
            matteTextures = new()
            {
                diffuse = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/reyja/diffuse"),
                shade = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/reyja/shade"),
            }
        };
        chronos = new()
        {
            symbol = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/chronos/symbol"),
            shadow = Assets.textures.atoms.shadow,
            matteTextures = new()
            {
                diffuse = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/chronos/diffuse"),
                shade = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/chronos/shade"),
            }
        };
        zaryan = new()
        {
            symbol = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/zaryan/symbol"),
            shadow = Assets.textures.atoms.shadow,
            matteTextures = new()
            {
                diffuse = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/zaryan/diffuse"),
                shade = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/zaryan/shade"),
            }
        };
        iaso = new()
        {
            symbol = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/iaso/symbol"),
            shadow = Assets.textures.atoms.shadow,
            matteTextures = new()
            {
                diffuse = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/iaso/diffuse"),
                shade = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/iaso/shade"),
            }
        };
        tano = new()
        {
            symbol = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/tano/symbol"),
            shadow = Assets.textures.atoms.shadow,
            matteTextures = new()
            {
                diffuse = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/tano/diffuse"),
                shade = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/tano/shade"),
            }
        };
        maru = new()
        {
            symbol = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/maru/symbol"),
            shadow = Assets.textures.atoms.shadow,
            matteTextures = new()
            {
                diffuse = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/maru/diffuse"),
                shade = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/maru/shade"),
            }
        };
        homonculum = new()
        {
            symbol = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/homonculum/symbol"),
            shadow = Assets.textures.atoms.shadow,
            matteTextures = new()
            {
                diffuse = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/homonculum/diffuse"),
                shade = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/homonculum/shade"),
            }
        };
        lono = new()
        {
            symbol = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/lono/symbol"),
            shadow = Assets.textures.atoms.shadow,
            matteTextures = new()
            {
                diffuse = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/lono/diffuse"),
                shade = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/lono/shade"),
            }
        };
        lua = new()
        {
            symbol = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/lua/symbol"),
            shadow = Assets.textures.atoms.shadow,
            matteTextures = new()
            {
                diffuse = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/lua/diffuse"),
                shade = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/lua/shade"),
            }
        };
        tao = new()
        {
            symbol = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/tao/symbol"),
            shadow = Assets.textures.atoms.shadow,
            matteTextures = new()
            {
                diffuse = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/tao/diffuse"),
                shade = AssetLoaderHelper.LoadTexture("textures/atoms/Hi30MC/Origami/tao/shade"),
            }
        };

        Origami.Instance.AddAtomType(rei, "rei");
        Origami.Instance.AddAtomType(nazum, "nazum");
        Origami.Instance.AddAtomType(reyja, "reyja");
        Origami.Instance.AddAtomType(chronos, "chronos");
        Origami.Instance.AddAtomType(zaryan, "zaryan");
        Origami.Instance.AddAtomType(iaso, "iaso");
        Origami.Instance.AddAtomType(tano, "tano");
        Origami.Instance.AddAtomType(maru, "maru");
        Origami.Instance.AddAtomType(homonculum, "homonculum");
        Origami.Instance.AddAtomType(lono, "lono");
        Origami.Instance.AddAtomType(lua, "lua");
        Origami.Instance.AddAtomType(tao, "tao");
    }
}
