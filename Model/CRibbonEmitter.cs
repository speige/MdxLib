// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CRibbonEmitter
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Animator;
using MdxLib.Animator.Animatable;

namespace MdxLib.Model
{
  public sealed class CRibbonEmitter : CNode<CRibbonEmitter>
  {
    private int _Rows = 1;
    private int _Columns = 1;
    private int _EmissionRate;
    private float _LifeSpan;
    private float _Gravity = 1f;
    private CAnimator<float> _HeightAbove;
    private CAnimator<float> _HeightBelow;
    private CAnimator<float> _Alpha;
    private CAnimator<MdxLib.Primitives.CVector3> _Color;
    private CAnimator<int> _TextureSlot;
    private CAnimator<float> _Visibility;
    private CObjectReference<CMaterial> _Material;

    public CRibbonEmitter(CModel Model)
      : base(Model)
    {
    }

    public override string ToString() => "Ribbon Emitter #" + (object) this.ObjectId;

    public override int NodeId => this.Model.GetRibbonEmitterNodeId(this);

    public int Rows
    {
      get => this._Rows;
      set
      {
        this.AddSetObjectFieldCommand<int>("_Rows", value);
        this._Rows = value;
      }
    }

    public int Columns
    {
      get => this._Columns;
      set
      {
        this.AddSetObjectFieldCommand<int>("_Columns", value);
        this._Columns = value;
      }
    }

    public int EmissionRate
    {
      get => this._EmissionRate;
      set
      {
        this.AddSetObjectFieldCommand<int>("_EmissionRate", value);
        this._EmissionRate = value;
      }
    }

    public float LifeSpan
    {
      get => this._LifeSpan;
      set
      {
        this.AddSetObjectFieldCommand<float>("_LifeSpan", value);
        this._LifeSpan = value;
      }
    }

    public float Gravity
    {
      get => this._Gravity;
      set
      {
        this.AddSetObjectFieldCommand<float>("_Gravity", value);
        this._Gravity = value;
      }
    }

    public CAnimator<float> HeightAbove => this._HeightAbove ?? (this._HeightAbove = new CAnimator<float>(this.Model, (CAnimatable<float>) new CFloat(0.0f)));

    public CAnimator<float> HeightBelow => this._HeightBelow ?? (this._HeightBelow = new CAnimator<float>(this.Model, (CAnimatable<float>) new CFloat(0.0f)));

    public CAnimator<float> Alpha => this._Alpha ?? (this._Alpha = new CAnimator<float>(this.Model, (CAnimatable<float>) new CFloat(1f)));

    public CAnimator<MdxLib.Primitives.CVector3> Color => this._Color ?? (this._Color = new CAnimator<MdxLib.Primitives.CVector3>(this.Model, (CAnimatable<MdxLib.Primitives.CVector3>) new MdxLib.Animator.Animatable.CVector3(CConstants.DefaultColor)));

    public CAnimator<int> TextureSlot => this._TextureSlot ?? (this._TextureSlot = new CAnimator<int>(this.Model, (CAnimatable<int>) new CInteger(0)));

    public CAnimator<float> Visibility => this._Visibility ?? (this._Visibility = new CAnimator<float>(this.Model, (CAnimatable<float>) new CFloat(1f)));

    public CObjectReference<CMaterial> Material => this._Material ?? (this._Material = new CObjectReference<CMaterial>(this.Model));
  }
}
