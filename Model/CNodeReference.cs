// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CNodeReference
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Command;
using System;

namespace MdxLib.Model
{
  public sealed class CNodeReference
  {
    private CModel _Model;
    private INode _Node;

    internal CNodeReference(CModel Model) => this._Model = Model;

    public void Attach(INode Node)
    {
      this.Detach();
      if (Node == null)
        return;
      if (Node.Model != this._Model)
        throw new InvalidOperationException("The node belongs to another model!");
      if (!(Node is CUnknown cunknown))
        return;
      if (this.CanAddCommand)
      {
        ICommand Command = (ICommand) new CAttachNode(this, Node);
        Command.Do();
        this.AddCommand(Command);
      }
      else
      {
        cunknown.NodeReferenceSet.Add((object) this);
        this._Node = Node;
      }
    }

    public void Detach()
    {
      if (this._Node == null || !(this._Node is CUnknown node))
        return;
      if (this.CanAddCommand)
      {
        ICommand Command = (ICommand) new CDetachNode(this, this._Node);
        Command.Do();
        this.AddCommand(Command);
      }
      else
      {
        node.NodeReferenceSet.Remove((object) this);
        this._Node = (INode) null;
      }
    }

    internal void ForceAttach(INode Node)
    {
      this.ForceDetach();
      if (!(Node is CUnknown cunknown))
        return;
      cunknown.NodeReferenceSet.Add((object) this);
      this._Node = Node;
    }

    internal void ForceDetach()
    {
      if (!(this._Node is CUnknown node))
        return;
      node.NodeReferenceSet.Remove((object) this);
      this._Node = (INode) null;
    }

    internal void AddCommand(ICommand Command)
    {
      if (this._Model.CommandGroup == null)
        return;
      this._Model.CommandGroup.Add(Command);
    }

    public CModel Model => this._Model;

    public INode Node => this._Node;

    public int NodeId => this._Node == null ? -1 : this._Node.NodeId;

    public int ObjectId => this._Node == null ? -1 : this._Node.ObjectId;

    internal bool CanAddCommand => this._Model.CommandGroup != null;

    internal INode InternalNode
    {
      get => this._Node;
      set => this._Node = value;
    }
  }
}
