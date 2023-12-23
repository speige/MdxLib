// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CLight
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Animator;
using MdxLib.Animator.Animatable;

namespace MdxLib.Model
{
  public sealed class CLight : CNode<CLight>
  {
    private ELightType _Type;
    private CAnimator<float> _AttenuationStart;
    private CAnimator<float> _AttenuationEnd;
    private CAnimator<MdxLib.Primitives.CVector3> _Color;
    private CAnimator<float> _Intensity;
    private CAnimator<MdxLib.Primitives.CVector3> _AmbientColor;
    private CAnimator<float> _AmbientIntensity;
    private CAnimator<float> _Visibility;

    public CLight(CModel Model)
      : base(Model)
    {
    }

    public override string ToString() => "Light #" + (object) this.ObjectId;

    public override int NodeId => this.Model.GetLightNodeId(this);

    public ELightType Type
    {
      get => this._Type;
      set
      {
        this.AddSetObjectFieldCommand<ELightType>("_Type", value);
        this._Type = value;
      }
    }

    public CAnimator<float> AttenuationStart => this._AttenuationStart ?? (this._AttenuationStart = new CAnimator<float>(this.Model, (CAnimatable<float>) new CFloat(0.0f)));

    public CAnimator<float> AttenuationEnd => this._AttenuationEnd ?? (this._AttenuationEnd = new CAnimator<float>(this.Model, (CAnimatable<float>) new CFloat(0.0f)));

    public CAnimator<MdxLib.Primitives.CVector3> Color => this._Color ?? (this._Color = new CAnimator<MdxLib.Primitives.CVector3>(this.Model, (CAnimatable<MdxLib.Primitives.CVector3>) new MdxLib.Animator.Animatable.CVector3(CConstants.DefaultColor)));

    public CAnimator<float> Intensity => this._Intensity ?? (this._Intensity = new CAnimator<float>(this.Model, (CAnimatable<float>) new CFloat(0.0f)));

    public CAnimator<MdxLib.Primitives.CVector3> AmbientColor => this._AmbientColor ?? (this._AmbientColor = new CAnimator<MdxLib.Primitives.CVector3>(this.Model, (CAnimatable<MdxLib.Primitives.CVector3>) new MdxLib.Animator.Animatable.CVector3(CConstants.DefaultColor)));

    public CAnimator<float> AmbientIntensity => this._AmbientIntensity ?? (this._AmbientIntensity = new CAnimator<float>(this.Model, (CAnimatable<float>) new CFloat(0.0f)));

    public CAnimator<float> Visibility => this._Visibility ?? (this._Visibility = new CAnimator<float>(this.Model, (CAnimatable<float>) new CFloat(1f)));
  }
}
