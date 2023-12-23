// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CObjectContainer`1
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Command;
using MdxLib.Command.ObjectContainer;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MdxLib.Model
{
  public sealed class CObjectContainer<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
    where T : CObject<T>
  {
    private CModel _Model;
    private List<T> ObjectList;

    internal CObjectContainer(CModel Model)
    {
      this._Model = Model;
      this.ObjectList = new List<T>();
    }

    public void Clear()
    {
      if (this.ObjectList.Count <= 0)
        return;
      LinkedList<CDetacher> DetacherList = new LinkedList<CDetacher>();
      this.BuildDetacherList((ICollection<CDetacher>) DetacherList);
      if (this.CanAddCommand)
      {
        ICommand Command = (ICommand) new CClear<T>(this, (IEnumerable<CDetacher>) DetacherList);
        Command.Do();
        this.AddCommand(Command);
      }
      else
      {
        CDetacher.DetachAllDetachers((IEnumerable<CDetacher>) DetacherList);
        foreach (T obj in this.ObjectList)
          obj.ObjectContainer = (CObjectContainer<T>) null;
        this.ObjectList.Clear();
      }
    }

    public void Add(T Object)
    {
      if ((object) Object == null)
        return;
      if (Object.Model != this._Model)
        throw new InvalidOperationException("The object belongs to another model!");
      if (Object.ObjectContainer != null)
        throw new InvalidOperationException("The object is already in a container!");
      if (this.CanAddCommand)
      {
        ICommand Command = (ICommand) new CAdd<T>(this, Object);
        Command.Do();
        this.AddCommand(Command);
      }
      else
      {
        this.ObjectList.Add(Object);
        Object.ObjectContainer = this;
      }
    }

    public void Insert(int Index, T Object)
    {
      if ((object) Object == null)
        return;
      if (Object.Model != this._Model)
        throw new InvalidOperationException("The object belongs to another model!");
      if (Object.ObjectContainer != null)
        throw new InvalidOperationException("The object is already in a container!");
      if (Index < 0 || Index > this.ObjectList.Count)
        return;
      if (this.CanAddCommand)
      {
        ICommand Command = (ICommand) new CInsert<T>(this, Index, Object);
        Command.Do();
        this.AddCommand(Command);
      }
      else
      {
        this.ObjectList.Insert(Index, Object);
        Object.ObjectContainer = this;
      }
    }

    public void Set(int Index, T Object)
    {
      if ((object) Object == null)
        return;
      if (Object.Model != this._Model)
        throw new InvalidOperationException("The object belongs to another model!");
      if (Object.ObjectContainer != null)
        throw new InvalidOperationException("The object is already in a container!");
      if (!this.ContainsIndex(Index))
        return;
      T obj = this.ObjectList[Index];
      LinkedList<CDetacher> DetacherList = new LinkedList<CDetacher>();
      obj.BuildDetacherList((ICollection<CDetacher>) DetacherList);
      if (this.CanAddCommand)
      {
        ICommand Command = (ICommand) new CSet<T>(this, Index, Object, (IEnumerable<CDetacher>) DetacherList);
        Command.Do();
        this.AddCommand(Command);
      }
      else
      {
        CDetacher.DetachAllDetachers((IEnumerable<CDetacher>) DetacherList);
        obj.ObjectContainer = (CObjectContainer<T>) null;
        this.ObjectList[Index] = Object;
        Object.ObjectContainer = this;
      }
    }

    public bool Remove(T Object)
    {
      if ((object) Object == null)
        return false;
      int num = this.IndexOf(Object);
      if (num == -1)
        return false;
      LinkedList<CDetacher> DetacherList = new LinkedList<CDetacher>();
      Object.BuildDetacherList((ICollection<CDetacher>) DetacherList);
      if (this.CanAddCommand)
      {
        ICommand Command = (ICommand) new CRemoveAt<T>(this, num, (IEnumerable<CDetacher>) DetacherList);
        Command.Do();
        this.AddCommand(Command);
      }
      else
      {
        CDetacher.DetachAllDetachers((IEnumerable<CDetacher>) DetacherList);
        Object.ObjectContainer = (CObjectContainer<T>) null;
        this.ObjectList.RemoveAt(num);
      }
      return true;
    }

    public void RemoveAt(int Index)
    {
      T obj = this.Get(Index);
      if ((object) obj == null)
        return;
      LinkedList<CDetacher> DetacherList = new LinkedList<CDetacher>();
      obj.BuildDetacherList((ICollection<CDetacher>) DetacherList);
      if (this.CanAddCommand)
      {
        ICommand Command = (ICommand) new CRemoveAt<T>(this, Index, (IEnumerable<CDetacher>) DetacherList);
        Command.Do();
        this.AddCommand(Command);
      }
      else
      {
        CDetacher.DetachAllDetachers((IEnumerable<CDetacher>) DetacherList);
        obj.ObjectContainer = (CObjectContainer<T>) null;
        this.ObjectList.RemoveAt(Index);
      }
    }

    public T Get(int Index) => !this.ContainsIndex(Index) ? default (T) : this.ObjectList[Index];

    public int IndexOf(T Object) => this.ObjectList.IndexOf(Object);

    public bool Contains(T Object) => (object) Object != null && this.ObjectList.Contains(Object);

    public bool ContainsIndex(int Index) => Index >= 0 && Index < this.ObjectList.Count;

    public void CopyTo(T[] Array, int Index) => this.ObjectList.CopyTo(Array, Index);

    public IEnumerator<T> GetEnumerator() => (IEnumerator<T>) this.ObjectList.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.ObjectList.GetEnumerator();

    internal void BuildDetacherList(ICollection<CDetacher> DetacherList)
    {
      foreach (T obj in this.ObjectList)
        obj.BuildDetacherList(DetacherList);
    }

    internal void AddCommand(ICommand Command)
    {
      if (this._Model.CommandGroup == null)
        return;
      this._Model.CommandGroup.Add(Command);
    }

    public CModel Model => this._Model;

    public bool HasReferences
    {
      get
      {
        foreach (T obj in this.ObjectList)
        {
          if (obj.HasReferences)
            return true;
        }
        return false;
      }
    }

    public int Count => this.ObjectList.Count;

    public bool IsReadOnly => false;

    public T this[int Index]
    {
      get => this.Get(Index);
      set
      {
        if ((object) value != null)
          this.Set(Index, value);
        else
          this.RemoveAt(Index);
      }
    }

    internal bool CanAddCommand => this._Model.CommandGroup != null;

    internal List<T> InternalObjectList
    {
      get => this.ObjectList;
      set => this.ObjectList = value;
    }
  }
}
