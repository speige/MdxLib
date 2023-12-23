// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdl.CEvent
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using MdxLib.ModelFormats.Mdl.Token;
using System;

namespace MdxLib.ModelFormats.Mdl
{
  internal sealed class CEvent : CNode
  {
    private CEvent()
    {
    }

    public void LoadAll(CLoader Loader, MdxLib.Model.CModel Model)
    {
      MdxLib.Model.CEvent cevent = new MdxLib.Model.CEvent(Model);
      this.Load(Loader, Model, cevent);
      Model.Events.Add(cevent);
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CEvent Event)
    {
      Event.Name = Loader.ReadString();
      Loader.ExpectToken(EType.CurlyBracketLeft);
      while (Loader.PeekToken() != EType.CurlyBracketRight)
      {
        string Tag1 = Loader.ReadWord();
        if (!this.LoadNode<MdxLib.Model.CEvent>(Loader, Model, (CNode<MdxLib.Model.CEvent>) Event, Tag1))
        {
          switch (Tag1)
          {
            case "static":
              string Tag2 = Loader.ReadWord();
              if (!this.LoadStaticNode<MdxLib.Model.CEvent>(Loader, Model, (CNode<MdxLib.Model.CEvent>) Event, Tag2))
                throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + Tag2 + "\"!");
              continue;
            case "eventtrack":
              Loader.ReadInteger();
              Loader.ExpectToken(EType.CurlyBracketLeft);
              while (Loader.PeekToken() != EType.CurlyBracketRight)
                Event.Tracks.Add(new CEventTrack(Model)
                {
                  Time = this.LoadInteger(Loader)
                });
              int num = (int) Loader.ReadToken();
              continue;
            default:
              throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + Tag1 + "\"!");
          }
        }
      }
      int num1 = (int) Loader.ReadToken();
    }

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasEvents)
        return;
      foreach (MdxLib.Model.CEvent Event in Model.Events)
        this.Save(Saver, Model, Event);
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CEvent Event)
    {
      Saver.BeginGroup("EventObject", Event.Name);
      this.SaveNode<MdxLib.Model.CEvent>(Saver, Model, (CNode<MdxLib.Model.CEvent>) Event);
      Saver.BeginGroup("EventTrack", Event.Tracks.Count);
      foreach (CEventTrack track in Event.Tracks)
      {
        Saver.WriteTabs();
        Saver.WriteInteger(track.Time);
        Saver.WriteLine(",");
      }
      Saver.EndGroup();
      Saver.EndGroup();
    }

    public static CEvent Instance => CEvent.CSingleton.Instance;

    private static class CSingleton
    {
      public static CEvent Instance = new CEvent();
    }
  }
}
