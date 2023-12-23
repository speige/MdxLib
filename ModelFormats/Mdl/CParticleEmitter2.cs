// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdl.CParticleEmitter2
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using MdxLib.ModelFormats.Mdl.Token;
using MdxLib.ModelFormats.Mdl.Value;
using MdxLib.Primitives;
using System;

namespace MdxLib.ModelFormats.Mdl
{
  internal sealed class CParticleEmitter2 : CNode
  {
    private CParticleEmitter2()
    {
    }

    public void LoadAll(CLoader Loader, MdxLib.Model.CModel Model)
    {
      MdxLib.Model.CParticleEmitter2 cparticleEmitter2 = new MdxLib.Model.CParticleEmitter2(Model);
      this.Load(Loader, Model, cparticleEmitter2);
      Model.ParticleEmitters2.Add(cparticleEmitter2);
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CParticleEmitter2 ParticleEmitter2)
    {
      CParticleEmitter2.SSegment ssegment1 = new CParticleEmitter2.SSegment(CConstants.DefaultColor, 1f, 1f);
      CParticleEmitter2.SSegment ssegment2 = new CParticleEmitter2.SSegment(CConstants.DefaultColor, 1f, 1f);
      CParticleEmitter2.SSegment ssegment3 = new CParticleEmitter2.SSegment(CConstants.DefaultColor, 1f, 1f);
      ParticleEmitter2.Name = Loader.ReadString();
      Loader.ExpectToken(EType.CurlyBracketLeft);
      while (Loader.PeekToken() != EType.CurlyBracketRight)
      {
        string Tag1 = Loader.ReadWord();
        if (!this.LoadNode<MdxLib.Model.CParticleEmitter2>(Loader, Model, (CNode<MdxLib.Model.CParticleEmitter2>) ParticleEmitter2, Tag1))
        {
          switch (Tag1)
          {
            case "static":
              string Tag2 = Loader.ReadWord();
              if (!this.LoadStaticNode<MdxLib.Model.CParticleEmitter2>(Loader, Model, (CNode<MdxLib.Model.CParticleEmitter2>) ParticleEmitter2, Tag2))
              {
                switch (Tag2)
                {
                  case "speed":
                    this.LoadStaticAnimator<float>(Loader, Model, ParticleEmitter2.Speed, (IValue<float>) CFloat.Instance);
                    continue;
                  case "variation":
                    this.LoadStaticAnimator<float>(Loader, Model, ParticleEmitter2.Variation, (IValue<float>) CFloat.Instance);
                    continue;
                  case "latitude":
                    this.LoadStaticAnimator<float>(Loader, Model, ParticleEmitter2.Latitude, (IValue<float>) CFloat.Instance);
                    continue;
                  case "gravity":
                    this.LoadStaticAnimator<float>(Loader, Model, ParticleEmitter2.Gravity, (IValue<float>) CFloat.Instance);
                    continue;
                  case "visibility":
                    this.LoadStaticAnimator<float>(Loader, Model, ParticleEmitter2.Visibility, (IValue<float>) CFloat.Instance);
                    continue;
                  case "emissionrate":
                    this.LoadStaticAnimator<float>(Loader, Model, ParticleEmitter2.EmissionRate, (IValue<float>) CFloat.Instance);
                    continue;
                  case "width":
                    this.LoadStaticAnimator<float>(Loader, Model, ParticleEmitter2.Width, (IValue<float>) CFloat.Instance);
                    continue;
                  case "length":
                    this.LoadStaticAnimator<float>(Loader, Model, ParticleEmitter2.Length, (IValue<float>) CFloat.Instance);
                    continue;
                  default:
                    throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + Tag2 + "\"!");
                }
              }
              else
                continue;
            case "speed":
              this.LoadAnimator<float>(Loader, Model, ParticleEmitter2.Speed, (IValue<float>) CFloat.Instance);
              continue;
            case "variation":
              this.LoadAnimator<float>(Loader, Model, ParticleEmitter2.Variation, (IValue<float>) CFloat.Instance);
              continue;
            case "latitude":
              this.LoadAnimator<float>(Loader, Model, ParticleEmitter2.Latitude, (IValue<float>) CFloat.Instance);
              continue;
            case "gravity":
              this.LoadAnimator<float>(Loader, Model, ParticleEmitter2.Gravity, (IValue<float>) CFloat.Instance);
              continue;
            case "visibility":
              this.LoadAnimator<float>(Loader, Model, ParticleEmitter2.Visibility, (IValue<float>) CFloat.Instance);
              continue;
            case "emissionrate":
              this.LoadAnimator<float>(Loader, Model, ParticleEmitter2.EmissionRate, (IValue<float>) CFloat.Instance);
              continue;
            case "width":
              this.LoadAnimator<float>(Loader, Model, ParticleEmitter2.Width, (IValue<float>) CFloat.Instance);
              continue;
            case "length":
              this.LoadAnimator<float>(Loader, Model, ParticleEmitter2.Length, (IValue<float>) CFloat.Instance);
              continue;
            case "rows":
              ParticleEmitter2.Rows = this.LoadInteger(Loader);
              continue;
            case "columns":
              ParticleEmitter2.Columns = this.LoadInteger(Loader);
              continue;
            case "textureid":
              Loader.Attacher.AddObject<MdxLib.Model.CTexture>(Model.Textures, ParticleEmitter2.Texture, this.LoadId(Loader));
              continue;
            case "replaceableid":
              ParticleEmitter2.ReplaceableId = this.LoadInteger(Loader);
              continue;
            case "priorityplane":
              ParticleEmitter2.PriorityPlane = this.LoadInteger(Loader);
              continue;
            case "time":
              ParticleEmitter2.Time = this.LoadFloat(Loader);
              continue;
            case "lifespan":
              ParticleEmitter2.LifeSpan = this.LoadFloat(Loader);
              continue;
            case "taillength":
              ParticleEmitter2.TailLength = this.LoadFloat(Loader);
              continue;
            case "segmentcolor":
              Loader.ExpectToken(EType.CurlyBracketLeft);
              Loader.ExpectWord("color");
              ssegment1.Color = Loader.ReadColor();
              Loader.ExpectToken(EType.Separator);
              Loader.ExpectWord("color");
              ssegment2.Color = Loader.ReadColor();
              Loader.ExpectToken(EType.Separator);
              Loader.ExpectWord("color");
              ssegment3.Color = Loader.ReadColor();
              Loader.ExpectToken(EType.Separator);
              Loader.ExpectToken(EType.CurlyBracketRight);
              Loader.ExpectToken(EType.Separator);
              continue;
            case "alpha":
              MdxLib.Primitives.CVector3 cvector3_1 = this.LoadVector3(Loader);
              ssegment1.Alpha = cvector3_1.X / (float) byte.MaxValue;
              ssegment2.Alpha = cvector3_1.Y / (float) byte.MaxValue;
              ssegment3.Alpha = cvector3_1.Z / (float) byte.MaxValue;
              continue;
            case "particlescaling":
              MdxLib.Primitives.CVector3 cvector3_2 = this.LoadVector3(Loader);
              ssegment1.Scaling = cvector3_2.X;
              ssegment2.Scaling = cvector3_2.Y;
              ssegment3.Scaling = cvector3_2.Z;
              continue;
            case "lifespanuvanim":
              MdxLib.Primitives.CVector3 cvector3_3 = this.LoadVector3(Loader);
              ParticleEmitter2.HeadLife = new CInterval((int) cvector3_3.X, (int) cvector3_3.Y, (int) cvector3_3.Z);
              continue;
            case "decayuvanim":
              MdxLib.Primitives.CVector3 cvector3_4 = this.LoadVector3(Loader);
              ParticleEmitter2.HeadDecay = new CInterval((int) cvector3_4.X, (int) cvector3_4.Y, (int) cvector3_4.Z);
              continue;
            case "tailuvanim":
              MdxLib.Primitives.CVector3 cvector3_5 = this.LoadVector3(Loader);
              ParticleEmitter2.TailLife = new CInterval((int) cvector3_5.X, (int) cvector3_5.Y, (int) cvector3_5.Z);
              continue;
            case "taildecayuvanim":
              MdxLib.Primitives.CVector3 cvector3_6 = this.LoadVector3(Loader);
              ParticleEmitter2.TailDecay = new CInterval((int) cvector3_6.X, (int) cvector3_6.Y, (int) cvector3_6.Z);
              continue;
            case "sortprimsfarz":
              ParticleEmitter2.SortPrimitivesFarZ = this.LoadBoolean(Loader);
              continue;
            case "lineemitter":
              ParticleEmitter2.LineEmitter = this.LoadBoolean(Loader);
              continue;
            case "modelspace":
              ParticleEmitter2.ModelSpace = this.LoadBoolean(Loader);
              continue;
            case "unshaded":
              ParticleEmitter2.Unshaded = this.LoadBoolean(Loader);
              continue;
            case "unfogged":
              ParticleEmitter2.Unfogged = this.LoadBoolean(Loader);
              continue;
            case "xyquad":
              ParticleEmitter2.XYQuad = this.LoadBoolean(Loader);
              continue;
            case "squirt":
              ParticleEmitter2.Squirt = this.LoadBoolean(Loader);
              continue;
            case "head":
              ParticleEmitter2.Head = this.LoadBoolean(Loader);
              continue;
            case "tail":
              ParticleEmitter2.Tail = this.LoadBoolean(Loader);
              continue;
            case "both":
              ParticleEmitter2.Head = ParticleEmitter2.Tail = this.LoadBoolean(Loader);
              continue;
            case "blend":
              ParticleEmitter2.FilterMode = EParticleEmitter2FilterMode.Blend;
              this.LoadBoolean(Loader);
              continue;
            case "additive":
              ParticleEmitter2.FilterMode = EParticleEmitter2FilterMode.Additive;
              this.LoadBoolean(Loader);
              continue;
            case "modulate":
              ParticleEmitter2.FilterMode = EParticleEmitter2FilterMode.Modulate;
              this.LoadBoolean(Loader);
              continue;
            case "modulate2x":
              ParticleEmitter2.FilterMode = EParticleEmitter2FilterMode.Modulate2x;
              this.LoadBoolean(Loader);
              continue;
            case "alphakey":
              ParticleEmitter2.FilterMode = EParticleEmitter2FilterMode.AlphaKey;
              this.LoadBoolean(Loader);
              continue;
            default:
              throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + Tag1 + "\"!");
          }
        }
      }
      int num = (int) Loader.ReadToken();
      ParticleEmitter2.Segment1 = new CSegment(ssegment1.Color, ssegment1.Alpha, ssegment1.Scaling);
      ParticleEmitter2.Segment2 = new CSegment(ssegment2.Color, ssegment2.Alpha, ssegment2.Scaling);
      ParticleEmitter2.Segment3 = new CSegment(ssegment3.Color, ssegment3.Alpha, ssegment3.Scaling);
    }

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasParticleEmitters2)
        return;
      foreach (MdxLib.Model.CParticleEmitter2 ParticleEmitter2 in Model.ParticleEmitters2)
        this.Save(Saver, Model, ParticleEmitter2);
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CParticleEmitter2 ParticleEmitter2)
    {
      Saver.BeginGroup(nameof (ParticleEmitter2), ParticleEmitter2.Name);
      this.SaveNode<MdxLib.Model.CParticleEmitter2>(Saver, Model, (CNode<MdxLib.Model.CParticleEmitter2>) ParticleEmitter2);
      this.SaveBoolean(Saver, this.FilterModeToString(ParticleEmitter2.FilterMode), true);
      this.SaveBoolean(Saver, "SortPrimsFarZ", ParticleEmitter2.SortPrimitivesFarZ);
      this.SaveBoolean(Saver, "LineEmitter", ParticleEmitter2.LineEmitter);
      this.SaveBoolean(Saver, "ModelSpace", ParticleEmitter2.ModelSpace);
      this.SaveBoolean(Saver, "Unshaded", ParticleEmitter2.Unshaded);
      this.SaveBoolean(Saver, "Unfogged", ParticleEmitter2.Unfogged);
      this.SaveBoolean(Saver, "XYQuad", ParticleEmitter2.XYQuad);
      this.SaveBoolean(Saver, "Squirt", ParticleEmitter2.Squirt);
      this.SaveBoolean(Saver, "Head", ParticleEmitter2.Head && !ParticleEmitter2.Tail);
      this.SaveBoolean(Saver, "Tail", ParticleEmitter2.Tail && !ParticleEmitter2.Head);
      this.SaveBoolean(Saver, "Both", ParticleEmitter2.Head && ParticleEmitter2.Tail);
      this.SaveInteger(Saver, "Rows", ParticleEmitter2.Rows, ECondition.NotZero);
      this.SaveInteger(Saver, "Columns", ParticleEmitter2.Columns, ECondition.NotZero);
      this.SaveId(Saver, "TextureID", ParticleEmitter2.Texture.ObjectId, ECondition.NotInvalidId);
      this.SaveInteger(Saver, "ReplaceableId", ParticleEmitter2.ReplaceableId, ECondition.NotZero);
      this.SaveInteger(Saver, "PriorityPlane", ParticleEmitter2.PriorityPlane, ECondition.NotZero);
      this.SaveFloat(Saver, "Time", ParticleEmitter2.Time, ECondition.NotZero);
      this.SaveFloat(Saver, "LifeSpan", ParticleEmitter2.LifeSpan, ECondition.NotZero);
      this.SaveFloat(Saver, "TailLength", ParticleEmitter2.TailLength, ECondition.NotZero);
      Saver.BeginGroup("SegmentColor");
      this.SaveColor(Saver, "Color", ParticleEmitter2.Segment1.Color);
      this.SaveColor(Saver, "Color", ParticleEmitter2.Segment2.Color);
      this.SaveColor(Saver, "Color", ParticleEmitter2.Segment3.Color);
      Saver.EndGroup(",");
      Saver.WriteTabs();
      Saver.WriteWord("Alpha { ");
      Saver.WriteInteger((int) ((double) ParticleEmitter2.Segment1.Alpha * (double) byte.MaxValue));
      Saver.WriteWord(", ");
      Saver.WriteInteger((int) ((double) ParticleEmitter2.Segment2.Alpha * (double) byte.MaxValue));
      Saver.WriteWord(", ");
      Saver.WriteInteger((int) ((double) ParticleEmitter2.Segment3.Alpha * (double) byte.MaxValue));
      Saver.WriteLine(" },");
      this.SaveVector3(Saver, "ParticleScaling", new MdxLib.Primitives.CVector3(ParticleEmitter2.Segment1.Scaling, ParticleEmitter2.Segment2.Scaling, ParticleEmitter2.Segment3.Scaling));
      this.SaveVector3(Saver, "LifeSpanUVAnim", new MdxLib.Primitives.CVector3((float) ParticleEmitter2.HeadLife.Start, (float) ParticleEmitter2.HeadLife.End, (float) ParticleEmitter2.HeadLife.Repeat));
      this.SaveVector3(Saver, "DecayUVAnim", new MdxLib.Primitives.CVector3((float) ParticleEmitter2.HeadDecay.Start, (float) ParticleEmitter2.HeadDecay.End, (float) ParticleEmitter2.HeadDecay.Repeat));
      this.SaveVector3(Saver, "TailUVAnim", new MdxLib.Primitives.CVector3((float) ParticleEmitter2.TailLife.Start, (float) ParticleEmitter2.TailLife.End, (float) ParticleEmitter2.TailLife.Repeat));
      this.SaveVector3(Saver, "TailDecayUVAnim", new MdxLib.Primitives.CVector3((float) ParticleEmitter2.TailDecay.Start, (float) ParticleEmitter2.TailDecay.End, (float) ParticleEmitter2.TailDecay.Repeat));
      this.SaveAnimator<float>(Saver, Model, ParticleEmitter2.Speed, (IValue<float>) CFloat.Instance, "Speed");
      this.SaveAnimator<float>(Saver, Model, ParticleEmitter2.Variation, (IValue<float>) CFloat.Instance, "Variation");
      this.SaveAnimator<float>(Saver, Model, ParticleEmitter2.Latitude, (IValue<float>) CFloat.Instance, "Latitude");
      this.SaveAnimator<float>(Saver, Model, ParticleEmitter2.Gravity, (IValue<float>) CFloat.Instance, "Gravity");
      this.SaveAnimator<float>(Saver, Model, ParticleEmitter2.EmissionRate, (IValue<float>) CFloat.Instance, "EmissionRate");
      this.SaveAnimator<float>(Saver, Model, ParticleEmitter2.Width, (IValue<float>) CFloat.Instance, "Width");
      this.SaveAnimator<float>(Saver, Model, ParticleEmitter2.Length, (IValue<float>) CFloat.Instance, "Length");
      this.SaveAnimator<float>(Saver, Model, ParticleEmitter2.Visibility, (IValue<float>) CFloat.Instance, "Visibility", ECondition.NotOne);
      Saver.EndGroup();
    }

    private string FilterModeToString(EParticleEmitter2FilterMode FilterMode)
    {
      switch (FilterMode)
      {
        case EParticleEmitter2FilterMode.Blend:
          return "Blend";
        case EParticleEmitter2FilterMode.Additive:
          return "Additive";
        case EParticleEmitter2FilterMode.Modulate:
          return "Modulate";
        case EParticleEmitter2FilterMode.Modulate2x:
          return "Modulate2x";
        case EParticleEmitter2FilterMode.AlphaKey:
          return "AlphaKey";
        default:
          return "";
      }
    }

    public static CParticleEmitter2 Instance => CParticleEmitter2.CSingleton.Instance;

    private struct SSegment
    {
      public MdxLib.Primitives.CVector3 Color;
      public float Alpha;
      public float Scaling;

      public SSegment(MdxLib.Primitives.CVector3 Color, float Alpha, float Scaling)
      {
        this.Color = Color;
        this.Alpha = Alpha;
        this.Scaling = Scaling;
      }
    }

    private static class CSingleton
    {
      public static CParticleEmitter2 Instance = new CParticleEmitter2();
    }
  }
}
