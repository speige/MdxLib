// Decompiled with JetBrains decompiler
// Type: MdxLib.Command.ObjectContainer.CRemoveAt`1
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using System.Collections.Generic;

namespace MdxLib.Command.ObjectContainer
{
  internal sealed class CRemoveAt<T> : ICommand where T : CObject<T>
  {
    private CObjectContainer<T> CurrentContainer;
    private int CurrentIndex = -1;
    private T OldObject = default (T);
    private IEnumerable<CDetacher> CurrentDetacherList;

    public CRemoveAt(CObjectContainer<T> Container, int Index, IEnumerable<CDetacher> DetacherList)
    {
      this.CurrentContainer = Container;
      this.CurrentIndex = Index;
      this.OldObject = this.CurrentContainer.InternalObjectList[this.CurrentIndex];
      this.CurrentDetacherList = DetacherList;
    }

    public void Do()
    {
      CDetacher.DetachAllDetachers(this.CurrentDetacherList);
      this.OldObject.ObjectContainer = (CObjectContainer<T>) null;
      this.CurrentContainer.InternalObjectList.RemoveAt(this.CurrentIndex);
    }

    public void Undo()
    {
      this.CurrentContainer.InternalObjectList.Insert(this.CurrentIndex, this.OldObject);
      this.OldObject.ObjectContainer = this.CurrentContainer;
      CDetacher.AttachAllDetachers(this.CurrentDetacherList);
    }
  }
}
