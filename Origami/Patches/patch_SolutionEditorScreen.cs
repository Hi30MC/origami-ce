using System;
using Mono.Cecil;
using MonoMod;
using MonoMod.Cil;
using MonoMod.InlineRT;
using MonoMod.Utils;

#pragma warning disable IDE1006

class patch_SolutionEditorScreen
{
    [MonoModILInject("RenderErrorPanel")]
    public static void PatchRenderErrorPanel(MethodDefinition method, CustomAttribute attribute)
    {
        // throw if method body is empty; nothing to check!
        if (!method.HasBody)
        {
            throw new Exception("Unable to patch wasActivated reset. (no body)");
        }

        ILCursor cursor = new(new ILContext(method));
        TypeDefinition ses = MonoModRule.Modder.FindType("SolutionEditorScreen").Resolve();

        // go to ~IL_003c: `Bounds2 bounds = Bounds2.WithSize(..., 160f));`. Change 160f
        cursor.TryGotoNext(MoveType.After,
            instr => instr.MatchCallvirt("Texture", "GetWidth"),
            instr => instr.MatchConvR4(),
            instr => instr.MatchLdcR4(160)
        );
        cursor.Index--;
        cursor.Remove();
        cursor.EmitLdarg1();
        cursor.EmitCallvirt(ses.FindMethod("Origami_GetBoxHeight").Resolve()); // text height + 136

        // go to ~IL_00a8: `TextureRenderer.Render(..., bounds.Min + new Vector2(21f, 120f));`. Change 120f
        cursor.TryGotoNext(MoveType.After,
            instr => instr.MatchLdfld("Bounds2", "Min"),
            instr => instr.MatchLdcR4(21),
            instr => instr.MatchLdcR4(120)
        );
        cursor.Index--;
        cursor.Remove();
        cursor.EmitLdarg1();
        cursor.EmitCallvirt(ses.FindMethod("Origami_GetBarOffset").Resolve()); // (text_height + 136) - 40

        // go to ~IL_00de: `TextureRenderer.RenderText(..., bounds.Center + new Vector2(-2f, 50f), ...)`. Change 50f
        cursor.TryGotoNext(MoveType.After,
            instr => instr.MatchCall("Bounds2", "get_Center"),
            instr => instr.MatchLdcR4(-2),
            instr => instr.MatchLdcR4(50)
        );
        cursor.Index--;
        cursor.Remove();
        cursor.EmitLdarg1();
        cursor.EmitCallvirt(ses.FindMethod("Origami_GetErrorTextOffset").Resolve()); // (text_height + 136) / 2 - 30
    }

    public static float Origami_GetTextHeight(SimError err)
    {
        return TextureRenderer.GetTextBounds(
            err.errorMessage,
            new Vector2(100, 100), Assets.fonts.crimson_13, TextAlignment.Center, 1f, 0.6f, 300f, float.MaxValue).Height;
    }

    public static float Origami_GetBoxHeight(SimError err)
    {
        return Origami_GetTextHeight(err) + 136f;
    }

    public static float Origami_GetBarOffset(SimError err)
    {
        return Origami_GetTextHeight(err) + 96f;
    }

    public static float Origami_GetErrorTextOffset(SimError err)
    {
        return Origami_GetTextHeight(err) / 2 + 38;
    }
}
