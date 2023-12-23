// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.CGeosetGroup
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System.Xml;

namespace MdxLib.ModelFormats.Xml
{
  internal sealed class CGeosetGroup : CObject
  {
    private CGeosetGroup()
    {
    }

    public void Load(
      CLoader Loader,
      XmlNode Node,
      MdxLib.Model.CModel Model,
      MdxLib.Model.CGeoset Geoset,
      MdxLib.Model.CGeosetGroup GeosetGroup)
    {
      foreach (XmlNode selectNode in Node.SelectNodes("geoset_group_node"))
      {
        MdxLib.Model.CGeosetGroupNode cgeosetGroupNode = new MdxLib.Model.CGeosetGroupNode(Model);
        CGeosetGroupNode.Instance.Load(Loader, selectNode, Model, Geoset, GeosetGroup, cgeosetGroupNode);
        GeosetGroup.Nodes.Add(cgeosetGroupNode);
      }
    }

    public void Save(
      CSaver Saver,
      XmlNode Node,
      MdxLib.Model.CModel Model,
      MdxLib.Model.CGeoset Geoset,
      MdxLib.Model.CGeosetGroup GeosetGroup)
    {
      if (!GeosetGroup.HasNodes)
        return;
      foreach (MdxLib.Model.CGeosetGroupNode node in GeosetGroup.Nodes)
      {
        XmlElement Node1 = this.AppendElement(Node, "geoset_group_node");
        CGeosetGroupNode.Instance.Save(Saver, (XmlNode) Node1, Model, Geoset, GeosetGroup, node);
      }
    }

    public static CGeosetGroup Instance => CGeosetGroup.CSingleton.Instance;

    private static class CSingleton
    {
      public static CGeosetGroup Instance = new CGeosetGroup();
    }
  }
}
