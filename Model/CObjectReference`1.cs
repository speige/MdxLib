// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CObjectReference`1
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Command;
using System;

namespace MdxLib.Model
{
  public sealed class CObjectReference<T> where T : CObject<T>
  {
    private CModel _Model;
    private T _Object = default (T);

    internal CObjectReference(CModel Model) => this._Model = Model;

    public void Attach(T Object)
    {
      this.Detach();
      if ((object) Object == null)
        return;
      if (Object.Model != this._Model)
        throw new InvalidOperationException("The object belongs to another model!");
      CUnknown cunknown = (CUnknown) Object;
      if (cunknown == null)
        return;
      if (this.CanAddCommand)
      {
        ICommand Command = (ICommand) new CAttachObject<T>(this, Object);
        Command.Do();
        this.AddCommand(Command);
      }
      else
      {
        cunknown.ObjectReferenceSet.Add((object) this);
        this._Object = Object;
      }
    }

    public void Detach()
    {
      if ((object) this._Object == null)
        return;
      CUnknown cunknown = (CUnknown) this._Object;
      if (cunknown == null)
        return;
      if (this.CanAddCommand)
      {
        ICommand Command = (ICommand) new CDetachObject<T>(this, this._Object);
        Command.Do();
        this.AddCommand(Command);
      }
      else
      {
        cunknown.ObjectReferenceSet.Remove((object) this);
        this._Object = default (T);
      }
    }

    internal void ForceAttach(T Object)
    {
      this.ForceDetach();
      CUnknown cunknown = (CUnknown) Object;
      if (cunknown == null)
        return;
      cunknown.ObjectReferenceSet.Add((object) this);
      this._Object = Object;
    }

    internal void ForceDetach()
    {
      CUnknown cunknown = (CUnknown) this._Object;
      if (cunknown == null)
        return;
      cunknown.ObjectReferenceSet.Remove((object) this);
      this._Object = default (T);
    }

    internal void AddCommand(ICommand Command)
    {
      if (this._Model.CommandGroup == null)
        return;
      this._Model.CommandGroup.Add(Command);
    }

    public CModel Model => this._Model;

    public T Object => this._Object;

    public int ObjectId => (object) this._Object == null ? -1 : this._Object.ObjectId;

    internal bool CanAddCommand => this._Model.CommandGroup != null;

    internal T InternalObject
    {
      get => this._Object;
      set => this._Object = value;
    }
  }
}
