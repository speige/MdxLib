// Decompiled with JetBrains decompiler
// Type: MdxLib.Animator.Animatable.CFloat
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

namespace MdxLib.Animator.Animatable
{
  internal sealed class CFloat : CAnimatable<float>
  {
    public CFloat(float DefaultValue)
      : base(DefaultValue)
    {
    }

    public override float InterpolateNone(
      CTime Time,
      CAnimatorNode<float> Node1,
      CAnimatorNode<float> Node2)
    {
      return Node1.Value;
    }

    public override float InterpolateLinear(
      CTime Time,
      CAnimatorNode<float> Node1,
      CAnimatorNode<float> Node2)
    {
      float num1 = (float) (Time.Time - Node1.Time) / (float) (Node2.Time - Node1.Time);
      float num2 = 1f - num1;
      return (float) ((double) Node1.Value * (double) num2 + (double) Node2.Value * (double) num1);
    }

    public override float InterpolateBezier(
      CTime Time,
      CAnimatorNode<float> Node1,
      CAnimatorNode<float> Node2)
    {
      float num1 = (float) (Time.Time - Node1.Time) / (float) (Node2.Time - Node1.Time);
      float num2 = num1 * num1;
      float num3 = 1f - num1;
      float num4 = num3 * num3;
      float num5 = num4 * num3;
      float num6 = 3f * num1 * num4;
      float num7 = 3f * num2 * num3;
      float num8 = num2 * num1;
      return (float) ((double) Node1.Value * (double) num5 + (double) Node1.OutTangent * (double) num6 + (double) Node2.InTangent * (double) num7 + (double) Node2.Value * (double) num8);
    }

    public override float InterpolateHermite(
      CTime Time,
      CAnimatorNode<float> Node1,
      CAnimatorNode<float> Node2)
    {
      float num1 = (float) (Time.Time - Node1.Time) / (float) (Node2.Time - Node1.Time);
      float num2 = num1 * num1;
      float num3 = (float) ((double) num2 * (2.0 * (double) num1 - 3.0) + 1.0);
      float num4 = num2 * (num1 - 2f) + num1;
      float num5 = num2 * (num1 - 1f);
      float num6 = num2 * (float) (3.0 - 2.0 * (double) num1);
      return (float) ((double) Node1.Value * (double) num3 + (double) Node1.OutTangent * (double) num4 + (double) Node2.InTangent * (double) num5 + (double) Node2.Value * (double) num6);
    }
  }
}
