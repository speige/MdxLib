// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.CGeosetGroupNode
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System.Xml;

namespace MdxLib.ModelFormats.Xml
{
  internal sealed class CGeosetGroupNode : CObject
  {
    private CGeosetGroupNode()
    {
    }

    public void Load(
      CLoader Loader,
      XmlNode Node,
      MdxLib.Model.CModel Model,
      MdxLib.Model.CGeoset Geoset,
      MdxLib.Model.CGeosetGroup GeosetGroup,
      MdxLib.Model.CGeosetGroupNode GeosetGroupNode)
    {
      Loader.Attacher.AddNode(Model, GeosetGroupNode.Node, this.ReadInteger(Node, "node", -1));
    }

    public void Save(
      CSaver Saver,
      XmlNode Node,
      MdxLib.Model.CModel Model,
      MdxLib.Model.CGeoset Geoset,
      MdxLib.Model.CGeosetGroup GeosetGroup,
      MdxLib.Model.CGeosetGroupNode GeosetGroupNode)
    {
      this.WriteInteger(Node, "node", GeosetGroupNode.Node.NodeId);
    }

    public static CGeosetGroupNode Instance => CGeosetGroupNode.CSingleton.Instance;

    private static class CSingleton
    {
      public static CGeosetGroupNode Instance = new CGeosetGroupNode();
    }
  }
}
