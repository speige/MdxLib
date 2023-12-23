// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CMaterial
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System.Collections.Generic;

namespace MdxLib.Model
{
  public sealed class CMaterial : CObject<CMaterial>
  {
    private int _PriorityPlane;
    private bool _ConstantColor;
    private bool _FullResolution;
    private bool _SortPrimitivesFarZ;
    private bool _SortPrimitivesNearZ;
    private CObjectContainer<CMaterialLayer> _Layers;

    public CMaterial(CModel Model)
      : base(Model)
    {
    }

    internal override void BuildDetacherList(ICollection<CDetacher> DetacherList)
    {
      base.BuildDetacherList(DetacherList);
      if (this._Layers == null)
        return;
      this._Layers.BuildDetacherList(DetacherList);
    }

    public override string ToString() => "Material #" + (object) this.ObjectId;

    public override bool HasReferences => this._Layers != null && this._Layers.HasReferences || base.HasReferences;

    public int PriorityPlane
    {
      get => this._PriorityPlane;
      set
      {
        this.AddSetObjectFieldCommand<int>("_PriorityPlane", value);
        this._PriorityPlane = value;
      }
    }

    public bool ConstantColor
    {
      get => this._ConstantColor;
      set
      {
        this.AddSetObjectFieldCommand<bool>("_ConstantColor", value);
        this._ConstantColor = value;
      }
    }

    public bool FullResolution
    {
      get => this._FullResolution;
      set
      {
        this.AddSetObjectFieldCommand<bool>("_FullResolution", value);
        this._FullResolution = value;
      }
    }

    public bool SortPrimitivesFarZ
    {
      get => this._SortPrimitivesFarZ;
      set
      {
        this.AddSetObjectFieldCommand<bool>("_SortPrimitivesFarZ", value);
        this._SortPrimitivesFarZ = value;
      }
    }

    public bool SortPrimitivesNearZ
    {
      get => this._SortPrimitivesNearZ;
      set
      {
        this.AddSetObjectFieldCommand<bool>("_SortPrimitivesNearZ", value);
        this._SortPrimitivesNearZ = value;
      }
    }

    public bool HasLayers => this._Layers != null && this._Layers.Count > 0;

    public CObjectContainer<CMaterialLayer> Layers => this._Layers ?? (this._Layers = new CObjectContainer<CMaterialLayer>(this.Model));
  }
}
