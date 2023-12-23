// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdl.CModelInfo
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.ModelFormats.Mdl.Token;
using MdxLib.Primitives;
using System;

namespace MdxLib.ModelFormats.Mdl
{
  internal sealed class CModelInfo : CObject
  {
    private CModelInfo()
    {
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model)
    {
      float Radius = 0.0f;
      CVector3 Min = CConstants.DefaultVector3;
      CVector3 Max = CConstants.DefaultVector3;
      Model.Name = Loader.ReadString();
      Loader.ExpectToken(EType.CurlyBracketLeft);
      while (Loader.PeekToken() != EType.CurlyBracketRight)
      {
        string str = Loader.ReadWord();
        switch (str)
        {
          case "formatversion":
            Model.Version = this.LoadInteger(Loader);
            break;
          case "blendtime":
            Model.BlendTime = this.LoadInteger(Loader);
            break;
          case "minimumextent":
            Min = this.LoadVector3(Loader);
            break;
          case "maximumextent":
            Max = this.LoadVector3(Loader);
            break;
          case "boundsradius":
            Radius = this.LoadFloat(Loader);
            break;
          case "animationfile":
            Model.AnimationFile = this.LoadString(Loader);
            break;
          case "numgeosets":
            this.LoadInteger(Loader);
            break;
          case "numgeosetanims":
            this.LoadInteger(Loader);
            break;
          case "numhelpers":
            this.LoadInteger(Loader);
            break;
          case "numlights":
            this.LoadInteger(Loader);
            break;
          case "numbones":
            this.LoadInteger(Loader);
            break;
          case "numattachments":
            this.LoadInteger(Loader);
            break;
          case "numparticleemitters":
            this.LoadInteger(Loader);
            break;
          case "numparticleemitters2":
            this.LoadInteger(Loader);
            break;
          case "numribbonemitters":
            this.LoadInteger(Loader);
            break;
          case "numevents":
            this.LoadInteger(Loader);
            break;
          default:
            throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + str + "\"!");
        }
        Model.Extent = new CExtent(Min, Max, Radius);
      }
      int num = (int) Loader.ReadToken();
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model)
    {
      Saver.BeginGroup(nameof (Model), Model.Name);
      this.SaveInteger(Saver, "NumGeosets", Model.Geosets.Count, ECondition.NotZero);
      this.SaveInteger(Saver, "NumGeosetAnims", Model.GeosetAnimations.Count, ECondition.NotZero);
      this.SaveInteger(Saver, "NumHelpers", Model.Helpers.Count, ECondition.NotZero);
      this.SaveInteger(Saver, "NumLights", Model.Lights.Count, ECondition.NotZero);
      this.SaveInteger(Saver, "NumBones", Model.Bones.Count, ECondition.NotZero);
      this.SaveInteger(Saver, "NumAttachments", Model.Attachments.Count, ECondition.NotZero);
      this.SaveInteger(Saver, "NumParticleEmitters", Model.ParticleEmitters.Count, ECondition.NotZero);
      this.SaveInteger(Saver, "NumParticleEmitters2", Model.ParticleEmitters2.Count, ECondition.NotZero);
      this.SaveInteger(Saver, "NumRibbonEmitters", Model.RibbonEmitters.Count, ECondition.NotZero);
      this.SaveInteger(Saver, "NumEvents", Model.Events.Count, ECondition.NotZero);
      this.SaveInteger(Saver, "BlendTime", Model.BlendTime);
      this.SaveVector3(Saver, "MinimumExtent", Model.Extent.Min, ECondition.NotZero);
      this.SaveVector3(Saver, "MaximumExtent", Model.Extent.Max, ECondition.NotZero);
      this.SaveFloat(Saver, "BoundsRadius", Model.Extent.Radius, ECondition.NotZero);
      this.SaveString(Saver, "AnimationFile", Model.AnimationFile, ECondition.NotEmpty);
      Saver.EndGroup();
    }

    public static CModelInfo Instance => CModelInfo.CSingleton.Instance;

    private static class CSingleton
    {
      public static CModelInfo Instance = new CModelInfo();
    }
  }
}
