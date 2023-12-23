// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdx.CMetaData
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System.IO;
using System.Xml;

namespace MdxLib.ModelFormats.Mdx
{
  internal sealed class CMetaData : CObject
  {
    private CMetaData()
    {
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model)
    {
      int Length = Loader.ReadInt32();
      using (StringReader input = new StringReader(Loader.ReadString(Length)))
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
      Saver.WriteTag("META");
      Saver.PushLocation();
      using (MemoryStream w1 = new MemoryStream())
      {
        using (XmlTextWriter w2 = new XmlTextWriter((Stream) w1, CConstants.SimpleTextEncoding))
        {
          w2.Formatting = Formatting.None;
          w2.WriteStartDocument();
          Model.MetaData.Save((XmlWriter) w2);
          Saver.Write(w1.GetBuffer());
        }
      }
      Saver.PopExclusiveLocation();
    }

    public static CMetaData Instance => CMetaData.CSingleton.Instance;

    private static class CSingleton
    {
      public static CMetaData Instance = new CMetaData();
    }
  }
}
