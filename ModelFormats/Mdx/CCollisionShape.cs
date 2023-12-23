// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdx.CCollisionShape
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using System;

namespace MdxLib.ModelFormats.Mdx
{
  internal sealed class CCollisionShape : CNode
  {
    private CCollisionShape()
    {
    }

    public void LoadAll(CLoader Loader, MdxLib.Model.CModel Model)
    {
      int num = Loader.ReadInt32();
      while (num > 0)
      {
        Loader.PushLocation();
        MdxLib.Model.CCollisionShape ccollisionShape = new MdxLib.Model.CCollisionShape(Model);
        this.Load(Loader, Model, ccollisionShape);
        Model.CollisionShapes.Add(ccollisionShape);
        num -= Loader.PopLocation();
        if (num < 0)
          throw new Exception("Error at location " + (object) Loader.Location + ", too many CollisionShape bytes were read!");
      }
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CCollisionShape CollisionShape)
    {
      CNode.LoadNode<MdxLib.Model.CCollisionShape>(Loader, Model, (CNode<MdxLib.Model.CCollisionShape>) CollisionShape);
      switch (Loader.ReadInt32())
      {
        case 0:
          CollisionShape.Type = ECollisionShapeType.Box;
          break;
        case 2:
          CollisionShape.Type = ECollisionShapeType.Sphere;
          break;
      }
      switch (CollisionShape.Type)
      {
        case ECollisionShapeType.Box:
          CollisionShape.Vertex1 = Loader.ReadVector3();
          CollisionShape.Vertex2 = Loader.ReadVector3();
          break;
        case ECollisionShapeType.Sphere:
          CollisionShape.Vertex1 = Loader.ReadVector3();
          CollisionShape.Radius = Loader.ReadFloat();
          break;
      }
    }

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasCollisionShapes)
        return;
      Saver.WriteTag("CLID");
      Saver.PushLocation();
      foreach (MdxLib.Model.CCollisionShape collisionShape in Model.CollisionShapes)
        this.Save(Saver, Model, collisionShape);
      Saver.PopExclusiveLocation();
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CCollisionShape CollisionShape)
    {
      CNode.SaveNode<MdxLib.Model.CCollisionShape>(Saver, Model, (CNode<MdxLib.Model.CCollisionShape>) CollisionShape, 8192);
      switch (CollisionShape.Type)
      {
        case ECollisionShapeType.Box:
          Saver.WriteInt32(0);
          Saver.WriteVector3(CollisionShape.Vertex1);
          Saver.WriteVector3(CollisionShape.Vertex2);
          break;
        case ECollisionShapeType.Sphere:
          Saver.WriteInt32(2);
          Saver.WriteVector3(CollisionShape.Vertex1);
          Saver.WriteFloat(CollisionShape.Radius);
          break;
      }
    }

    public static CCollisionShape Instance => CCollisionShape.CSingleton.Instance;

    private static class CSingleton
    {
      public static CCollisionShape Instance = new CCollisionShape();
    }
  }
}
