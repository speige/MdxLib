// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdl.Value.CColor
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

namespace MdxLib.ModelFormats.Mdl.Value
{
  internal sealed class CColor : CUnknown, IValue<MdxLib.Primitives.CVector3>
  {
    private CColor()
    {
    }

    public MdxLib.Primitives.CVector3 Read(CLoader Loader) => Loader.ReadColor();

    public void Write(CSaver Saver, MdxLib.Primitives.CVector3 Value) => Saver.WriteColor(Value);

    public bool ValidCondition(MdxLib.Primitives.CVector3 Value, ECondition Condition)
    {
      switch (Condition)
      {
        case ECondition.NotZero:
          if ((double) Value.X == 0.0 && (double) Value.Y == 0.0 && (double) Value.Z == 0.0)
            return false;
          break;
        case ECondition.NotOne:
          if ((double) Value.X == 1.0 && (double) Value.Y == 1.0 && (double) Value.Z == 1.0)
            return false;
          break;
      }
      return true;
    }

    public static CColor Instance => CColor.CSingleton.Instance;

    private static class CSingleton
    {
      public static CColor Instance = new CColor();
    }
  }
}
