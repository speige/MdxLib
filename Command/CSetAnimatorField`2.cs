// Decompiled with JetBrains decompiler
// Type: MdxLib.Command.CSetAnimatorField`2
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Animator;
using System.Reflection;

namespace MdxLib.Command
{
  internal sealed class CSetAnimatorField<T, T2> : ICommand where T : new()
  {
    private CAnimator<T> CurrentAnimator;
    private T2 OldValue = default (T2);
    private T2 NewValue = default (T2);
    private FieldInfo FieldInfo;

    public CSetAnimatorField(CAnimator<T> Animator, string FieldName, T2 Value)
    {
      this.FieldInfo = typeof (CAnimator<T>).GetField(FieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
      this.CurrentAnimator = Animator;
      this.OldValue = (T2) this.FieldInfo.GetValue((object) this.CurrentAnimator);
      this.NewValue = Value;
    }

    public void Do() => this.FieldInfo.SetValue((object) this.CurrentAnimator, (object) this.NewValue);

    public void Undo() => this.FieldInfo.SetValue((object) this.CurrentAnimator, (object) this.OldValue);
  }
}
