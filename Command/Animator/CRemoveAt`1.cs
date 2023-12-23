﻿// Decompiled with JetBrains decompiler
// Type: MdxLib.Command.Animator.CRemoveAt`1
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Animator;

namespace MdxLib.Command.Animator
{
  internal sealed class CRemoveAt<T> : ICommand where T : new()
  {
    private CAnimator<T> CurrentAnimator;
    private int CurrentIndex = -1;
    private CAnimatorNode<T> OldNode;

    public CRemoveAt(CAnimator<T> Animator, int Index)
    {
      this.CurrentAnimator = Animator;
      this.CurrentIndex = Index;
      this.OldNode = this.CurrentAnimator.InternalNodeList[this.CurrentIndex];
    }

    public void Do() => this.CurrentAnimator.InternalNodeList.RemoveAt(this.CurrentIndex);

    public void Undo() => this.CurrentAnimator.InternalNodeList.Insert(this.CurrentIndex, this.OldNode);
  }
}
