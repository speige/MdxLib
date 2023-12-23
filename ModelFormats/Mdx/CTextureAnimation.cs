// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdx.CTextureAnimation
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.ModelFormats.Mdx.Value;
using System;

namespace MdxLib.ModelFormats.Mdx
{
  internal sealed class CTextureAnimation : CObject
  {
    private CTextureAnimation()
    {
    }

    public void LoadAll(CLoader Loader, MdxLib.Model.CModel Model)
    {
      int num = Loader.ReadInt32();
      while (num > 0)
      {
        Loader.PushLocation();
        MdxLib.Model.CTextureAnimation ctextureAnimation = new MdxLib.Model.CTextureAnimation(Model);
        this.Load(Loader, Model, ctextureAnimation);
        Model.TextureAnimations.Add(ctextureAnimation);
        num -= Loader.PopLocation();
        if (num < 0)
          throw new Exception("Error at location " + (object) Loader.Location + ", too many TextureAnimation bytes were read!");
      }
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CTextureAnimation TextureAnimation)
    {
      Loader.PushLocation();
      int num = Loader.ReadInt32() - Loader.PopLocation();
      if (num < 0)
        throw new Exception("Error at location " + (object) Loader.Location + ", too many TextureAnimation bytes were read!");
      while (num > 0)
      {
        Loader.PushLocation();
        string str = Loader.ReadTag();
        switch (str)
        {
          case "KTAT":
            CObject.LoadAnimator<MdxLib.Primitives.CVector3>(Loader, Model, TextureAnimation.Translation, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdx.Value.CVector3.Instance);
            break;
          case "KTAR":
            CObject.LoadAnimator<MdxLib.Primitives.CVector4>(Loader, Model, TextureAnimation.Rotation, (IValue<MdxLib.Primitives.CVector4>) MdxLib.ModelFormats.Mdx.Value.CVector4.Instance);
            break;
          case "KTAS":
            CObject.LoadAnimator<MdxLib.Primitives.CVector3>(Loader, Model, TextureAnimation.Scaling, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdx.Value.CVector3.Instance);
            break;
          default:
            throw new Exception("Error at location " + (object) Loader.Location + ", unknown TextureAnimation tag \"" + str + "\"!");
        }
        num -= Loader.PopLocation();
        if (num < 0)
          throw new Exception("Error at location " + (object) Loader.Location + ", too many TextureAnimation bytes were read!");
      }
    }

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasTextureAnimations)
        return;
      Saver.WriteTag("TXAN");
      Saver.PushLocation();
      foreach (MdxLib.Model.CTextureAnimation textureAnimation in Model.TextureAnimations)
        this.Save(Saver, Model, textureAnimation);
      Saver.PopExclusiveLocation();
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CTextureAnimation TextureAnimation)
    {
      Saver.PushLocation();
      CObject.SaveAnimator<MdxLib.Primitives.CVector3>(Saver, Model, TextureAnimation.Translation, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdx.Value.CVector3.Instance, "KTAT");
      CObject.SaveAnimator<MdxLib.Primitives.CVector4>(Saver, Model, TextureAnimation.Rotation, (IValue<MdxLib.Primitives.CVector4>) MdxLib.ModelFormats.Mdx.Value.CVector4.Instance, "KTAR");
      CObject.SaveAnimator<MdxLib.Primitives.CVector3>(Saver, Model, TextureAnimation.Scaling, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdx.Value.CVector3.Instance, "KTAS");
      Saver.PopInclusiveLocation();
    }

    public static CTextureAnimation Instance => CTextureAnimation.CSingleton.Instance;

    private static class CSingleton
    {
      public static CTextureAnimation Instance = new CTextureAnimation();
    }
  }
}
