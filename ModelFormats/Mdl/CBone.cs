// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdl.CBone
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using MdxLib.ModelFormats.Mdl.Token;
using System;

namespace MdxLib.ModelFormats.Mdl
{
  internal sealed class CBone : CNode
  {
    private CBone()
    {
    }

    public void LoadAll(CLoader Loader, MdxLib.Model.CModel Model)
    {
      MdxLib.Model.CBone cbone = new MdxLib.Model.CBone(Model);
      this.Load(Loader, Model, cbone);
      Model.Bones.Add(cbone);
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CBone Bone)
    {
      Bone.Name = Loader.ReadString();
      Loader.ExpectToken(EType.CurlyBracketLeft);
      while (Loader.PeekToken() != EType.CurlyBracketRight)
      {
        string Tag1 = Loader.ReadWord();
        if (!this.LoadNode<MdxLib.Model.CBone>(Loader, Model, (CNode<MdxLib.Model.CBone>) Bone, Tag1))
        {
          switch (Tag1)
          {
            case "static":
              string Tag2 = Loader.ReadWord();
              if (!this.LoadStaticNode<MdxLib.Model.CBone>(Loader, Model, (CNode<MdxLib.Model.CBone>) Bone, Tag2))
                throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + Tag2 + "\"!");
              continue;
            case "geosetid":
              Loader.Attacher.AddObject<MdxLib.Model.CGeoset>(Model.Geosets, Bone.Geoset, this.LoadId(Loader));
              continue;
            case "geosetanimid":
              Loader.Attacher.AddObject<MdxLib.Model.CGeosetAnimation>(Model.GeosetAnimations, Bone.GeosetAnimation, this.LoadId(Loader));
              continue;
            default:
              throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + Tag1 + "\"!");
          }
        }
      }
      int num = (int) Loader.ReadToken();
    }

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasBones)
        return;
      foreach (MdxLib.Model.CBone bone in Model.Bones)
        this.Save(Saver, Model, bone);
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CBone Bone)
    {
      Saver.BeginGroup(nameof (Bone), Bone.Name);
      this.SaveNode<MdxLib.Model.CBone>(Saver, Model, (CNode<MdxLib.Model.CBone>) Bone);
      this.SaveId(Saver, "GeosetId", Bone.Geoset.ObjectId, true);
      this.SaveId(Saver, "GeosetAnimId", Bone.GeosetAnimation.ObjectId, false);
      Saver.EndGroup();
    }

    public static CBone Instance => CBone.CSingleton.Instance;

    private static class CSingleton
    {
      public static CBone Instance = new CBone();
    }
  }
}
