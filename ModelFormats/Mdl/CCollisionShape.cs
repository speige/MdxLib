// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdl.CCollisionShape
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using MdxLib.ModelFormats.Mdl.Token;
using System;

namespace MdxLib.ModelFormats.Mdl
{
  internal sealed class CCollisionShape : CNode
  {
    private CCollisionShape()
    {
    }

    public void LoadAll(CLoader Loader, MdxLib.Model.CModel Model)
    {
      MdxLib.Model.CCollisionShape ccollisionShape = new MdxLib.Model.CCollisionShape(Model);
      this.Load(Loader, Model, ccollisionShape);
      Model.CollisionShapes.Add(ccollisionShape);
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CCollisionShape CollisionShape)
    {
      CollisionShape.Name = Loader.ReadString();
      Loader.ExpectToken(EType.CurlyBracketLeft);
      while (Loader.PeekToken() != EType.CurlyBracketRight)
      {
        string Tag1 = Loader.ReadWord();
        if (!this.LoadNode<MdxLib.Model.CCollisionShape>(Loader, Model, (CNode<MdxLib.Model.CCollisionShape>) CollisionShape, Tag1))
        {
          switch (Tag1)
          {
            case "static":
              string Tag2 = Loader.ReadWord();
              if (!this.LoadStaticNode<MdxLib.Model.CCollisionShape>(Loader, Model, (CNode<MdxLib.Model.CCollisionShape>) CollisionShape, Tag2))
                throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + Tag2 + "\"!");
              continue;
            case "box":
              CollisionShape.Type = ECollisionShapeType.Box;
              this.LoadBoolean(Loader);
              continue;
            case "sphere":
              CollisionShape.Type = ECollisionShapeType.Sphere;
              this.LoadBoolean(Loader);
              continue;
            case "boundsradius":
              CollisionShape.Radius = this.LoadFloat(Loader);
              continue;
            case "vertices":
              int num = Loader.ReadInteger();
              Loader.ExpectToken(EType.CurlyBracketLeft);
              switch (num)
              {
                case 1:
                  CollisionShape.Vertex1 = this.LoadVector3(Loader);
                  break;
                case 2:
                  CollisionShape.Vertex1 = this.LoadVector3(Loader);
                  CollisionShape.Vertex2 = this.LoadVector3(Loader);
                  break;
                default:
                  throw new Exception("Bad vertex count at line " + (object) Loader.Line + ", got " + (object) num + " vertices!");
              }
              Loader.ExpectToken(EType.CurlyBracketRight);
              continue;
            default:
              throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + Tag1 + "\"!");
          }
        }
      }
      int num1 = (int) Loader.ReadToken();
    }

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasCollisionShapes)
        return;
      foreach (MdxLib.Model.CCollisionShape collisionShape in Model.CollisionShapes)
        this.Save(Saver, Model, collisionShape);
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CCollisionShape CollisionShape)
    {
      Saver.BeginGroup(nameof (CollisionShape), CollisionShape.Name);
      this.SaveNode<MdxLib.Model.CCollisionShape>(Saver, Model, (CNode<MdxLib.Model.CCollisionShape>) CollisionShape);
      this.SaveBoolean(Saver, this.TypeToString(CollisionShape.Type), true);
      switch (CollisionShape.Type)
      {
        case ECollisionShapeType.Box:
          Saver.BeginGroup("Vertices", 2);
          Saver.WriteTabs();
          Saver.WriteVector3(CollisionShape.Vertex1);
          Saver.WriteLine(",");
          Saver.WriteTabs();
          Saver.WriteVector3(CollisionShape.Vertex2);
          Saver.WriteLine(",");
          Saver.EndGroup();
          break;
        case ECollisionShapeType.Sphere:
          Saver.BeginGroup("Vertices", 1);
          Saver.WriteTabs();
          Saver.WriteVector3(CollisionShape.Vertex1);
          Saver.WriteLine(",");
          Saver.EndGroup();
          this.SaveFloat(Saver, "BoundsRadius", CollisionShape.Radius, ECondition.NotZero);
          break;
      }
      Saver.EndGroup();
    }

    private string TypeToString(ECollisionShapeType Type)
    {
      switch (Type)
      {
        case ECollisionShapeType.Box:
          return "Box";
        case ECollisionShapeType.Sphere:
          return "Sphere";
        default:
          return "";
      }
    }

    public static CCollisionShape Instance => CCollisionShape.CSingleton.Instance;

    private static class CSingleton
    {
      public static CCollisionShape Instance = new CCollisionShape();
    }
  }
}
