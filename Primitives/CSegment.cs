// Decompiled with JetBrains decompiler
// Type: MdxLib.Primitives.CSegment
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System;

namespace MdxLib.Primitives
{
  public sealed class CSegment : ICloneable
  {
    private CVector3 _Color;
    private float _Alpha;
    private float _Scaling;

    public CSegment() => this._Color = new CVector3(1f, 1f, 1f);

    public CSegment(CSegment Segment)
    {
      this._Color = Segment._Color;
      this._Alpha = Segment._Alpha;
      this._Scaling = Segment._Scaling;
    }

    public CSegment(CVector3 Color, float Alpha, float Scaling)
    {
      this._Color = Color;
      this._Alpha = Alpha;
      this._Scaling = Scaling;
    }

    public object Clone() => (object) new CSegment(this);

    public override string ToString() => "";

    public CVector3 Color => this._Color;

    public float Alpha => this._Alpha;

    public float Scaling => this._Scaling;
  }
}
