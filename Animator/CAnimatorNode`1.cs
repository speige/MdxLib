// Decompiled with JetBrains decompiler
// Type: MdxLib.Animator.CAnimatorNode`1
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

namespace MdxLib.Animator
{
  public sealed class CAnimatorNode<T> where T : new()
  {
    private int _Time;
    private T _Value = default (T);
    private T _InTangent = default (T);
    private T _OutTangent = default (T);

    public CAnimatorNode()
    {
      this._Value = new T();
      this._InTangent = new T();
      this._OutTangent = new T();
    }

    public CAnimatorNode(CAnimatorNode<T> Node)
    {
      this._Time = Node._Time;
      this._Value = Node._Value;
      this._InTangent = Node._InTangent;
      this._OutTangent = Node._OutTangent;
    }

    public CAnimatorNode(int Time, T Value)
    {
      this._Time = Time;
      this._Value = Value;
      this._InTangent = new T();
      this._OutTangent = new T();
    }

    public CAnimatorNode(int Time, T Value, T InTangent, T OutTangent)
    {
      this._Time = Time;
      this._Value = Value;
      this._InTangent = InTangent;
      this._OutTangent = OutTangent;
    }

    public int Time => this._Time;

    public T Value => this._Value;

    public T InTangent => this._InTangent;

    public T OutTangent => this._OutTangent;
  }
}
