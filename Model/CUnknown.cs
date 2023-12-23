// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CUnknown
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System.Collections.Generic;

namespace MdxLib.Model
{
  public abstract class CUnknown : IUnknown
  {
    private object _Tag;
    private HashSet<object> _ObjectReferenceSet;
    private HashSet<object> _NodeReferenceSet;

    public object Tag
    {
      get => this._Tag;
      set => this._Tag = value;
    }

    internal virtual void BuildDetacherList(ICollection<CDetacher> DetacherList)
    {
      if (this._ObjectReferenceSet != null)
        this.BuildObjectDetacherList(DetacherList);
      if (this._NodeReferenceSet == null)
        return;
      this.BuildNodeDetacherList(DetacherList);
    }

    internal virtual void BuildObjectDetacherList(ICollection<CDetacher> DetacherList)
    {
    }

    internal virtual void BuildNodeDetacherList(ICollection<CDetacher> DetacherList)
    {
    }

    internal HashSet<object> ObjectReferenceSet => this._ObjectReferenceSet ?? (this._ObjectReferenceSet = new HashSet<object>());

    internal HashSet<object> NodeReferenceSet => this._NodeReferenceSet ?? (this._NodeReferenceSet = new HashSet<object>());
  }
}
