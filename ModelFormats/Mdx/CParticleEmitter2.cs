// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdx.CParticleEmitter2
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using MdxLib.ModelFormats.Mdx.Value;
using MdxLib.Primitives;
using System;

namespace MdxLib.ModelFormats.Mdx
{
  internal sealed class CParticleEmitter2 : CNode
  {
    private CParticleEmitter2()
    {
    }

    public void LoadAll(CLoader Loader, MdxLib.Model.CModel Model)
    {
      int num = Loader.ReadInt32();
      while (num > 0)
      {
        Loader.PushLocation();
        MdxLib.Model.CParticleEmitter2 cparticleEmitter2 = new MdxLib.Model.CParticleEmitter2(Model);
        this.Load(Loader, Model, cparticleEmitter2);
        Model.ParticleEmitters2.Add(cparticleEmitter2);
        num -= Loader.PopLocation();
        if (num < 0)
          throw new Exception("Error at location " + (object) Loader.Location + ", too many ParticleEmitter2 bytes were read!");
      }
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CParticleEmitter2 ParticleEmitter2)
    {
      CParticleEmitter2.SSegment ssegment1 = new CParticleEmitter2.SSegment();
      CParticleEmitter2.SSegment ssegment2 = new CParticleEmitter2.SSegment();
      CParticleEmitter2.SSegment ssegment3 = new CParticleEmitter2.SSegment();
      CParticleEmitter2.SInterval sinterval1 = new CParticleEmitter2.SInterval();
      CParticleEmitter2.SInterval sinterval2 = new CParticleEmitter2.SInterval();
      CParticleEmitter2.SInterval sinterval3 = new CParticleEmitter2.SInterval();
      CParticleEmitter2.SInterval sinterval4 = new CParticleEmitter2.SInterval();
      Loader.PushLocation();
      int num1 = Loader.ReadInt32();
      int num2 = CNode.LoadNode<MdxLib.Model.CParticleEmitter2>(Loader, Model, (CNode<MdxLib.Model.CParticleEmitter2>) ParticleEmitter2);
      ParticleEmitter2.Speed.MakeStatic(Loader.ReadFloat());
      ParticleEmitter2.Variation.MakeStatic(Loader.ReadFloat());
      ParticleEmitter2.Latitude.MakeStatic(Loader.ReadFloat());
      ParticleEmitter2.Gravity.MakeStatic(Loader.ReadFloat());
      ParticleEmitter2.LifeSpan = Loader.ReadFloat();
      ParticleEmitter2.EmissionRate.MakeStatic(Loader.ReadFloat());
      ParticleEmitter2.Length.MakeStatic(Loader.ReadFloat());
      ParticleEmitter2.Width.MakeStatic(Loader.ReadFloat());
      int num3 = Loader.ReadInt32();
      ParticleEmitter2.Rows = Loader.ReadInt32();
      ParticleEmitter2.Columns = Loader.ReadInt32();
      int num4 = Loader.ReadInt32();
      ParticleEmitter2.TailLength = Loader.ReadFloat();
      ParticleEmitter2.Time = Loader.ReadFloat();
      ssegment1.Color = Loader.ReadVector3();
      ssegment2.Color = Loader.ReadVector3();
      ssegment3.Color = Loader.ReadVector3();
      ssegment1.Alpha = (float) Loader.ReadInt8() / (float) byte.MaxValue;
      ssegment2.Alpha = (float) Loader.ReadInt8() / (float) byte.MaxValue;
      ssegment3.Alpha = (float) Loader.ReadInt8() / (float) byte.MaxValue;
      ssegment1.Scaling = Loader.ReadFloat();
      ssegment2.Scaling = Loader.ReadFloat();
      ssegment3.Scaling = Loader.ReadFloat();
      sinterval1.Start = Loader.ReadInt32();
      sinterval1.End = Loader.ReadInt32();
      sinterval1.Repeat = Loader.ReadInt32();
      sinterval2.Start = Loader.ReadInt32();
      sinterval2.End = Loader.ReadInt32();
      sinterval2.Repeat = Loader.ReadInt32();
      sinterval3.Start = Loader.ReadInt32();
      sinterval3.End = Loader.ReadInt32();
      sinterval3.Repeat = Loader.ReadInt32();
      sinterval4.Start = Loader.ReadInt32();
      sinterval4.End = Loader.ReadInt32();
      sinterval4.Repeat = Loader.ReadInt32();
      ParticleEmitter2.Segment1 = new CSegment(ssegment1.Color, ssegment1.Alpha, ssegment1.Scaling);
      ParticleEmitter2.Segment2 = new CSegment(ssegment2.Color, ssegment2.Alpha, ssegment2.Scaling);
      ParticleEmitter2.Segment3 = new CSegment(ssegment3.Color, ssegment3.Alpha, ssegment3.Scaling);
      ParticleEmitter2.HeadLife = new CInterval(sinterval1.Start, sinterval1.End, sinterval1.Repeat);
      ParticleEmitter2.HeadDecay = new CInterval(sinterval2.Start, sinterval2.End, sinterval2.Repeat);
      ParticleEmitter2.TailLife = new CInterval(sinterval3.Start, sinterval3.End, sinterval3.Repeat);
      ParticleEmitter2.TailDecay = new CInterval(sinterval4.Start, sinterval4.End, sinterval4.Repeat);
      Loader.Attacher.AddObject<MdxLib.Model.CTexture>(Model.Textures, ParticleEmitter2.Texture, Loader.ReadInt32());
      int num5 = Loader.ReadInt32();
      ParticleEmitter2.PriorityPlane = Loader.ReadInt32();
      ParticleEmitter2.ReplaceableId = Loader.ReadInt32();
      switch (num3)
      {
        case 0:
          ParticleEmitter2.FilterMode = EParticleEmitter2FilterMode.Blend;
          break;
        case 1:
          ParticleEmitter2.FilterMode = EParticleEmitter2FilterMode.Additive;
          break;
        case 2:
          ParticleEmitter2.FilterMode = EParticleEmitter2FilterMode.Modulate;
          break;
        case 3:
          ParticleEmitter2.FilterMode = EParticleEmitter2FilterMode.Modulate2x;
          break;
        case 4:
          ParticleEmitter2.FilterMode = EParticleEmitter2FilterMode.AlphaKey;
          break;
      }
      ParticleEmitter2.Unshaded = (num2 & 32768) != 0;
      ParticleEmitter2.SortPrimitivesFarZ = (num2 & 65536) != 0;
      ParticleEmitter2.LineEmitter = (num2 & 131072) != 0;
      ParticleEmitter2.Unfogged = (num2 & 262144) != 0;
      ParticleEmitter2.ModelSpace = (num2 & 524288) != 0;
      ParticleEmitter2.XYQuad = (num2 & 1048576) != 0;
      ParticleEmitter2.Head = num4 == 0 || num4 == 2;
      ParticleEmitter2.Tail = num4 == 1 || num4 == 2;
      ParticleEmitter2.Squirt = num5 == 1;
      int num6 = num1 - Loader.PopLocation();
      if (num6 < 0)
        throw new Exception("Error at location " + (object) Loader.Location + ", too many ParticleEmitter2 bytes were read!");
      while (num6 > 0)
      {
        Loader.PushLocation();
        string str = Loader.ReadTag();
        switch (str)
        {
          case "KP2S":
            CObject.LoadAnimator<float>(Loader, Model, ParticleEmitter2.Speed, (IValue<float>) CFloat.Instance);
            break;
          case "KP2R":
            CObject.LoadAnimator<float>(Loader, Model, ParticleEmitter2.Variation, (IValue<float>) CFloat.Instance);
            break;
          case "KP2L":
            CObject.LoadAnimator<float>(Loader, Model, ParticleEmitter2.Latitude, (IValue<float>) CFloat.Instance);
            break;
          case "KP2G":
            CObject.LoadAnimator<float>(Loader, Model, ParticleEmitter2.Gravity, (IValue<float>) CFloat.Instance);
            break;
          case "KP2E":
            CObject.LoadAnimator<float>(Loader, Model, ParticleEmitter2.EmissionRate, (IValue<float>) CFloat.Instance);
            break;
          case "KP2W":
            CObject.LoadAnimator<float>(Loader, Model, ParticleEmitter2.Width, (IValue<float>) CFloat.Instance);
            break;
          case "KP2N":
            CObject.LoadAnimator<float>(Loader, Model, ParticleEmitter2.Length, (IValue<float>) CFloat.Instance);
            break;
          case "KP2V":
            CObject.LoadAnimator<float>(Loader, Model, ParticleEmitter2.Visibility, (IValue<float>) CFloat.Instance);
            break;
          default:
            throw new Exception("Error at location " + (object) Loader.Location + ", unknown ParticleEmitter2 tag \"" + str + "\"!");
        }
        num6 -= Loader.PopLocation();
        if (num6 < 0)
          throw new Exception("Error at location " + (object) Loader.Location + ", too many ParticleEmitter2 bytes were read!");
      }
    }

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasParticleEmitters2)
        return;
      Saver.WriteTag("PRE2");
      Saver.PushLocation();
      foreach (MdxLib.Model.CParticleEmitter2 ParticleEmitter2 in Model.ParticleEmitters2)
        this.Save(Saver, Model, ParticleEmitter2);
      Saver.PopExclusiveLocation();
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CParticleEmitter2 ParticleEmitter2)
    {
      int Flags = 4096;
      int num1 = 0;
      if (ParticleEmitter2.Unshaded)
        Flags |= 32768;
      if (ParticleEmitter2.SortPrimitivesFarZ)
        Flags |= 65536;
      if (ParticleEmitter2.LineEmitter)
        Flags |= 131072;
      if (ParticleEmitter2.Unfogged)
        Flags |= 262144;
      if (ParticleEmitter2.ModelSpace)
        Flags |= 524288;
      if (ParticleEmitter2.XYQuad)
        Flags |= 1048576;
      int num2 = !ParticleEmitter2.Head ? (!ParticleEmitter2.Tail ? 0 : 1) : (!ParticleEmitter2.Tail ? 0 : 2);
      switch (ParticleEmitter2.FilterMode)
      {
        case EParticleEmitter2FilterMode.Blend:
          num1 = 0;
          break;
        case EParticleEmitter2FilterMode.Additive:
          num1 = 1;
          break;
        case EParticleEmitter2FilterMode.Modulate:
          num1 = 2;
          break;
        case EParticleEmitter2FilterMode.Modulate2x:
          num1 = 3;
          break;
        case EParticleEmitter2FilterMode.AlphaKey:
          num1 = 4;
          break;
      }
      Saver.PushLocation();
      CNode.SaveNode<MdxLib.Model.CParticleEmitter2>(Saver, Model, (CNode<MdxLib.Model.CParticleEmitter2>) ParticleEmitter2, Flags);
      Saver.WriteFloat(ParticleEmitter2.Speed.GetValue());
      Saver.WriteFloat(ParticleEmitter2.Variation.GetValue());
      Saver.WriteFloat(ParticleEmitter2.Latitude.GetValue());
      Saver.WriteFloat(ParticleEmitter2.Gravity.GetValue());
      Saver.WriteFloat(ParticleEmitter2.LifeSpan);
      Saver.WriteFloat(ParticleEmitter2.EmissionRate.GetValue());
      Saver.WriteFloat(ParticleEmitter2.Length.GetValue());
      Saver.WriteFloat(ParticleEmitter2.Width.GetValue());
      Saver.WriteInt32(num1);
      Saver.WriteInt32(ParticleEmitter2.Rows);
      Saver.WriteInt32(ParticleEmitter2.Columns);
      Saver.WriteInt32(num2);
      Saver.WriteFloat(ParticleEmitter2.TailLength);
      Saver.WriteFloat(ParticleEmitter2.Time);
      Saver.WriteVector3(ParticleEmitter2.Segment1.Color);
      Saver.WriteVector3(ParticleEmitter2.Segment2.Color);
      Saver.WriteVector3(ParticleEmitter2.Segment3.Color);
      Saver.WriteInt8((int) ((double) ParticleEmitter2.Segment1.Alpha * (double) byte.MaxValue));
      Saver.WriteInt8((int) ((double) ParticleEmitter2.Segment2.Alpha * (double) byte.MaxValue));
      Saver.WriteInt8((int) ((double) ParticleEmitter2.Segment3.Alpha * (double) byte.MaxValue));
      Saver.WriteFloat(ParticleEmitter2.Segment1.Scaling);
      Saver.WriteFloat(ParticleEmitter2.Segment2.Scaling);
      Saver.WriteFloat(ParticleEmitter2.Segment3.Scaling);
      Saver.WriteInt32(ParticleEmitter2.HeadLife.Start);
      Saver.WriteInt32(ParticleEmitter2.HeadLife.End);
      Saver.WriteInt32(ParticleEmitter2.HeadLife.Repeat);
      Saver.WriteInt32(ParticleEmitter2.HeadDecay.Start);
      Saver.WriteInt32(ParticleEmitter2.HeadDecay.End);
      Saver.WriteInt32(ParticleEmitter2.HeadDecay.Repeat);
      Saver.WriteInt32(ParticleEmitter2.TailLife.Start);
      Saver.WriteInt32(ParticleEmitter2.TailLife.End);
      Saver.WriteInt32(ParticleEmitter2.TailLife.Repeat);
      Saver.WriteInt32(ParticleEmitter2.TailDecay.Start);
      Saver.WriteInt32(ParticleEmitter2.TailDecay.End);
      Saver.WriteInt32(ParticleEmitter2.TailDecay.Repeat);
      Saver.WriteInt32(ParticleEmitter2.Texture.ObjectId);
      Saver.WriteInt32(ParticleEmitter2.Squirt ? 1 : 0);
      Saver.WriteInt32(ParticleEmitter2.PriorityPlane);
      Saver.WriteInt32(ParticleEmitter2.ReplaceableId);
      CObject.SaveAnimator<float>(Saver, Model, ParticleEmitter2.Speed, (IValue<float>) CFloat.Instance, "KP2S");
      CObject.SaveAnimator<float>(Saver, Model, ParticleEmitter2.Variation, (IValue<float>) CFloat.Instance, "KP2R");
      CObject.SaveAnimator<float>(Saver, Model, ParticleEmitter2.Latitude, (IValue<float>) CFloat.Instance, "KP2L");
      CObject.SaveAnimator<float>(Saver, Model, ParticleEmitter2.Gravity, (IValue<float>) CFloat.Instance, "KP2G");
      CObject.SaveAnimator<float>(Saver, Model, ParticleEmitter2.EmissionRate, (IValue<float>) CFloat.Instance, "KP2E");
      CObject.SaveAnimator<float>(Saver, Model, ParticleEmitter2.Width, (IValue<float>) CFloat.Instance, "KP2W");
      CObject.SaveAnimator<float>(Saver, Model, ParticleEmitter2.Length, (IValue<float>) CFloat.Instance, "KP2N");
      CObject.SaveAnimator<float>(Saver, Model, ParticleEmitter2.Visibility, (IValue<float>) CFloat.Instance, "KP2V");
      Saver.PopInclusiveLocation();
    }

    public static CParticleEmitter2 Instance => CParticleEmitter2.CSingleton.Instance;

    private struct SInterval
    {
      public int Start;
      public int End;
      public int Repeat;
    }

    private struct SSegment
    {
      public MdxLib.Primitives.CVector3 Color;
      public float Alpha;
      public float Scaling;
    }

    private static class CSingleton
    {
      public static CParticleEmitter2 Instance = new CParticleEmitter2();
    }
  }
}
