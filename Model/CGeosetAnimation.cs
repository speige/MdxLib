// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CGeosetAnimation
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Animator;
using MdxLib.Animator.Animatable;

namespace MdxLib.Model
{
  public sealed class CGeosetAnimation : CObject<CGeosetAnimation>
  {
    private bool _UseColor;
    private bool _DropShadow;
    private CAnimator<MdxLib.Primitives.CVector3> _Color;
    private CAnimator<float> _Alpha;
    private CObjectReference<CGeoset> _Geoset;

    public CGeosetAnimation(CModel Model)
      : base(Model)
    {
    }

    public override string ToString() => "Geoset Animation #" + (object) this.ObjectId;

    public bool UseColor
    {
      get => this._UseColor;
      set
      {
        this.AddSetObjectFieldCommand<bool>("_UseColor", value);
        this._UseColor = value;
      }
    }

    public bool DropShadow
    {
      get => this._DropShadow;
      set
      {
        this.AddSetObjectFieldCommand<bool>("_DropShadow", value);
        this._DropShadow = value;
      }
    }

    public CAnimator<MdxLib.Primitives.CVector3> Color => this._Color ?? (this._Color = new CAnimator<MdxLib.Primitives.CVector3>(this.Model, (CAnimatable<MdxLib.Primitives.CVector3>) new MdxLib.Animator.Animatable.CVector3(CConstants.DefaultColor)));

    public CAnimator<float> Alpha => this._Alpha ?? (this._Alpha = new CAnimator<float>(this.Model, (CAnimatable<float>) new CFloat(1f)));

    public CObjectReference<CGeoset> Geoset => this._Geoset ?? (this._Geoset = new CObjectReference<CGeoset>(this.Model));
  }
}
