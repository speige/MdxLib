// Decompiled with JetBrains decompiler
// Type: MdxLib.Command.ObjectContainer.CInsert`1
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;

namespace MdxLib.Command.ObjectContainer
{
  internal sealed class CInsert<T> : ICommand where T : CObject<T>
  {
    private CObjectContainer<T> CurrentContainer;
    private int CurrentIndex = -1;
    private T NewObject = default (T);

    public CInsert(CObjectContainer<T> Container, int Index, T Object)
    {
      this.CurrentContainer = Container;
      this.CurrentIndex = Index;
      this.NewObject = Object;
    }

    public void Do()
    {
      this.CurrentContainer.InternalObjectList.Insert(this.CurrentIndex, this.NewObject);
      this.NewObject.ObjectContainer = this.CurrentContainer;
    }

    public void Undo()
    {
      this.NewObject.ObjectContainer = (CObjectContainer<T>) null;
      this.CurrentContainer.InternalObjectList.RemoveAt(this.CurrentIndex);
    }
  }
}
