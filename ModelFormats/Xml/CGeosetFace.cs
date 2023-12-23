// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.CGeosetFace
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System.Xml;

namespace MdxLib.ModelFormats.Xml
{
  internal sealed class CGeosetFace : CObject
  {
    private CGeosetFace()
    {
    }

    public void Load(
      CLoader Loader,
      XmlNode Node,
      MdxLib.Model.CModel Model,
      MdxLib.Model.CGeoset Geoset,
      MdxLib.Model.CGeosetFace GeosetFace)
    {
      Loader.Attacher.AddObject<MdxLib.Model.CGeosetVertex>(Geoset.Vertices, GeosetFace.Vertex1, this.ReadInteger(Node, "vertex_1", -1));
      Loader.Attacher.AddObject<MdxLib.Model.CGeosetVertex>(Geoset.Vertices, GeosetFace.Vertex2, this.ReadInteger(Node, "vertex_2", -1));
      Loader.Attacher.AddObject<MdxLib.Model.CGeosetVertex>(Geoset.Vertices, GeosetFace.Vertex3, this.ReadInteger(Node, "vertex_3", -1));
    }

    public void Save(
      CSaver Saver,
      XmlNode Node,
      MdxLib.Model.CModel Model,
      MdxLib.Model.CGeoset Geoset,
      MdxLib.Model.CGeosetFace GeosetFace)
    {
      this.WriteInteger(Node, "vertex_1", GeosetFace.Vertex1.ObjectId);
      this.WriteInteger(Node, "vertex_2", GeosetFace.Vertex2.ObjectId);
      this.WriteInteger(Node, "vertex_3", GeosetFace.Vertex3.ObjectId);
    }

    public static CGeosetFace Instance => CGeosetFace.CSingleton.Instance;

    private static class CSingleton
    {
      public static CGeosetFace Instance = new CGeosetFace();
    }
  }
}
