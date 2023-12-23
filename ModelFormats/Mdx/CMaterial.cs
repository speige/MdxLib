// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdx.CMaterial
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using MdxLib.ModelFormats.Mdx.Value;
using System;

namespace MdxLib.ModelFormats.Mdx
{
  internal sealed class CMaterial : CObject
  {
    private CMaterial()
    {
    }

    public void LoadAll(CLoader Loader, MdxLib.Model.CModel Model)
    {
      int num = Loader.ReadInt32();
      while (num > 0)
      {
        Loader.PushLocation();
        MdxLib.Model.CMaterial cmaterial = new MdxLib.Model.CMaterial(Model);
        this.Load(Loader, Model, cmaterial);
        Model.Materials.Add(cmaterial);
        num -= Loader.PopLocation();
        if (num < 0)
          throw new Exception("Error at location " + (object) Loader.Location + ", too many Material bytes were read!");
      }
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CMaterial Material)
    {
      Loader.PushLocation();
      int num1 = Loader.ReadInt32();
      Material.PriorityPlane = Loader.ReadInt32();
      int num2 = Loader.ReadInt32();
      Material.ConstantColor = (num2 & 1) != 0;
      Material.SortPrimitivesNearZ = (num2 & 8) != 0;
      Material.SortPrimitivesFarZ = (num2 & 16) != 0;
      Material.FullResolution = (num2 & 32) != 0;
      if (num1 - Loader.PopLocation() < 0)
        throw new Exception("Error at location " + (object) Loader.Location + ", too many Material bytes were read!");
      Loader.ExpectTag("LAYS");
      int num3 = Loader.ReadInt32();
      for (int index = 0; index < num3; ++index)
      {
        CMaterialLayer cmaterialLayer = new CMaterialLayer(Model);
        this.LoadLayer(Loader, Model, Material, cmaterialLayer);
        Material.Layers.Add(cmaterialLayer);
      }
    }

    public void LoadLayer(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CMaterial Material, CMaterialLayer Layer)
    {
      Loader.PushLocation();
      int num1 = Loader.ReadInt32();
      int num2 = Loader.ReadInt32();
      int num3 = Loader.ReadInt32();
      int num4 = Loader.ReadInt32();
      Layer.TextureId.MakeStatic(num4);
      Loader.Attacher.AddObject<MdxLib.Model.CTexture>(Model.Textures, Layer.Texture, num4);
      Loader.Attacher.AddObject<MdxLib.Model.CTextureAnimation>(Model.TextureAnimations, Layer.TextureAnimation, Loader.ReadInt32());
      Layer.CoordId = Loader.ReadInt32();
      Layer.Alpha.MakeStatic(Loader.ReadFloat());
      switch (num2)
      {
        case 0:
          Layer.FilterMode = EMaterialLayerFilterMode.None;
          break;
        case 1:
          Layer.FilterMode = EMaterialLayerFilterMode.Transparent;
          break;
        case 2:
          Layer.FilterMode = EMaterialLayerFilterMode.Blend;
          break;
        case 3:
          Layer.FilterMode = EMaterialLayerFilterMode.Additive;
          break;
        case 4:
          Layer.FilterMode = EMaterialLayerFilterMode.AdditiveAlpha;
          break;
        case 5:
          Layer.FilterMode = EMaterialLayerFilterMode.Modulate;
          break;
        case 6:
          Layer.FilterMode = EMaterialLayerFilterMode.Modulate2x;
          break;
      }
      Layer.Unshaded = (num3 & 1) != 0;
      Layer.SphereEnvironmentMap = (num3 & 2) != 0;
      Layer.TwoSided = (num3 & 16) != 0;
      Layer.Unfogged = (num3 & 32) != 0;
      Layer.NoDepthTest = (num3 & 64) != 0;
      Layer.NoDepthSet = (num3 & 128) != 0;
      int num5 = num1 - Loader.PopLocation();
      if (num5 < 0)
        throw new Exception("Error at location " + (object) Loader.Location + ", too many MaterialLayer bytes were read!");
      while (num5 > 0)
      {
        Loader.PushLocation();
        string str = Loader.ReadTag();
        switch (str)
        {
          case "KMTF":
            CObject.LoadAnimator<int>(Loader, Model, Layer.TextureId, (IValue<int>) CInteger.Instance);
            break;
          case "KMTA":
            CObject.LoadAnimator<float>(Loader, Model, Layer.Alpha, (IValue<float>) CFloat.Instance);
            break;
          default:
            throw new Exception("Error at location " + (object) Loader.Location + ", unknown MaterialLayer tag \"" + str + "\"!");
        }
        num5 -= Loader.PopLocation();
        if (num5 < 0)
          throw new Exception("Error at location " + (object) Loader.Location + ", too many MaterialLayer bytes were read!");
      }
    }

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasMaterials)
        return;
      Saver.WriteTag("MTLS");
      Saver.PushLocation();
      foreach (MdxLib.Model.CMaterial material in Model.Materials)
        this.Save(Saver, Model, material);
      Saver.PopExclusiveLocation();
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CMaterial Material)
    {
      int num = 0;
      if (Material.ConstantColor)
        num |= 1;
      if (Material.SortPrimitivesNearZ)
        num |= 8;
      if (Material.SortPrimitivesFarZ)
        num |= 16;
      if (Material.FullResolution)
        num |= 32;
      Saver.PushLocation();
      Saver.WriteInt32(Material.PriorityPlane);
      Saver.WriteInt32(num);
      Saver.WriteTag("LAYS");
      Saver.WriteInt32(Material.Layers.Count);
      foreach (CMaterialLayer layer in Material.Layers)
        this.SaveLayer(Saver, Model, Material, layer);
      Saver.PopInclusiveLocation();
    }

    public void SaveLayer(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CMaterial Material, CMaterialLayer Layer)
    {
      int num1 = 0;
      int num2 = 0;
      if (Layer.Unshaded)
        num1 |= 1;
      if (Layer.SphereEnvironmentMap)
        num1 |= 2;
      if (Layer.TwoSided)
        num1 |= 16;
      if (Layer.Unfogged)
        num1 |= 32;
      if (Layer.NoDepthTest)
        num1 |= 64;
      if (Layer.NoDepthSet)
        num1 |= 128;
      switch (Layer.FilterMode)
      {
        case EMaterialLayerFilterMode.None:
          num2 = 0;
          break;
        case EMaterialLayerFilterMode.Transparent:
          num2 = 1;
          break;
        case EMaterialLayerFilterMode.Blend:
          num2 = 2;
          break;
        case EMaterialLayerFilterMode.Additive:
          num2 = 3;
          break;
        case EMaterialLayerFilterMode.AdditiveAlpha:
          num2 = 4;
          break;
        case EMaterialLayerFilterMode.Modulate:
          num2 = 5;
          break;
        case EMaterialLayerFilterMode.Modulate2x:
          num2 = 6;
          break;
      }
      Saver.PushLocation();
      Saver.WriteInt32(num2);
      Saver.WriteInt32(num1);
      Saver.WriteInt32(Layer.Texture.ObjectId);
      Saver.WriteInt32(Layer.TextureAnimation.ObjectId);
      Saver.WriteInt32(Layer.CoordId);
      Saver.WriteFloat(Layer.Alpha.GetValue());
      CObject.SaveAnimator<int>(Saver, Model, Layer.TextureId, (IValue<int>) CInteger.Instance, "KMTF");
      CObject.SaveAnimator<float>(Saver, Model, Layer.Alpha, (IValue<float>) CFloat.Instance, "KMTA");
      Saver.PopInclusiveLocation();
    }

    public static CMaterial Instance => CMaterial.CSingleton.Instance;

    private static class CSingleton
    {
      public static CMaterial Instance = new CMaterial();
    }
  }
}
