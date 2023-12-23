// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CGeosetFace
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

namespace MdxLib.Model
{
  public sealed class CGeosetFace : CObject<CGeosetFace>
  {
    private CObjectReference<CGeosetVertex> _Vertex1;
    private CObjectReference<CGeosetVertex> _Vertex2;
    private CObjectReference<CGeosetVertex> _Vertex3;

    public CGeosetFace(CModel Model)
      : base(Model)
    {
    }

    public override string ToString() => "Geoset Face #" + (object) this.ObjectId;

    public CObjectReference<CGeosetVertex> Vertex1 => this._Vertex1 ?? (this._Vertex1 = new CObjectReference<CGeosetVertex>(this.Model));

    public CObjectReference<CGeosetVertex> Vertex2 => this._Vertex2 ?? (this._Vertex2 = new CObjectReference<CGeosetVertex>(this.Model));

    public CObjectReference<CGeosetVertex> Vertex3 => this._Vertex3 ?? (this._Vertex3 = new CObjectReference<CGeosetVertex>(this.Model));
  }
}
