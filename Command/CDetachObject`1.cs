// Decompiled with JetBrains decompiler
// Type: MdxLib.Command.CDetachObject`1
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;

namespace MdxLib.Command
{
  internal sealed class CDetachObject<T> : ICommand where T : CObject<T>
  {
    private CObjectReference<T> CurrentObjectReference;
    private CUnknown Unknown;
    private T OldObject = default (T);

    public CDetachObject(CObjectReference<T> ObjectReference, T Object)
    {
      this.CurrentObjectReference = ObjectReference;
      this.Unknown = (CUnknown) Object;
      this.OldObject = Object;
    }

    public void Do()
    {
      this.Unknown.ObjectReferenceSet.Remove((object) this.CurrentObjectReference);
      this.CurrentObjectReference.InternalObject = default (T);
    }

    public void Undo()
    {
      this.Unknown.ObjectReferenceSet.Add((object) this.CurrentObjectReference);
      this.CurrentObjectReference.InternalObject = this.OldObject;
    }
  }
}
