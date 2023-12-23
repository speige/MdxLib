// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.CSaver
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

namespace MdxLib.ModelFormats.Xml
{
  internal sealed class CSaver
  {
    private string _Name = "";

    public CSaver(string Name) => this._Name = Name;

    public string Name => this._Name;
  }
}
