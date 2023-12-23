// Decompiled with JetBrains decompiler
// Type: MdxLib.Command.CAttachNode
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;

namespace MdxLib.Command
{
  internal sealed class CAttachNode : ICommand
  {
    private CNodeReference CurrentNodeReference;
    private CUnknown Unknown;
    private INode NewNode;

    public CAttachNode(CNodeReference NodeReference, INode Node)
    {
      this.CurrentNodeReference = NodeReference;
      this.Unknown = Node as CUnknown;
      this.NewNode = Node;
    }

    public void Do()
    {
      this.Unknown.NodeReferenceSet.Add((object) this.CurrentNodeReference);
      this.CurrentNodeReference.InternalNode = this.NewNode;
    }

    public void Undo()
    {
      this.Unknown.NodeReferenceSet.Remove((object) this.CurrentNodeReference);
      this.CurrentNodeReference.InternalNode = (INode) null;
    }
  }
}
