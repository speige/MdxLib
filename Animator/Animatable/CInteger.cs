// Decompiled with JetBrains decompiler
// Type: MdxLib.Animator.Animatable.CInteger
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

namespace MdxLib.Animator.Animatable
{
  internal sealed class CInteger : CAnimatable<int>
  {
    public CInteger(int DefaultValue)
      : base(DefaultValue)
    {
    }

    public override int InterpolateNone(
      CTime Time,
      CAnimatorNode<int> Node1,
      CAnimatorNode<int> Node2)
    {
      return Node1.Value;
    }

    public override int InterpolateLinear(
      CTime Time,
      CAnimatorNode<int> Node1,
      CAnimatorNode<int> Node2)
    {
      return Node1.Value;
    }

    public override int InterpolateBezier(
      CTime Time,
      CAnimatorNode<int> Node1,
      CAnimatorNode<int> Node2)
    {
      return Node1.Value;
    }

    public override int InterpolateHermite(
      CTime Time,
      CAnimatorNode<int> Node1,
      CAnimatorNode<int> Node2)
    {
      return Node1.Value;
    }
  }
}
