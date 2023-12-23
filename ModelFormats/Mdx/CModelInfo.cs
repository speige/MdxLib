// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdx.CModelInfo
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

namespace MdxLib.ModelFormats.Mdx
{
  internal sealed class CModelInfo : CObject
  {
    private CModelInfo()
    {
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model)
    {
      Loader.ReadInt32();
      Model.Name = Loader.ReadString(80);
      Model.AnimationFile = Loader.ReadString(260);
      Model.Extent = Loader.ReadExtent();
      Model.BlendTime = Loader.ReadInt32();
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model)
    {
      Saver.WriteTag("MODL");
      Saver.PushLocation();
      Saver.WriteString(Model.Name, 80);
      Saver.WriteString(Model.AnimationFile, 260);
      Saver.WriteExtent(Model.Extent);
      Saver.WriteInt32(Model.BlendTime);
      Saver.PopExclusiveLocation();
    }

    public static CModelInfo Instance => CModelInfo.CSingleton.Instance;

    private static class CSingleton
    {
      public static CModelInfo Instance = new CModelInfo();
    }
  }
}
