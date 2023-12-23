// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.CGeosetExtent
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System.Xml;

namespace MdxLib.ModelFormats.Xml
{
  internal sealed class CGeosetExtent : CObject
  {
    private CGeosetExtent()
    {
    }

    public void Load(
      CLoader Loader,
      XmlNode Node,
      MdxLib.Model.CModel Model,
      MdxLib.Model.CGeoset Geoset,
      MdxLib.Model.CGeosetExtent GeosetExtent)
    {
      GeosetExtent.Extent = this.ReadExtent(Node, "extent", GeosetExtent.Extent);
    }

    public void Save(
      CSaver Saver,
      XmlNode Node,
      MdxLib.Model.CModel Model,
      MdxLib.Model.CGeoset Geoset,
      MdxLib.Model.CGeosetExtent GeosetExtent)
    {
      this.WriteExtent(Node, "extent", GeosetExtent.Extent);
    }

    public static CGeosetExtent Instance => CGeosetExtent.CSingleton.Instance;

    private static class CSingleton
    {
      public static CGeosetExtent Instance = new CGeosetExtent();
    }
  }
}
