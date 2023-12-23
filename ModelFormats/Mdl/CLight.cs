// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdl.CLight
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using MdxLib.ModelFormats.Mdl.Token;
using MdxLib.ModelFormats.Mdl.Value;
using System;

namespace MdxLib.ModelFormats.Mdl
{
  internal sealed class CLight : CNode
  {
    private CLight()
    {
    }

    public void LoadAll(CLoader Loader, MdxLib.Model.CModel Model)
    {
      MdxLib.Model.CLight clight = new MdxLib.Model.CLight(Model);
      this.Load(Loader, Model, clight);
      Model.Lights.Add(clight);
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CLight Light)
    {
      Light.Name = Loader.ReadString();
      Loader.ExpectToken(EType.CurlyBracketLeft);
      while (Loader.PeekToken() != EType.CurlyBracketRight)
      {
        string Tag1 = Loader.ReadWord();
        if (!this.LoadNode<MdxLib.Model.CLight>(Loader, Model, (CNode<MdxLib.Model.CLight>) Light, Tag1))
        {
          switch (Tag1)
          {
            case "static":
              string Tag2 = Loader.ReadWord();
              if (!this.LoadStaticNode<MdxLib.Model.CLight>(Loader, Model, (CNode<MdxLib.Model.CLight>) Light, Tag2))
              {
                switch (Tag2)
                {
                  case "attenuationstart":
                    this.LoadStaticAnimator<float>(Loader, Model, Light.AttenuationStart, (IValue<float>) CFloat.Instance);
                    continue;
                  case "attenuationend":
                    this.LoadStaticAnimator<float>(Loader, Model, Light.AttenuationEnd, (IValue<float>) CFloat.Instance);
                    continue;
                  case "color":
                    this.LoadStaticAnimator<MdxLib.Primitives.CVector3>(Loader, Model, Light.Color, (IValue<MdxLib.Primitives.CVector3>) CColor.Instance);
                    continue;
                  case "intensity":
                    this.LoadStaticAnimator<float>(Loader, Model, Light.Intensity, (IValue<float>) CFloat.Instance);
                    continue;
                  case "ambcolor":
                    this.LoadStaticAnimator<MdxLib.Primitives.CVector3>(Loader, Model, Light.AmbientColor, (IValue<MdxLib.Primitives.CVector3>) CColor.Instance);
                    continue;
                  case "ambintensity":
                    this.LoadStaticAnimator<float>(Loader, Model, Light.AmbientIntensity, (IValue<float>) CFloat.Instance);
                    continue;
                  case "visibility":
                    this.LoadStaticAnimator<float>(Loader, Model, Light.Visibility, (IValue<float>) CFloat.Instance);
                    continue;
                  default:
                    throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + Tag2 + "\"!");
                }
              }
              else
                continue;
            case "attenuationstart":
              this.LoadAnimator<float>(Loader, Model, Light.AttenuationStart, (IValue<float>) CFloat.Instance);
              continue;
            case "attenuationend":
              this.LoadAnimator<float>(Loader, Model, Light.AttenuationEnd, (IValue<float>) CFloat.Instance);
              continue;
            case "color":
              this.LoadAnimator<MdxLib.Primitives.CVector3>(Loader, Model, Light.Color, (IValue<MdxLib.Primitives.CVector3>) CColor.Instance);
              continue;
            case "intensity":
              this.LoadAnimator<float>(Loader, Model, Light.Intensity, (IValue<float>) CFloat.Instance);
              continue;
            case "ambcolor":
              this.LoadAnimator<MdxLib.Primitives.CVector3>(Loader, Model, Light.AmbientColor, (IValue<MdxLib.Primitives.CVector3>) CColor.Instance);
              continue;
            case "ambintensity":
              this.LoadAnimator<float>(Loader, Model, Light.AmbientIntensity, (IValue<float>) CFloat.Instance);
              continue;
            case "visibility":
              this.LoadAnimator<float>(Loader, Model, Light.Visibility, (IValue<float>) CFloat.Instance);
              continue;
            case "omnidirectional":
              Light.Type = ELightType.Omnidirectional;
              this.LoadBoolean(Loader);
              continue;
            case "directional":
              Light.Type = ELightType.Directional;
              this.LoadBoolean(Loader);
              continue;
            case "ambient":
              Light.Type = ELightType.Ambient;
              this.LoadBoolean(Loader);
              continue;
            default:
              throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + Tag1 + "\"!");
          }
        }
      }
      int num = (int) Loader.ReadToken();
    }

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasLights)
        return;
      foreach (MdxLib.Model.CLight light in Model.Lights)
        this.Save(Saver, Model, light);
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CLight Light)
    {
      Saver.BeginGroup(nameof (Light), Light.Name);
      this.SaveNode<MdxLib.Model.CLight>(Saver, Model, (CNode<MdxLib.Model.CLight>) Light);
      this.SaveBoolean(Saver, this.TypeToString(Light.Type), true);
      this.SaveAnimator<float>(Saver, Model, Light.AttenuationStart, (IValue<float>) CFloat.Instance, "AttenuationStart");
      this.SaveAnimator<float>(Saver, Model, Light.AttenuationEnd, (IValue<float>) CFloat.Instance, "AttenuationEnd");
      this.SaveAnimator<MdxLib.Primitives.CVector3>(Saver, Model, Light.Color, (IValue<MdxLib.Primitives.CVector3>) CColor.Instance, "Color");
      this.SaveAnimator<float>(Saver, Model, Light.Intensity, (IValue<float>) CFloat.Instance, "Intensity");
      this.SaveAnimator<MdxLib.Primitives.CVector3>(Saver, Model, Light.AmbientColor, (IValue<MdxLib.Primitives.CVector3>) CColor.Instance, "AmbColor");
      this.SaveAnimator<float>(Saver, Model, Light.AmbientIntensity, (IValue<float>) CFloat.Instance, "AmbIntensity");
      this.SaveAnimator<float>(Saver, Model, Light.Visibility, (IValue<float>) CFloat.Instance, "Visibility", ECondition.NotOne);
      Saver.EndGroup();
    }

    private string TypeToString(ELightType Type)
    {
      switch (Type)
      {
        case ELightType.Omnidirectional:
          return "Omnidirectional";
        case ELightType.Directional:
          return "Directional";
        case ELightType.Ambient:
          return "Ambient";
        default:
          return "";
      }
    }

    public static CLight Instance => CLight.CSingleton.Instance;

    private static class CSingleton
    {
      public static CLight Instance = new CLight();
    }
  }
}
