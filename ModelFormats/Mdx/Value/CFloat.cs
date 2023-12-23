// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdx.Value.CFloat
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

namespace MdxLib.ModelFormats.Mdx.Value
{
  internal sealed class CFloat : CUnknown, IValue<float>
  {
    private CFloat()
    {
    }

    public float Read(CLoader Loader) => Loader.ReadFloat();

    public void Write(CSaver Saver, float Value) => Saver.WriteFloat(Value);

    public static CFloat Instance => CFloat.CSingleton.Instance;

    private static class CSingleton
    {
      public static CFloat Instance = new CFloat();
    }
  }
}
