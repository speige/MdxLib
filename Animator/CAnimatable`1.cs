// Decompiled with JetBrains decompiler
// Type: MdxLib.Animator.CAnimatable`1
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

namespace MdxLib.Animator
{
  internal abstract class CAnimatable<T> where T : new()
  {
    private T _DefaultValue = default (T);

    public CAnimatable(T DefaultValue) => this._DefaultValue = DefaultValue;

    public T Interpolate(
      EInterpolationType Type,
      CTime Time,
      CAnimatorNode<T> Node1,
      CAnimatorNode<T> Node2)
    {
      if (Node1 == null)
        return this._DefaultValue;
      if (Node2 == null || Node1.Time >= Node2.Time)
        return Node1.Value;
      switch (Type)
      {
        case EInterpolationType.None:
          return this.InterpolateNone(Time, Node1, Node2);
        case EInterpolationType.Linear:
          return this.InterpolateLinear(Time, Node1, Node2);
        case EInterpolationType.Bezier:
          return this.InterpolateBezier(Time, Node1, Node2);
        case EInterpolationType.Hermite:
          return this.InterpolateHermite(Time, Node1, Node2);
        default:
          return this._DefaultValue;
      }
    }

    public abstract T InterpolateNone(CTime Time, CAnimatorNode<T> Node1, CAnimatorNode<T> Node2);

    public abstract T InterpolateLinear(CTime Time, CAnimatorNode<T> Node1, CAnimatorNode<T> Node2);

    public abstract T InterpolateBezier(CTime Time, CAnimatorNode<T> Node1, CAnimatorNode<T> Node2);

    public abstract T InterpolateHermite(
      CTime Time,
      CAnimatorNode<T> Node1,
      CAnimatorNode<T> Node2);

    public T DefaultValue => this._DefaultValue;
  }
}
