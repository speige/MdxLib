// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdx.CEvent
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using System;

namespace MdxLib.ModelFormats.Mdx
{
  internal sealed class CEvent : CNode
  {
    private CEvent()
    {
    }

    public void LoadAll(CLoader Loader, MdxLib.Model.CModel Model)
    {
      int num = Loader.ReadInt32();
      while (num > 0)
      {
        Loader.PushLocation();
        MdxLib.Model.CEvent cevent = new MdxLib.Model.CEvent(Model);
        this.Load(Loader, Model, cevent);
        Model.Events.Add(cevent);
        num -= Loader.PopLocation();
        if (num < 0)
          throw new Exception("Error at location " + (object) Loader.Location + ", too many Event bytes were read!");
      }
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CEvent Event)
    {
      CNode.LoadNode<MdxLib.Model.CEvent>(Loader, Model, (CNode<MdxLib.Model.CEvent>) Event);
      Loader.ExpectTag("KEVT");
      int num = Loader.ReadInt32();
      Loader.Attacher.AddObject<MdxLib.Model.CGlobalSequence>(Model.GlobalSequences, Event.GlobalSequence, Loader.ReadInt32());
      for (int index = 0; index < num; ++index)
      {
        CEventTrack ceventTrack = new CEventTrack(Model);
        this.LoadTrack(Loader, Model, Event, ceventTrack);
        Event.Tracks.Add(ceventTrack);
      }
    }

    public void LoadTrack(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CEvent Event, CEventTrack Track) => Track.Time = Loader.ReadInt32();

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasEvents)
        return;
      Saver.WriteTag("EVTS");
      Saver.PushLocation();
      foreach (MdxLib.Model.CEvent Event in Model.Events)
        this.Save(Saver, Model, Event);
      Saver.PopExclusiveLocation();
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CEvent Event)
    {
      CNode.SaveNode<MdxLib.Model.CEvent>(Saver, Model, (CNode<MdxLib.Model.CEvent>) Event, 1024);
      Saver.WriteTag("KEVT");
      Saver.WriteInt32(Event.Tracks.Count);
      Saver.WriteInt32(Event.GlobalSequence.ObjectId);
      foreach (CEventTrack track in Event.Tracks)
        this.SaveTrack(Saver, Model, Event, track);
    }

    public void SaveTrack(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CEvent Event, CEventTrack Track) => Saver.WriteInt32(Track.Time);

    public static CEvent Instance => CEvent.CSingleton.Instance;

    private static class CSingleton
    {
      public static CEvent Instance = new CEvent();
    }
  }
}
