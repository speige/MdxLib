// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdl.CModelVersion
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.ModelFormats.Mdl.Token;
using System;

namespace MdxLib.ModelFormats.Mdl
{
  internal sealed class CModelVersion : CObject
  {
    private CModelVersion()
    {
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model)
    {
      Loader.ExpectToken(EType.CurlyBracketLeft);
      while (Loader.PeekToken() != EType.CurlyBracketRight)
      {
        string str = Loader.ReadWord();
        switch (str)
        {
          case "formatversion":
            Model.Version = this.LoadInteger(Loader);
            continue;
          default:
            throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + str + "\"!");
        }
      }
      int num = (int) Loader.ReadToken();
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model)
    {
      Saver.BeginGroup("Version");
      this.SaveInteger(Saver, "FormatVersion", Model.Version);
      Saver.EndGroup();
    }

    public static CModelVersion Instance => CModelVersion.CSingleton.Instance;

    private static class CSingleton
    {
      public static CModelVersion Instance = new CModelVersion();
    }
  }
}
