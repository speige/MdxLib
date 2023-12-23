// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CGlobalSequence
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

namespace MdxLib.Model
{
  public sealed class CGlobalSequence : CObject<CGlobalSequence>
  {
    private int _Duration;

    public CGlobalSequence(CModel Model)
      : base(Model)
    {
    }

    public override string ToString() => "Global Sequence #" + (object) this.ObjectId;

    public int Duration
    {
      get => this._Duration;
      set
      {
        this.AddSetObjectFieldCommand<int>("_Duration", value);
        this._Duration = value;
      }
    }
  }
}
