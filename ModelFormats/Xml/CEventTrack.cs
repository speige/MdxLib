// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.CEventTrack
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System.Xml;

namespace MdxLib.ModelFormats.Xml
{
  internal sealed class CEventTrack : CObject
  {
    private CEventTrack()
    {
    }

    public void Load(
      CLoader Loader,
      XmlNode Node,
      MdxLib.Model.CModel Model,
      MdxLib.Model.CEvent Event,
      MdxLib.Model.CEventTrack EventTrack)
    {
      EventTrack.Time = this.ReadInteger(Node, "time", EventTrack.Time);
    }

    public void Save(
      CSaver Saver,
      XmlNode Node,
      MdxLib.Model.CModel Model,
      MdxLib.Model.CEvent Event,
      MdxLib.Model.CEventTrack EventTrack)
    {
      this.WriteInteger(Node, "time", EventTrack.Time);
    }

    public static CEventTrack Instance => CEventTrack.CSingleton.Instance;

    private static class CSingleton
    {
      public static CEventTrack Instance = new CEventTrack();
    }
  }
}
