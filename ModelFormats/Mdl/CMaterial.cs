// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdl.CMaterial
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using MdxLib.ModelFormats.Mdl.Token;
using MdxLib.ModelFormats.Mdl.Value;
using System;

namespace MdxLib.ModelFormats.Mdl
{
  internal sealed class CMaterial : CObject
  {
    private CMaterial()
    {
    }

    public void LoadAll(CLoader Loader, MdxLib.Model.CModel Model)
    {
      Loader.ReadInteger();
      Loader.ExpectToken(EType.CurlyBracketLeft);
      while (Loader.PeekToken() != EType.CurlyBracketRight)
      {
        string str = Loader.ReadWord();
        switch (str)
        {
          case "material":
            MdxLib.Model.CMaterial cmaterial = new MdxLib.Model.CMaterial(Model);
            this.Load(Loader, Model, cmaterial);
            Model.Materials.Add(cmaterial);
            continue;
          default:
            throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + str + "\"!");
        }
      }
      int num = (int) Loader.ReadToken();
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CMaterial Material)
    {
      Loader.ExpectToken(EType.CurlyBracketLeft);
      while (Loader.PeekToken() != EType.CurlyBracketRight)
      {
        string str1 = Loader.ReadWord();
        switch (str1)
        {
          case "priorityplane":
            Material.PriorityPlane = this.LoadInteger(Loader);
            continue;
          case "constantcolor":
            Material.ConstantColor = this.LoadBoolean(Loader);
            continue;
          case "sortprimsnearz":
            Material.SortPrimitivesNearZ = this.LoadBoolean(Loader);
            continue;
          case "sortprimsfarz":
            Material.SortPrimitivesFarZ = this.LoadBoolean(Loader);
            continue;
          case "fullresolution":
            Material.FullResolution = this.LoadBoolean(Loader);
            continue;
          case "layer":
            CMaterialLayer Object = new CMaterialLayer(Model);
            Loader.ExpectToken(EType.CurlyBracketLeft);
            while (Loader.PeekToken() != EType.CurlyBracketRight)
            {
              string str2 = Loader.ReadWord();
              switch (str2)
              {
                case "static":
                  string str3 = Loader.ReadWord();
                  switch (str3)
                  {
                    case "textureid":
                      this.LoadStaticAnimator<int>(Loader, Model, Object.TextureId, (IValue<int>) CInteger.Instance);
                      Loader.Attacher.AddObject<MdxLib.Model.CTexture>(Model.Textures, Object.Texture, Object.TextureId.GetValue());
                      continue;
                    case "alpha":
                      this.LoadStaticAnimator<float>(Loader, Model, Object.Alpha, (IValue<float>) CFloat.Instance);
                      continue;
                    default:
                      throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + str3 + "\"!");
                  }
                case "textureid":
                  this.LoadAnimator<int>(Loader, Model, Object.TextureId, (IValue<int>) CInteger.Instance);
                  continue;
                case "alpha":
                  this.LoadAnimator<float>(Loader, Model, Object.Alpha, (IValue<float>) CFloat.Instance);
                  continue;
                case "tvertexanimid":
                  Loader.Attacher.AddObject<MdxLib.Model.CTextureAnimation>(Model.TextureAnimations, Object.TextureAnimation, this.LoadInteger(Loader));
                  continue;
                case "coordid":
                  Object.CoordId = this.LoadInteger(Loader);
                  continue;
                case "twosided":
                  Object.TwoSided = this.LoadBoolean(Loader);
                  continue;
                case "unshaded":
                  Object.Unshaded = this.LoadBoolean(Loader);
                  continue;
                case "unfogged":
                  Object.Unfogged = this.LoadBoolean(Loader);
                  continue;
                case "sphereenvmap":
                  Object.SphereEnvironmentMap = this.LoadBoolean(Loader);
                  continue;
                case "nodepthtest":
                  Object.NoDepthTest = this.LoadBoolean(Loader);
                  continue;
                case "nodepthset":
                  Object.NoDepthSet = this.LoadBoolean(Loader);
                  continue;
                case "filtermode":
                  Object.FilterMode = this.StringToFilterMode(this.LoadWord(Loader));
                  continue;
                default:
                  throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + str2 + "\"!");
              }
            }
            int num = (int) Loader.ReadToken();
            Material.Layers.Add(Object);
            continue;
          default:
            throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + str1 + "\"!");
        }
      }
      int num1 = (int) Loader.ReadToken();
    }

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasMaterials)
        return;
      Saver.BeginGroup("Materials", Model.Materials.Count);
      foreach (MdxLib.Model.CMaterial material in Model.Materials)
        this.Save(Saver, Model, material);
      Saver.EndGroup();
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CMaterial Material)
    {
      Saver.BeginGroup(nameof (Material));
      this.SaveBoolean(Saver, "ConstantColor", Material.ConstantColor);
      this.SaveBoolean(Saver, "SortPrimsNearZ", Material.SortPrimitivesNearZ);
      this.SaveBoolean(Saver, "SortPrimsFarZ", Material.SortPrimitivesFarZ);
      this.SaveBoolean(Saver, "FullResolution", Material.FullResolution);
      this.SaveInteger(Saver, "PriorityPlane", Material.PriorityPlane, ECondition.NotZero);
      foreach (CMaterialLayer layer in Material.Layers)
      {
        Saver.BeginGroup("Layer");
        Saver.WriteTabs();
        Saver.WriteWord("FilterMode ");
        Saver.WriteWord(this.FilterModeToString(layer.FilterMode));
        Saver.WriteLine(",");
        if (layer.TextureId.Animated)
          this.SaveAnimator<int>(Saver, Model, layer.TextureId, (IValue<int>) CInteger.Instance, "TextureID");
        else
          this.SaveId(Saver, "static TextureID", layer.Texture.ObjectId, ECondition.NotInvalidId);
        this.SaveAnimator<float>(Saver, Model, layer.Alpha, (IValue<float>) CFloat.Instance, "Alpha", ECondition.NotOne);
        this.SaveBoolean(Saver, "TwoSided", layer.TwoSided);
        this.SaveBoolean(Saver, "Unshaded", layer.Unshaded);
        this.SaveBoolean(Saver, "Unfogged", layer.Unfogged);
        this.SaveBoolean(Saver, "SphereEnvMap", layer.SphereEnvironmentMap);
        this.SaveBoolean(Saver, "NoDepthTest", layer.NoDepthTest);
        this.SaveBoolean(Saver, "NoDepthSet", layer.NoDepthSet);
        this.SaveId(Saver, "TVertexAnimId", layer.TextureAnimation.ObjectId, ECondition.NotInvalidId);
        this.SaveInteger(Saver, "CoordId", layer.CoordId, ECondition.NotZero);
        Saver.EndGroup();
      }
      Saver.EndGroup();
    }

    private string FilterModeToString(EMaterialLayerFilterMode FilterMode)
    {
      switch (FilterMode)
      {
        case EMaterialLayerFilterMode.None:
          return "None";
        case EMaterialLayerFilterMode.Transparent:
          return "Transparent";
        case EMaterialLayerFilterMode.Blend:
          return "Blend";
        case EMaterialLayerFilterMode.Additive:
          return "Additive";
        case EMaterialLayerFilterMode.AdditiveAlpha:
          return "AddAlpha";
        case EMaterialLayerFilterMode.Modulate:
          return "Modulate";
        case EMaterialLayerFilterMode.Modulate2x:
          return "Modulate2x";
        default:
          return "";
      }
    }

    private EMaterialLayerFilterMode StringToFilterMode(string String)
    {
      switch (String)
      {
        case "none":
          return EMaterialLayerFilterMode.None;
        case "transparent":
          return EMaterialLayerFilterMode.Transparent;
        case "blend":
          return EMaterialLayerFilterMode.Blend;
        case "additive":
          return EMaterialLayerFilterMode.Additive;
        case "addalpha":
          return EMaterialLayerFilterMode.AdditiveAlpha;
        case "modulate":
          return EMaterialLayerFilterMode.Modulate;
        case "modulate2x":
          return EMaterialLayerFilterMode.Modulate2x;
        default:
          return EMaterialLayerFilterMode.None;
      }
    }

    public static CMaterial Instance => CMaterial.CSingleton.Instance;

    private static class CSingleton
    {
      public static CMaterial Instance = new CMaterial();
    }
  }
}
