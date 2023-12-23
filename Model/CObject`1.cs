// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CObject`1
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Command;
using System.Collections.Generic;

namespace MdxLib.Model
{
  public abstract class CObject<T> : CUnknown, IObject, IUnknown where T : CObject<T>
  {
    private CModel _Model;
    private CObjectContainer<T> _ObjectContainer;

    public CObject(CModel Model) => this._Model = Model;

    internal override void BuildObjectDetacherList(ICollection<CDetacher> DetacherList)
    {
      foreach (object objectReference in this.ObjectReferenceSet)
      {
        if (objectReference is CObjectReference<T> ObjectReference)
          DetacherList.Add((CDetacher) new CObjectDetacher<T>(ObjectReference));
      }
    }

    internal void AddSetObjectFieldCommand<T2>(string FieldName, T2 Value)
    {
      if (this._Model.CommandGroup == null)
        return;
      this._Model.CommandGroup.Add((ICommand) new CSetObjectField<T, T2>((T) this, FieldName, Value));
    }

    public int ObjectId => this._ObjectContainer == null ? -1 : this._ObjectContainer.IndexOf((T) this);

    public CModel Model => this._Model;

    public virtual bool HasReferences => this.ObjectReferenceSet.Count > 0;

    internal CObjectContainer<T> ObjectContainer
    {
      get => this._ObjectContainer;
      set => this._ObjectContainer = value;
    }
  }
}
