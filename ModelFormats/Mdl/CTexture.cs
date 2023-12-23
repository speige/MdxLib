// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdl.CTexture
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.ModelFormats.Mdl.Token;
using System;

namespace MdxLib.ModelFormats.Mdl
{
  internal sealed class CTexture : CObject
  {
    private CTexture()
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
          case "bitmap":
            MdxLib.Model.CTexture ctexture = new MdxLib.Model.CTexture(Model);
            this.Load(Loader, Model, ctexture);
            Model.Textures.Add(ctexture);
            continue;
          default:
            throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + str + "\"!");
        }
      }
      int num = (int) Loader.ReadToken();
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CTexture Texture)
    {
      Loader.ExpectToken(EType.CurlyBracketLeft);
      while (Loader.PeekToken() != EType.CurlyBracketRight)
      {
        string str = Loader.ReadWord();
        switch (str)
        {
          case "image":
            Texture.FileName = this.LoadString(Loader);
            continue;
          case "replaceableid":
            Texture.ReplaceableId = this.LoadInteger(Loader);
            continue;
          case "wrapwidth":
            Texture.WrapWidth = this.LoadBoolean(Loader);
            continue;
          case "wrapheight":
            Texture.WrapHeight = this.LoadBoolean(Loader);
            continue;
          default:
            throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + str + "\"!");
        }
      }
      int num = (int) Loader.ReadToken();
    }

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasTextures)
        return;
      Saver.BeginGroup("Textures", Model.Textures.Count);
      foreach (MdxLib.Model.CTexture texture in Model.Textures)
        this.Save(Saver, Model, texture);
      Saver.EndGroup();
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CTexture Texture)
    {
      Saver.BeginGroup("Bitmap");
      this.SaveString(Saver, "Image", Texture.FileName);
      this.SaveInteger(Saver, "ReplaceableId", Texture.ReplaceableId, ECondition.NotZero);
      this.SaveBoolean(Saver, "WrapWidth", Texture.WrapWidth);
      this.SaveBoolean(Saver, "WrapHeight", Texture.WrapHeight);
      Saver.EndGroup();
    }

    public static CTexture Instance => CTexture.CSingleton.Instance;

    private static class CSingleton
    {
      public static CTexture Instance = new CTexture();
    }
  }
}
