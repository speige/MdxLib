// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.Value.CInteger
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System.Xml;

namespace MdxLib.ModelFormats.Xml.Value
{
  internal sealed class CInteger : CUnknown, IValue<int>
  {
    private CInteger()
    {
    }

    public int Read(XmlNode Node, string Name, int DefaultValue) => this.ReadInteger(Node, Name, DefaultValue);

    public void Write(XmlNode Node, string Name, int Value) => this.WriteInteger(Node, Name, Value);

    public static CInteger Instance => CInteger.CSingleton.Instance;

    private static class CSingleton
    {
      public static CInteger Instance = new CInteger();
    }
  }
}
