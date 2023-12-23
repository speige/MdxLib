// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.CGeosetVertex
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System.Xml;

namespace MdxLib.ModelFormats.Xml
{
  internal sealed class CGeosetVertex : CObject
  {
    private CGeosetVertex()
    {
    }

    public void Load(
      CLoader Loader,
      XmlNode Node,
      MdxLib.Model.CModel Model,
      MdxLib.Model.CGeoset Geoset,
      MdxLib.Model.CGeosetVertex GeosetVertex)
    {
      GeosetVertex.Position = this.ReadVector3(Node, "position", GeosetVertex.Position);
      GeosetVertex.Normal = this.ReadVector3(Node, "normal", GeosetVertex.Normal);
      GeosetVertex.TexturePosition = this.ReadVector2(Node, "texture_position", GeosetVertex.TexturePosition);
      Loader.Attacher.AddObject<MdxLib.Model.CGeosetGroup>(Geoset.Groups, GeosetVertex.Group, this.ReadInteger(Node, "geoset_group", -1));
    }

    public void Save(
      CSaver Saver,
      XmlNode Node,
      MdxLib.Model.CModel Model,
      MdxLib.Model.CGeoset Geoset,
      MdxLib.Model.CGeosetVertex GeosetVertex)
    {
      this.WriteVector3(Node, "position", GeosetVertex.Position);
      this.WriteVector3(Node, "normal", GeosetVertex.Normal);
      this.WriteVector2(Node, "texture_position", GeosetVertex.TexturePosition);
      this.WriteInteger(Node, "geoset_group", GeosetVertex.Group.ObjectId);
    }

    public static CGeosetVertex Instance => CGeosetVertex.CSingleton.Instance;

    private static class CSingleton
    {
      public static CGeosetVertex Instance = new CGeosetVertex();
    }
  }
}
