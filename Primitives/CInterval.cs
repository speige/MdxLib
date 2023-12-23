// Decompiled with JetBrains decompiler
// Type: MdxLib.Primitives.CInterval
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System;

namespace MdxLib.Primitives
{
  public sealed class CInterval : ICloneable
  {
    private int _Start;
    private int _End;
    private int _Repeat;

    public CInterval()
    {
    }

    public CInterval(CInterval Interval)
    {
      this._Start = Interval._Start;
      this._End = Interval._End;
      this._Repeat = Interval._Repeat;
    }

    public CInterval(int Start, int End, int Repeat)
    {
      this._Start = Start;
      this._End = End;
      this._Repeat = Repeat;
    }

    public object Clone() => (object) new CInterval(this);

    public override string ToString() => "{ " + (object) this._Start + ", " + (object) this._End + ", " + (object) this._Repeat + " }";

    public int Start => this._Start;

    public int End => this._End;

    public int Repeat => this._Repeat;
  }
}
