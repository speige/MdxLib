// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CGeoset
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Primitives;
using System.Collections.Generic;

namespace MdxLib.Model
{
  public sealed class CGeoset : CObject<CGeoset>
  {
    private int _SelectionGroup;
    private bool _Unselectable;
    private CExtent _Extent = CConstants.DefaultExtent;
    private CObjectReference<CMaterial> _Material;
    private CObjectContainer<CGeosetVertex> _Vertices;
    private CObjectContainer<CGeosetFace> _Faces;
    private CObjectContainer<CGeosetGroup> _Groups;
    private CObjectContainer<CGeosetExtent> _Extents;

    public CGeoset(CModel Model)
      : base(Model)
    {
    }

    internal override void BuildDetacherList(ICollection<CDetacher> DetacherList)
    {
      base.BuildDetacherList(DetacherList);
      if (this._Vertices != null)
        this._Vertices.BuildDetacherList(DetacherList);
      if (this._Faces != null)
        this._Faces.BuildDetacherList(DetacherList);
      if (this._Groups != null)
        this._Groups.BuildDetacherList(DetacherList);
      if (this._Extents == null)
        return;
      this._Extents.BuildDetacherList(DetacherList);
    }

    public override string ToString() => "Geoset #" + (object) this.ObjectId;

    public override bool HasReferences => this._Vertices != null && this._Vertices.HasReferences || this._Faces != null && this._Faces.HasReferences || this._Groups != null && this._Groups.HasReferences || this._Extents != null && this._Extents.HasReferences || base.HasReferences;

    public int SelectionGroup
    {
      get => this._SelectionGroup;
      set
      {
        this.AddSetObjectFieldCommand<int>("_SelectionGroup", value);
        this._SelectionGroup = value;
      }
    }

    public bool Unselectable
    {
      get => this._Unselectable;
      set
      {
        this.AddSetObjectFieldCommand<bool>("_Unselectable", value);
        this._Unselectable = value;
      }
    }

    public CExtent Extent
    {
      get => this._Extent;
      set
      {
        this.AddSetObjectFieldCommand<CExtent>("_Extent", value);
        this._Extent = value;
      }
    }

    public CObjectReference<CMaterial> Material => this._Material ?? (this._Material = new CObjectReference<CMaterial>(this.Model));

    public bool HasVertices => this._Vertices != null && this._Vertices.Count > 0;

    public bool HasFaces => this._Faces != null && this._Faces.Count > 0;

    public bool HasGroups => this._Groups != null && this._Groups.Count > 0;

    public bool HasExtents => this._Extents != null && this._Extents.Count > 0;

    public CObjectContainer<CGeosetVertex> Vertices => this._Vertices ?? (this._Vertices = new CObjectContainer<CGeosetVertex>(this.Model));

    public CObjectContainer<CGeosetFace> Faces => this._Faces ?? (this._Faces = new CObjectContainer<CGeosetFace>(this.Model));

    public CObjectContainer<CGeosetGroup> Groups => this._Groups ?? (this._Groups = new CObjectContainer<CGeosetGroup>(this.Model));

    public CObjectContainer<CGeosetExtent> Extents => this._Extents ?? (this._Extents = new CObjectContainer<CGeosetExtent>(this.Model));
  }
}
