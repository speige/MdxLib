// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CGeosetGroup
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System.Collections.Generic;

namespace MdxLib.Model
{
  public sealed class CGeosetGroup : CObject<CGeosetGroup>
  {
    private CObjectContainer<CGeosetGroupNode> _Nodes;

    public CGeosetGroup(CModel Model)
      : base(Model)
    {
    }

    internal override void BuildDetacherList(ICollection<CDetacher> DetacherList)
    {
      base.BuildDetacherList(DetacherList);
      if (this._Nodes == null)
        return;
      this._Nodes.BuildDetacherList(DetacherList);
    }

    public override string ToString() => "Geoset Group #" + (object) this.ObjectId;

    public override bool HasReferences => this._Nodes != null && this._Nodes.HasReferences || base.HasReferences;

    public bool HasNodes => this._Nodes != null && this._Nodes.Count > 0;

    public CObjectContainer<CGeosetGroupNode> Nodes => this._Nodes ?? (this._Nodes = new CObjectContainer<CGeosetGroupNode>(this.Model));
  }
}
