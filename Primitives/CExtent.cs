// Decompiled with JetBrains decompiler
// Type: MdxLib.Primitives.CExtent
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System;

namespace MdxLib.Primitives
{
  public sealed class CExtent : ICloneable
  {
    private CVector3 _Min;
    private CVector3 _Max;
    private float _Radius;

    public CExtent()
    {
      this._Min = new CVector3();
      this._Max = new CVector3();
    }

    public CExtent(CExtent Extent)
    {
      this._Min = Extent._Min;
      this._Max = Extent._Max;
      this._Radius = Extent._Radius;
    }

    public CExtent(CVector3 Min, CVector3 Max, float Radius)
    {
      this._Min = Min;
      this._Max = Max;
      this._Radius = Radius;
    }

    public object Clone() => (object) new CExtent(this);

    public override string ToString() => "{ " + (object) this._Min + ", " + (object) this._Max + ", " + (object) this._Radius + " }";

    public CVector3 Min => this._Min;

    public CVector3 Max => this._Max;

    public float Radius => this._Radius;
  }
}
