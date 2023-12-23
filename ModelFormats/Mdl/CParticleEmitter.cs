// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdl.CParticleEmitter
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using MdxLib.ModelFormats.Mdl.Token;
using MdxLib.ModelFormats.Mdl.Value;
using System;

namespace MdxLib.ModelFormats.Mdl
{
  internal sealed class CParticleEmitter : CNode
  {
    private CParticleEmitter()
    {
    }

    public void LoadAll(CLoader Loader, MdxLib.Model.CModel Model)
    {
      MdxLib.Model.CParticleEmitter cparticleEmitter = new MdxLib.Model.CParticleEmitter(Model);
      this.Load(Loader, Model, cparticleEmitter);
      Model.ParticleEmitters.Add(cparticleEmitter);
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CParticleEmitter ParticleEmitter)
    {
      ParticleEmitter.Name = Loader.ReadString();
      Loader.ExpectToken(EType.CurlyBracketLeft);
      while (Loader.PeekToken() != EType.CurlyBracketRight)
      {
        string Tag1 = Loader.ReadWord();
        if (!this.LoadNode<MdxLib.Model.CParticleEmitter>(Loader, Model, (CNode<MdxLib.Model.CParticleEmitter>) ParticleEmitter, Tag1))
        {
          switch (Tag1)
          {
            case "static":
              string Tag2 = Loader.ReadWord();
              if (!this.LoadStaticNode<MdxLib.Model.CParticleEmitter>(Loader, Model, (CNode<MdxLib.Model.CParticleEmitter>) ParticleEmitter, Tag2))
              {
                switch (Tag2)
                {
                  case "emissionrate":
                    this.LoadStaticAnimator<float>(Loader, Model, ParticleEmitter.EmissionRate, (IValue<float>) CFloat.Instance);
                    continue;
                  case "gravity":
                    this.LoadStaticAnimator<float>(Loader, Model, ParticleEmitter.Gravity, (IValue<float>) CFloat.Instance);
                    continue;
                  case "longitude":
                    this.LoadStaticAnimator<float>(Loader, Model, ParticleEmitter.Longitude, (IValue<float>) CFloat.Instance);
                    continue;
                  case "latitude":
                    this.LoadStaticAnimator<float>(Loader, Model, ParticleEmitter.Latitude, (IValue<float>) CFloat.Instance);
                    continue;
                  case "visibility":
                    this.LoadStaticAnimator<float>(Loader, Model, ParticleEmitter.Visibility, (IValue<float>) CFloat.Instance);
                    continue;
                  default:
                    throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + Tag2 + "\"!");
                }
              }
              else
                continue;
            case "emissionrate":
              this.LoadAnimator<float>(Loader, Model, ParticleEmitter.EmissionRate, (IValue<float>) CFloat.Instance);
              continue;
            case "gravity":
              this.LoadAnimator<float>(Loader, Model, ParticleEmitter.Gravity, (IValue<float>) CFloat.Instance);
              continue;
            case "longitude":
              this.LoadAnimator<float>(Loader, Model, ParticleEmitter.Longitude, (IValue<float>) CFloat.Instance);
              continue;
            case "latitude":
              this.LoadAnimator<float>(Loader, Model, ParticleEmitter.Latitude, (IValue<float>) CFloat.Instance);
              continue;
            case "visibility":
              this.LoadAnimator<float>(Loader, Model, ParticleEmitter.Visibility, (IValue<float>) CFloat.Instance);
              continue;
            case "emitterusesmdl":
              ParticleEmitter.EmitterUsesMdl = this.LoadBoolean(Loader);
              continue;
            case "emitterusestga":
              ParticleEmitter.EmitterUsesTga = this.LoadBoolean(Loader);
              continue;
            case "particle":
              Loader.ExpectToken(EType.CurlyBracketLeft);
              while (Loader.PeekToken() != EType.CurlyBracketRight)
              {
                string str1 = Loader.ReadWord();
                switch (str1)
                {
                  case "static":
                    string str2 = Loader.ReadWord();
                    switch (str2)
                    {
                      case "lifespan":
                        this.LoadStaticAnimator<float>(Loader, Model, ParticleEmitter.LifeSpan, (IValue<float>) CFloat.Instance);
                        continue;
                      case "initvelocity":
                        this.LoadStaticAnimator<float>(Loader, Model, ParticleEmitter.InitialVelocity, (IValue<float>) CFloat.Instance);
                        continue;
                      default:
                        throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + str2 + "\"!");
                    }
                  case "lifespan":
                    this.LoadAnimator<float>(Loader, Model, ParticleEmitter.LifeSpan, (IValue<float>) CFloat.Instance);
                    continue;
                  case "initvelocity":
                    this.LoadAnimator<float>(Loader, Model, ParticleEmitter.InitialVelocity, (IValue<float>) CFloat.Instance);
                    continue;
                  case "path":
                    ParticleEmitter.FileName = this.LoadString(Loader);
                    continue;
                  default:
                    throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + str1 + "\"!");
                }
              }
              int num = (int) Loader.ReadToken();
              continue;
            default:
              throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + Tag1 + "\"!");
          }
        }
      }
      int num1 = (int) Loader.ReadToken();
    }

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasParticleEmitters)
        return;
      foreach (MdxLib.Model.CParticleEmitter particleEmitter in Model.ParticleEmitters)
        this.Save(Saver, Model, particleEmitter);
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CParticleEmitter ParticleEmitter)
    {
      Saver.BeginGroup(nameof (ParticleEmitter), ParticleEmitter.Name);
      this.SaveNode<MdxLib.Model.CParticleEmitter>(Saver, Model, (CNode<MdxLib.Model.CParticleEmitter>) ParticleEmitter);
      this.SaveBoolean(Saver, "EmitterUsesMDL", ParticleEmitter.EmitterUsesMdl);
      this.SaveBoolean(Saver, "EmitterUsesTGA", ParticleEmitter.EmitterUsesTga);
      this.SaveAnimator<float>(Saver, Model, ParticleEmitter.EmissionRate, (IValue<float>) CFloat.Instance, "EmissionRate");
      this.SaveAnimator<float>(Saver, Model, ParticleEmitter.Gravity, (IValue<float>) CFloat.Instance, "Gravity");
      this.SaveAnimator<float>(Saver, Model, ParticleEmitter.Longitude, (IValue<float>) CFloat.Instance, "Longitude");
      this.SaveAnimator<float>(Saver, Model, ParticleEmitter.Latitude, (IValue<float>) CFloat.Instance, "Latitude");
      this.SaveAnimator<float>(Saver, Model, ParticleEmitter.Visibility, (IValue<float>) CFloat.Instance, "Visibility", ECondition.NotOne);
      Saver.BeginGroup("Particle");
      this.SaveString(Saver, "Path", ParticleEmitter.FileName);
      this.SaveAnimator<float>(Saver, Model, ParticleEmitter.LifeSpan, (IValue<float>) CFloat.Instance, "LifeSpan");
      this.SaveAnimator<float>(Saver, Model, ParticleEmitter.InitialVelocity, (IValue<float>) CFloat.Instance, "InitVelocity");
      Saver.EndGroup();
      Saver.EndGroup();
    }

    public static CParticleEmitter Instance => CParticleEmitter.CSingleton.Instance;

    private static class CSingleton
    {
      public static CParticleEmitter Instance = new CParticleEmitter();
    }
  }
}
