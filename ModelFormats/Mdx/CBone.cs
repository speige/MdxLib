// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdx.CBone
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using System;

namespace MdxLib.ModelFormats.Mdx
{
  internal sealed class CBone : CNode
  {
    private CBone()
    {
    }

    public void LoadAll(CLoader Loader, MdxLib.Model.CModel Model)
    {
      int num = Loader.ReadInt32();
      while (num > 0)
      {
        Loader.PushLocation();
        MdxLib.Model.CBone cbone = new MdxLib.Model.CBone(Model);
        this.Load(Loader, Model, cbone);
        Model.Bones.Add(cbone);
        num -= Loader.PopLocation();
        if (num < 0)
          throw new Exception("Error at location " + (object) Loader.Location + ", too many Bone bytes were read!");
      }
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CBone Bone)
    {
      CNode.LoadNode<MdxLib.Model.CBone>(Loader, Model, (CNode<MdxLib.Model.CBone>) Bone);
      Loader.Attacher.AddObject<MdxLib.Model.CGeoset>(Model.Geosets, Bone.Geoset, Loader.ReadInt32());
      Loader.Attacher.AddObject<MdxLib.Model.CGeosetAnimation>(Model.GeosetAnimations, Bone.GeosetAnimation, Loader.ReadInt32());
    }

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasBones)
        return;
      Saver.WriteTag("BONE");
      Saver.PushLocation();
      foreach (MdxLib.Model.CBone bone in Model.Bones)
        this.Save(Saver, Model, bone);
      Saver.PopExclusiveLocation();
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CBone Bone)
    {
      CNode.SaveNode<MdxLib.Model.CBone>(Saver, Model, (CNode<MdxLib.Model.CBone>) Bone, 256);
      Saver.WriteInt32(Bone.Geoset.ObjectId);
      Saver.WriteInt32(Bone.GeosetAnimation.ObjectId);
    }

    public static CBone Instance => CBone.CSingleton.Instance;

    private static class CSingleton
    {
      public static CBone Instance = new CBone();
    }
  }
}
