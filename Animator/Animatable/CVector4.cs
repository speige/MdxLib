// Decompiled with JetBrains decompiler
// Type: MdxLib.Animator.Animatable.CVector4
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

namespace MdxLib.Animator.Animatable
{
  internal sealed class CVector4 : CAnimatable<MdxLib.Primitives.CVector4>
  {
    public CVector4(MdxLib.Primitives.CVector4 DefaultValue)
      : base(DefaultValue)
    {
    }

    public override MdxLib.Primitives.CVector4 InterpolateNone(
      CTime Time,
      CAnimatorNode<MdxLib.Primitives.CVector4> Node1,
      CAnimatorNode<MdxLib.Primitives.CVector4> Node2)
    {
      return Node1.Value;
    }

    public override MdxLib.Primitives.CVector4 InterpolateLinear(
      CTime Time,
      CAnimatorNode<MdxLib.Primitives.CVector4> Node1,
      CAnimatorNode<MdxLib.Primitives.CVector4> Node2)
    {
      float num1 = (float) (Time.Time - Node1.Time) / (float) (Node2.Time - Node1.Time);
      float num2 = 1f - num1;
      return new MdxLib.Primitives.CVector4((float) ((double) Node1.Value.X * (double) num2 + (double) Node2.Value.X * (double) num1), (float) ((double) Node1.Value.Y * (double) num2 + (double) Node2.Value.Y * (double) num1), (float) ((double) Node1.Value.Z * (double) num2 + (double) Node2.Value.Z * (double) num1), (float) ((double) Node1.Value.W * (double) num2 + (double) Node2.Value.W * (double) num1));
    }

    public override MdxLib.Primitives.CVector4 InterpolateBezier(
      CTime Time,
      CAnimatorNode<MdxLib.Primitives.CVector4> Node1,
      CAnimatorNode<MdxLib.Primitives.CVector4> Node2)
    {
      float num1 = (float) (Time.Time - Node1.Time) / (float) (Node2.Time - Node1.Time);
      float num2 = num1 * num1;
      float num3 = 1f - num1;
      float num4 = num3 * num3;
      float num5 = num4 * num3;
      float num6 = 3f * num1 * num4;
      float num7 = 3f * num2 * num3;
      float num8 = num2 * num1;
      return new MdxLib.Primitives.CVector4((float) ((double) Node1.Value.X * (double) num5 + (double) Node1.OutTangent.X * (double) num6 + (double) Node2.InTangent.X * (double) num7 + (double) Node2.Value.X * (double) num8), (float) ((double) Node1.Value.Y * (double) num5 + (double) Node1.OutTangent.Y * (double) num6 + (double) Node2.InTangent.Y * (double) num7 + (double) Node2.Value.Y * (double) num8), (float) ((double) Node1.Value.Z * (double) num5 + (double) Node1.OutTangent.Z * (double) num6 + (double) Node2.InTangent.Z * (double) num7 + (double) Node2.Value.Z * (double) num8), (float) ((double) Node1.Value.W * (double) num5 + (double) Node1.OutTangent.W * (double) num6 + (double) Node2.InTangent.W * (double) num7 + (double) Node2.Value.W * (double) num8));
    }

    public override MdxLib.Primitives.CVector4 InterpolateHermite(
      CTime Time,
      CAnimatorNode<MdxLib.Primitives.CVector4> Node1,
      CAnimatorNode<MdxLib.Primitives.CVector4> Node2)
    {
      float num1 = (float) (Time.Time - Node1.Time) / (float) (Node2.Time - Node1.Time);
      float num2 = num1 * num1;
      float num3 = (float) ((double) num2 * (2.0 * (double) num1 - 3.0) + 1.0);
      float num4 = num2 * (num1 - 2f) + num1;
      float num5 = num2 * (num1 - 1f);
      float num6 = num2 * (float) (3.0 - 2.0 * (double) num1);
      return new MdxLib.Primitives.CVector4((float) ((double) Node1.Value.X * (double) num3 + (double) Node1.OutTangent.X * (double) num4 + (double) Node2.InTangent.X * (double) num5 + (double) Node2.Value.X * (double) num6), (float) ((double) Node1.Value.Y * (double) num3 + (double) Node1.OutTangent.Y * (double) num4 + (double) Node2.InTangent.Y * (double) num5 + (double) Node2.Value.Y * (double) num6), (float) ((double) Node1.Value.Z * (double) num3 + (double) Node1.OutTangent.Z * (double) num4 + (double) Node2.InTangent.Z * (double) num5 + (double) Node2.Value.Z * (double) num6), (float) ((double) Node1.Value.W * (double) num3 + (double) Node1.OutTangent.W * (double) num4 + (double) Node2.InTangent.W * (double) num5 + (double) Node2.Value.W * (double) num6));
    }
  }
}
