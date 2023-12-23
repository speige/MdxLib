// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CParticleEmitter
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Animator;
using MdxLib.Animator.Animatable;

namespace MdxLib.Model
{
  public sealed class CParticleEmitter : CNode<CParticleEmitter>
  {
    private string _FileName = "";
    private bool _EmitterUsesMdl;
    private bool _EmitterUsesTga;
    private CAnimator<float> _EmissionRate;
    private CAnimator<float> _Gravity;
    private CAnimator<float> _Longitude;
    private CAnimator<float> _Latitude;
    private CAnimator<float> _LifeSpan;
    private CAnimator<float> _InitialVelocity;
    private CAnimator<float> _Visibility;

    public CParticleEmitter(CModel Model)
      : base(Model)
    {
    }

    public override string ToString() => "Particle Emitter #" + (object) this.ObjectId;

    public override int NodeId => this.Model.GetParticleEmitterNodeId(this);

    public string FileName
    {
      get => this._FileName;
      set
      {
        this.AddSetObjectFieldCommand<string>("_FileName", value);
        this._FileName = value;
      }
    }

    public bool EmitterUsesMdl
    {
      get => this._EmitterUsesMdl;
      set
      {
        this.AddSetObjectFieldCommand<bool>("_EmitterUsesMdl", value);
        this._EmitterUsesMdl = value;
      }
    }

    public bool EmitterUsesTga
    {
      get => this._EmitterUsesTga;
      set
      {
        this.AddSetObjectFieldCommand<bool>("_EmitterUsesTga", value);
        this._EmitterUsesTga = value;
      }
    }

    public CAnimator<float> EmissionRate => this._EmissionRate ?? (this._EmissionRate = new CAnimator<float>(this.Model, (CAnimatable<float>) new CFloat(0.0f)));

    public CAnimator<float> Gravity => this._Gravity ?? (this._Gravity = new CAnimator<float>(this.Model, (CAnimatable<float>) new CFloat(0.0f)));

    public CAnimator<float> Longitude => this._Longitude ?? (this._Longitude = new CAnimator<float>(this.Model, (CAnimatable<float>) new CFloat(0.0f)));

    public CAnimator<float> Latitude => this._Latitude ?? (this._Latitude = new CAnimator<float>(this.Model, (CAnimatable<float>) new CFloat(0.0f)));

    public CAnimator<float> LifeSpan => this._LifeSpan ?? (this._LifeSpan = new CAnimator<float>(this.Model, (CAnimatable<float>) new CFloat(0.0f)));

    public CAnimator<float> InitialVelocity => this._InitialVelocity ?? (this._InitialVelocity = new CAnimator<float>(this.Model, (CAnimatable<float>) new CFloat(0.0f)));

    public CAnimator<float> Visibility => this._Visibility ?? (this._Visibility = new CAnimator<float>(this.Model, (CAnimatable<float>) new CFloat(1f)));
  }
}
