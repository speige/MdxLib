// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.CMaterialLayer
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using MdxLib.ModelFormats.Xml.Value;
using System.Xml;

namespace MdxLib.ModelFormats.Xml
{
  internal sealed class CMaterialLayer : CObject
  {
    private CMaterialLayer()
    {
    }

    public void Load(
      CLoader Loader,
      XmlNode Node,
      MdxLib.Model.CModel Model,
      MdxLib.Model.CMaterial Material,
      MdxLib.Model.CMaterialLayer MaterialLayer)
    {
      MaterialLayer.FilterMode = this.StringToFilterMode(this.ReadString(Node, "filter_mode", this.FilterModeToString(MaterialLayer.FilterMode)));
      MaterialLayer.CoordId = this.ReadInteger(Node, "coord_id", MaterialLayer.CoordId);
      MaterialLayer.Unshaded = this.ReadBoolean(Node, "unshaded", MaterialLayer.Unshaded);
      MaterialLayer.Unfogged = this.ReadBoolean(Node, "unfogged", MaterialLayer.Unfogged);
      MaterialLayer.TwoSided = this.ReadBoolean(Node, "two_sided", MaterialLayer.TwoSided);
      MaterialLayer.SphereEnvironmentMap = this.ReadBoolean(Node, "sphere_environment_map", MaterialLayer.SphereEnvironmentMap);
      MaterialLayer.NoDepthTest = this.ReadBoolean(Node, "no_depth_test", MaterialLayer.NoDepthTest);
      MaterialLayer.NoDepthSet = this.ReadBoolean(Node, "no_depth_set", MaterialLayer.NoDepthSet);
      this.LoadAnimator<int>(Loader, Node, Model, MaterialLayer.TextureId, (IValue<int>) CInteger.Instance, "texture_id");
      this.LoadAnimator<float>(Loader, Node, Model, MaterialLayer.Alpha, (IValue<float>) CFloat.Instance, "alpha");
      Loader.Attacher.AddObject<MdxLib.Model.CTexture>(Model.Textures, MaterialLayer.Texture, this.ReadInteger(Node, "texture", -1));
      Loader.Attacher.AddObject<MdxLib.Model.CTextureAnimation>(Model.TextureAnimations, MaterialLayer.TextureAnimation, this.ReadInteger(Node, "texture_animation", -1));
    }

    public void Save(
      CSaver Saver,
      XmlNode Node,
      MdxLib.Model.CModel Model,
      MdxLib.Model.CMaterial Material,
      MdxLib.Model.CMaterialLayer MaterialLayer)
    {
      this.WriteString(Node, "filter_mode", this.FilterModeToString(MaterialLayer.FilterMode));
      this.WriteInteger(Node, "coord_id", MaterialLayer.CoordId);
      this.WriteBoolean(Node, "unshaded", MaterialLayer.Unshaded);
      this.WriteBoolean(Node, "unfogged", MaterialLayer.Unfogged);
      this.WriteBoolean(Node, "two_sided", MaterialLayer.TwoSided);
      this.WriteBoolean(Node, "sphere_environment_map", MaterialLayer.SphereEnvironmentMap);
      this.WriteBoolean(Node, "no_depth_test", MaterialLayer.NoDepthTest);
      this.WriteBoolean(Node, "no_depth_set", MaterialLayer.NoDepthSet);
      this.SaveAnimator<int>(Saver, Node, Model, MaterialLayer.TextureId, (IValue<int>) CInteger.Instance, "texture_id");
      this.SaveAnimator<float>(Saver, Node, Model, MaterialLayer.Alpha, (IValue<float>) CFloat.Instance, "alpha");
      this.WriteInteger(Node, "texture", MaterialLayer.Texture.ObjectId);
      this.WriteInteger(Node, "texture_animation", MaterialLayer.TextureAnimation.ObjectId);
    }

    private string FilterModeToString(EMaterialLayerFilterMode FilterMode)
    {
      switch (FilterMode)
      {
        case EMaterialLayerFilterMode.None:
          return "none";
        case EMaterialLayerFilterMode.Transparent:
          return "transparent";
        case EMaterialLayerFilterMode.Blend:
          return "blend";
        case EMaterialLayerFilterMode.Additive:
          return "additive";
        case EMaterialLayerFilterMode.AdditiveAlpha:
          return "additive_alpha";
        case EMaterialLayerFilterMode.Modulate:
          return "modulate";
        case EMaterialLayerFilterMode.Modulate2x:
          return "modulate_2x";
        default:
          return "";
      }
    }

    private EMaterialLayerFilterMode StringToFilterMode(string String)
    {
      switch (String)
      {
        case "none":
          return EMaterialLayerFilterMode.None;
        case "transparent":
          return EMaterialLayerFilterMode.Transparent;
        case "blend":
          return EMaterialLayerFilterMode.Blend;
        case "additive":
          return EMaterialLayerFilterMode.Additive;
        case "additive_alpha":
          return EMaterialLayerFilterMode.AdditiveAlpha;
        case "modulate":
          return EMaterialLayerFilterMode.Modulate;
        case "modulate_2x":
          return EMaterialLayerFilterMode.Modulate2x;
        default:
          return EMaterialLayerFilterMode.None;
      }
    }

    public static CMaterialLayer Instance => CMaterialLayer.CSingleton.Instance;

    private static class CSingleton
    {
      public static CMaterialLayer Instance = new CMaterialLayer();
    }
  }
}
