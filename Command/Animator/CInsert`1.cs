// Decompiled with JetBrains decompiler
// Type: MdxLib.Command.Animator.CInsert`1
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Animator;

namespace MdxLib.Command.Animator
{
  internal sealed class CInsert<T> : ICommand where T : new()
  {
    private CAnimator<T> CurrentAnimator;
    private int CurrentIndex = -1;
    private CAnimatorNode<T> NewNode;

    public CInsert(CAnimator<T> Animator, int Index, CAnimatorNode<T> Node)
    {
      this.CurrentAnimator = Animator;
      this.CurrentIndex = Index;
      this.NewNode = Node;
    }

    public void Do() => this.CurrentAnimator.InternalNodeList.Insert(this.CurrentIndex, this.NewNode);

    public void Undo() => this.CurrentAnimator.InternalNodeList.RemoveAt(this.CurrentIndex);
  }
}
