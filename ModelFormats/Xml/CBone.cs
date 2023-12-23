// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.CBone
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System.Xml;

namespace MdxLib.ModelFormats.Xml
{
  internal sealed class CBone : CNode
  {
    private CBone()
    {
    }

    public void Load(CLoader Loader, XmlNode Node, MdxLib.Model.CModel Model, MdxLib.Model.CBone Bone)
    {
      this.LoadNode<MdxLib.Model.CBone>(Loader, Node, Model, Bone);
      Loader.Attacher.AddObject<MdxLib.Model.CGeoset>(Model.Geosets, Bone.Geoset, this.ReadInteger(Node, "geoset", -1));
      Loader.Attacher.AddObject<MdxLib.Model.CGeosetAnimation>(Model.GeosetAnimations, Bone.GeosetAnimation, this.ReadInteger(Node, "geoset_animation", -1));
    }

    public void Save(CSaver Saver, XmlNode Node, MdxLib.Model.CModel Model, MdxLib.Model.CBone Bone)
    {
      this.SaveNode<MdxLib.Model.CBone>(Saver, Node, Model, Bone);
      this.WriteInteger(Node, "geoset", Bone.Geoset.ObjectId);
      this.WriteInteger(Node, "geoset_animation", Bone.GeosetAnimation.ObjectId);
    }

    public static CBone Instance => CBone.CSingleton.Instance;

    private static class CSingleton
    {
      public static CBone Instance = new CBone();
    }
  }
}
