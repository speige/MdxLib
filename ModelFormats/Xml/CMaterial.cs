// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.CMaterial
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System.Xml;

namespace MdxLib.ModelFormats.Xml
{
  internal sealed class CMaterial : CObject
  {
    private CMaterial()
    {
    }

    public void Load(CLoader Loader, XmlNode Node, MdxLib.Model.CModel Model, MdxLib.Model.CMaterial Material)
    {
      Material.PriorityPlane = this.ReadInteger(Node, "priority_plane", Material.PriorityPlane);
      Material.ConstantColor = this.ReadBoolean(Node, "constant_color", Material.ConstantColor);
      Material.FullResolution = this.ReadBoolean(Node, "full_resolution", Material.FullResolution);
      Material.SortPrimitivesFarZ = this.ReadBoolean(Node, "sort_primitives_far_z", Material.SortPrimitivesFarZ);
      Material.SortPrimitivesNearZ = this.ReadBoolean(Node, "sort_primitives_near_z", Material.SortPrimitivesNearZ);
      foreach (XmlNode selectNode in Node.SelectNodes("material_layer"))
      {
        MdxLib.Model.CMaterialLayer cmaterialLayer = new MdxLib.Model.CMaterialLayer(Model);
        CMaterialLayer.Instance.Load(Loader, selectNode, Model, Material, cmaterialLayer);
        Material.Layers.Add(cmaterialLayer);
      }
    }

    public void Save(CSaver Saver, XmlNode Node, MdxLib.Model.CModel Model, MdxLib.Model.CMaterial Material)
    {
      this.WriteInteger(Node, "priority_plane", Material.PriorityPlane);
      this.WriteBoolean(Node, "constant_color", Material.ConstantColor);
      this.WriteBoolean(Node, "full_resolution", Material.FullResolution);
      this.WriteBoolean(Node, "sort_primitives_far_z", Material.SortPrimitivesFarZ);
      this.WriteBoolean(Node, "sort_primitives_near_z", Material.SortPrimitivesNearZ);
      if (!Material.HasLayers)
        return;
      foreach (MdxLib.Model.CMaterialLayer layer in Material.Layers)
      {
        XmlElement Node1 = this.AppendElement(Node, "material_layer");
        CMaterialLayer.Instance.Save(Saver, (XmlNode) Node1, Model, Material, layer);
      }
    }

    public static CMaterial Instance => CMaterial.CSingleton.Instance;

    private static class CSingleton
    {
      public static CMaterial Instance = new CMaterial();
    }
  }
}
