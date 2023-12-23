// Decompiled with JetBrains decompiler
// Type: MdxLib.Animator.Animatable.CQuaternion
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System;

namespace MdxLib.Animator.Animatable
{
  internal sealed class CQuaternion : CAnimatable<MdxLib.Primitives.CVector4>
  {
    private const float Threshold = 0.95f;

    public CQuaternion(MdxLib.Primitives.CVector4 DefaultValue)
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
      float Factor = (float) (Time.Time - Node1.Time) / (float) (Node2.Time - Node1.Time);
      return this.GetSlerp(Node1.Value, Node2.Value, Factor, true);
    }

    public override MdxLib.Primitives.CVector4 InterpolateBezier(
      CTime Time,
      CAnimatorNode<MdxLib.Primitives.CVector4> Node1,
      CAnimatorNode<MdxLib.Primitives.CVector4> Node2)
    {
      float Factor = (float) (Time.Time - Node1.Time) / (float) (Node2.Time - Node1.Time);
      MdxLib.Primitives.CVector4 slerp1 = this.GetSlerp(Node1.Value, Node1.OutTangent, Factor, false);
      MdxLib.Primitives.CVector4 slerp2 = this.GetSlerp(Node1.OutTangent, Node2.InTangent, Factor, false);
      MdxLib.Primitives.CVector4 slerp3 = this.GetSlerp(Node2.InTangent, Node2.Value, Factor, false);
      return this.GetSlerp(this.GetSlerp(slerp1, slerp2, Factor, false), this.GetSlerp(slerp2, slerp3, Factor, false), Factor, false);
    }

    public override MdxLib.Primitives.CVector4 InterpolateHermite(
      CTime Time,
      CAnimatorNode<MdxLib.Primitives.CVector4> Node1,
      CAnimatorNode<MdxLib.Primitives.CVector4> Node2)
    {
      float Factor = (float) (Time.Time - Node1.Time) / (float) (Node2.Time - Node1.Time);
      return this.GetSlerp(this.GetSlerp(Node1.Value, Node2.Value, Factor, false), this.GetSlerp(Node1.OutTangent, Node2.InTangent, Factor, false), (float) (2.0 * (double) Factor * (1.0 - (double) Factor)), false);
    }

    private float GetDotProduct(MdxLib.Primitives.CVector4 Quaternion1, MdxLib.Primitives.CVector4 Quaternion2) => (float) ((double) Quaternion1.X * (double) Quaternion2.X + (double) Quaternion1.Y * (double) Quaternion2.Y + (double) Quaternion1.Z * (double) Quaternion2.Z + (double) Quaternion1.W * (double) Quaternion2.W);

    private MdxLib.Primitives.CVector4 GetSlerp(
      MdxLib.Primitives.CVector4 Quaternion1,
      MdxLib.Primitives.CVector4 Quaternion2,
      float Factor,
      bool InvertIfNeccessary)
    {
      float num1 = 1f - Factor;
      float d = this.GetDotProduct(Quaternion1, Quaternion2);
      if (InvertIfNeccessary && (double) d < 0.0)
      {
        d = -d;
        Quaternion2 = new MdxLib.Primitives.CVector4(-Quaternion2.X, -Quaternion2.Y, -Quaternion2.Z, -Quaternion2.W);
      }
      if ((double) d > -0.949999988079071 && (double) d < 0.949999988079071)
      {
        float a = (float) Math.Acos((double) d);
        float num2 = 1f / (float) Math.Sin((double) a);
        float num3 = num2 * (float) Math.Sin((double) a * (double) num1);
        float num4 = num2 * (float) Math.Sin((double) a * (double) Factor);
        return new MdxLib.Primitives.CVector4((float) ((double) Quaternion1.X * (double) num3 + (double) Quaternion2.X * (double) num4), (float) ((double) Quaternion1.Y * (double) num3 + (double) Quaternion2.Y * (double) num4), (float) ((double) Quaternion1.Z * (double) num3 + (double) Quaternion2.Z * (double) num4), (float) ((double) Quaternion1.W * (double) num3 + (double) Quaternion2.W * (double) num4));
      }
      float num5 = (float) ((double) Quaternion1.X * (double) num1 + (double) Quaternion2.X * (double) Factor);
      float num6 = (float) ((double) Quaternion1.Y * (double) num1 + (double) Quaternion2.Y * (double) Factor);
      float num7 = (float) ((double) Quaternion1.Z * (double) num1 + (double) Quaternion2.Z * (double) Factor);
      float num8 = (float) ((double) Quaternion1.W * (double) num1 + (double) Quaternion2.W * (double) Factor);
      float num9 = (float) Math.Sqrt((double) num5 * (double) num5 + (double) num6 * (double) num6 + (double) num7 * (double) num7 + (double) num8 * (double) num8);
      float num10 = (double) num9 != 0.0 ? 1f / num9 : 0.0f;
      return new MdxLib.Primitives.CVector4(num5 * num10, num6 * num9, num7 * num9, num8 * num9);
    }
  }
}
