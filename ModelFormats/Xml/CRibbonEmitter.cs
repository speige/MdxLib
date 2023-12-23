// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.CRibbonEmitter
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.ModelFormats.Xml.Value;
using System.Xml;

namespace MdxLib.ModelFormats.Xml
{
  internal sealed class CRibbonEmitter : CNode
  {
    private CRibbonEmitter()
    {
    }

    public void Load(CLoader Loader, XmlNode Node, MdxLib.Model.CModel Model, MdxLib.Model.CRibbonEmitter RibbonEmitter)
    {
      this.LoadNode<MdxLib.Model.CRibbonEmitter>(Loader, Node, Model, RibbonEmitter);
      RibbonEmitter.EmissionRate = this.ReadInteger(Node, "emission_rate", RibbonEmitter.EmissionRate);
      RibbonEmitter.LifeSpan = this.ReadFloat(Node, "life_span", RibbonEmitter.LifeSpan);
      RibbonEmitter.Gravity = this.ReadFloat(Node, "gravity", RibbonEmitter.Gravity);
      RibbonEmitter.Rows = this.ReadInteger(Node, "rows", RibbonEmitter.Rows);
      RibbonEmitter.Columns = this.ReadInteger(Node, "columns", RibbonEmitter.Columns);
      this.LoadAnimator<float>(Loader, Node, Model, RibbonEmitter.HeightAbove, (IValue<float>) CFloat.Instance, "height_above");
      this.LoadAnimator<float>(Loader, Node, Model, RibbonEmitter.HeightBelow, (IValue<float>) CFloat.Instance, "height_below");
      this.LoadAnimator<float>(Loader, Node, Model, RibbonEmitter.Alpha, (IValue<float>) CFloat.Instance, "alpha");
      this.LoadAnimator<MdxLib.Primitives.CVector3>(Loader, Node, Model, RibbonEmitter.Color, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Xml.Value.CVector3.Instance, "color");
      this.LoadAnimator<int>(Loader, Node, Model, RibbonEmitter.TextureSlot, (IValue<int>) CInteger.Instance, "texture_slot");
      this.LoadAnimator<float>(Loader, Node, Model, RibbonEmitter.Visibility, (IValue<float>) CFloat.Instance, "visibility");
      Loader.Attacher.AddObject<MdxLib.Model.CMaterial>(Model.Materials, RibbonEmitter.Material, this.ReadInteger(Node, "material", -1));
    }

    public void Save(CSaver Saver, XmlNode Node, MdxLib.Model.CModel Model, MdxLib.Model.CRibbonEmitter RibbonEmitter)
    {
      this.SaveNode<MdxLib.Model.CRibbonEmitter>(Saver, Node, Model, RibbonEmitter);
      this.WriteInteger(Node, "emission_rate", RibbonEmitter.EmissionRate);
      this.WriteFloat(Node, "life_span", RibbonEmitter.LifeSpan);
      this.WriteFloat(Node, "gravity", RibbonEmitter.Gravity);
      this.WriteInteger(Node, "rows", RibbonEmitter.Rows);
      this.WriteInteger(Node, "columns", RibbonEmitter.Columns);
      this.SaveAnimator<float>(Saver, Node, Model, RibbonEmitter.HeightAbove, (IValue<float>) CFloat.Instance, "height_above");
      this.SaveAnimator<float>(Saver, Node, Model, RibbonEmitter.HeightBelow, (IValue<float>) CFloat.Instance, "height_below");
      this.SaveAnimator<float>(Saver, Node, Model, RibbonEmitter.Alpha, (IValue<float>) CFloat.Instance, "alpha");
      this.SaveAnimator<MdxLib.Primitives.CVector3>(Saver, Node, Model, RibbonEmitter.Color, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Xml.Value.CVector3.Instance, "color");
      this.SaveAnimator<int>(Saver, Node, Model, RibbonEmitter.TextureSlot, (IValue<int>) CInteger.Instance, "texture_slot");
      this.SaveAnimator<float>(Saver, Node, Model, RibbonEmitter.Visibility, (IValue<float>) CFloat.Instance, "visibility");
      this.WriteInteger(Node, "material", RibbonEmitter.Material.ObjectId);
    }

    public static CRibbonEmitter Instance => CRibbonEmitter.CSingleton.Instance;

    private static class CSingleton
    {
      public static CRibbonEmitter Instance = new CRibbonEmitter();
    }
  }
}
