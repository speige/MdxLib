// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdx.Value.CVector2
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

namespace MdxLib.ModelFormats.Mdx.Value
{
  internal sealed class CVector2 : CUnknown, IValue<MdxLib.Primitives.CVector2>
  {
    private CVector2()
    {
    }

    public MdxLib.Primitives.CVector2 Read(CLoader Loader) => Loader.ReadVector2();

    public void Write(CSaver Saver, MdxLib.Primitives.CVector2 Value) => Saver.WriteVector2(Value);

    public static CVector2 Instance => CVector2.CSingleton.Instance;

    private static class CSingleton
    {
      public static CVector2 Instance = new CVector2();
    }
  }
}
