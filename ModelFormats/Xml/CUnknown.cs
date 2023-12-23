// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.CUnknown
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Primitives;
using System;
using System.Xml;

namespace MdxLib.ModelFormats.Xml
{
  internal abstract class CUnknown
  {
    public bool ReadBoolean(XmlNode Node, string Name, bool DefaultValue) => !(Node.SelectSingleNode(Name) is XmlElement xmlElement) ? DefaultValue : this.Bool(xmlElement.GetAttribute("bool"), DefaultValue);

    public int ReadInteger(XmlNode Node, string Name, int DefaultValue) => !(Node.SelectSingleNode(Name) is XmlElement xmlElement) ? DefaultValue : this.Int(xmlElement.GetAttribute("int"), DefaultValue);

    public float ReadFloat(XmlNode Node, string Name, float DefaultValue) => !(Node.SelectSingleNode(Name) is XmlElement xmlElement) ? DefaultValue : this.Float(xmlElement.GetAttribute("float"), DefaultValue);

    public string ReadString(XmlNode Node, string Name, string DefaultValue) => !(Node.SelectSingleNode(Name) is XmlElement xmlElement) ? DefaultValue : xmlElement.GetAttribute("string") ?? DefaultValue;

    public CVector2 ReadVector2(XmlNode Node, string Name, CVector2 DefaultValue) => !(Node.SelectSingleNode(Name) is XmlElement xmlElement) ? DefaultValue : new CVector2(this.Float(xmlElement.GetAttribute("x"), DefaultValue.X), this.Float(xmlElement.GetAttribute("y"), DefaultValue.Y));

    public CVector3 ReadVector3(XmlNode Node, string Name, CVector3 DefaultValue) => !(Node.SelectSingleNode(Name) is XmlElement xmlElement) ? DefaultValue : new CVector3(this.Float(xmlElement.GetAttribute("x"), DefaultValue.X), this.Float(xmlElement.GetAttribute("y"), DefaultValue.Y), this.Float(xmlElement.GetAttribute("z"), DefaultValue.Z));

    public CVector4 ReadVector4(XmlNode Node, string Name, CVector4 DefaultValue) => !(Node.SelectSingleNode(Name) is XmlElement xmlElement) ? DefaultValue : new CVector4(this.Float(xmlElement.GetAttribute("x"), DefaultValue.X), this.Float(xmlElement.GetAttribute("y"), DefaultValue.Y), this.Float(xmlElement.GetAttribute("z"), DefaultValue.Z), this.Float(xmlElement.GetAttribute("w"), DefaultValue.W));

    public CExtent ReadExtent(XmlNode Node, string Name, CExtent DefaultValue)
    {
      XmlNode Node1 = Node.SelectSingleNode(Name);
      return Node1 == null ? DefaultValue : new CExtent(this.ReadVector3(Node1, "min", DefaultValue.Min), this.ReadVector3(Node1, "max", DefaultValue.Max), this.ReadFloat(Node1, "radius", DefaultValue.Radius));
    }

    public CSegment ReadSegment(XmlNode Node, string Name, CSegment DefaultValue)
    {
      XmlNode Node1 = Node.SelectSingleNode(Name);
      return Node1 == null ? DefaultValue : new CSegment(this.ReadVector3(Node1, "color", DefaultValue.Color), this.ReadFloat(Node1, "alpha", DefaultValue.Alpha), this.ReadFloat(Node1, "scaling", DefaultValue.Scaling));
    }

    public CInterval ReadInterval(XmlNode Node, string Name, CInterval DefaultValue)
    {
      XmlNode Node1 = Node.SelectSingleNode(Name);
      return Node1 == null ? DefaultValue : new CInterval(this.ReadInteger(Node1, "start", DefaultValue.Start), this.ReadInteger(Node1, "end", DefaultValue.End), this.ReadInteger(Node1, "repeat", DefaultValue.Repeat));
    }

    public void WriteBoolean(XmlNode Node, string Name, bool Value) => this.AppendAttribute((XmlNode) this.AppendElement(Node, Name), "bool", Value ? "1" : "0");

    public void WriteInteger(XmlNode Node, string Name, int Value) => this.AppendAttribute((XmlNode) this.AppendElement(Node, Name), "int", Value.ToString());

    public void WriteFloat(XmlNode Node, string Name, float Value) => this.AppendAttribute((XmlNode) this.AppendElement(Node, Name), "float", Value.ToString((IFormatProvider) CConstants.NumberFormat));

    public void WriteString(XmlNode Node, string Name, string Value) => this.AppendAttribute((XmlNode) this.AppendElement(Node, Name), "string", Value);

    public void WriteVector2(XmlNode Node, string Name, CVector2 Value)
    {
      XmlElement Node1 = this.AppendElement(Node, Name);
      this.AppendAttribute((XmlNode) Node1, "x", Value.X.ToString((IFormatProvider) CConstants.NumberFormat));
      this.AppendAttribute((XmlNode) Node1, "y", Value.Y.ToString((IFormatProvider) CConstants.NumberFormat));
    }

    public void WriteVector3(XmlNode Node, string Name, CVector3 Value)
    {
      XmlElement Node1 = this.AppendElement(Node, Name);
      this.AppendAttribute((XmlNode) Node1, "x", Value.X.ToString((IFormatProvider) CConstants.NumberFormat));
      this.AppendAttribute((XmlNode) Node1, "y", Value.Y.ToString((IFormatProvider) CConstants.NumberFormat));
      this.AppendAttribute((XmlNode) Node1, "z", Value.Z.ToString((IFormatProvider) CConstants.NumberFormat));
    }

    public void WriteVector4(XmlNode Node, string Name, CVector4 Value)
    {
      XmlElement Node1 = this.AppendElement(Node, Name);
      this.AppendAttribute((XmlNode) Node1, "x", Value.X.ToString((IFormatProvider) CConstants.NumberFormat));
      this.AppendAttribute((XmlNode) Node1, "y", Value.Y.ToString((IFormatProvider) CConstants.NumberFormat));
      this.AppendAttribute((XmlNode) Node1, "z", Value.Z.ToString((IFormatProvider) CConstants.NumberFormat));
      this.AppendAttribute((XmlNode) Node1, "w", Value.W.ToString((IFormatProvider) CConstants.NumberFormat));
    }

    public void WriteExtent(XmlNode Node, string Name, CExtent Value)
    {
      XmlElement Node1 = this.AppendElement(Node, Name);
      this.WriteVector3((XmlNode) Node1, "min", Value.Min);
      this.WriteVector3((XmlNode) Node1, "max", Value.Max);
      this.WriteFloat((XmlNode) Node1, "radius", Value.Radius);
    }

    public void WriteSegment(XmlNode Node, string Name, CSegment Value)
    {
      XmlElement Node1 = this.AppendElement(Node, Name);
      this.WriteVector3((XmlNode) Node1, "color", Value.Color);
      this.WriteFloat((XmlNode) Node1, "alpha", Value.Alpha);
      this.WriteFloat((XmlNode) Node1, "scaling", Value.Scaling);
    }

    public void WriteInterval(XmlNode Node, string Name, CInterval Value)
    {
      XmlElement Node1 = this.AppendElement(Node, Name);
      this.WriteInteger((XmlNode) Node1, "start", Value.Start);
      this.WriteInteger((XmlNode) Node1, "end", Value.End);
      this.WriteInteger((XmlNode) Node1, "repeat", Value.Repeat);
    }

    public XmlElement AppendElement(XmlNode Node, string Name)
    {
      XmlElement element = Node.OwnerDocument.CreateElement(Name);
      Node.AppendChild((XmlNode) element);
      return element;
    }

    public XmlAttribute AppendAttribute(XmlNode Node, string Name, string Value)
    {
      XmlAttribute attribute = Node.OwnerDocument.CreateAttribute(Name);
      attribute.Value = Value;
      Node.Attributes.Append(attribute);
      return attribute;
    }

    public bool Bool(string String, bool DefaultValue)
    {
      try
      {
        return String == null ? DefaultValue : int.Parse(String) != 0;
      }
      catch (Exception ex)
      {
        return DefaultValue;
      }
    }

    public int Int(string String, int DefaultValue)
    {
      try
      {
        return String == null ? DefaultValue : int.Parse(String);
      }
      catch (Exception ex)
      {
        return DefaultValue;
      }
    }

    public float Float(string String, float DefaultValue)
    {
      try
      {
        return String == null ? DefaultValue : float.Parse(String, (IFormatProvider) CConstants.NumberFormat);
      }
      catch (Exception ex)
      {
        return DefaultValue;
      }
    }
  }
}
