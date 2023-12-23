// Decompiled with JetBrains decompiler
// Type: MdxLib.Command.ObjectContainer.CClear`1
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using System.Collections.Generic;

namespace MdxLib.Command.ObjectContainer
{
  internal sealed class CClear<T> : ICommand where T : CObject<T>
  {
    private CObjectContainer<T> CurrentContainer;
    private List<T> OldObjectList;
    private List<T> NewObjectList;
    private IEnumerable<CDetacher> CurrentDetacherList;

    public CClear(CObjectContainer<T> Container, IEnumerable<CDetacher> DetacherList)
    {
      this.CurrentContainer = Container;
      this.OldObjectList = this.CurrentContainer.InternalObjectList;
      this.NewObjectList = new List<T>();
      this.CurrentDetacherList = DetacherList;
    }

    public void Do()
    {
      CDetacher.DetachAllDetachers(this.CurrentDetacherList);
      foreach (T oldObject in this.OldObjectList)
        oldObject.ObjectContainer = (CObjectContainer<T>) null;
      this.CurrentContainer.InternalObjectList = this.NewObjectList;
    }

    public void Undo()
    {
      this.CurrentContainer.InternalObjectList = this.OldObjectList;
      foreach (T oldObject in this.OldObjectList)
        oldObject.ObjectContainer = this.CurrentContainer;
      CDetacher.AttachAllDetachers(this.CurrentDetacherList);
    }
  }
}
