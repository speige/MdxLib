// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdl.CHelper
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using MdxLib.ModelFormats.Mdl.Token;
using System;

namespace MdxLib.ModelFormats.Mdl
{
  internal sealed class CHelper : CNode
  {
    private CHelper()
    {
    }

    public void LoadAll(CLoader Loader, MdxLib.Model.CModel Model)
    {
      MdxLib.Model.CHelper chelper = new MdxLib.Model.CHelper(Model);
      this.Load(Loader, Model, chelper);
      Model.Helpers.Add(chelper);
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CHelper Helper)
    {
      Helper.Name = Loader.ReadString();
      Loader.ExpectToken(EType.CurlyBracketLeft);
      while (Loader.PeekToken() != EType.CurlyBracketRight)
      {
        string Tag1 = Loader.ReadWord();
        if (!this.LoadNode<MdxLib.Model.CHelper>(Loader, Model, (CNode<MdxLib.Model.CHelper>) Helper, Tag1))
        {
          switch (Tag1)
          {
            case "static":
              string Tag2 = Loader.ReadWord();
              if (!this.LoadStaticNode<MdxLib.Model.CHelper>(Loader, Model, (CNode<MdxLib.Model.CHelper>) Helper, Tag2))
                throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + Tag2 + "\"!");
              continue;
            default:
              throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + Tag1 + "\"!");
          }
        }
      }
      int num = (int) Loader.ReadToken();
    }

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasHelpers)
        return;
      foreach (MdxLib.Model.CHelper helper in Model.Helpers)
        this.Save(Saver, Model, helper);
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CHelper Helper)
    {
      Saver.BeginGroup(nameof (Helper), Helper.Name);
      this.SaveNode<MdxLib.Model.CHelper>(Saver, Model, (CNode<MdxLib.Model.CHelper>) Helper);
      Saver.EndGroup();
    }

    public static CHelper Instance => CHelper.CSingleton.Instance;

    private static class CSingleton
    {
      public static CHelper Instance = new CHelper();
    }
  }
}
