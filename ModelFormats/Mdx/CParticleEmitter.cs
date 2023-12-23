// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdx.CParticleEmitter
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using MdxLib.ModelFormats.Mdx.Value;
using System;

namespace MdxLib.ModelFormats.Mdx
{
  internal sealed class CParticleEmitter : CNode
  {
    private CParticleEmitter()
    {
    }

    public void LoadAll(CLoader Loader, MdxLib.Model.CModel Model)
    {
      int num = Loader.ReadInt32();
      while (num > 0)
      {
        Loader.PushLocation();
        MdxLib.Model.CParticleEmitter cparticleEmitter = new MdxLib.Model.CParticleEmitter(Model);
        this.Load(Loader, Model, cparticleEmitter);
        Model.ParticleEmitters.Add(cparticleEmitter);
        num -= Loader.PopLocation();
        if (num < 0)
          throw new Exception("Error at location " + (object) Loader.Location + ", too many ParticleEmitter bytes were read!");
      }
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CParticleEmitter ParticleEmitter)
    {
      Loader.PushLocation();
      int num1 = Loader.ReadInt32();
      int num2 = CNode.LoadNode<MdxLib.Model.CParticleEmitter>(Loader, Model, (CNode<MdxLib.Model.CParticleEmitter>) ParticleEmitter);
      ParticleEmitter.EmissionRate.MakeStatic(Loader.ReadFloat());
      ParticleEmitter.Gravity.MakeStatic(Loader.ReadFloat());
      ParticleEmitter.Longitude.MakeStatic(Loader.ReadFloat());
      ParticleEmitter.Latitude.MakeStatic(Loader.ReadFloat());
      ParticleEmitter.FileName = Loader.ReadString(260);
      ParticleEmitter.LifeSpan.MakeStatic(Loader.ReadFloat());
      ParticleEmitter.InitialVelocity.MakeStatic(Loader.ReadFloat());
      ParticleEmitter.EmitterUsesMdl = (num2 & 32768) != 0;
      ParticleEmitter.EmitterUsesTga = (num2 & 65536) != 0;
      int num3 = num1 - Loader.PopLocation();
      if (num3 < 0)
        throw new Exception("Error at location " + (object) Loader.Location + ", too many ParticleEmitter bytes were read!");
      while (num3 > 0)
      {
        Loader.PushLocation();
        string str = Loader.ReadTag();
        switch (str)
        {
          case "KPEE":
            CObject.LoadAnimator<float>(Loader, Model, ParticleEmitter.EmissionRate, (IValue<float>) CFloat.Instance);
            break;
          case "KPEG":
            CObject.LoadAnimator<float>(Loader, Model, ParticleEmitter.Gravity, (IValue<float>) CFloat.Instance);
            break;
          case "KPLN":
            CObject.LoadAnimator<float>(Loader, Model, ParticleEmitter.Longitude, (IValue<float>) CFloat.Instance);
            break;
          case "KPLT":
            CObject.LoadAnimator<float>(Loader, Model, ParticleEmitter.Latitude, (IValue<float>) CFloat.Instance);
            break;
          case "KPEL":
            CObject.LoadAnimator<float>(Loader, Model, ParticleEmitter.LifeSpan, (IValue<float>) CFloat.Instance);
            break;
          case "KPES":
            CObject.LoadAnimator<float>(Loader, Model, ParticleEmitter.InitialVelocity, (IValue<float>) CFloat.Instance);
            break;
          case "KPEV":
            CObject.LoadAnimator<float>(Loader, Model, ParticleEmitter.Visibility, (IValue<float>) CFloat.Instance);
            break;
          default:
            throw new Exception("Error at location " + (object) Loader.Location + ", unknown ParticleEmitter tag \"" + str + "\"!");
        }
        num3 -= Loader.PopLocation();
        if (num3 < 0)
          throw new Exception("Error at location " + (object) Loader.Location + ", too many ParticleEmitter bytes were read!");
      }
    }

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasParticleEmitters)
        return;
      Saver.WriteTag("PREM");
      Saver.PushLocation();
      foreach (MdxLib.Model.CParticleEmitter particleEmitter in Model.ParticleEmitters)
        this.Save(Saver, Model, particleEmitter);
      Saver.PopExclusiveLocation();
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CParticleEmitter ParticleEmitter)
    {
      int Flags = 4096;
      if (ParticleEmitter.EmitterUsesMdl)
        Flags |= 32768;
      if (ParticleEmitter.EmitterUsesTga)
        Flags |= 65536;
      Saver.PushLocation();
      CNode.SaveNode<MdxLib.Model.CParticleEmitter>(Saver, Model, (CNode<MdxLib.Model.CParticleEmitter>) ParticleEmitter, Flags);
      Saver.WriteFloat(ParticleEmitter.EmissionRate.GetValue());
      Saver.WriteFloat(ParticleEmitter.Gravity.GetValue());
      Saver.WriteFloat(ParticleEmitter.Longitude.GetValue());
      Saver.WriteFloat(ParticleEmitter.Latitude.GetValue());
      Saver.WriteString(ParticleEmitter.FileName, 260);
      Saver.WriteFloat(ParticleEmitter.LifeSpan.GetValue());
      Saver.WriteFloat(ParticleEmitter.InitialVelocity.GetValue());
      CObject.SaveAnimator<float>(Saver, Model, ParticleEmitter.EmissionRate, (IValue<float>) CFloat.Instance, "KPEE");
      CObject.SaveAnimator<float>(Saver, Model, ParticleEmitter.Gravity, (IValue<float>) CFloat.Instance, "KPEG");
      CObject.SaveAnimator<float>(Saver, Model, ParticleEmitter.Longitude, (IValue<float>) CFloat.Instance, "KPLN");
      CObject.SaveAnimator<float>(Saver, Model, ParticleEmitter.Latitude, (IValue<float>) CFloat.Instance, "KPLT");
      CObject.SaveAnimator<float>(Saver, Model, ParticleEmitter.LifeSpan, (IValue<float>) CFloat.Instance, "KPEL");
      CObject.SaveAnimator<float>(Saver, Model, ParticleEmitter.InitialVelocity, (IValue<float>) CFloat.Instance, "KPES");
      CObject.SaveAnimator<float>(Saver, Model, ParticleEmitter.Visibility, (IValue<float>) CFloat.Instance, "KPEV");
      Saver.PopInclusiveLocation();
    }

    public static CParticleEmitter Instance => CParticleEmitter.CSingleton.Instance;

    private static class CSingleton
    {
      public static CParticleEmitter Instance = new CParticleEmitter();
    }
  }
}
