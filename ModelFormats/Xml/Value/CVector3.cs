// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.Value.CVector3
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System.Xml;

namespace MdxLib.ModelFormats.Xml.Value
{
  internal sealed class CVector3 : CUnknown, IValue<MdxLib.Primitives.CVector3>
  {
    private CVector3()
    {
    }

    public MdxLib.Primitives.CVector3 Read(
      XmlNode Node,
      string Name,
      MdxLib.Primitives.CVector3 DefaultValue)
    {
      return this.ReadVector3(Node, Name, DefaultValue);
    }

    public void Write(XmlNode Node, string Name, MdxLib.Primitives.CVector3 Value) => this.WriteVector3(Node, Name, Value);

    public static CVector3 Instance => CVector3.CSingleton.Instance;

    private static class CSingleton
    {
      public static CVector3 Instance = new CVector3();
    }
  }
}
