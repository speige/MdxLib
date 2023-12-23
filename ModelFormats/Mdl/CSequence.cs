// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdl.CSequence
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.ModelFormats.Mdl.Token;
using MdxLib.Primitives;
using System;

namespace MdxLib.ModelFormats.Mdl
{
  internal sealed class CSequence : CObject
  {
    private CSequence()
    {
    }

    public void LoadAll(CLoader Loader, MdxLib.Model.CModel Model)
    {
      Loader.ReadInteger();
      Loader.ExpectToken(EType.CurlyBracketLeft);
      while (Loader.PeekToken() != EType.CurlyBracketRight)
      {
        string str = Loader.ReadWord();
        switch (str)
        {
          case "anim":
            MdxLib.Model.CSequence csequence = new MdxLib.Model.CSequence(Model);
            this.Load(Loader, Model, csequence);
            Model.Sequences.Add(csequence);
            continue;
          default:
            throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + str + "\"!");
        }
      }
      int num = (int) Loader.ReadToken();
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CSequence Sequence)
    {
      float Radius = 0.0f;
      CVector3 Min = CConstants.DefaultVector3;
      CVector3 Max = CConstants.DefaultVector3;
      Sequence.Name = Loader.ReadString();
      Loader.ExpectToken(EType.CurlyBracketLeft);
      while (Loader.PeekToken() != EType.CurlyBracketRight)
      {
        string str = Loader.ReadWord();
        switch (str)
        {
          case "syncpoint":
            Sequence.SyncPoint = this.LoadInteger(Loader);
            continue;
          case "rarity":
            Sequence.Rarity = this.LoadFloat(Loader);
            continue;
          case "movespeed":
            Sequence.MoveSpeed = this.LoadFloat(Loader);
            continue;
          case "minimumextent":
            Min = this.LoadVector3(Loader);
            continue;
          case "maximumextent":
            Max = this.LoadVector3(Loader);
            continue;
          case "boundsradius":
            Radius = this.LoadFloat(Loader);
            continue;
          case "nonlooping":
            Sequence.NonLooping = this.LoadBoolean(Loader);
            continue;
          case "interval":
            Loader.ExpectToken(EType.CurlyBracketLeft);
            Sequence.IntervalStart = Loader.ReadInteger();
            Loader.ExpectToken(EType.Separator);
            Sequence.IntervalEnd = Loader.ReadInteger();
            Loader.ExpectToken(EType.CurlyBracketRight);
            Loader.ExpectToken(EType.Separator);
            continue;
          default:
            throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + str + "\"!");
        }
      }
      int num = (int) Loader.ReadToken();
      Sequence.Extent = new CExtent(Min, Max, Radius);
    }

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasSequences)
        return;
      Saver.BeginGroup("Sequences", Model.Sequences.Count);
      foreach (MdxLib.Model.CSequence sequence in Model.Sequences)
        this.Save(Saver, Model, sequence);
      Saver.EndGroup();
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CSequence Sequence)
    {
      Saver.BeginGroup("Anim", Sequence.Name);
      Saver.WriteTabs();
      Saver.WriteWord("Interval { ");
      Saver.WriteInteger(Sequence.IntervalStart);
      Saver.WriteWord(", ");
      Saver.WriteInteger(Sequence.IntervalEnd);
      Saver.WriteLine(" },");
      this.SaveInteger(Saver, "SyncPoint", Sequence.SyncPoint, ECondition.NotZero);
      this.SaveFloat(Saver, "Rarity", Sequence.Rarity, ECondition.NotZero);
      this.SaveFloat(Saver, "MoveSpeed", Sequence.MoveSpeed, ECondition.NotZero);
      this.SaveBoolean(Saver, "NonLooping", Sequence.NonLooping);
      this.SaveVector3(Saver, "MinimumExtent", Sequence.Extent.Min, ECondition.NotZero);
      this.SaveVector3(Saver, "MaximumExtent", Sequence.Extent.Max, ECondition.NotZero);
      this.SaveFloat(Saver, "BoundsRadius", Sequence.Extent.Radius, ECondition.NotZero);
      Saver.EndGroup();
    }

    public static CSequence Instance => CSequence.CSingleton.Instance;

    private static class CSingleton
    {
      public static CSequence Instance = new CSequence();
    }
  }
}
