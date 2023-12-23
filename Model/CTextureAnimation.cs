// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CTextureAnimation
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Animator;
using MdxLib.Animator.Animatable;

namespace MdxLib.Model
{
  public sealed class CTextureAnimation : CObject<CTextureAnimation>
  {
    private CAnimator<MdxLib.Primitives.CVector3> _Translation;
    private CAnimator<MdxLib.Primitives.CVector4> _Rotation;
    private CAnimator<MdxLib.Primitives.CVector3> _Scaling;

    public CTextureAnimation(CModel Model)
      : base(Model)
    {
    }

    public override string ToString() => "Texture Animation #" + (object) this.ObjectId;

    public CAnimator<MdxLib.Primitives.CVector3> Translation => this._Translation ?? (this._Translation = new CAnimator<MdxLib.Primitives.CVector3>(this.Model, (CAnimatable<MdxLib.Primitives.CVector3>) new MdxLib.Animator.Animatable.CVector3(CConstants.DefaultTranslation)));

    public CAnimator<MdxLib.Primitives.CVector4> Rotation => this._Rotation ?? (this._Rotation = new CAnimator<MdxLib.Primitives.CVector4>(this.Model, (CAnimatable<MdxLib.Primitives.CVector4>) new CQuaternion(CConstants.DefaultRotation)));

    public CAnimator<MdxLib.Primitives.CVector3> Scaling => this._Scaling ?? (this._Scaling = new CAnimator<MdxLib.Primitives.CVector3>(this.Model, (CAnimatable<MdxLib.Primitives.CVector3>) new MdxLib.Animator.Animatable.CVector3(CConstants.DefaultScaling)));
  }
}
