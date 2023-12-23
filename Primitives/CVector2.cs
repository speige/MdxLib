// Decompiled with JetBrains decompiler
// Type: MdxLib.Primitives.CVector2
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System;

namespace MdxLib.Primitives
{
  public sealed class CVector2 : ICloneable
  {
    private float _X;
    private float _Y;

    public CVector2()
    {
    }

    public CVector2(CVector2 Vector)
    {
      this._X = Vector._X;
      this._Y = Vector._Y;
    }

    public CVector2(float X, float Y)
    {
      this._X = X;
      this._Y = Y;
    }

    public object Clone() => (object) new CVector2(this);

    public override string ToString() => "{ " + (object) this._X + ", " + (object) this._Y + " }";

    public float X => this._X;

    public float Y => this._Y;
  }
}
