// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.Value.CVector2
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System.Xml;

namespace MdxLib.ModelFormats.Xml.Value
{
  internal sealed class CVector2 : CUnknown, IValue<MdxLib.Primitives.CVector2>
  {
    private CVector2()
    {
    }

    public MdxLib.Primitives.CVector2 Read(
      XmlNode Node,
      string Name,
      MdxLib.Primitives.CVector2 DefaultValue)
    {
      return this.ReadVector2(Node, Name, DefaultValue);
    }

    public void Write(XmlNode Node, string Name, MdxLib.Primitives.CVector2 Value) => this.WriteVector2(Node, Name, Value);

    public static CVector2 Instance => CVector2.CSingleton.Instance;

    private static class CSingleton
    {
      public static CVector2 Instance = new CVector2();
    }
  }
}
