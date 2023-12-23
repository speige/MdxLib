// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.Value.CFloat
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System.Xml;

namespace MdxLib.ModelFormats.Xml.Value
{
  internal sealed class CFloat : CUnknown, IValue<float>
  {
    private CFloat()
    {
    }

    public float Read(XmlNode Node, string Name, float DefaultValue) => this.ReadFloat(Node, Name, DefaultValue);

    public void Write(XmlNode Node, string Name, float Value) => this.WriteFloat(Node, Name, Value);

    public static CFloat Instance => CFloat.CSingleton.Instance;

    private static class CSingleton
    {
      public static CFloat Instance = new CFloat();
    }
  }
}
