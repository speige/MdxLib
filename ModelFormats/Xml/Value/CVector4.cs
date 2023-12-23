// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.Value.CVector4
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System.Xml;

namespace MdxLib.ModelFormats.Xml.Value
{
  internal sealed class CVector4 : CUnknown, IValue<MdxLib.Primitives.CVector4>
  {
    private CVector4()
    {
    }

    public MdxLib.Primitives.CVector4 Read(
      XmlNode Node,
      string Name,
      MdxLib.Primitives.CVector4 DefaultValue)
    {
      return this.ReadVector4(Node, Name, DefaultValue);
    }

    public void Write(XmlNode Node, string Name, MdxLib.Primitives.CVector4 Value) => this.WriteVector4(Node, Name, Value);

    public static CVector4 Instance => CVector4.CSingleton.Instance;

    private static class CSingleton
    {
      public static CVector4 Instance = new CVector4();
    }
  }
}
