// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdx.CGlobalSequence
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System;

namespace MdxLib.ModelFormats.Mdx
{
  internal sealed class CGlobalSequence : CObject
  {
    private CGlobalSequence()
    {
    }

    public void LoadAll(CLoader Loader, MdxLib.Model.CModel Model)
    {
      int num = Loader.ReadInt32();
      while (num > 0)
      {
        Loader.PushLocation();
        MdxLib.Model.CGlobalSequence cglobalSequence = new MdxLib.Model.CGlobalSequence(Model);
        this.Load(Loader, Model, cglobalSequence);
        Model.GlobalSequences.Add(cglobalSequence);
        num -= Loader.PopLocation();
        if (num < 0)
          throw new Exception("Error at location " + (object) Loader.Location + ", too many GlobalSequence bytes were read!");
      }
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CGlobalSequence GlobalSequence) => GlobalSequence.Duration = Loader.ReadInt32();

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasGlobalSequences)
        return;
      Saver.WriteTag("GLBS");
      Saver.PushLocation();
      foreach (MdxLib.Model.CGlobalSequence globalSequence in Model.GlobalSequences)
        this.Save(Saver, Model, globalSequence);
      Saver.PopExclusiveLocation();
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CGlobalSequence GlobalSequence) => Saver.WriteInt32(GlobalSequence.Duration);

    public static CGlobalSequence Instance => CGlobalSequence.CSingleton.Instance;

    private static class CSingleton
    {
      public static CGlobalSequence Instance = new CGlobalSequence();
    }
  }
}
