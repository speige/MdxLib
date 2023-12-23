// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CNode`1
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Animator;
using MdxLib.Animator.Animatable;
using MdxLib.Command;
using System.Collections.Generic;

namespace MdxLib.Model
{
  public abstract class CNode<T> : CObject<T>, INode, IObject, IUnknown where T : CNode<T>
  {
    private string _Name = "";
    private bool _DontInheritTranslation;
    private bool _DontInheritRotation;
    private bool _DontInheritScaling;
    private bool _Billboarded;
    private bool _BillboardedLockX;
    private bool _BillboardedLockY;
    private bool _BillboardedLockZ;
    private bool _CameraAnchored;
    private MdxLib.Primitives.CVector3 _PivotPoint = CConstants.DefaultVector3;
    private CAnimator<MdxLib.Primitives.CVector3> _Translation;
    private CAnimator<MdxLib.Primitives.CVector4> _Rotation;
    private CAnimator<MdxLib.Primitives.CVector3> _Scaling;
    private CNodeReference _Parent;

    public CNode(CModel Model)
      : base(Model)
    {
    }

    internal override void BuildNodeDetacherList(ICollection<CDetacher> DetacherList)
    {
      foreach (object nodeReference in this.NodeReferenceSet)
      {
        if (nodeReference is CNodeReference NodeReference)
          DetacherList.Add((CDetacher) new CNodeDetacher(NodeReference));
      }
    }

    internal void AddSetNodeFieldCommand<T2>(string FieldName, T2 Value)
    {
      if (this.Model.CommandGroup == null)
        return;
      this.Model.CommandGroup.Add((ICommand) new CSetNodeField<T, T2>((T) this, FieldName, Value));
    }

    public abstract int NodeId { get; }

    public override bool HasReferences => this.NodeReferenceSet.Count > 0 || base.HasReferences;

    public string Name
    {
      get => this._Name;
      set
      {
        this.AddSetNodeFieldCommand<string>("_Name", value);
        this._Name = value;
      }
    }

    public bool DontInheritTranslation
    {
      get => this._DontInheritTranslation;
      set
      {
        this.AddSetNodeFieldCommand<bool>("_DontInheritTranslation", value);
        this._DontInheritTranslation = value;
      }
    }

    public bool DontInheritRotation
    {
      get => this._DontInheritRotation;
      set
      {
        this.AddSetNodeFieldCommand<bool>("_DontInheritRotation", value);
        this._DontInheritRotation = value;
      }
    }

    public bool DontInheritScaling
    {
      get => this._DontInheritScaling;
      set
      {
        this.AddSetNodeFieldCommand<bool>("_DontInheritScaling", value);
        this._DontInheritScaling = value;
      }
    }

    public bool Billboarded
    {
      get => this._Billboarded;
      set
      {
        this.AddSetNodeFieldCommand<bool>("_Billboarded", value);
        this._Billboarded = value;
      }
    }

    public bool BillboardedLockX
    {
      get => this._BillboardedLockX;
      set
      {
        this.AddSetNodeFieldCommand<bool>("_BillboardedLockX", value);
        this._BillboardedLockX = value;
      }
    }

    public bool BillboardedLockY
    {
      get => this._BillboardedLockY;
      set
      {
        this.AddSetNodeFieldCommand<bool>("_BillboardedLockY", value);
        this._BillboardedLockY = value;
      }
    }

    public bool BillboardedLockZ
    {
      get => this._BillboardedLockZ;
      set
      {
        this.AddSetNodeFieldCommand<bool>("_BillboardedLockZ", value);
        this._BillboardedLockZ = value;
      }
    }

    public bool CameraAnchored
    {
      get => this._CameraAnchored;
      set
      {
        this.AddSetNodeFieldCommand<bool>("_CameraAnchored", value);
        this._CameraAnchored = value;
      }
    }

    public MdxLib.Primitives.CVector3 PivotPoint
    {
      get => this._PivotPoint;
      set
      {
        this.AddSetNodeFieldCommand<MdxLib.Primitives.CVector3>("_PivotPoint", value);
        this._PivotPoint = value;
      }
    }

    public CAnimator<MdxLib.Primitives.CVector3> Translation => this._Translation ?? (this._Translation = new CAnimator<MdxLib.Primitives.CVector3>(this.Model, (CAnimatable<MdxLib.Primitives.CVector3>) new MdxLib.Animator.Animatable.CVector3(CConstants.DefaultTranslation)));

    public CAnimator<MdxLib.Primitives.CVector4> Rotation => this._Rotation ?? (this._Rotation = new CAnimator<MdxLib.Primitives.CVector4>(this.Model, (CAnimatable<MdxLib.Primitives.CVector4>) new CQuaternion(CConstants.DefaultRotation)));

    public CAnimator<MdxLib.Primitives.CVector3> Scaling => this._Scaling ?? (this._Scaling = new CAnimator<MdxLib.Primitives.CVector3>(this.Model, (CAnimatable<MdxLib.Primitives.CVector3>) new MdxLib.Animator.Animatable.CVector3(CConstants.DefaultScaling)));

    public CNodeReference Parent => this._Parent ?? (this._Parent = new CNodeReference(this.Model));
  }
}
