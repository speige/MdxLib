// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdx.CLight
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using MdxLib.ModelFormats.Mdx.Value;
using System;

namespace MdxLib.ModelFormats.Mdx
{
  internal sealed class CLight : CNode
  {
    private CLight()
    {
    }

    public void LoadAll(CLoader Loader, MdxLib.Model.CModel Model)
    {
      int num = Loader.ReadInt32();
      while (num > 0)
      {
        Loader.PushLocation();
        MdxLib.Model.CLight clight = new MdxLib.Model.CLight(Model);
        this.Load(Loader, Model, clight);
        Model.Lights.Add(clight);
        num -= Loader.PopLocation();
        if (num < 0)
          throw new Exception("Error at location " + (object) Loader.Location + ", too many Light bytes were read!");
      }
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CLight Light)
    {
      Loader.PushLocation();
      int num1 = Loader.ReadInt32();
      CNode.LoadNode<MdxLib.Model.CLight>(Loader, Model, (CNode<MdxLib.Model.CLight>) Light);
      int num2 = Loader.ReadInt32();
      Light.AttenuationStart.MakeStatic(Loader.ReadFloat());
      Light.AttenuationEnd.MakeStatic(Loader.ReadFloat());
      Light.Color.MakeStatic(Loader.ReadVector3());
      Light.Intensity.MakeStatic(Loader.ReadFloat());
      Light.AmbientColor.MakeStatic(Loader.ReadVector3());
      Light.AmbientIntensity.MakeStatic(Loader.ReadFloat());
      switch (num2)
      {
        case 0:
          Light.Type = ELightType.Omnidirectional;
          break;
        case 1:
          Light.Type = ELightType.Directional;
          break;
        case 2:
          Light.Type = ELightType.Ambient;
          break;
      }
      int num3 = num1 - Loader.PopLocation();
      if (num3 < 0)
        throw new Exception("Error at location " + (object) Loader.Location + ", too many Light bytes were read!");
      while (num3 > 0)
      {
        Loader.PushLocation();
        string str = Loader.ReadTag();
        switch (str)
        {
          case "KLAS":
            CObject.LoadAnimator<float>(Loader, Model, Light.AttenuationStart, (IValue<float>) CFloat.Instance);
            break;
          case "KLAE":
            CObject.LoadAnimator<float>(Loader, Model, Light.AttenuationEnd, (IValue<float>) CFloat.Instance);
            break;
          case "KLAC":
            CObject.LoadAnimator<MdxLib.Primitives.CVector3>(Loader, Model, Light.Color, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdx.Value.CVector3.Instance);
            break;
          case "KLAI":
            CObject.LoadAnimator<float>(Loader, Model, Light.Intensity, (IValue<float>) CFloat.Instance);
            break;
          case "KLBC":
            CObject.LoadAnimator<MdxLib.Primitives.CVector3>(Loader, Model, Light.AmbientColor, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdx.Value.CVector3.Instance);
            break;
          case "KLBI":
            CObject.LoadAnimator<float>(Loader, Model, Light.AmbientIntensity, (IValue<float>) CFloat.Instance);
            break;
          case "KLAV":
            CObject.LoadAnimator<float>(Loader, Model, Light.Visibility, (IValue<float>) CFloat.Instance);
            break;
          default:
            throw new Exception("Error at location " + (object) Loader.Location + ", unknown Light tag \"" + str + "\"!");
        }
        num3 -= Loader.PopLocation();
        if (num3 < 0)
          throw new Exception("Error at location " + (object) Loader.Location + ", too many Light bytes were read!");
      }
    }

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasLights)
        return;
      Saver.WriteTag("LITE");
      Saver.PushLocation();
      foreach (MdxLib.Model.CLight light in Model.Lights)
        this.Save(Saver, Model, light);
      Saver.PopExclusiveLocation();
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CLight Light)
    {
      int num = 0;
      switch (Light.Type)
      {
        case ELightType.Omnidirectional:
          num = 0;
          break;
        case ELightType.Directional:
          num = 1;
          break;
        case ELightType.Ambient:
          num = 2;
          break;
      }
      Saver.PushLocation();
      CNode.SaveNode<MdxLib.Model.CLight>(Saver, Model, (CNode<MdxLib.Model.CLight>) Light, 512);
      Saver.WriteInt32(num);
      Saver.WriteFloat(Light.AttenuationStart.GetValue());
      Saver.WriteFloat(Light.AttenuationEnd.GetValue());
      Saver.WriteVector3(Light.Color.GetValue());
      Saver.WriteFloat(Light.Intensity.GetValue());
      Saver.WriteVector3(Light.AmbientColor.GetValue());
      Saver.WriteFloat(Light.AmbientIntensity.GetValue());
      CObject.SaveAnimator<float>(Saver, Model, Light.AttenuationStart, (IValue<float>) CFloat.Instance, "KLAS");
      CObject.SaveAnimator<float>(Saver, Model, Light.AttenuationEnd, (IValue<float>) CFloat.Instance, "KLAE");
      CObject.SaveAnimator<MdxLib.Primitives.CVector3>(Saver, Model, Light.Color, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdx.Value.CVector3.Instance, "KLAC");
      CObject.SaveAnimator<float>(Saver, Model, Light.Intensity, (IValue<float>) CFloat.Instance, "KLAI");
      CObject.SaveAnimator<MdxLib.Primitives.CVector3>(Saver, Model, Light.AmbientColor, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdx.Value.CVector3.Instance, "KLBC");
      CObject.SaveAnimator<float>(Saver, Model, Light.AmbientIntensity, (IValue<float>) CFloat.Instance, "KLBI");
      CObject.SaveAnimator<float>(Saver, Model, Light.Visibility, (IValue<float>) CFloat.Instance, "KLAV");
      Saver.PopInclusiveLocation();
    }

    public static CLight Instance => CLight.CSingleton.Instance;

    private static class CSingleton
    {
      public static CLight Instance = new CLight();
    }
  }
}
