﻿// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.CXml
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.ModelFormats.Xml;
using System;
using System.IO;
using System.Text;
using System.Xml;

namespace MdxLib.ModelFormats
{
  public sealed class CXml : IModelFormat
  {
    public void Load(string Name, Stream Stream, MdxLib.Model.CModel Model)
    {
      if (!Stream.CanRead)
        throw new NotSupportedException("Unable to load \"" + Name + "\", the stream does not support reading!");
      using (XmlTextReader reader = new XmlTextReader(Stream))
      {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load((XmlReader) reader);
        XmlNode Node = xmlDocument.SelectSingleNode("model");
        if (Node == null)
          throw new Exception("Unable to load \"" + Name + "\", could not find the root node!");
        CLoader Loader = new CLoader(Name);
        MdxLib.ModelFormats.Xml.CModel.Instance.Load(Loader, Node, Model);
        Loader.Attacher.Attach();
      }
    }

    public void Save(string Name, Stream Stream, MdxLib.Model.CModel Model)
    {
      if (!Stream.CanWrite)
        throw new NotSupportedException("Unable to load \"" + Name + "\", the stream does not support writing!");
      using (XmlTextWriter w = new XmlTextWriter(Stream, CConstants.TextEncoding))
      {
        XmlDocument xmlDocument = new XmlDocument();
        w.Formatting = Formatting.Indented;
        w.WriteStartDocument();
        w.WriteComment(this.BuildHeader(Name));
        XmlNode element = (XmlNode) xmlDocument.CreateElement("model");
        xmlDocument.AppendChild(element);
        MdxLib.ModelFormats.Xml.CModel.Instance.Save(new CSaver(Name), element, Model);
        xmlDocument.Save((XmlWriter) w);
      }
    }

    private string BuildHeader(string Name)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.AppendLine("");
      stringBuilder.AppendLine("+~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
      stringBuilder.AppendLine("|");
      stringBuilder.AppendLine("| " + Name.Replace("\n", "").Replace("\r", ""));
      stringBuilder.AppendLine("| Generated by MdxLib v1.04 (written by Magnus Ostberg, aka Magos)");
      stringBuilder.AppendLine("| " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
      stringBuilder.AppendLine("| http://www.magosx.com");
      stringBuilder.AppendLine("|");
      stringBuilder.AppendLine("+~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
      return stringBuilder.ToString();
    }
  }
}
