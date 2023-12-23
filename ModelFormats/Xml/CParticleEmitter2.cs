// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.CParticleEmitter2
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using MdxLib.ModelFormats.Xml.Value;
using System.Xml;

namespace MdxLib.ModelFormats.Xml
{
  internal sealed class CParticleEmitter2 : CNode
  {
    private CParticleEmitter2()
    {
    }

    public void Load(
      CLoader Loader,
      XmlNode Node,
      MdxLib.Model.CModel Model,
      MdxLib.Model.CParticleEmitter2 ParticleEmitter2)
    {
      this.LoadNode<MdxLib.Model.CParticleEmitter2>(Loader, Node, Model, ParticleEmitter2);
      ParticleEmitter2.FilterMode = this.StringToFilterMode(this.ReadString(Node, "filter_mode", this.FilterModeToString(ParticleEmitter2.FilterMode)));
      ParticleEmitter2.Rows = this.ReadInteger(Node, "rows", ParticleEmitter2.Rows);
      ParticleEmitter2.Columns = this.ReadInteger(Node, "columns", ParticleEmitter2.Columns);
      ParticleEmitter2.PriorityPlane = this.ReadInteger(Node, "priority_plane", ParticleEmitter2.PriorityPlane);
      ParticleEmitter2.ReplaceableId = this.ReadInteger(Node, "replaceable_id", ParticleEmitter2.ReplaceableId);
      ParticleEmitter2.Time = this.ReadFloat(Node, "time", ParticleEmitter2.Time);
      ParticleEmitter2.LifeSpan = this.ReadFloat(Node, "life_span", ParticleEmitter2.LifeSpan);
      ParticleEmitter2.TailLength = this.ReadFloat(Node, "tail_length", ParticleEmitter2.TailLength);
      ParticleEmitter2.SortPrimitivesFarZ = this.ReadBoolean(Node, "sort_primitives_far_z", ParticleEmitter2.SortPrimitivesFarZ);
      ParticleEmitter2.LineEmitter = this.ReadBoolean(Node, "line_emitter", ParticleEmitter2.LineEmitter);
      ParticleEmitter2.ModelSpace = this.ReadBoolean(Node, "model_space", ParticleEmitter2.ModelSpace);
      ParticleEmitter2.Unshaded = this.ReadBoolean(Node, "unshaded", ParticleEmitter2.Unshaded);
      ParticleEmitter2.Unfogged = this.ReadBoolean(Node, "unfogged", ParticleEmitter2.Unfogged);
      ParticleEmitter2.XYQuad = this.ReadBoolean(Node, "xy_quad", ParticleEmitter2.XYQuad);
      ParticleEmitter2.Squirt = this.ReadBoolean(Node, "squirt", ParticleEmitter2.Squirt);
      ParticleEmitter2.Head = this.ReadBoolean(Node, "head", ParticleEmitter2.Head);
      ParticleEmitter2.Tail = this.ReadBoolean(Node, "tail", ParticleEmitter2.Tail);
      ParticleEmitter2.Segment1 = this.ReadSegment(Node, "segment_1", ParticleEmitter2.Segment1);
      ParticleEmitter2.Segment2 = this.ReadSegment(Node, "segment_2", ParticleEmitter2.Segment2);
      ParticleEmitter2.Segment3 = this.ReadSegment(Node, "segment_3", ParticleEmitter2.Segment3);
      ParticleEmitter2.HeadLife = this.ReadInterval(Node, "head_life", ParticleEmitter2.HeadLife);
      ParticleEmitter2.HeadDecay = this.ReadInterval(Node, "head_decay", ParticleEmitter2.HeadDecay);
      ParticleEmitter2.TailLife = this.ReadInterval(Node, "tail_life", ParticleEmitter2.TailLife);
      ParticleEmitter2.TailDecay = this.ReadInterval(Node, "tail_decay", ParticleEmitter2.TailDecay);
      this.LoadAnimator<float>(Loader, Node, Model, ParticleEmitter2.Speed, (IValue<float>) CFloat.Instance, "speed");
      this.LoadAnimator<float>(Loader, Node, Model, ParticleEmitter2.Variation, (IValue<float>) CFloat.Instance, "variation");
      this.LoadAnimator<float>(Loader, Node, Model, ParticleEmitter2.Latitude, (IValue<float>) CFloat.Instance, "latitude");
      this.LoadAnimator<float>(Loader, Node, Model, ParticleEmitter2.Gravity, (IValue<float>) CFloat.Instance, "gravity");
      this.LoadAnimator<float>(Loader, Node, Model, ParticleEmitter2.Visibility, (IValue<float>) CFloat.Instance, "visibility");
      this.LoadAnimator<float>(Loader, Node, Model, ParticleEmitter2.EmissionRate, (IValue<float>) CFloat.Instance, "emission_rate");
      this.LoadAnimator<float>(Loader, Node, Model, ParticleEmitter2.Width, (IValue<float>) CFloat.Instance, "width");
      this.LoadAnimator<float>(Loader, Node, Model, ParticleEmitter2.Length, (IValue<float>) CFloat.Instance, "length");
      Loader.Attacher.AddObject<MdxLib.Model.CTexture>(Model.Textures, ParticleEmitter2.Texture, this.ReadInteger(Node, "texture", -1));
    }

    public void Save(CSaver Saver, XmlNode Node, MdxLib.Model.CModel Model, MdxLib.Model.CParticleEmitter2 ParticleEmitter2)
    {
      this.SaveNode<MdxLib.Model.CParticleEmitter2>(Saver, Node, Model, ParticleEmitter2);
      this.WriteString(Node, "filter_mode", this.FilterModeToString(ParticleEmitter2.FilterMode));
      this.WriteInteger(Node, "rows", ParticleEmitter2.Rows);
      this.WriteInteger(Node, "columns", ParticleEmitter2.Columns);
      this.WriteInteger(Node, "priority_plane", ParticleEmitter2.PriorityPlane);
      this.WriteInteger(Node, "replaceable_id", ParticleEmitter2.ReplaceableId);
      this.WriteFloat(Node, "time", ParticleEmitter2.Time);
      this.WriteFloat(Node, "life_span", ParticleEmitter2.LifeSpan);
      this.WriteFloat(Node, "tail_length", ParticleEmitter2.TailLength);
      this.WriteBoolean(Node, "sort_primitives_far_z", ParticleEmitter2.SortPrimitivesFarZ);
      this.WriteBoolean(Node, "line_emitter", ParticleEmitter2.LineEmitter);
      this.WriteBoolean(Node, "model_space", ParticleEmitter2.ModelSpace);
      this.WriteBoolean(Node, "unshaded", ParticleEmitter2.Unshaded);
      this.WriteBoolean(Node, "unfogged", ParticleEmitter2.Unfogged);
      this.WriteBoolean(Node, "xy_quad", ParticleEmitter2.XYQuad);
      this.WriteBoolean(Node, "squirt", ParticleEmitter2.Squirt);
      this.WriteBoolean(Node, "head", ParticleEmitter2.Head);
      this.WriteBoolean(Node, "tail", ParticleEmitter2.Tail);
      this.WriteSegment(Node, "segment_1", ParticleEmitter2.Segment1);
      this.WriteSegment(Node, "segment_2", ParticleEmitter2.Segment2);
      this.WriteSegment(Node, "segment_3", ParticleEmitter2.Segment3);
      this.WriteInterval(Node, "head_life", ParticleEmitter2.HeadLife);
      this.WriteInterval(Node, "head_decay", ParticleEmitter2.HeadDecay);
      this.WriteInterval(Node, "tail_life", ParticleEmitter2.TailLife);
      this.WriteInterval(Node, "tail_decay", ParticleEmitter2.TailDecay);
      this.SaveAnimator<float>(Saver, Node, Model, ParticleEmitter2.Speed, (IValue<float>) CFloat.Instance, "speed");
      this.SaveAnimator<float>(Saver, Node, Model, ParticleEmitter2.Variation, (IValue<float>) CFloat.Instance, "variation");
      this.SaveAnimator<float>(Saver, Node, Model, ParticleEmitter2.Latitude, (IValue<float>) CFloat.Instance, "latitude");
      this.SaveAnimator<float>(Saver, Node, Model, ParticleEmitter2.Gravity, (IValue<float>) CFloat.Instance, "gravity");
      this.SaveAnimator<float>(Saver, Node, Model, ParticleEmitter2.Visibility, (IValue<float>) CFloat.Instance, "visibility");
      this.SaveAnimator<float>(Saver, Node, Model, ParticleEmitter2.EmissionRate, (IValue<float>) CFloat.Instance, "emission_rate");
      this.SaveAnimator<float>(Saver, Node, Model, ParticleEmitter2.Width, (IValue<float>) CFloat.Instance, "width");
      this.SaveAnimator<float>(Saver, Node, Model, ParticleEmitter2.Length, (IValue<float>) CFloat.Instance, "length");
      this.WriteInteger(Node, "texture", ParticleEmitter2.Texture.ObjectId);
    }

    private string FilterModeToString(EParticleEmitter2FilterMode FilterMode)
    {
      switch (FilterMode)
      {
        case EParticleEmitter2FilterMode.Blend:
          return "blend";
        case EParticleEmitter2FilterMode.Additive:
          return "additive";
        case EParticleEmitter2FilterMode.Modulate:
          return "modulate";
        case EParticleEmitter2FilterMode.Modulate2x:
          return "modulate_2x";
        case EParticleEmitter2FilterMode.AlphaKey:
          return "alpha_key";
        default:
          return "";
      }
    }

    private EParticleEmitter2FilterMode StringToFilterMode(string String)
    {
      switch (String)
      {
        case "blend":
          return EParticleEmitter2FilterMode.Blend;
        case "additive":
          return EParticleEmitter2FilterMode.Additive;
        case "modulate":
          return EParticleEmitter2FilterMode.Modulate;
        case "modulate_2x":
          return EParticleEmitter2FilterMode.Modulate2x;
        case "alpha_key":
          return EParticleEmitter2FilterMode.AlphaKey;
        default:
          return EParticleEmitter2FilterMode.Blend;
      }
    }

    public static CParticleEmitter2 Instance => CParticleEmitter2.CSingleton.Instance;

    private static class CSingleton
    {
      public static CParticleEmitter2 Instance = new CParticleEmitter2();
    }
  }
}
