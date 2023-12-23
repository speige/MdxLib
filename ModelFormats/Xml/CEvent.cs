// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.CEvent
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System.Xml;

namespace MdxLib.ModelFormats.Xml
{
  internal sealed class CEvent : CNode
  {
    private CEvent()
    {
    }

    public void Load(CLoader Loader, XmlNode Node, MdxLib.Model.CModel Model, MdxLib.Model.CEvent Event)
    {
      this.LoadNode<MdxLib.Model.CEvent>(Loader, Node, Model, Event);
      Loader.Attacher.AddObject<MdxLib.Model.CGlobalSequence>(Model.GlobalSequences, Event.GlobalSequence, this.ReadInteger(Node, "global_sequence", -1));
      foreach (XmlNode selectNode in Node.SelectNodes("event_track"))
      {
        MdxLib.Model.CEventTrack ceventTrack = new MdxLib.Model.CEventTrack(Model);
        CEventTrack.Instance.Load(Loader, selectNode, Model, Event, ceventTrack);
        Event.Tracks.Add(ceventTrack);
      }
    }

    public void Save(CSaver Saver, XmlNode Node, MdxLib.Model.CModel Model, MdxLib.Model.CEvent Event)
    {
      this.SaveNode<MdxLib.Model.CEvent>(Saver, Node, Model, Event);
      this.WriteInteger(Node, "global_sequence", Event.GlobalSequence.ObjectId);
      if (!Event.HasTracks)
        return;
      foreach (MdxLib.Model.CEventTrack track in Event.Tracks)
      {
        XmlElement Node1 = this.AppendElement(Node, "event_track");
        CEventTrack.Instance.Save(Saver, (XmlNode) Node1, Model, Event, track);
      }
    }

    public static CEvent Instance => CEvent.CSingleton.Instance;

    private static class CSingleton
    {
      public static CEvent Instance = new CEvent();
    }
  }
}
