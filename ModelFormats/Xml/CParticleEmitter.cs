// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.CParticleEmitter
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.ModelFormats.Xml.Value;
using System.Xml;

namespace MdxLib.ModelFormats.Xml
{
  internal sealed class CParticleEmitter : CNode
  {
    private CParticleEmitter()
    {
    }

    public void Load(CLoader Loader, XmlNode Node, MdxLib.Model.CModel Model, MdxLib.Model.CParticleEmitter ParticleEmitter)
    {
      this.LoadNode<MdxLib.Model.CParticleEmitter>(Loader, Node, Model, ParticleEmitter);
      ParticleEmitter.FileName = this.ReadString(Node, "filename", ParticleEmitter.FileName);
      ParticleEmitter.EmitterUsesMdl = this.ReadBoolean(Node, "emitter_uses_mdl", ParticleEmitter.EmitterUsesMdl);
      ParticleEmitter.EmitterUsesTga = this.ReadBoolean(Node, "emitter_uses_tga", ParticleEmitter.EmitterUsesTga);
      this.LoadAnimator<float>(Loader, Node, Model, ParticleEmitter.EmissionRate, (IValue<float>) CFloat.Instance, "emission_rate");
      this.LoadAnimator<float>(Loader, Node, Model, ParticleEmitter.Gravity, (IValue<float>) CFloat.Instance, "gravity");
      this.LoadAnimator<float>(Loader, Node, Model, ParticleEmitter.Longitude, (IValue<float>) CFloat.Instance, "longitude");
      this.LoadAnimator<float>(Loader, Node, Model, ParticleEmitter.Latitude, (IValue<float>) CFloat.Instance, "latitude");
      this.LoadAnimator<float>(Loader, Node, Model, ParticleEmitter.Visibility, (IValue<float>) CFloat.Instance, "visibility");
      this.LoadAnimator<float>(Loader, Node, Model, ParticleEmitter.LifeSpan, (IValue<float>) CFloat.Instance, "life_span");
      this.LoadAnimator<float>(Loader, Node, Model, ParticleEmitter.InitialVelocity, (IValue<float>) CFloat.Instance, "initial_velocity");
    }

    public void Save(CSaver Saver, XmlNode Node, MdxLib.Model.CModel Model, MdxLib.Model.CParticleEmitter ParticleEmitter)
    {
      this.SaveNode<MdxLib.Model.CParticleEmitter>(Saver, Node, Model, ParticleEmitter);
      this.WriteString(Node, "filename", ParticleEmitter.FileName);
      this.WriteBoolean(Node, "emitter_uses_mdl", ParticleEmitter.EmitterUsesMdl);
      this.WriteBoolean(Node, "emitter_uses_tga", ParticleEmitter.EmitterUsesTga);
      this.SaveAnimator<float>(Saver, Node, Model, ParticleEmitter.EmissionRate, (IValue<float>) CFloat.Instance, "emission_rate");
      this.SaveAnimator<float>(Saver, Node, Model, ParticleEmitter.Gravity, (IValue<float>) CFloat.Instance, "gravity");
      this.SaveAnimator<float>(Saver, Node, Model, ParticleEmitter.Longitude, (IValue<float>) CFloat.Instance, "longitude");
      this.SaveAnimator<float>(Saver, Node, Model, ParticleEmitter.Latitude, (IValue<float>) CFloat.Instance, "latitude");
      this.SaveAnimator<float>(Saver, Node, Model, ParticleEmitter.Visibility, (IValue<float>) CFloat.Instance, "visibility");
      this.SaveAnimator<float>(Saver, Node, Model, ParticleEmitter.LifeSpan, (IValue<float>) CFloat.Instance, "life_span");
      this.SaveAnimator<float>(Saver, Node, Model, ParticleEmitter.InitialVelocity, (IValue<float>) CFloat.Instance, "initial_velocity");
    }

    public static CParticleEmitter Instance => CParticleEmitter.CSingleton.Instance;

    private static class CSingleton
    {
      public static CParticleEmitter Instance = new CParticleEmitter();
    }
  }
}
