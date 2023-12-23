// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CCamera
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Animator;
using MdxLib.Animator.Animatable;

namespace MdxLib.Model
{
  public sealed class CCamera : CObject<CCamera>
  {
    private string _Name = "";
    private float _FieldOfView = 0.7853982f;
    private float _NearDistance = 10f;
    private float _FarDistance = 1000f;
    private MdxLib.Primitives.CVector3 _Position = CConstants.DefaultVector3;
    private MdxLib.Primitives.CVector3 _TargetPosition = CConstants.DefaultVector3;
    private CAnimator<float> _Rotation;
    private CAnimator<MdxLib.Primitives.CVector3> _Translation;
    private CAnimator<MdxLib.Primitives.CVector3> _TargetTranslation;

    public CCamera(CModel Model)
      : base(Model)
    {
    }

    public override string ToString() => "Camera #" + (object) this.ObjectId;

    public string Name
    {
      get => this._Name;
      set
      {
        this.AddSetObjectFieldCommand<string>("_Name", value);
        this._Name = value;
      }
    }

    public float FieldOfView
    {
      get => this._FieldOfView;
      set
      {
        this.AddSetObjectFieldCommand<float>("_FieldOfView", value);
        this._FieldOfView = value;
      }
    }

    public float NearDistance
    {
      get => this._NearDistance;
      set
      {
        this.AddSetObjectFieldCommand<float>("_NearDistance", value);
        this._NearDistance = value;
      }
    }

    public float FarDistance
    {
      get => this._FarDistance;
      set
      {
        this.AddSetObjectFieldCommand<float>("_FarDistance", value);
        this._FarDistance = value;
      }
    }

    public MdxLib.Primitives.CVector3 Position
    {
      get => this._Position;
      set
      {
        this.AddSetObjectFieldCommand<MdxLib.Primitives.CVector3>("_Position", value);
        this._Position = value;
      }
    }

    public MdxLib.Primitives.CVector3 TargetPosition
    {
      get => this._TargetPosition;
      set
      {
        this.AddSetObjectFieldCommand<MdxLib.Primitives.CVector3>("_TargetPosition", value);
        this._TargetPosition = value;
      }
    }

    public CAnimator<float> Rotation => this._Rotation ?? (this._Rotation = new CAnimator<float>(this.Model, (CAnimatable<float>) new CFloat(0.0f)));

    public CAnimator<MdxLib.Primitives.CVector3> Translation => this._Translation ?? (this._Translation = new CAnimator<MdxLib.Primitives.CVector3>(this.Model, (CAnimatable<MdxLib.Primitives.CVector3>) new MdxLib.Animator.Animatable.CVector3(CConstants.DefaultTranslation)));

    public CAnimator<MdxLib.Primitives.CVector3> TargetTranslation => this._TargetTranslation ?? (this._TargetTranslation = new CAnimator<MdxLib.Primitives.CVector3>(this.Model, (CAnimatable<MdxLib.Primitives.CVector3>) new MdxLib.Animator.Animatable.CVector3(CConstants.DefaultTranslation)));
  }
}
