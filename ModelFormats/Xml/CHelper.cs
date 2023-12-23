// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.CHelper
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System.Xml;

namespace MdxLib.ModelFormats.Xml
{
  internal sealed class CHelper : CNode
  {
    private CHelper()
    {
    }

    public void Load(CLoader Loader, XmlNode Node, MdxLib.Model.CModel Model, MdxLib.Model.CHelper Helper) => this.LoadNode<MdxLib.Model.CHelper>(Loader, Node, Model, Helper);

    public void Save(CSaver Saver, XmlNode Node, MdxLib.Model.CModel Model, MdxLib.Model.CHelper Helper) => this.SaveNode<MdxLib.Model.CHelper>(Saver, Node, Model, Helper);

    public static CHelper Instance => CHelper.CSingleton.Instance;

    private static class CSingleton
    {
      public static CHelper Instance = new CHelper();
    }
  }
}
