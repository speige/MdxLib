// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdx.CSequence
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System;

namespace MdxLib.ModelFormats.Mdx
{
  internal sealed class CSequence : CObject
  {
    private CSequence()
    {
    }

    public void LoadAll(CLoader Loader, MdxLib.Model.CModel Model)
    {
      int num = Loader.ReadInt32();
      while (num > 0)
      {
        Loader.PushLocation();
        MdxLib.Model.CSequence csequence = new MdxLib.Model.CSequence(Model);
        this.Load(Loader, Model, csequence);
        Model.Sequences.Add(csequence);
        num -= Loader.PopLocation();
        if (num < 0)
          throw new Exception("Error at location " + (object) Loader.Location + ", too many Sequence bytes were read!");
      }
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CSequence Sequence)
    {
      Sequence.Name = Loader.ReadString(80);
      Sequence.IntervalStart = Loader.ReadInt32();
      Sequence.IntervalEnd = Loader.ReadInt32();
      Sequence.MoveSpeed = Loader.ReadFloat();
      int num = Loader.ReadInt32();
      Sequence.Rarity = Loader.ReadFloat();
      Sequence.SyncPoint = Loader.ReadInt32();
      Sequence.Extent = Loader.ReadExtent();
      Sequence.NonLooping = (num & 1) != 0;
    }

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasSequences)
        return;
      Saver.WriteTag("SEQS");
      Saver.PushLocation();
      foreach (MdxLib.Model.CSequence sequence in Model.Sequences)
        this.Save(Saver, Model, sequence);
      Saver.PopExclusiveLocation();
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CSequence Sequence)
    {
      int num = 0;
      if (Sequence.NonLooping)
        num |= 1;
      Saver.WriteString(Sequence.Name, 80);
      Saver.WriteInt32(Sequence.IntervalStart);
      Saver.WriteInt32(Sequence.IntervalEnd);
      Saver.WriteFloat(Sequence.MoveSpeed);
      Saver.WriteInt32(num);
      Saver.WriteFloat(Sequence.Rarity);
      Saver.WriteInt32(Sequence.SyncPoint);
      Saver.WriteExtent(Sequence.Extent);
    }

    public static CSequence Instance => CSequence.CSingleton.Instance;

    private static class CSingleton
    {
      public static CSequence Instance = new CSequence();
    }
  }
}
