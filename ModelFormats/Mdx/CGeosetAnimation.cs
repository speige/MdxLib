// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdx.CGeosetAnimation
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.ModelFormats.Mdx.Value;
using System;

namespace MdxLib.ModelFormats.Mdx
{
  internal sealed class CGeosetAnimation : CObject
  {
    private CGeosetAnimation()
    {
    }

    public void LoadAll(CLoader Loader, MdxLib.Model.CModel Model)
    {
      int num = Loader.ReadInt32();
      while (num > 0)
      {
        Loader.PushLocation();
        MdxLib.Model.CGeosetAnimation cgeosetAnimation = new MdxLib.Model.CGeosetAnimation(Model);
        this.Load(Loader, Model, cgeosetAnimation);
        Model.GeosetAnimations.Add(cgeosetAnimation);
        num -= Loader.PopLocation();
        if (num < 0)
          throw new Exception("Error at location " + (object) Loader.Location + ", too many GeosetAnimation bytes were read!");
      }
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CGeosetAnimation GeosetAnimation)
    {
      Loader.PushLocation();
      int num1 = Loader.ReadInt32();
      GeosetAnimation.Alpha.MakeStatic(Loader.ReadFloat());
      int num2 = Loader.ReadInt32();
      GeosetAnimation.Color.MakeStatic(Loader.ReadVector3());
      Loader.Attacher.AddObject<MdxLib.Model.CGeoset>(Model.Geosets, GeosetAnimation.Geoset, Loader.ReadInt32());
      GeosetAnimation.DropShadow = (num2 & 1) != 0;
      GeosetAnimation.UseColor = (num2 & 2) != 0;
      int num3 = num1 - Loader.PopLocation();
      if (num3 < 0)
        throw new Exception("Error at location " + (object) Loader.Location + ", too many GeosetAnimation bytes were read!");
      while (num3 > 0)
      {
        Loader.PushLocation();
        string str = Loader.ReadTag();
        switch (str)
        {
          case "KGAO":
            CObject.LoadAnimator<float>(Loader, Model, GeosetAnimation.Alpha, (IValue<float>) CFloat.Instance);
            break;
          case "KGAC":
            CObject.LoadAnimator<MdxLib.Primitives.CVector3>(Loader, Model, GeosetAnimation.Color, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdx.Value.CVector3.Instance);
            break;
          default:
            throw new Exception("Error at location " + (object) Loader.Location + ", unknown GeosetAnimation tag \"" + str + "\"!");
        }
        num3 -= Loader.PopLocation();
        if (num3 < 0)
          throw new Exception("Error at location " + (object) Loader.Location + ", too many GeosetAnimation bytes were read!");
      }
    }

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasGeosetAnimations)
        return;
      Saver.WriteTag("GEOA");
      Saver.PushLocation();
      foreach (MdxLib.Model.CGeosetAnimation geosetAnimation in Model.GeosetAnimations)
        this.Save(Saver, Model, geosetAnimation);
      Saver.PopExclusiveLocation();
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CGeosetAnimation GeosetAnimation)
    {
      int num = 0;
      if (GeosetAnimation.DropShadow)
        num |= 1;
      if (GeosetAnimation.UseColor)
        num |= 2;
      Saver.PushLocation();
      Saver.WriteFloat(GeosetAnimation.Alpha.GetValue());
      Saver.WriteInt32(num);
      Saver.WriteVector3(GeosetAnimation.Color.GetValue());
      Saver.WriteInt32(GeosetAnimation.Geoset.ObjectId);
      CObject.SaveAnimator<float>(Saver, Model, GeosetAnimation.Alpha, (IValue<float>) CFloat.Instance, "KGAO");
      CObject.SaveAnimator<MdxLib.Primitives.CVector3>(Saver, Model, GeosetAnimation.Color, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdx.Value.CVector3.Instance, "KGAC");
      Saver.PopInclusiveLocation();
    }

    public static CGeosetAnimation Instance => CGeosetAnimation.CSingleton.Instance;

    private static class CSingleton
    {
      public static CGeosetAnimation Instance = new CGeosetAnimation();
    }
  }
}
