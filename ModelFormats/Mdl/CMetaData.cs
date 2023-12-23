// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdl.CMetaData
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System;
using System.IO;
using System.Xml;

namespace MdxLib.ModelFormats.Mdl
{
  internal sealed class CMetaData : CObject
  {
    private CMetaData()
    {
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model)
    {
      using (StringReader input = new StringReader(Loader.ReadMetaData()))
      {
        using (XmlTextReader reader = new XmlTextReader((TextReader) input))
        {
          XmlDocument xmlDocument = new XmlDocument();
          xmlDocument.Load((XmlReader) reader);
          XmlNode node = xmlDocument.SelectSingleNode("meta");
          if (node == null || node.ChildNodes.Count <= 0)
            return;
          XmlNode newChild = Model.MetaData.ImportNode(node, true);
          Model.MetaData.ReplaceChild(newChild, (XmlNode) Model.MetaData.DocumentElement);
        }
      }
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasMetaData)
        return;
      using (StringWriter w1 = new StringWriter())
      {
        using (XmlTextWriter w2 = new XmlTextWriter((TextWriter) w1))
        {
          w2.Formatting = Formatting.Indented;
          w2.WriteStartDocument();
          Model.MetaData.Save((XmlWriter) w2);
          string str1 = w1.ToString().Replace("\r", "");
          string[] separator = new string[1]{ "\n" };
          foreach (string str2 in str1.Split(separator, StringSplitOptions.None))
            Saver.WriteLine("//" + str2);
        }
      }
    }

    public static CMetaData Instance => CMetaData.CSingleton.Instance;

    private static class CSingleton
    {
      public static CMetaData Instance = new CMetaData();
    }
  }
}
