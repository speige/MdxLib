// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.CObject
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Animator;
using MdxLib.ModelFormats.Xml.Value;
using System.Xml;

namespace MdxLib.ModelFormats.Xml
{
  internal abstract class CObject : CUnknown
  {
    public void LoadAnimator<T>(
      CLoader Loader,
      XmlNode Node,
      MdxLib.Model.CModel Model,
      CAnimator<T> Animator,
      IValue<T> ValueHandler,
      string Name)
      where T : new()
    {
      if (!(Node.SelectSingleNode(Name) is XmlElement Node1))
        return;
      T DefaultValue = new T();
      if (this.Bool(Node1.GetAttribute("animated"), false))
      {
        Animator.MakeAnimated();
        Animator.Type = this.StringToType(this.ReadString((XmlNode) Node1, "type", this.TypeToString(Animator.Type)));
        Loader.Attacher.AddObject<MdxLib.Model.CGlobalSequence>(Model.GlobalSequences, Animator.GlobalSequence, this.ReadInteger((XmlNode) Node1, "global_sequence", -1));
        foreach (XmlNode selectNode in Node1.SelectNodes("node"))
        {
          CAnimatorNode<T> Node2 = new CAnimatorNode<T>(this.ReadInteger(selectNode, "time", 0), ValueHandler.Read(selectNode, "value", Animator.GetValue()), ValueHandler.Read(selectNode, "in_tangent", DefaultValue), ValueHandler.Read(selectNode, "out_tangent", DefaultValue));
          Animator.Add(Node2);
        }
      }
      else
      {
        T StaticValue = ValueHandler.Read((XmlNode) Node1, "static", Animator.GetValue());
        Animator.MakeStatic(StaticValue);
      }
    }

    public void SaveAnimator<T>(
      CSaver Saver,
      XmlNode Node,
      MdxLib.Model.CModel Model,
      CAnimator<T> Animator,
      IValue<T> ValueHandler,
      string Name)
      where T : new()
    {
      XmlElement Node1 = this.AppendElement(Node, Name);
      this.AppendAttribute((XmlNode) Node1, "animated", Animator.Animated ? "1" : "0");
      if (Animator.Animated)
      {
        this.WriteString((XmlNode) Node1, "type", this.TypeToString(Animator.Type));
        this.WriteInteger(Node, "global_sequence", Animator.GlobalSequence.ObjectId);
        foreach (CAnimatorNode<T> canimatorNode in Animator)
        {
          XmlNode Node2 = (XmlNode) this.AppendElement((XmlNode) Node1, "node");
          this.WriteInteger(Node2, "time", canimatorNode.Time);
          ValueHandler.Write(Node2, "value", canimatorNode.Value);
          ValueHandler.Write(Node2, "in_tangent", canimatorNode.InTangent);
          ValueHandler.Write(Node2, "out_tangent", canimatorNode.OutTangent);
        }
      }
      else
        ValueHandler.Write((XmlNode) Node1, "static", Animator.GetValue());
    }

    private string TypeToString(EInterpolationType Type)
    {
      switch (Type)
      {
        case EInterpolationType.None:
          return "none";
        case EInterpolationType.Linear:
          return "linear";
        case EInterpolationType.Bezier:
          return "bezier";
        case EInterpolationType.Hermite:
          return "hermite";
        default:
          return "";
      }
    }

    private EInterpolationType StringToType(string String)
    {
      switch (String)
      {
        case "none":
          return EInterpolationType.None;
        case "linear":
          return EInterpolationType.Linear;
        case "bezier":
          return EInterpolationType.Bezier;
        case "hermite":
          return EInterpolationType.Hermite;
        default:
          return EInterpolationType.None;
      }
    }
  }
}
