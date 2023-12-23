// Decompiled with JetBrains decompiler
// Type: MdxLib.Command.CCommandGroup
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System.Collections.Generic;

namespace MdxLib.Command
{
  internal sealed class CCommandGroup : ICommand
  {
    private LinkedList<ICommand> CommandList;

    public CCommandGroup() => this.CommandList = new LinkedList<ICommand>();

    public void Add(ICommand Command) => this.CommandList.AddLast(Command);

    public void Do()
    {
      for (LinkedListNode<ICommand> linkedListNode = this.CommandList.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
        linkedListNode.Value.Do();
    }

    public void Undo()
    {
      for (LinkedListNode<ICommand> linkedListNode = this.CommandList.Last; linkedListNode != null; linkedListNode = linkedListNode.Previous)
        linkedListNode.Value.Undo();
    }
  }
}
