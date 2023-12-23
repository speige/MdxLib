// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdl.Value.CFloat
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

namespace MdxLib.ModelFormats.Mdl.Value
{
  internal sealed class CFloat : CUnknown, IValue<float>
  {
    private CFloat()
    {
    }

    public float Read(CLoader Loader) => Loader.ReadFloat();

    public void Write(CSaver Saver, float Value) => Saver.WriteFloat(Value);

    public bool ValidCondition(float Value, ECondition Condition)
    {
      switch (Condition)
      {
        case ECondition.NotZero:
          if ((double) Value == 0.0)
            return false;
          break;
        case ECondition.NotOne:
          if ((double) Value == 1.0)
            return false;
          break;
      }
      return true;
    }

    public static CFloat Instance => CFloat.CSingleton.Instance;

    private static class CSingleton
    {
      public static CFloat Instance = new CFloat();
    }
  }
}
