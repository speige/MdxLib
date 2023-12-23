// Decompiled with JetBrains decompiler
// Type: MdxLib.Animator.CTime
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;

namespace MdxLib.Animator
{
  public sealed class CTime
  {
    private int _Time;
    private int _IntervalStart = int.MinValue;
    private int _IntervalEnd = int.MaxValue;

    public CTime()
    {
    }

    public CTime(CTime Time)
    {
      this._Time = Time._Time;
      this._IntervalStart = Time._IntervalStart;
      this._IntervalEnd = Time._IntervalEnd;
    }

    public CTime(int Time) => this._Time = Time;

    public CTime(int Time, int IntervalStart, int IntervalEnd)
    {
      this._Time = Time;
      this._IntervalStart = IntervalStart;
      this._IntervalEnd = IntervalEnd;
    }

    public CTime(int Time, CSequence Sequence)
    {
      this._Time = Time;
      this._IntervalStart = Sequence.IntervalStart;
      this._IntervalEnd = Sequence.IntervalEnd;
    }

    public CTime(int Time, CGlobalSequence GlobalSequence)
    {
      this._Time = Time;
      this._IntervalStart = 0;
      this._IntervalEnd = GlobalSequence.Duration;
    }

    public int Time => this._Time;

    public int IntervalStart => this._IntervalStart;

    public int IntervalEnd => this._IntervalEnd;
  }
}
