// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CGeosetVertex
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Primitives;

namespace MdxLib.Model
{
  public sealed class CGeosetVertex : CObject<CGeosetVertex>
  {
    private CVector3 _Position = CConstants.DefaultVector3;
    private CVector3 _Normal = CConstants.DefaultVector3;
    private CVector2 _TexturePosition = CConstants.DefaultVector2;
    private CObjectReference<CGeosetGroup> _Group;

    public CGeosetVertex(CModel Model)
      : base(Model)
    {
    }

    public override string ToString() => "Geoset Vertex #" + (object) this.ObjectId;

    public CVector3 Position
    {
      get => this._Position;
      set
      {
        this.AddSetObjectFieldCommand<CVector3>("_Position", value);
        this._Position = value;
      }
    }

    public CVector3 Normal
    {
      get => this._Normal;
      set
      {
        this.AddSetObjectFieldCommand<CVector3>("_Normal", value);
        this._Normal = value;
      }
    }

    public CVector2 TexturePosition
    {
      get => this._TexturePosition;
      set
      {
        this.AddSetObjectFieldCommand<CVector2>("_TexturePosition", value);
        this._TexturePosition = value;
      }
    }

    public CObjectReference<CGeosetGroup> Group => this._Group ?? (this._Group = new CObjectReference<CGeosetGroup>(this.Model));
  }
}
