// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.CGeosetAnimation
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.ModelFormats.Xml.Value;
using System.Xml;

namespace MdxLib.ModelFormats.Xml
{
  internal sealed class CGeosetAnimation : CObject
  {
    private CGeosetAnimation()
    {
    }

    public void Load(CLoader Loader, XmlNode Node, MdxLib.Model.CModel Model, MdxLib.Model.CGeosetAnimation GeosetAnimation)
    {
      GeosetAnimation.UseColor = this.ReadBoolean(Node, "use_color", GeosetAnimation.UseColor);
      GeosetAnimation.DropShadow = this.ReadBoolean(Node, "drop_shadow", GeosetAnimation.DropShadow);
      this.LoadAnimator<MdxLib.Primitives.CVector3>(Loader, Node, Model, GeosetAnimation.Color, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Xml.Value.CVector3.Instance, "color");
      this.LoadAnimator<float>(Loader, Node, Model, GeosetAnimation.Alpha, (IValue<float>) CFloat.Instance, "alpha");
      Loader.Attacher.AddObject<MdxLib.Model.CGeoset>(Model.Geosets, GeosetAnimation.Geoset, this.ReadInteger(Node, "geoset", -1));
    }

    public void Save(CSaver Saver, XmlNode Node, MdxLib.Model.CModel Model, MdxLib.Model.CGeosetAnimation GeosetAnimation)
    {
      this.WriteBoolean(Node, "use_color", GeosetAnimation.UseColor);
      this.WriteBoolean(Node, "drop_shadow", GeosetAnimation.DropShadow);
      this.SaveAnimator<MdxLib.Primitives.CVector3>(Saver, Node, Model, GeosetAnimation.Color, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Xml.Value.CVector3.Instance, "color");
      this.SaveAnimator<float>(Saver, Node, Model, GeosetAnimation.Alpha, (IValue<float>) CFloat.Instance, "alpha");
      this.WriteInteger(Node, "geoset", GeosetAnimation.Geoset.ObjectId);
    }

    public static CGeosetAnimation Instance => CGeosetAnimation.CSingleton.Instance;

    private static class CSingleton
    {
      public static CGeosetAnimation Instance = new CGeosetAnimation();
    }
  }
}
