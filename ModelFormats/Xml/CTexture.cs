// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.CTexture
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System.Xml;

namespace MdxLib.ModelFormats.Xml
{
  internal sealed class CTexture : CObject
  {
    private CTexture()
    {
    }

    public void Load(CLoader Loader, XmlNode Node, MdxLib.Model.CModel Model, MdxLib.Model.CTexture Texture)
    {
      Texture.FileName = this.ReadString(Node, "filename", Texture.FileName);
      Texture.ReplaceableId = this.ReadInteger(Node, "replaceable_id", Texture.ReplaceableId);
      Texture.WrapWidth = this.ReadBoolean(Node, "wrap_width", Texture.WrapWidth);
      Texture.WrapHeight = this.ReadBoolean(Node, "wrap_height", Texture.WrapHeight);
    }

    public void Save(CSaver Saver, XmlNode Node, MdxLib.Model.CModel Model, MdxLib.Model.CTexture Texture)
    {
      this.WriteString(Node, "filename", Texture.FileName);
      this.WriteInteger(Node, "replaceable_id", Texture.ReplaceableId);
      this.WriteBoolean(Node, "wrap_width", Texture.WrapWidth);
      this.WriteBoolean(Node, "wrap_height", Texture.WrapHeight);
    }

    public static CTexture Instance => CTexture.CSingleton.Instance;

    private static class CSingleton
    {
      public static CTexture Instance = new CTexture();
    }
  }
}
