// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdl.CTextureAnimation
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.ModelFormats.Mdl.Token;
using MdxLib.ModelFormats.Mdl.Value;
using System;

namespace MdxLib.ModelFormats.Mdl
{
  internal sealed class CTextureAnimation : CObject
  {
    private CTextureAnimation()
    {
    }

    public void LoadAll(CLoader Loader, MdxLib.Model.CModel Model)
    {
      Loader.ReadInteger();
      Loader.ExpectToken(EType.CurlyBracketLeft);
      while (Loader.PeekToken() != EType.CurlyBracketRight)
      {
        string str = Loader.ReadWord();
        switch (str)
        {
          case "tvertexanim":
            MdxLib.Model.CTextureAnimation ctextureAnimation = new MdxLib.Model.CTextureAnimation(Model);
            this.Load(Loader, Model, ctextureAnimation);
            Model.TextureAnimations.Add(ctextureAnimation);
            continue;
          default:
            throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + str + "\"!");
        }
      }
      int num = (int) Loader.ReadToken();
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CTextureAnimation TextureAnimation)
    {
      Loader.ExpectToken(EType.CurlyBracketLeft);
      while (Loader.PeekToken() != EType.CurlyBracketRight)
      {
        string str1 = Loader.ReadWord();
        switch (str1)
        {
          case "static":
            string str2 = Loader.ReadWord();
            switch (str2)
            {
              case "translation":
                this.LoadStaticAnimator<MdxLib.Primitives.CVector3>(Loader, Model, TextureAnimation.Translation, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdl.Value.CVector3.Instance);
                continue;
              case "rotation":
                this.LoadStaticAnimator<MdxLib.Primitives.CVector4>(Loader, Model, TextureAnimation.Rotation, (IValue<MdxLib.Primitives.CVector4>) MdxLib.ModelFormats.Mdl.Value.CVector4.Instance);
                continue;
              case "scaling":
                this.LoadStaticAnimator<MdxLib.Primitives.CVector3>(Loader, Model, TextureAnimation.Scaling, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdl.Value.CVector3.Instance);
                continue;
              default:
                throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + str2 + "\"!");
            }
          case "translation":
            this.LoadAnimator<MdxLib.Primitives.CVector3>(Loader, Model, TextureAnimation.Translation, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdl.Value.CVector3.Instance);
            continue;
          case "rotation":
            this.LoadAnimator<MdxLib.Primitives.CVector4>(Loader, Model, TextureAnimation.Rotation, (IValue<MdxLib.Primitives.CVector4>) MdxLib.ModelFormats.Mdl.Value.CVector4.Instance);
            continue;
          case "scaling":
            this.LoadAnimator<MdxLib.Primitives.CVector3>(Loader, Model, TextureAnimation.Scaling, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdl.Value.CVector3.Instance);
            continue;
          default:
            throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + str1 + "\"!");
        }
      }
      int num = (int) Loader.ReadToken();
    }

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasTextureAnimations)
        return;
      Saver.BeginGroup("TextureAnims", Model.TextureAnimations.Count);
      foreach (MdxLib.Model.CTextureAnimation textureAnimation in Model.TextureAnimations)
        this.Save(Saver, Model, textureAnimation);
      Saver.EndGroup();
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CTextureAnimation TextureAnimation)
    {
      Saver.BeginGroup("TVertexAnim");
      this.SaveAnimator<MdxLib.Primitives.CVector3>(Saver, Model, TextureAnimation.Translation, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdl.Value.CVector3.Instance, "Translation", ECondition.NotZero);
      this.SaveAnimator<MdxLib.Primitives.CVector4>(Saver, Model, TextureAnimation.Rotation, (IValue<MdxLib.Primitives.CVector4>) MdxLib.ModelFormats.Mdl.Value.CVector4.Instance, "Rotation", ECondition.NotDefaultQuaternion);
      this.SaveAnimator<MdxLib.Primitives.CVector3>(Saver, Model, TextureAnimation.Scaling, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdl.Value.CVector3.Instance, "Scaling", ECondition.NotOne);
      Saver.EndGroup();
    }

    public static CTextureAnimation Instance => CTextureAnimation.CSingleton.Instance;

    private static class CSingleton
    {
      public static CTextureAnimation Instance = new CTextureAnimation();
    }
  }
}
