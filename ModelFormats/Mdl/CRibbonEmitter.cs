// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdl.CRibbonEmitter
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using MdxLib.ModelFormats.Mdl.Token;
using MdxLib.ModelFormats.Mdl.Value;
using System;

namespace MdxLib.ModelFormats.Mdl
{
  internal sealed class CRibbonEmitter : CNode
  {
    private CRibbonEmitter()
    {
    }

    public void LoadAll(CLoader Loader, MdxLib.Model.CModel Model)
    {
      MdxLib.Model.CRibbonEmitter cribbonEmitter = new MdxLib.Model.CRibbonEmitter(Model);
      this.Load(Loader, Model, cribbonEmitter);
      Model.RibbonEmitters.Add(cribbonEmitter);
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CRibbonEmitter RibbonEmitter)
    {
      RibbonEmitter.Name = Loader.ReadString();
      Loader.ExpectToken(EType.CurlyBracketLeft);
      while (Loader.PeekToken() != EType.CurlyBracketRight)
      {
        string Tag1 = Loader.ReadWord();
        if (!this.LoadNode<MdxLib.Model.CRibbonEmitter>(Loader, Model, (CNode<MdxLib.Model.CRibbonEmitter>) RibbonEmitter, Tag1))
        {
          switch (Tag1)
          {
            case "static":
              string Tag2 = Loader.ReadWord();
              if (!this.LoadStaticNode<MdxLib.Model.CRibbonEmitter>(Loader, Model, (CNode<MdxLib.Model.CRibbonEmitter>) RibbonEmitter, Tag2))
              {
                switch (Tag2)
                {
                  case "heightabove":
                    this.LoadStaticAnimator<float>(Loader, Model, RibbonEmitter.HeightAbove, (IValue<float>) CFloat.Instance);
                    continue;
                  case "heightbelow":
                    this.LoadStaticAnimator<float>(Loader, Model, RibbonEmitter.HeightBelow, (IValue<float>) CFloat.Instance);
                    continue;
                  case "alpha":
                    this.LoadStaticAnimator<float>(Loader, Model, RibbonEmitter.Alpha, (IValue<float>) CFloat.Instance);
                    continue;
                  case "color":
                    this.LoadStaticAnimator<MdxLib.Primitives.CVector3>(Loader, Model, RibbonEmitter.Color, (IValue<MdxLib.Primitives.CVector3>) CColor.Instance);
                    continue;
                  case "textureslot":
                    this.LoadStaticAnimator<int>(Loader, Model, RibbonEmitter.TextureSlot, (IValue<int>) CInteger.Instance);
                    continue;
                  case "visibility":
                    this.LoadStaticAnimator<float>(Loader, Model, RibbonEmitter.Visibility, (IValue<float>) CFloat.Instance);
                    continue;
                  default:
                    throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + Tag2 + "\"!");
                }
              }
              else
                continue;
            case "heightabove":
              this.LoadAnimator<float>(Loader, Model, RibbonEmitter.HeightAbove, (IValue<float>) CFloat.Instance);
              continue;
            case "heightbelow":
              this.LoadAnimator<float>(Loader, Model, RibbonEmitter.HeightBelow, (IValue<float>) CFloat.Instance);
              continue;
            case "alpha":
              this.LoadAnimator<float>(Loader, Model, RibbonEmitter.Alpha, (IValue<float>) CFloat.Instance);
              continue;
            case "color":
              this.LoadAnimator<MdxLib.Primitives.CVector3>(Loader, Model, RibbonEmitter.Color, (IValue<MdxLib.Primitives.CVector3>) CColor.Instance);
              continue;
            case "textureslot":
              this.LoadAnimator<int>(Loader, Model, RibbonEmitter.TextureSlot, (IValue<int>) CInteger.Instance);
              continue;
            case "visibility":
              this.LoadAnimator<float>(Loader, Model, RibbonEmitter.Visibility, (IValue<float>) CFloat.Instance);
              continue;
            case "emissionrate":
              RibbonEmitter.EmissionRate = this.LoadInteger(Loader);
              continue;
            case "lifespan":
              RibbonEmitter.LifeSpan = this.LoadFloat(Loader);
              continue;
            case "gravity":
              RibbonEmitter.Gravity = this.LoadFloat(Loader);
              continue;
            case "rows":
              RibbonEmitter.Rows = this.LoadInteger(Loader);
              continue;
            case "columns":
              RibbonEmitter.Columns = this.LoadInteger(Loader);
              continue;
            case "materialid":
              Loader.Attacher.AddObject<MdxLib.Model.CMaterial>(Model.Materials, RibbonEmitter.Material, this.LoadId(Loader));
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
      if (!Model.HasRibbonEmitters)
        return;
      foreach (MdxLib.Model.CRibbonEmitter ribbonEmitter in Model.RibbonEmitters)
        this.Save(Saver, Model, ribbonEmitter);
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CRibbonEmitter RibbonEmitter)
    {
      Saver.BeginGroup(nameof (RibbonEmitter), RibbonEmitter.Name);
      this.SaveNode<MdxLib.Model.CRibbonEmitter>(Saver, Model, (CNode<MdxLib.Model.CRibbonEmitter>) RibbonEmitter);
      this.SaveInteger(Saver, "EmissionRate", RibbonEmitter.EmissionRate);
      this.SaveFloat(Saver, "LifeSpan", RibbonEmitter.LifeSpan);
      this.SaveFloat(Saver, "Gravity", RibbonEmitter.Gravity, ECondition.NotZero);
      this.SaveInteger(Saver, "Rows", RibbonEmitter.Rows);
      this.SaveInteger(Saver, "Columns", RibbonEmitter.Columns);
      this.SaveId(Saver, "MaterialID", RibbonEmitter.Material.ObjectId, ECondition.NotInvalidId);
      this.SaveAnimator<float>(Saver, Model, RibbonEmitter.HeightAbove, (IValue<float>) CFloat.Instance, "HeightAbove");
      this.SaveAnimator<float>(Saver, Model, RibbonEmitter.HeightBelow, (IValue<float>) CFloat.Instance, "HeightBelow");
      this.SaveAnimator<float>(Saver, Model, RibbonEmitter.Alpha, (IValue<float>) CFloat.Instance, "Alpha");
      this.SaveAnimator<MdxLib.Primitives.CVector3>(Saver, Model, RibbonEmitter.Color, (IValue<MdxLib.Primitives.CVector3>) CColor.Instance, "Color");
      this.SaveAnimator<int>(Saver, Model, RibbonEmitter.TextureSlot, (IValue<int>) CInteger.Instance, "TextureSlot");
      this.SaveAnimator<float>(Saver, Model, RibbonEmitter.Visibility, (IValue<float>) CFloat.Instance, "Visibility", ECondition.NotOne);
      Saver.EndGroup();
    }

    public static CRibbonEmitter Instance => CRibbonEmitter.CSingleton.Instance;

    private static class CSingleton
    {
      public static CRibbonEmitter Instance = new CRibbonEmitter();
    }
  }
}
