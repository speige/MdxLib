// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdl.Value.CVector4
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

namespace MdxLib.ModelFormats.Mdl.Value
{
  internal sealed class CVector4 : CUnknown, IValue<MdxLib.Primitives.CVector4>
  {
    private CVector4()
    {
    }

    public MdxLib.Primitives.CVector4 Read(CLoader Loader) => Loader.ReadVector4();

    public void Write(CSaver Saver, MdxLib.Primitives.CVector4 Value) => Saver.WriteVector4(Value);

    public bool ValidCondition(MdxLib.Primitives.CVector4 Value, ECondition Condition)
    {
      switch (Condition)
      {
        case ECondition.NotZero:
          if ((double) Value.X == 0.0 && (double) Value.Y == 0.0 && (double) Value.Z == 0.0 && (double) Value.W == 0.0)
            return false;
          break;
        case ECondition.NotOne:
          if ((double) Value.X == 1.0 && (double) Value.Y == 1.0 && (double) Value.Z == 1.0 && (double) Value.W == 1.0)
            return false;
          break;
        case ECondition.NotDefaultQuaternion:
          if ((double) Value.X == 0.0 && (double) Value.Y == 0.0 && (double) Value.Z == 0.0 && (double) Value.W == 1.0)
            return false;
          break;
      }
      return true;
    }

    public static CVector4 Instance => CVector4.CSingleton.Instance;

    private static class CSingleton
    {
      public static CVector4 Instance = new CVector4();
    }
  }
}
