// Decompiled with JetBrains decompiler
// Type: MdxLib.Primitives.CVector4
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System;

namespace MdxLib.Primitives
{
  public sealed class CVector4 : ICloneable
  {
    private float _X;
    private float _Y;
    private float _Z;
    private float _W;

    public CVector4()
    {
    }

    public CVector4(CVector4 Vector)
    {
      this._X = Vector._X;
      this._Y = Vector._Y;
      this._Z = Vector._Z;
      this._W = Vector._W;
    }

    public CVector4(float X, float Y, float Z, float W)
    {
      this._X = X;
      this._Y = Y;
      this._Z = Z;
      this._W = W;
    }

    public object Clone() => (object) new CVector4(this);

    public override string ToString() => "{ " + (object) this._X + ", " + (object) this._Y + ", " + (object) this._Z + ", " + (object) this._W + " }";

    public float X => this._X;

    public float Y => this._Y;

    public float Z => this._Z;

    public float W => this._W;
  }
}
