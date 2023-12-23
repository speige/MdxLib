// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdx.CModelVersion
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

namespace MdxLib.ModelFormats.Mdx
{
  internal sealed class CModelVersion : CObject
  {
    private CModelVersion()
    {
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model)
    {
      Loader.ReadInt32();
      Model.Version = Loader.ReadInt32();
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model)
    {
      Saver.WriteTag("VERS");
      Saver.PushLocation();
      Saver.WriteInt32(Model.Version);
      Saver.PopExclusiveLocation();
    }

    public static CModelVersion Instance => CModelVersion.CSingleton.Instance;

    private static class CSingleton
    {
      public static CModelVersion Instance = new CModelVersion();
    }
  }
}
