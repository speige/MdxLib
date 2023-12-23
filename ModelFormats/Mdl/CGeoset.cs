// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdl.CGeoset
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using MdxLib.ModelFormats.Mdl.Token;
using MdxLib.Primitives;
using System;
using System.Collections.Generic;

namespace MdxLib.ModelFormats.Mdl
{
  internal sealed class CGeoset : CObject
  {
    private CGeoset()
    {
    }

    public void LoadAll(CLoader Loader, MdxLib.Model.CModel Model)
    {
      MdxLib.Model.CGeoset cgeoset = new MdxLib.Model.CGeoset(Model);
      this.Load(Loader, Model, cgeoset);
      Model.Geosets.Add(cgeoset);
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CGeoset Geoset)
    {
      int num1 = 0;
      float Radius1 = 0.0f;
      CVector3 Min1 = CConstants.DefaultVector3;
      CVector3 Max1 = CConstants.DefaultVector3;
      List<CVector3> cvector3List1 = new List<CVector3>();
      List<CVector3> cvector3List2 = new List<CVector3>();
      List<int> intList1 = new List<int>();
      List<CVector2> cvector2List = new List<CVector2>();
      List<int> intList2 = new List<int>();
      Loader.ExpectToken(EType.CurlyBracketLeft);
      while (Loader.PeekToken() != EType.CurlyBracketRight)
      {
        string str1 = Loader.ReadWord();
        switch (str1)
        {
          case "minimumextent":
            Min1 = this.LoadVector3(Loader);
            continue;
          case "maximumextent":
            Max1 = this.LoadVector3(Loader);
            continue;
          case "boundsradius":
            Radius1 = this.LoadFloat(Loader);
            continue;
          case "materialid":
            Loader.Attacher.AddObject<MdxLib.Model.CMaterial>(Model.Materials, Geoset.Material, this.LoadId(Loader));
            continue;
          case "selectiongroup":
            Geoset.SelectionGroup = this.LoadInteger(Loader);
            continue;
          case "unselectable":
            Geoset.Unselectable = this.LoadBoolean(Loader);
            continue;
          case "vertices":
            num1 = Loader.ReadInteger();
            Loader.ExpectToken(EType.CurlyBracketLeft);
            for (int index = 0; index < num1; ++index)
              cvector3List1.Add(this.LoadVector3(Loader));
            Loader.ExpectToken(EType.CurlyBracketRight);
            continue;
          case "normals":
            int num2 = Loader.ReadInteger();
            if (num2 != num1)
              throw new Exception("Vertex normal miscount at line " + (object) Loader.Line + " (" + (object) num2 + " normals, " + (object) num1 + " positions)!");
            Loader.ExpectToken(EType.CurlyBracketLeft);
            for (int index = 0; index < num2; ++index)
              cvector3List2.Add(this.LoadVector3(Loader));
            Loader.ExpectToken(EType.CurlyBracketRight);
            continue;
          case "tvertices":
            int num3 = Loader.ReadInteger();
            if (num3 != num1)
              throw new Exception("Vertex texture position miscount at line " + (object) Loader.Line + " (" + (object) num3 + " texture positions, " + (object) num1 + " positions)!");
            Loader.ExpectToken(EType.CurlyBracketLeft);
            for (int index = 0; index < num3; ++index)
              cvector2List.Add(this.LoadVector2(Loader));
            Loader.ExpectToken(EType.CurlyBracketRight);
            continue;
          case "vertexgroup":
            int num4 = num1;
            Loader.ExpectToken(EType.CurlyBracketLeft);
            for (int index = 0; index < num4; ++index)
              intList1.Add(this.LoadInteger(Loader));
            Loader.ExpectToken(EType.CurlyBracketRight);
            continue;
          case "faces":
            Loader.ReadInteger();
            int num5 = Loader.ReadInteger();
            Loader.ExpectToken(EType.CurlyBracketLeft);
            Loader.ExpectWord("triangles");
            Loader.ExpectToken(EType.CurlyBracketLeft);
            Loader.ExpectToken(EType.CurlyBracketLeft);
            for (int index = 0; index < num5; ++index)
            {
              intList2.Add(Loader.ReadInteger());
              if (Loader.PeekToken() == EType.Separator)
              {
                Loader.ExpectToken(EType.Separator);
              }
              else
              {
                Loader.ExpectToken(EType.CurlyBracketRight);
                Loader.ExpectToken(EType.Separator);
                if (index < num5 - 1)
                  Loader.ExpectToken(EType.CurlyBracketLeft);
              }
            }
            Loader.ExpectToken(EType.CurlyBracketRight);
            Loader.ExpectToken(EType.CurlyBracketRight);
            continue;
          case "groups":
            int num6 = Loader.ReadInteger();
            Loader.ReadInteger();
            Loader.ExpectToken(EType.CurlyBracketLeft);
            for (int index = 0; index < num6; ++index)
            {
              CGeosetGroup Object1 = new CGeosetGroup(Model);
              Geoset.Groups.Add(Object1);
              Loader.ExpectWord("matrices");
              Loader.ExpectToken(EType.CurlyBracketLeft);
              while (true)
              {
                CGeosetGroupNode Object2 = new CGeosetGroupNode(Model);
                Loader.Attacher.AddNode(Model, Object2.Node, Loader.ReadInteger());
                Object1.Nodes.Add(Object2);
                if (Loader.PeekToken() == EType.Separator)
                  Loader.ExpectToken(EType.Separator);
                else
                  break;
              }
              Loader.ExpectToken(EType.CurlyBracketRight);
              Loader.ExpectToken(EType.Separator);
            }
            Loader.ExpectToken(EType.CurlyBracketRight);
            continue;
          case "anim":
            float Radius2 = 0.0f;
            CVector3 Min2 = CConstants.DefaultVector3;
            CVector3 Max2 = CConstants.DefaultVector3;
            Loader.ExpectToken(EType.CurlyBracketLeft);
            while (Loader.PeekToken() != EType.CurlyBracketRight)
            {
              string str2 = Loader.ReadWord();
              switch (str2)
              {
                case "minimumextent":
                  Min2 = this.LoadVector3(Loader);
                  continue;
                case "maximumextent":
                  Max2 = this.LoadVector3(Loader);
                  continue;
                case "boundsradius":
                  Radius2 = this.LoadFloat(Loader);
                  continue;
                default:
                  throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + str2 + "\"!");
              }
            }
            int num7 = (int) Loader.ReadToken();
            Geoset.Extents.Add(new CGeosetExtent(Model)
            {
              Extent = new CExtent(Min2, Max2, Radius2)
            });
            continue;
          default:
            throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + str1 + "\"!");
        }
      }
      int num8 = (int) Loader.ReadToken();
      Geoset.Extent = new CExtent(Min1, Max1, Radius1);
      for (int index = 0; index < num1; ++index)
      {
        CGeosetVertex Object = new CGeosetVertex(Model);
        Object.Position = cvector3List1[index];
        Object.Normal = cvector3List2[index];
        Object.TexturePosition = cvector2List[index];
        Loader.Attacher.AddObject<CGeosetGroup>(Geoset.Groups, Object.Group, intList1[index]);
        Geoset.Vertices.Add(Object);
      }
      if (intList2.Count % 3 != 0)
        throw new Exception("Bad Geoset at line " + (object) Loader.Line + ", nr of indexes not divisible by 3!");
      int num9 = intList2.Count / 3;
      for (int index = 0; index < num9; ++index)
      {
        CGeosetFace Object = new CGeosetFace(Model);
        Loader.Attacher.AddObject<CGeosetVertex>(Geoset.Vertices, Object.Vertex1, intList2[index * 3]);
        Loader.Attacher.AddObject<CGeosetVertex>(Geoset.Vertices, Object.Vertex2, intList2[index * 3 + 1]);
        Loader.Attacher.AddObject<CGeosetVertex>(Geoset.Vertices, Object.Vertex3, intList2[index * 3 + 2]);
        Geoset.Faces.Add(Object);
      }
    }

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasGeosets)
        return;
      foreach (MdxLib.Model.CGeoset geoset in Model.Geosets)
        this.Save(Saver, Model, geoset);
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CGeoset Geoset)
    {
      Saver.BeginGroup(nameof (Geoset));
      if (Geoset.Vertices.Count > 0)
      {
        Saver.BeginGroup("Vertices", Geoset.Vertices.Count);
        foreach (CGeosetVertex vertex in Geoset.Vertices)
        {
          Saver.WriteTabs();
          Saver.WriteVector3(vertex.Position);
          Saver.WriteLine(",");
        }
        Saver.EndGroup();
        Saver.BeginGroup("Normals", Geoset.Vertices.Count);
        foreach (CGeosetVertex vertex in Geoset.Vertices)
        {
          Saver.WriteTabs();
          Saver.WriteVector3(vertex.Normal);
          Saver.WriteLine(",");
        }
        Saver.EndGroup();
        Saver.BeginGroup("TVertices", Geoset.Vertices.Count);
        foreach (CGeosetVertex vertex in Geoset.Vertices)
        {
          Saver.WriteTabs();
          Saver.WriteVector2(vertex.TexturePosition);
          Saver.WriteLine(",");
        }
        Saver.EndGroup();
        Saver.BeginGroup("VertexGroup");
        foreach (CGeosetVertex vertex in Geoset.Vertices)
        {
          Saver.WriteTabs();
          Saver.WriteInteger(vertex.Group.ObjectId);
          Saver.WriteLine(",");
        }
        Saver.EndGroup();
      }
      if (Geoset.Faces.Count > 0)
      {
        bool flag = true;
        Saver.BeginGroup("Faces", 1, Geoset.Faces.Count * 3);
        Saver.BeginGroup("Triangles");
        Saver.WriteTabs();
        Saver.WriteWord("{ ");
        foreach (CGeosetFace face in Geoset.Faces)
        {
          if (!flag)
            Saver.WriteWord(", ");
          Saver.WriteInteger(face.Vertex1.ObjectId);
          Saver.WriteWord(", ");
          Saver.WriteInteger(face.Vertex2.ObjectId);
          Saver.WriteWord(", ");
          Saver.WriteInteger(face.Vertex3.ObjectId);
          flag = false;
        }
        Saver.WriteLine(" },");
        Saver.EndGroup();
        Saver.EndGroup();
      }
      if (Geoset.Groups.Count > 0)
      {
        int Size2 = 0;
        foreach (CGeosetGroup group in Geoset.Groups)
          Size2 += group.Nodes.Count;
        Saver.BeginGroup("Groups", Geoset.Groups.Count, Size2);
        foreach (CGeosetGroup group in Geoset.Groups)
        {
          bool flag = true;
          Saver.WriteTabs();
          Saver.WriteWord("Matrices { ");
          foreach (CGeosetGroupNode node in group.Nodes)
          {
            if (!flag)
              Saver.WriteWord(", ");
            Saver.WriteInteger(node.Node.NodeId);
            flag = false;
          }
          Saver.WriteLine(" },");
        }
        Saver.EndGroup();
      }
      this.SaveVector3(Saver, "MinimumExtent", Geoset.Extent.Min, ECondition.NotZero);
      this.SaveVector3(Saver, "MaximumExtent", Geoset.Extent.Max, ECondition.NotZero);
      this.SaveFloat(Saver, "BoundsRadius", Geoset.Extent.Radius, ECondition.NotZero);
      foreach (CGeosetExtent extent in Geoset.Extents)
      {
        Saver.BeginGroup("Anim");
        this.SaveVector3(Saver, "MinimumExtent", extent.Extent.Min, ECondition.NotZero);
        this.SaveVector3(Saver, "MaximumExtent", extent.Extent.Max, ECondition.NotZero);
        this.SaveFloat(Saver, "BoundsRadius", extent.Extent.Radius, ECondition.NotZero);
        Saver.EndGroup();
      }
      this.SaveId(Saver, "MaterialID", Geoset.Material.ObjectId, ECondition.NotInvalidId);
      this.SaveInteger(Saver, "SelectionGroup", Geoset.SelectionGroup);
      this.SaveBoolean(Saver, "Unselectable", Geoset.Unselectable);
      Saver.EndGroup();
    }

    public static CGeoset Instance => CGeoset.CSingleton.Instance;

    private static class CSingleton
    {
      public static CGeoset Instance = new CGeoset();
    }
  }
}
