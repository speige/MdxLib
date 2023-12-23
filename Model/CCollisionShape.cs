// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CCollisionShape
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Primitives;

namespace MdxLib.Model
{
  public sealed class CCollisionShape : CNode<CCollisionShape>
  {
    private ECollisionShapeType _Type;
    private float _Radius;
    private CVector3 _Vertex1 = CConstants.DefaultVector3;
    private CVector3 _Vertex2 = CConstants.DefaultVector3;

    public CCollisionShape(CModel Model)
      : base(Model)
    {
    }

    public override string ToString() => "Collision Shape #" + (object) this.ObjectId;

    public override int NodeId => this.Model.GetCollisionShapeNodeId(this);

    public ECollisionShapeType Type
    {
      get => this._Type;
      set
      {
        this.AddSetObjectFieldCommand<ECollisionShapeType>("_Type", value);
        this._Type = value;
      }
    }

    public float Radius
    {
      get => this._Radius;
      set
      {
        this.AddSetObjectFieldCommand<float>("_Radius", value);
        this._Radius = value;
      }
    }

    public CVector3 Vertex1
    {
      get => this._Vertex1;
      set
      {
        this.AddSetObjectFieldCommand<CVector3>("_Vertex1", value);
        this._Vertex1 = value;
      }
    }

    public CVector3 Vertex2
    {
      get => this._Vertex2;
      set
      {
        this.AddSetObjectFieldCommand<CVector3>("_Vertex2", value);
        this._Vertex2 = value;
      }
    }
  }
}
