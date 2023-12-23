// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CEvent
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System.Collections.Generic;

namespace MdxLib.Model
{
  public sealed class CEvent : CNode<CEvent>
  {
    private CObjectReference<CGlobalSequence> _GlobalSequence;
    private CObjectContainer<CEventTrack> _Tracks;

    public CEvent(CModel Model)
      : base(Model)
    {
    }

    internal override void BuildDetacherList(ICollection<CDetacher> DetacherList)
    {
      base.BuildDetacherList(DetacherList);
      if (this._Tracks == null)
        return;
      this._Tracks.BuildDetacherList(DetacherList);
    }

    public override string ToString() => "Event #" + (object) this.ObjectId;

    public override int NodeId => this.Model.GetEventNodeId(this);

    public override bool HasReferences => this._Tracks != null && this._Tracks.HasReferences || base.HasReferences;

    public CObjectReference<CGlobalSequence> GlobalSequence => this._GlobalSequence ?? (this._GlobalSequence = new CObjectReference<CGlobalSequence>(this.Model));

    public bool HasTracks => this._Tracks != null && this._Tracks.Count > 0;

    public CObjectContainer<CEventTrack> Tracks => this._Tracks ?? (this._Tracks = new CObjectContainer<CEventTrack>(this.Model));
  }
}
