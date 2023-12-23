// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CGeosetExtent
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Primitives;

namespace MdxLib.Model
{
  public sealed class CGeosetExtent : CObject<CGeosetExtent>
  {
    private CExtent _Extent = CConstants.DefaultExtent;

    public CGeosetExtent(CModel Model)
      : base(Model)
    {
    }

    public override string ToString() => "Geoset Extent #" + (object) this.ObjectId;

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
