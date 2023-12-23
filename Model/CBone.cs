// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CBone
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

namespace MdxLib.Model
{
  public sealed class CBone : CNode<CBone>
  {
    private CObjectReference<CGeoset> _Geoset;
    private CObjectReference<CGeosetAnimation> _GeosetAnimation;

    public CBone(CModel Model)
      : base(Model)
    {
    }

    public override string ToString() => "Bone #" + (object) this.ObjectId;

    public override int NodeId => this.Model.GetBoneNodeId(this);

    public CObjectReference<CGeoset> Geoset => this._Geoset ?? (this._Geoset = new CObjectReference<CGeoset>(this.Model));

    public CObjectReference<CGeosetAnimation> GeosetAnimation => this._GeosetAnimation ?? (this._GeosetAnimation = new CObjectReference<CGeosetAnimation>(this.Model));
  }
}
