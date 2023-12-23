// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.CTextureAnimation
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.ModelFormats.Xml.Value;
using System.Xml;

namespace MdxLib.ModelFormats.Xml
{
  internal sealed class CTextureAnimation : CObject
  {
    private CTextureAnimation()
    {
    }

    public void Load(
      CLoader Loader,
      XmlNode Node,
      MdxLib.Model.CModel Model,
      MdxLib.Model.CTextureAnimation TextureAnimation)
    {
      this.LoadAnimator<MdxLib.Primitives.CVector3>(Loader, Node, Model, TextureAnimation.Translation, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Xml.Value.CVector3.Instance, "translation");
      this.LoadAnimator<MdxLib.Primitives.CVector4>(Loader, Node, Model, TextureAnimation.Rotation, (IValue<MdxLib.Primitives.CVector4>) MdxLib.ModelFormats.Xml.Value.CVector4.Instance, "rotation");
      this.LoadAnimator<MdxLib.Primitives.CVector3>(Loader, Node, Model, TextureAnimation.Scaling, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Xml.Value.CVector3.Instance, "scaling");
    }

    public void Save(CSaver Saver, XmlNode Node, MdxLib.Model.CModel Model, MdxLib.Model.CTextureAnimation TextureAnimation)
    {
      this.SaveAnimator<MdxLib.Primitives.CVector3>(Saver, Node, Model, TextureAnimation.Translation, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Xml.Value.CVector3.Instance, "translation");
      this.SaveAnimator<MdxLib.Primitives.CVector4>(Saver, Node, Model, TextureAnimation.Rotation, (IValue<MdxLib.Primitives.CVector4>) MdxLib.ModelFormats.Xml.Value.CVector4.Instance, "rotation");
      this.SaveAnimator<MdxLib.Primitives.CVector3>(Saver, Node, Model, TextureAnimation.Scaling, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Xml.Value.CVector3.Instance, "scaling");
    }

    public static CTextureAnimation Instance => CTextureAnimation.CSingleton.Instance;

    private static class CSingleton
    {
      public static CTextureAnimation Instance = new CTextureAnimation();
    }
  }
}
