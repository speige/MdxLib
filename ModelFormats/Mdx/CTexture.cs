// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdx.CTexture
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System;

namespace MdxLib.ModelFormats.Mdx
{
  internal sealed class CTexture : CObject
  {
    private CTexture()
    {
    }

    public void LoadAll(CLoader Loader, MdxLib.Model.CModel Model)
    {
      int num = Loader.ReadInt32();
      while (num > 0)
      {
        Loader.PushLocation();
        MdxLib.Model.CTexture ctexture = new MdxLib.Model.CTexture(Model);
        this.Load(Loader, Model, ctexture);
        Model.Textures.Add(ctexture);
        num -= Loader.PopLocation();
        if (num < 0)
          throw new Exception("Error at location " + (object) Loader.Location + ", too many Texture bytes were read!");
      }
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CTexture Texture)
    {
      Texture.ReplaceableId = Loader.ReadInt32();
      Texture.FileName = Loader.ReadString(260);
      int num = Loader.ReadInt32();
      Texture.WrapWidth = (num & 1) != 0;
      Texture.WrapHeight = (num & 2) != 0;
    }

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasTextures)
        return;
      Saver.WriteTag("TEXS");
      Saver.PushLocation();
      foreach (MdxLib.Model.CTexture texture in Model.Textures)
        this.Save(Saver, Model, texture);
      Saver.PopExclusiveLocation();
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CTexture Texture)
    {
      int num = 0;
      if (Texture.WrapWidth)
        num |= 1;
      if (Texture.WrapHeight)
        num |= 2;
      Saver.WriteInt32(Texture.ReplaceableId);
      Saver.WriteString(Texture.FileName, 260);
      Saver.WriteInt32(num);
    }

    public static CTexture Instance => CTexture.CSingleton.Instance;

    private static class CSingleton
    {
      public static CTexture Instance = new CTexture();
    }
  }
}
