// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CEventTrack
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

namespace MdxLib.Model
{
  public sealed class CEventTrack : CObject<CEventTrack>
  {
    private int _Time;

    public CEventTrack(CModel Model)
      : base(Model)
    {
    }

    public override string ToString() => "Event Track #" + (object) this.ObjectId;

    public int Time
    {
      get => this._Time;
      set
      {
        this.AddSetObjectFieldCommand<int>("_Time", value);
        this._Time = value;
      }
    }
  }
}
