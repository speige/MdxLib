// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdl.Value.IValue`1
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

namespace MdxLib.ModelFormats.Mdl.Value
{
  internal interface IValue<T> where T : new()
  {
    T Read(CLoader Loader);

    void Write(CSaver Saver, T Value);

    bool ValidCondition(T Value, ECondition Condition);
  }
}
