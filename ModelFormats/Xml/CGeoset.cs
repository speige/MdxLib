// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.CGeoset
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System.Xml;

namespace MdxLib.ModelFormats.Xml
{
  internal sealed class CGeoset : CObject
  {
    private CGeoset()
    {
    }

    public void Load(CLoader Loader, XmlNode Node, MdxLib.Model.CModel Model, MdxLib.Model.CGeoset Geoset)
    {
      Geoset.SelectionGroup = this.ReadInteger(Node, "selection_group", Geoset.SelectionGroup);
      Geoset.Unselectable = this.ReadBoolean(Node, "unselectable", Geoset.Unselectable);
      Geoset.Extent = this.ReadExtent(Node, "extent", Geoset.Extent);
      Loader.Attacher.AddObject<MdxLib.Model.CMaterial>(Model.Materials, Geoset.Material, this.ReadInteger(Node, "material", -1));
      foreach (XmlNode selectNode in Node.SelectNodes("geoset_vertex"))
      {
        MdxLib.Model.CGeosetVertex cgeosetVertex = new MdxLib.Model.CGeosetVertex(Model);
        CGeosetVertex.Instance.Load(Loader, selectNode, Model, Geoset, cgeosetVertex);
        Geoset.Vertices.Add(cgeosetVertex);
      }
      foreach (XmlNode selectNode in Node.SelectNodes("geoset_face"))
      {
        MdxLib.Model.CGeosetFace cgeosetFace = new MdxLib.Model.CGeosetFace(Model);
        CGeosetFace.Instance.Load(Loader, selectNode, Model, Geoset, cgeosetFace);
        Geoset.Faces.Add(cgeosetFace);
      }
      foreach (XmlNode selectNode in Node.SelectNodes("geoset_group"))
      {
        MdxLib.Model.CGeosetGroup cgeosetGroup = new MdxLib.Model.CGeosetGroup(Model);
        CGeosetGroup.Instance.Load(Loader, selectNode, Model, Geoset, cgeosetGroup);
        Geoset.Groups.Add(cgeosetGroup);
      }
      foreach (XmlNode selectNode in Node.SelectNodes("geoset_extent"))
      {
        MdxLib.Model.CGeosetExtent cgeosetExtent = new MdxLib.Model.CGeosetExtent(Model);
        CGeosetExtent.Instance.Load(Loader, selectNode, Model, Geoset, cgeosetExtent);
        Geoset.Extents.Add(cgeosetExtent);
      }
    }

    public void Save(CSaver Saver, XmlNode Node, MdxLib.Model.CModel Model, MdxLib.Model.CGeoset Geoset)
    {
      this.WriteInteger(Node, "selection_group", Geoset.SelectionGroup);
      this.WriteBoolean(Node, "unselectable", Geoset.Unselectable);
      this.WriteExtent(Node, "extent", Geoset.Extent);
      this.WriteInteger(Node, "material", Geoset.Material.ObjectId);
      if (Geoset.HasVertices)
      {
        foreach (MdxLib.Model.CGeosetVertex vertex in Geoset.Vertices)
        {
          XmlElement Node1 = this.AppendElement(Node, "geoset_vertex");
          CGeosetVertex.Instance.Save(Saver, (XmlNode) Node1, Model, Geoset, vertex);
        }
      }
      if (Geoset.HasFaces)
      {
        foreach (MdxLib.Model.CGeosetFace face in Geoset.Faces)
        {
          XmlElement Node2 = this.AppendElement(Node, "geoset_face");
          CGeosetFace.Instance.Save(Saver, (XmlNode) Node2, Model, Geoset, face);
        }
      }
      if (Geoset.HasGroups)
      {
        foreach (MdxLib.Model.CGeosetGroup group in Geoset.Groups)
        {
          XmlElement Node3 = this.AppendElement(Node, "geoset_group");
          CGeosetGroup.Instance.Save(Saver, (XmlNode) Node3, Model, Geoset, group);
        }
      }
      if (!Geoset.HasExtents)
        return;
      foreach (MdxLib.Model.CGeosetExtent extent in Geoset.Extents)
      {
        XmlElement Node4 = this.AppendElement(Node, "geoset_extent");
        CGeosetExtent.Instance.Save(Saver, (XmlNode) Node4, Model, Geoset, extent);
      }
    }

    public static CGeoset Instance => CGeoset.CSingleton.Instance;

    private static class CSingleton
    {
      public static CGeoset Instance = new CGeoset();
    }
  }
}
