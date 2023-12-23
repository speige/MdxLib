// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.CLoader
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.ModelFormats.Attacher;

namespace MdxLib.ModelFormats.Xml
{
  internal sealed class CLoader
  {
    private string _Name = "";
    private CAttacherContainer _Attacher;

    public CLoader(string Name)
    {
      this._Name = Name;
      this._Attacher = new CAttacherContainer();
    }

    public string Name => this._Name;

    public CAttacherContainer Attacher => this._Attacher;
  }
}
