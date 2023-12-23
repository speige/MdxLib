// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdx.CRibbonEmitter
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using MdxLib.ModelFormats.Mdx.Value;
using System;

namespace MdxLib.ModelFormats.Mdx
{
  internal sealed class CRibbonEmitter : CNode
  {
    private CRibbonEmitter()
    {
    }

    public void LoadAll(CLoader Loader, MdxLib.Model.CModel Model)
    {
      int num = Loader.ReadInt32();
      while (num > 0)
      {
        Loader.PushLocation();
        MdxLib.Model.CRibbonEmitter cribbonEmitter = new MdxLib.Model.CRibbonEmitter(Model);
        this.Load(Loader, Model, cribbonEmitter);
        Model.RibbonEmitters.Add(cribbonEmitter);
        num -= Loader.PopLocation();
        if (num < 0)
          throw new Exception("Error at location " + (object) Loader.Location + ", too many RibbonEmitter bytes were read!");
      }
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CRibbonEmitter RibbonEmitter)
    {
      Loader.PushLocation();
      int num1 = Loader.ReadInt32();
      CNode.LoadNode<MdxLib.Model.CRibbonEmitter>(Loader, Model, (CNode<MdxLib.Model.CRibbonEmitter>) RibbonEmitter);
      RibbonEmitter.HeightAbove.MakeStatic(Loader.ReadFloat());
      RibbonEmitter.HeightBelow.MakeStatic(Loader.ReadFloat());
      RibbonEmitter.Alpha.MakeStatic(Loader.ReadFloat());
      RibbonEmitter.Color.MakeStatic(Loader.ReadVector3());
      RibbonEmitter.LifeSpan = Loader.ReadFloat();
      RibbonEmitter.TextureSlot.MakeStatic(Loader.ReadInt32());
      RibbonEmitter.EmissionRate = Loader.ReadInt32();
      RibbonEmitter.Rows = Loader.ReadInt32();
      RibbonEmitter.Columns = Loader.ReadInt32();
      Loader.Attacher.AddObject<MdxLib.Model.CMaterial>(Model.Materials, RibbonEmitter.Material, Loader.ReadInt32());
      RibbonEmitter.Gravity = Loader.ReadFloat();
      int num2 = num1 - Loader.PopLocation();
      if (num2 < 0)
        throw new Exception("Error at location " + (object) Loader.Location + ", too many RibbonEmitter bytes were read!");
      while (num2 > 0)
      {
        Loader.PushLocation();
        string str = Loader.ReadTag();
        switch (str)
        {
          case "KRHA":
            CObject.LoadAnimator<float>(Loader, Model, RibbonEmitter.HeightAbove, (IValue<float>) CFloat.Instance);
            break;
          case "KRHB":
            CObject.LoadAnimator<float>(Loader, Model, RibbonEmitter.HeightBelow, (IValue<float>) CFloat.Instance);
            break;
          case "KRAL":
            CObject.LoadAnimator<float>(Loader, Model, RibbonEmitter.Alpha, (IValue<float>) CFloat.Instance);
            break;
          case "KRCO":
            CObject.LoadAnimator<MdxLib.Primitives.CVector3>(Loader, Model, RibbonEmitter.Color, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdx.Value.CVector3.Instance);
            break;
          case "KRTX":
            CObject.LoadAnimator<int>(Loader, Model, RibbonEmitter.TextureSlot, (IValue<int>) CInteger.Instance);
            break;
          case "KRVS":
            CObject.LoadAnimator<float>(Loader, Model, RibbonEmitter.Visibility, (IValue<float>) CFloat.Instance);
            break;
          default:
            throw new Exception("Error at location " + (object) Loader.Location + ", unknown RibbonEmitter tag \"" + str + "\"!");
        }
        num2 -= Loader.PopLocation();
        if (num2 < 0)
          throw new Exception("Error at location " + (object) Loader.Location + ", too many RibbonEmitter bytes were read!");
      }
    }

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasRibbonEmitters)
        return;
      Saver.WriteTag("RIBB");
      Saver.PushLocation();
      foreach (MdxLib.Model.CRibbonEmitter ribbonEmitter in Model.RibbonEmitters)
        this.Save(Saver, Model, ribbonEmitter);
      Saver.PopExclusiveLocation();
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CRibbonEmitter RibbonEmitter)
    {
      Saver.PushLocation();
      CNode.SaveNode<MdxLib.Model.CRibbonEmitter>(Saver, Model, (CNode<MdxLib.Model.CRibbonEmitter>) RibbonEmitter, 16384);
      Saver.WriteFloat(RibbonEmitter.HeightAbove.GetValue());
      Saver.WriteFloat(RibbonEmitter.HeightBelow.GetValue());
      Saver.WriteFloat(RibbonEmitter.Alpha.GetValue());
      Saver.WriteVector3(RibbonEmitter.Color.GetValue());
      Saver.WriteFloat(RibbonEmitter.LifeSpan);
      Saver.WriteInt32(RibbonEmitter.TextureSlot.GetValue());
      Saver.WriteInt32(RibbonEmitter.EmissionRate);
      Saver.WriteInt32(RibbonEmitter.Rows);
      Saver.WriteInt32(RibbonEmitter.Columns);
      Saver.WriteInt32(RibbonEmitter.Material.ObjectId);
      Saver.WriteFloat(RibbonEmitter.Gravity);
      CObject.SaveAnimator<float>(Saver, Model, RibbonEmitter.HeightAbove, (IValue<float>) CFloat.Instance, "KRHA");
      CObject.SaveAnimator<float>(Saver, Model, RibbonEmitter.HeightBelow, (IValue<float>) CFloat.Instance, "KRHB");
      CObject.SaveAnimator<float>(Saver, Model, RibbonEmitter.Alpha, (IValue<float>) CFloat.Instance, "KRAL");
      CObject.SaveAnimator<MdxLib.Primitives.CVector3>(Saver, Model, RibbonEmitter.Color, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdx.Value.CVector3.Instance, "KRCO");
      CObject.SaveAnimator<int>(Saver, Model, RibbonEmitter.TextureSlot, (IValue<int>) CInteger.Instance, "KRTX");
      CObject.SaveAnimator<float>(Saver, Model, RibbonEmitter.Visibility, (IValue<float>) CFloat.Instance, "KRVS");
      Saver.PopInclusiveLocation();
    }

    public static CRibbonEmitter Instance => CRibbonEmitter.CSingleton.Instance;

    private static class CSingleton
    {
      public static CRibbonEmitter Instance = new CRibbonEmitter();
    }
  }
}
