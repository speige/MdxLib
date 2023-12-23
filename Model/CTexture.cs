// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CTexture
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

namespace MdxLib.Model
{
  public sealed class CTexture : CObject<CTexture>
  {
    private string _FileName = "";
    private int _ReplaceableId;
    private bool _WrapWidth;
    private bool _WrapHeight;

    public CTexture(CModel Model)
      : base(Model)
    {
    }

    public override string ToString() => "Texture #" + (object) this.ObjectId;

    public string FileName
    {
      get => this._FileName;
      set
      {
        this.AddSetObjectFieldCommand<string>("_FileName", value);
        this._FileName = value;
      }
    }

    public int ReplaceableId
    {
      get => this._ReplaceableId;
      set
      {
        this.AddSetObjectFieldCommand<int>("_ReplaceableId", value);
        this._ReplaceableId = value;
      }
    }

    public bool WrapWidth
    {
      get => this._WrapWidth;
      set
      {
        this.AddSetObjectFieldCommand<bool>("_WrapWidth", value);
        this._WrapWidth = value;
      }
    }

    public bool WrapHeight
    {
      get => this._WrapHeight;
      set
      {
        this.AddSetObjectFieldCommand<bool>("_WrapHeight", value);
        this._WrapHeight = value;
      }
    }
  }
}
