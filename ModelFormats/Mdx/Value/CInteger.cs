// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdx.Value.CInteger
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

namespace MdxLib.ModelFormats.Mdx.Value
{
  internal sealed class CInteger : CUnknown, IValue<int>
  {
    private CInteger()
    {
    }

    public int Read(CLoader Loader) => Loader.ReadInt32();

    public void Write(CSaver Saver, int Value) => Saver.WriteInt32(Value);

    public static CInteger Instance => CInteger.CSingleton.Instance;

    private static class CSingleton
    {
      public static CInteger Instance = new CInteger();
    }
  }
}
