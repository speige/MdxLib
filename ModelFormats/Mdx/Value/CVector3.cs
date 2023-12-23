// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdx.Value.CVector3
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

namespace MdxLib.ModelFormats.Mdx.Value
{
  internal sealed class CVector3 : CUnknown, IValue<MdxLib.Primitives.CVector3>
  {
    private CVector3()
    {
    }

    public MdxLib.Primitives.CVector3 Read(CLoader Loader) => Loader.ReadVector3();

    public void Write(CSaver Saver, MdxLib.Primitives.CVector3 Value) => Saver.WriteVector3(Value);

    public static CVector3 Instance => CVector3.CSingleton.Instance;

    private static class CSingleton
    {
      public static CVector3 Instance = new CVector3();
    }
  }
}
