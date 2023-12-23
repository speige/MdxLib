// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdl.CGeosetAnimation
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.ModelFormats.Mdl.Token;
using MdxLib.ModelFormats.Mdl.Value;
using System;

namespace MdxLib.ModelFormats.Mdl
{
  internal sealed class CGeosetAnimation : CObject
  {
    private CGeosetAnimation()
    {
    }

    public void LoadAll(CLoader Loader, MdxLib.Model.CModel Model)
    {
      MdxLib.Model.CGeosetAnimation cgeosetAnimation = new MdxLib.Model.CGeosetAnimation(Model);
      this.Load(Loader, Model, cgeosetAnimation);
      Model.GeosetAnimations.Add(cgeosetAnimation);
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CGeosetAnimation GeosetAnimation)
    {
      Loader.ExpectToken(EType.CurlyBracketLeft);
      while (Loader.PeekToken() != EType.CurlyBracketRight)
      {
        string str1 = Loader.ReadWord();
        switch (str1)
        {
          case "static":
            string str2 = Loader.ReadWord();
            switch (str2)
            {
              case "alpha":
                this.LoadStaticAnimator<float>(Loader, Model, GeosetAnimation.Alpha, (IValue<float>) CFloat.Instance);
                continue;
              case "color":
                this.LoadStaticAnimator<MdxLib.Primitives.CVector3>(Loader, Model, GeosetAnimation.Color, (IValue<MdxLib.Primitives.CVector3>) CColor.Instance);
                GeosetAnimation.UseColor = true;
                continue;
              default:
                throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + str2 + "\"!");
            }
          case "alpha":
            this.LoadAnimator<float>(Loader, Model, GeosetAnimation.Alpha, (IValue<float>) CFloat.Instance);
            continue;
          case "color":
            this.LoadAnimator<MdxLib.Primitives.CVector3>(Loader, Model, GeosetAnimation.Color, (IValue<MdxLib.Primitives.CVector3>) CColor.Instance);
            continue;
          case "geosetid":
            Loader.Attacher.AddObject<MdxLib.Model.CGeoset>(Model.Geosets, GeosetAnimation.Geoset, this.LoadId(Loader));
            continue;
          case "dropshadow":
            GeosetAnimation.DropShadow = this.LoadBoolean(Loader);
            continue;
          default:
            throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + str1 + "\"!");
        }
      }
      int num = (int) Loader.ReadToken();
    }

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasGeosetAnimations)
        return;
      foreach (MdxLib.Model.CGeosetAnimation geosetAnimation in Model.GeosetAnimations)
        this.Save(Saver, Model, geosetAnimation);
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CGeosetAnimation GeosetAnimation)
    {
      Saver.BeginGroup("GeosetAnim");
      this.SaveAnimator<float>(Saver, Model, GeosetAnimation.Alpha, (IValue<float>) CFloat.Instance, "Alpha", ECondition.NotOne);
      if (GeosetAnimation.UseColor)
        this.SaveAnimator<MdxLib.Primitives.CVector3>(Saver, Model, GeosetAnimation.Color, (IValue<MdxLib.Primitives.CVector3>) CColor.Instance, "Color", ECondition.NotOne);
      this.SaveId(Saver, "GeosetId", GeosetAnimation.Geoset.ObjectId, ECondition.NotInvalidId);
      this.SaveBoolean(Saver, "DropShadow", GeosetAnimation.DropShadow);
      Saver.EndGroup();
    }

    public static CGeosetAnimation Instance => CGeosetAnimation.CSingleton.Instance;

    private static class CSingleton
    {
      public static CGeosetAnimation Instance = new CGeosetAnimation();
    }
  }
}
