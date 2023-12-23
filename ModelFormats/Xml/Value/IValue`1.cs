// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.Value.IValue`1
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System.Xml;

namespace MdxLib.ModelFormats.Xml.Value
{
  internal interface IValue<T> where T : new()
  {
    T Read(XmlNode Node, string Name, T DefaultValue);

    void Write(XmlNode Node, string Name, T Value);
  }
}
