// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdl.CGlobalSequence
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.ModelFormats.Mdl.Token;
using System;

namespace MdxLib.ModelFormats.Mdl
{
  internal sealed class CGlobalSequence : CObject
  {
    private CGlobalSequence()
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
          case "duration":
            MdxLib.Model.CGlobalSequence cglobalSequence = new MdxLib.Model.CGlobalSequence(Model);
            this.Load(Loader, Model, cglobalSequence);
            Model.GlobalSequences.Add(cglobalSequence);
            continue;
          default:
            throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + str + "\"!");
        }
      }
      int num = (int) Loader.ReadToken();
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CGlobalSequence GlobalSequence) => GlobalSequence.Duration = this.LoadInteger(Loader);

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasGlobalSequences)
        return;
      Saver.BeginGroup("GlobalSequences", Model.GlobalSequences.Count);
      foreach (MdxLib.Model.CGlobalSequence globalSequence in Model.GlobalSequences)
        this.Save(Saver, Model, globalSequence);
      Saver.EndGroup();
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CGlobalSequence GlobalSequence)
    {
      Saver.WriteTabs();
      Saver.WriteWord("Duration ");
      Saver.WriteInteger(GlobalSequence.Duration);
      Saver.WriteLine(",");
    }

    public static CGlobalSequence Instance => CGlobalSequence.CSingleton.Instance;

    private static class CSingleton
    {
      public static CGlobalSequence Instance = new CGlobalSequence();
    }
  }
}
