// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.CSequence
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System.Xml;

namespace MdxLib.ModelFormats.Xml
{
  internal sealed class CSequence : CObject
  {
    private CSequence()
    {
    }

    public void Load(CLoader Loader, XmlNode Node, MdxLib.Model.CModel Model, MdxLib.Model.CSequence Sequence)
    {
      Sequence.Name = this.ReadString(Node, "name", Sequence.Name);
      Sequence.Rarity = this.ReadFloat(Node, "rarity", Sequence.Rarity);
      Sequence.MoveSpeed = this.ReadFloat(Node, "move_speed", Sequence.MoveSpeed);
      Sequence.IntervalStart = this.ReadInteger(Node, "interval_start", Sequence.IntervalStart);
      Sequence.IntervalEnd = this.ReadInteger(Node, "interval_end", Sequence.IntervalEnd);
      Sequence.SyncPoint = this.ReadInteger(Node, "sync_point", Sequence.SyncPoint);
      Sequence.NonLooping = this.ReadBoolean(Node, "non_looping", Sequence.NonLooping);
      Sequence.Extent = this.ReadExtent(Node, "extent", Sequence.Extent);
    }

    public void Save(CSaver Saver, XmlNode Node, MdxLib.Model.CModel Model, MdxLib.Model.CSequence Sequence)
    {
      this.WriteString(Node, "name", Sequence.Name);
      this.WriteFloat(Node, "rarity", Sequence.Rarity);
      this.WriteFloat(Node, "move_speed", Sequence.MoveSpeed);
      this.WriteInteger(Node, "interval_start", Sequence.IntervalStart);
      this.WriteInteger(Node, "interval_end", Sequence.IntervalEnd);
      this.WriteInteger(Node, "sync_point", Sequence.SyncPoint);
      this.WriteBoolean(Node, "non_looping", Sequence.NonLooping);
      this.WriteExtent(Node, "extent", Sequence.Extent);
    }

    public static CSequence Instance => CSequence.CSingleton.Instance;

    private static class CSingleton
    {
      public static CSequence Instance = new CSequence();
    }
  }
}
