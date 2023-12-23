// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.CLight
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using MdxLib.ModelFormats.Xml.Value;
using System.Xml;

namespace MdxLib.ModelFormats.Xml
{
  internal sealed class CLight : CNode
  {
    private CLight()
    {
    }

    public void Load(CLoader Loader, XmlNode Node, MdxLib.Model.CModel Model, MdxLib.Model.CLight Light)
    {
      this.LoadNode<MdxLib.Model.CLight>(Loader, Node, Model, Light);
      Light.Type = this.StringToType(this.ReadString(Node, "type", this.TypeToString(Light.Type)));
      this.LoadAnimator<float>(Loader, Node, Model, Light.AttenuationStart, (IValue<float>) CFloat.Instance, "attenuation_start");
      this.LoadAnimator<float>(Loader, Node, Model, Light.AttenuationEnd, (IValue<float>) CFloat.Instance, "attenuation_end");
      this.LoadAnimator<MdxLib.Primitives.CVector3>(Loader, Node, Model, Light.Color, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Xml.Value.CVector3.Instance, "color");
      this.LoadAnimator<float>(Loader, Node, Model, Light.Intensity, (IValue<float>) CFloat.Instance, "intensity");
      this.LoadAnimator<MdxLib.Primitives.CVector3>(Loader, Node, Model, Light.AmbientColor, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Xml.Value.CVector3.Instance, "ambient_color");
      this.LoadAnimator<float>(Loader, Node, Model, Light.AmbientIntensity, (IValue<float>) CFloat.Instance, "ambient_intensity");
      this.LoadAnimator<float>(Loader, Node, Model, Light.Visibility, (IValue<float>) CFloat.Instance, "visibility");
    }

    public void Save(CSaver Saver, XmlNode Node, MdxLib.Model.CModel Model, MdxLib.Model.CLight Light)
    {
      this.SaveNode<MdxLib.Model.CLight>(Saver, Node, Model, Light);
      this.WriteString(Node, "type", this.TypeToString(Light.Type));
      this.SaveAnimator<float>(Saver, Node, Model, Light.AttenuationStart, (IValue<float>) CFloat.Instance, "attenuation_start");
      this.SaveAnimator<float>(Saver, Node, Model, Light.AttenuationEnd, (IValue<float>) CFloat.Instance, "attenuation_end");
      this.SaveAnimator<MdxLib.Primitives.CVector3>(Saver, Node, Model, Light.Color, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Xml.Value.CVector3.Instance, "color");
      this.SaveAnimator<float>(Saver, Node, Model, Light.Intensity, (IValue<float>) CFloat.Instance, "intensity");
      this.SaveAnimator<MdxLib.Primitives.CVector3>(Saver, Node, Model, Light.AmbientColor, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Xml.Value.CVector3.Instance, "ambient_color");
      this.SaveAnimator<float>(Saver, Node, Model, Light.AmbientIntensity, (IValue<float>) CFloat.Instance, "ambient_intensity");
      this.SaveAnimator<float>(Saver, Node, Model, Light.Visibility, (IValue<float>) CFloat.Instance, "visibility");
    }

    private string TypeToString(ELightType Type)
    {
      switch (Type)
      {
        case ELightType.Omnidirectional:
          return "omnidirectional";
        case ELightType.Directional:
          return "directional";
        case ELightType.Ambient:
          return "ambient";
        default:
          return "";
      }
    }

    private ELightType StringToType(string String)
    {
      switch (String)
      {
        case "omnidirectional":
          return ELightType.Omnidirectional;
        case "directional":
          return ELightType.Directional;
        case "ambient":
          return ELightType.Ambient;
        default:
          return ELightType.Omnidirectional;
      }
    }

    public static CLight Instance => CLight.CSingleton.Instance;

    private static class CSingleton
    {
      public static CLight Instance = new CLight();
    }
  }
}
