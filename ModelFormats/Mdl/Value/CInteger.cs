// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdl.Value.CInteger
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

namespace MdxLib.ModelFormats.Mdl.Value
{
  internal sealed class CInteger : CUnknown, IValue<int>
  {
    private CInteger()
    {
    }

    public int Read(CLoader Loader) => Loader.ReadInteger();

    public void Write(CSaver Saver, int Value) => Saver.WriteInteger(Value);

    public bool ValidCondition(int Value, ECondition Condition)
    {
      switch (Condition)
      {
        case ECondition.NotZero:
          if (Value == 0)
            return false;
          break;
        case ECondition.NotOne:
          if (Value == 1)
            return false;
          break;
        case ECondition.NotInvalidId:
          if (Value == -1)
            return false;
          break;
      }
      return true;
    }

    public static CInteger Instance => CInteger.CSingleton.Instance;

    private static class CSingleton
    {
      public static CInteger Instance = new CInteger();
    }
  }
}
