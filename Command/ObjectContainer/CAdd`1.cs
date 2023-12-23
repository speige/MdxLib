// Decompiled with JetBrains decompiler
// Type: MdxLib.Command.ObjectContainer.CAdd`1
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;

namespace MdxLib.Command.ObjectContainer
{
  internal sealed class CAdd<T> : ICommand where T : CObject<T>
  {
    private CObjectContainer<T> CurrentContainer;
    private T NewObject = default (T);

    public CAdd(CObjectContainer<T> Container, T Object)
    {
      this.CurrentContainer = Container;
      this.NewObject = Object;
    }

    public void Do()
    {
      this.CurrentContainer.InternalObjectList.Add(this.NewObject);
      this.NewObject.ObjectContainer = this.CurrentContainer;
    }

    public void Undo()
    {
      this.NewObject.ObjectContainer = (CObjectContainer<T>) null;
      this.CurrentContainer.InternalObjectList.Remove(this.NewObject);
    }
  }
}
