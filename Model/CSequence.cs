// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CSequence
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Primitives;

namespace MdxLib.Model
{
  public sealed class CSequence : CObject<CSequence>
  {
    private string _Name = "";
    private int _IntervalStart;
    private int _IntervalEnd;
    private int _SyncPoint;
    private float _Rarity;
    private float _MoveSpeed;
    private bool _NonLooping;
    private CExtent _Extent = CConstants.DefaultExtent;

    public CSequence(CModel Model)
      : base(Model)
    {
    }

    public override string ToString() => "Sequence #" + (object) this.ObjectId;

    public string Name
    {
      get => this._Name;
      set
      {
        this.AddSetObjectFieldCommand<string>("_Name", value);
        this._Name = value;
      }
    }

    public int IntervalStart
    {
      get => this._IntervalStart;
      set
      {
        this.AddSetObjectFieldCommand<int>("_IntervalStart", value);
        this._IntervalStart = value;
      }
    }

    public int IntervalEnd
    {
      get => this._IntervalEnd;
      set
      {
        this.AddSetObjectFieldCommand<int>("_IntervalEnd", value);
        this._IntervalEnd = value;
      }
    }

    public int SyncPoint
    {
      get => this._SyncPoint;
      set
      {
        this.AddSetObjectFieldCommand<int>("_SyncPoint", value);
        this._SyncPoint = value;
      }
    }

    public float Rarity
    {
      get => this._Rarity;
      set
      {
        this.AddSetObjectFieldCommand<float>("_Rarity", value);
        this._Rarity = value;
      }
    }

    public float MoveSpeed
    {
      get => this._MoveSpeed;
      set
      {
        this.AddSetObjectFieldCommand<float>("_MoveSpeed", value);
        this._MoveSpeed = value;
      }
    }

    public bool NonLooping
    {
      get => this._NonLooping;
      set
      {
        this.AddSetObjectFieldCommand<bool>("_NonLooping", value);
        this._NonLooping = value;
      }
    }

    public CExtent Extent
    {
      get => this._Extent;
      set
      {
        this.AddSetObjectFieldCommand<CExtent>("_Extent", value);
        this._Extent = value;
      }
    }
  }
}
