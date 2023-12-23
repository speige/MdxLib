// Decompiled with JetBrains decompiler
// Type: MdxLib.Command.Animator.CSet`1
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Animator;

namespace MdxLib.Command.Animator
{
  internal sealed class CSet<T> : ICommand where T : new()
  {
    private CAnimator<T> CurrentAnimator;
    private int CurrentIndex = -1;
    private CAnimatorNode<T> OldNode;
    private CAnimatorNode<T> NewNode;

    public CSet(CAnimator<T> Animator, int Index, CAnimatorNode<T> Node)
    {
      this.CurrentAnimator = Animator;
      this.CurrentIndex = Index;
      this.OldNode = this.CurrentAnimator.InternalNodeList[this.CurrentIndex];
      this.NewNode = Node;
    }

    public void Do() => this.CurrentAnimator.InternalNodeList[this.CurrentIndex] = this.NewNode;

    public void Undo() => this.CurrentAnimator.InternalNodeList[this.CurrentIndex] = this.OldNode;
  }
}
