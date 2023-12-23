// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdx.CHelper
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using System;

namespace MdxLib.ModelFormats.Mdx
{
  internal sealed class CHelper : CNode
  {
    private CHelper()
    {
    }

    public void LoadAll(CLoader Loader, MdxLib.Model.CModel Model)
    {
      int num = Loader.ReadInt32();
      while (num > 0)
      {
        Loader.PushLocation();
        MdxLib.Model.CHelper chelper = new MdxLib.Model.CHelper(Model);
        this.Load(Loader, Model, chelper);
        Model.Helpers.Add(chelper);
        num -= Loader.PopLocation();
        if (num < 0)
          throw new Exception("Error at location " + (object) Loader.Location + ", too many Helper bytes were read!");
      }
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CHelper Helper) => CNode.LoadNode<MdxLib.Model.CHelper>(Loader, Model, (CNode<MdxLib.Model.CHelper>) Helper);

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasHelpers)
        return;
      Saver.WriteTag("HELP");
      Saver.PushLocation();
      foreach (MdxLib.Model.CHelper helper in Model.Helpers)
        this.Save(Saver, Model, helper);
      Saver.PopExclusiveLocation();
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CHelper Helper) => CNode.SaveNode<MdxLib.Model.CHelper>(Saver, Model, (CNode<MdxLib.Model.CHelper>) Helper, 0);

    public static CHelper Instance => CHelper.CSingleton.Instance;

    private static class CSingleton
    {
      public static CHelper Instance = new CHelper();
    }
  }
}
