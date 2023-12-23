// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.CCollisionShape
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using System.Xml;

namespace MdxLib.ModelFormats.Xml
{
  internal sealed class CCollisionShape : CNode
  {
    private CCollisionShape()
    {
    }

    public void Load(CLoader Loader, XmlNode Node, MdxLib.Model.CModel Model, MdxLib.Model.CCollisionShape CollisionShape)
    {
      this.LoadNode<MdxLib.Model.CCollisionShape>(Loader, Node, Model, CollisionShape);
      CollisionShape.Type = this.StringToType(this.ReadString(Node, "type", this.TypeToString(CollisionShape.Type)));
      CollisionShape.Radius = this.ReadFloat(Node, "radius", CollisionShape.Radius);
      CollisionShape.Vertex1 = this.ReadVector3(Node, "vertex_1", CollisionShape.Vertex1);
      CollisionShape.Vertex2 = this.ReadVector3(Node, "vertex_2", CollisionShape.Vertex2);
    }

    public void Save(CSaver Saver, XmlNode Node, MdxLib.Model.CModel Model, MdxLib.Model.CCollisionShape CollisionShape)
    {
      this.SaveNode<MdxLib.Model.CCollisionShape>(Saver, Node, Model, CollisionShape);
      this.WriteString(Node, "type", this.TypeToString(CollisionShape.Type));
      this.WriteFloat(Node, "radius", CollisionShape.Radius);
      this.WriteVector3(Node, "vertex_1", CollisionShape.Vertex1);
      this.WriteVector3(Node, "vertex_2", CollisionShape.Vertex2);
    }

    private string TypeToString(ECollisionShapeType Type)
    {
      switch (Type)
      {
        case ECollisionShapeType.Box:
          return "box";
        case ECollisionShapeType.Sphere:
          return "sphere";
        default:
          return "";
      }
    }

    private ECollisionShapeType StringToType(string String)
    {
      switch (String)
      {
        case "box":
          return ECollisionShapeType.Box;
        case "sphere":
          return ECollisionShapeType.Sphere;
        default:
          return ECollisionShapeType.Box;
      }
    }

    public static CCollisionShape Instance => CCollisionShape.CSingleton.Instance;

    private static class CSingleton
    {
      public static CCollisionShape Instance = new CCollisionShape();
    }
  }
}
