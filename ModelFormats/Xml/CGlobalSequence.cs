// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.CGlobalSequence
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System.Xml;

namespace MdxLib.ModelFormats.Xml
{
  internal sealed class CGlobalSequence : CObject
  {
    private CGlobalSequence()
    {
    }

    public void Load(CLoader Loader, XmlNode Node, MdxLib.Model.CModel Model, MdxLib.Model.CGlobalSequence GlobalSequence) => GlobalSequence.Duration = this.ReadInteger(Node, "duration", GlobalSequence.Duration);

    public void Save(CSaver Saver, XmlNode Node, MdxLib.Model.CModel Model, MdxLib.Model.CGlobalSequence GlobalSequence) => this.WriteInteger(Node, "duration", GlobalSequence.Duration);

    public static CGlobalSequence Instance => CGlobalSequence.CSingleton.Instance;

    private static class CSingleton
    {
      public static CGlobalSequence Instance = new CGlobalSequence();
    }
  }
}
