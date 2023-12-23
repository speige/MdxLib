// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdx.CGeoset
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using MdxLib.Primitives;
using System;
using System.Collections.Generic;

namespace MdxLib.ModelFormats.Mdx
{
  internal sealed class CGeoset : CObject
  {
    private CGeoset()
    {
    }

    public void LoadAll(CLoader Loader, MdxLib.Model.CModel Model)
    {
      int num = Loader.ReadInt32();
      while (num > 0)
      {
        Loader.PushLocation();
        MdxLib.Model.CGeoset cgeoset = new MdxLib.Model.CGeoset(Model);
        this.Load(Loader, Model, cgeoset);
        Model.Geosets.Add(cgeoset);
        num -= Loader.PopLocation();
        if (num < 0)
          throw new Exception("Error at location " + (object) Loader.Location + ", too many Geoset bytes were read!");
      }
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CGeoset Geoset)
    {
      List<CVector3> cvector3List1 = new List<CVector3>();
      List<CVector3> cvector3List2 = new List<CVector3>();
      List<int> intList1 = new List<int>();
      List<CVector2> cvector2List = new List<CVector2>();
      List<int> intList2 = new List<int>();
      Loader.ReadInt32();
      Loader.ExpectTag("VRTX");
      int num1 = Loader.ReadInt32();
      for (int index = 0; index < num1; ++index)
        cvector3List1.Add(Loader.ReadVector3());
      Loader.ExpectTag("NRMS");
      int num2 = Loader.ReadInt32();
      if (num2 != num1)
        throw new Exception("Error at location " + (object) Loader.Location + ", vertex normal miscount (" + (object) num2 + " normals, " + (object) num1 + " positions)!");
      for (int index = 0; index < num2; ++index)
        cvector3List2.Add(Loader.ReadVector3());
      Loader.ExpectTag("PTYP");
      int num3 = Loader.ReadInt32();
      for (int index = 0; index < num3; ++index)
      {
        int num4 = Loader.ReadInt32();
        if (num4 != 4)
          throw new Exception("Error at location " + (object) Loader.Location + ", unsupported Geoset face type (type " + (object) num4 + ")!");
      }
      Loader.ExpectTag("PCNT");
      int num5 = Loader.ReadInt32();
      for (int index = 0; index < num5; ++index)
        Loader.ReadInt32();
      Loader.ExpectTag("PVTX");
      int num6 = Loader.ReadInt32();
      if (num6 % 3 != 0)
        throw new Exception("Error at location " + (object) Loader.Location + ", bad Geoset, nr of indexes not divisible by 3!");
      int num7 = num6 / 3;
      for (int index = 0; index < num7; ++index)
      {
        CGeosetFace Object = new CGeosetFace(Model);
        Loader.Attacher.AddObject<CGeosetVertex>(Geoset.Vertices, Object.Vertex1, Loader.ReadInt16());
        Loader.Attacher.AddObject<CGeosetVertex>(Geoset.Vertices, Object.Vertex2, Loader.ReadInt16());
        Loader.Attacher.AddObject<CGeosetVertex>(Geoset.Vertices, Object.Vertex3, Loader.ReadInt16());
        Geoset.Faces.Add(Object);
      }
      Loader.ExpectTag("GNDX");
      int num8 = Loader.ReadInt32();
      if (num8 != num1)
        throw new Exception("Error at location " + (object) Loader.Location + ", vertex group miscount (" + (object) num8 + " groups, " + (object) num1 + " positions)!");
      for (int index = 0; index < num8; ++index)
        intList1.Add(Loader.ReadInt8());
      Loader.ExpectTag("MTGC");
      int num9 = Loader.ReadInt32();
      for (int index = 0; index < num9; ++index)
      {
        intList2.Add(Loader.ReadInt32());
        Geoset.Groups.Add(new CGeosetGroup(Model));
      }
      Loader.ExpectTag("MATS");
      int num10 = Loader.ReadInt32();
      int num11 = -1;
      int num12 = 0;
      CGeosetGroup cgeosetGroup = (CGeosetGroup) null;
      for (int index = 0; index < num10; ++index)
      {
        if (num12 <= 0)
        {
          ++num11;
          num12 = intList2[num11];
          cgeosetGroup = Geoset.Groups[num11];
        }
        CGeosetGroupNode Object = new CGeosetGroupNode(Model);
        Loader.Attacher.AddNode(Model, Object.Node, Loader.ReadInt32());
        cgeosetGroup.Nodes.Add(Object);
        --num12;
      }
      Loader.Attacher.AddObject<MdxLib.Model.CMaterial>(Model.Materials, Geoset.Material, Loader.ReadInt32());
      int num13 = Loader.ReadInt32();
      Geoset.SelectionGroup = Loader.ReadInt32();
      Geoset.Extent = Loader.ReadExtent();
      int num14 = Loader.ReadInt32();
      for (int index = 0; index < num14; ++index)
        Geoset.Extents.Add(new CGeosetExtent(Model)
        {
          Extent = Loader.ReadExtent()
        });
      Loader.ExpectTag("UVAS");
      Loader.ReadInt32();
      Loader.ExpectTag("UVBS");
      int num15 = Loader.ReadInt32();
      if (num15 != num1)
        throw new Exception("Error at location " + (object) Loader.Location + ", vertex texture position miscount (" + (object) num15 + " texture positions, " + (object) num1 + " positions)!");
      for (int index = 0; index < num15; ++index)
        cvector2List.Add(Loader.ReadVector2());
      Geoset.Unselectable = (num13 & 4) != 0;
      for (int index = 0; index < num1; ++index)
      {
        CGeosetVertex Object = new CGeosetVertex(Model);
        Object.Position = cvector3List1[index];
        Object.Normal = cvector3List2[index];
        Object.TexturePosition = cvector2List[index];
        Loader.Attacher.AddObject<CGeosetGroup>(Geoset.Groups, Object.Group, intList1[index]);
        Geoset.Vertices.Add(Object);
      }
    }

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasGeosets)
        return;
      Saver.WriteTag("GEOS");
      Saver.PushLocation();
      foreach (MdxLib.Model.CGeoset geoset in Model.Geosets)
        this.Save(Saver, Model, geoset);
      Saver.PopExclusiveLocation();
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CGeoset Geoset)
    {
      int num1 = 0;
      int num2 = 0;
      if (Geoset.Unselectable)
        num1 |= 4;
      Saver.PushLocation();
      Saver.WriteTag("VRTX");
      Saver.WriteInt32(Geoset.Vertices.Count);
      foreach (CGeosetVertex vertex in Geoset.Vertices)
        Saver.WriteVector3(vertex.Position);
      Saver.WriteTag("NRMS");
      Saver.WriteInt32(Geoset.Vertices.Count);
      foreach (CGeosetVertex vertex in Geoset.Vertices)
        Saver.WriteVector3(vertex.Normal);
      Saver.WriteTag("PTYP");
      Saver.WriteInt32(1);
      Saver.WriteInt32(4);
      Saver.WriteTag("PCNT");
      Saver.WriteInt32(1);
      Saver.WriteInt32(Geoset.Faces.Count * 3);
      Saver.WriteTag("PVTX");
      Saver.WriteInt32(Geoset.Faces.Count * 3);
      foreach (CGeosetFace face in Geoset.Faces)
      {
        Saver.WriteInt16(face.Vertex1.ObjectId);
        Saver.WriteInt16(face.Vertex2.ObjectId);
        Saver.WriteInt16(face.Vertex3.ObjectId);
      }
      Saver.WriteTag("GNDX");
      Saver.WriteInt32(Geoset.Vertices.Count);
      foreach (CGeosetVertex vertex in Geoset.Vertices)
        Saver.WriteInt8(vertex.Group.ObjectId);
      Saver.WriteTag("MTGC");
      Saver.WriteInt32(Geoset.Groups.Count);
      foreach (CGeosetGroup group in Geoset.Groups)
      {
        num2 += group.Nodes.Count;
        Saver.WriteInt32(group.Nodes.Count);
      }
      Saver.WriteTag("MATS");
      Saver.WriteInt32(num2);
      foreach (CGeosetGroup group in Geoset.Groups)
      {
        foreach (CGeosetGroupNode node in group.Nodes)
          Saver.WriteInt32(node.Node.ObjectId);
      }
      Saver.WriteInt32(Geoset.Material.ObjectId);
      Saver.WriteInt32(num1);
      Saver.WriteInt32(Geoset.SelectionGroup);
      Saver.WriteExtent(Geoset.Extent);
      Saver.WriteInt32(Geoset.Extents.Count);
      foreach (CGeosetExtent extent in Geoset.Extents)
        Saver.WriteExtent(extent.Extent);
      Saver.WriteTag("UVAS");
      Saver.WriteInt32(1);
      Saver.WriteTag("UVBS");
      Saver.WriteInt32(Geoset.Vertices.Count);
      foreach (CGeosetVertex vertex in Geoset.Vertices)
        Saver.WriteVector2(vertex.TexturePosition);
      Saver.PopInclusiveLocation();
    }

    public static CGeoset Instance => CGeoset.CSingleton.Instance;

    private static class CSingleton
    {
      public static CGeoset Instance = new CGeoset();
    }
  }
}
