// Decompiled with JetBrains decompiler
// Type: MdxLib.Command.ObjectContainer.CSet`1
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using System.Collections.Generic;

namespace MdxLib.Command.ObjectContainer
{
  internal sealed class CSet<T> : ICommand where T : CObject<T>
  {
    private CObjectContainer<T> CurrentContainer;
    private int CurrentIndex = -1;
    private T OldObject = default (T);
    private T NewObject = default (T);
    private IEnumerable<CDetacher> CurrentDetacherList;

    public CSet(
      CObjectContainer<T> Container,
      int Index,
      T Object,
      IEnumerable<CDetacher> DetacherList)
    {
      this.CurrentContainer = Container;
      this.CurrentIndex = Index;
      this.OldObject = this.CurrentContainer.InternalObjectList[this.CurrentIndex];
      this.NewObject = Object;
      this.CurrentDetacherList = DetacherList;
    }

    public void Do()
    {
      CDetacher.DetachAllDetachers(this.CurrentDetacherList);
      this.OldObject.ObjectContainer = (CObjectContainer<T>) null;
      this.CurrentContainer.InternalObjectList[this.CurrentIndex] = this.NewObject;
      this.NewObject.ObjectContainer = this.CurrentContainer;
    }

    public void Undo()
    {
      this.NewObject.ObjectContainer = (CObjectContainer<T>) null;
      this.CurrentContainer.InternalObjectList[this.CurrentIndex] = this.OldObject;
      this.OldObject.ObjectContainer = this.CurrentContainer;
      CDetacher.AttachAllDetachers(this.CurrentDetacherList);
    }
  }
}
