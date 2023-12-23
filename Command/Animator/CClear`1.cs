// Decompiled with JetBrains decompiler
// Type: MdxLib.Command.Animator.CClear`1
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Animator;
using System.Collections.Generic;

namespace MdxLib.Command.Animator
{
  internal sealed class CClear<T> : ICommand where T : new()
  {
    private CAnimator<T> CurrentAnimator;
    private List<CAnimatorNode<T>> OldNodeList;
    private List<CAnimatorNode<T>> NewNodeList;

    public CClear(CAnimator<T> Animator)
    {
      this.CurrentAnimator = Animator;
      this.OldNodeList = this.CurrentAnimator.InternalNodeList;
      this.NewNodeList = new List<CAnimatorNode<T>>();
    }

    public void Do() => this.CurrentAnimator.InternalNodeList = this.NewNodeList;

    public void Undo() => this.CurrentAnimator.InternalNodeList = this.OldNodeList;
  }
}
