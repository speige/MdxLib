// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdl.CObject
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Animator;
using MdxLib.ModelFormats.Mdl.Token;
using MdxLib.ModelFormats.Mdl.Value;
using System;

namespace MdxLib.ModelFormats.Mdl
{
  internal abstract class CObject : CUnknown
  {
    public void LoadAnimator<T>(
      CLoader Loader,
      MdxLib.Model.CModel Model,
      CAnimator<T> Animator,
      IValue<T> ValueHandler)
      where T : new()
    {
      Animator.MakeAnimated();
      Loader.ReadInteger();
      Loader.ExpectToken(EType.CurlyBracketLeft);
      while (Loader.PeekToken() == EType.Word)
      {
        string str = Loader.ReadWord();
        switch (str)
        {
          case "dontinterp":
            Animator.Type = EInterpolationType.None;
            Loader.ExpectToken(EType.Separator);
            continue;
          case "linear":
            Animator.Type = EInterpolationType.Linear;
            Loader.ExpectToken(EType.Separator);
            continue;
          case "bezier":
            Animator.Type = EInterpolationType.Bezier;
            Loader.ExpectToken(EType.Separator);
            continue;
          case "hermite":
            Animator.Type = EInterpolationType.Hermite;
            Loader.ExpectToken(EType.Separator);
            continue;
          case "globalseqid":
            Loader.Attacher.AddObject<MdxLib.Model.CGlobalSequence>(Model.GlobalSequences, Animator.GlobalSequence, Loader.ReadInteger());
            Loader.ExpectToken(EType.Separator);
            continue;
          default:
            throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + str + "\"!");
        }
      }
      while (Loader.PeekToken() != EType.CurlyBracketRight)
      {
        int Time = Loader.ReadInteger();
        Loader.ExpectToken(EType.Colon);
        T obj = ValueHandler.Read(Loader);
        Loader.ExpectToken(EType.Separator);
        switch (Animator.Type)
        {
          case EInterpolationType.None:
          case EInterpolationType.Linear:
            Animator.Add(new CAnimatorNode<T>(Time, obj));
            continue;
          case EInterpolationType.Bezier:
          case EInterpolationType.Hermite:
            Loader.ExpectWord("intan");
            T InTangent = ValueHandler.Read(Loader);
            Loader.ExpectToken(EType.Separator);
            Loader.ExpectWord("outtan");
            T OutTangent = ValueHandler.Read(Loader);
            Loader.ExpectToken(EType.Separator);
            Animator.Add(new CAnimatorNode<T>(Time, obj, InTangent, OutTangent));
            continue;
          default:
            continue;
        }
      }
      int num = (int) Loader.ReadToken();
    }

    public void LoadStaticAnimator<T>(
      CLoader Loader,
      MdxLib.Model.CModel Model,
      CAnimator<T> Animator,
      IValue<T> ValueHandler)
      where T : new()
    {
      Animator.MakeStatic(ValueHandler.Read(Loader));
      Loader.ExpectToken(EType.Separator);
    }

    public void SaveAnimator<T>(
      CSaver Saver,
      MdxLib.Model.CModel Model,
      CAnimator<T> Animator,
      IValue<T> ValueHandler,
      string Name)
      where T : new()
    {
      this.SaveAnimator<T>(Saver, Model, Animator, ValueHandler, Name, ECondition.Always);
    }

    public void SaveAnimator<T>(
      CSaver Saver,
      MdxLib.Model.CModel Model,
      CAnimator<T> Animator,
      IValue<T> ValueHandler,
      string Name,
      ECondition Condition)
      where T : new()
    {
      if (Animator.Static)
      {
        if (!ValueHandler.ValidCondition(Animator.GetValue(), Condition))
          return;
        Saver.WriteTabs();
        Saver.WriteWord("static " + Name + " ");
        ValueHandler.Write(Saver, Animator.GetValue());
        Saver.WriteLine(",");
      }
      else
      {
        Saver.BeginGroup(Name, Animator.Count);
        this.SaveBoolean(Saver, this.TypeToString(Animator.Type), true);
        this.SaveId(Saver, "GlobalSeqId", Animator.GlobalSequence.ObjectId, ECondition.NotInvalidId);
        foreach (CAnimatorNode<T> canimatorNode in Animator)
        {
          Saver.WriteTabs();
          Saver.WriteInteger(canimatorNode.Time);
          Saver.WriteWord(": ");
          ValueHandler.Write(Saver, canimatorNode.Value);
          Saver.WriteLine(",");
          switch (Animator.Type)
          {
            case EInterpolationType.Bezier:
            case EInterpolationType.Hermite:
              Saver.WriteTabs();
              Saver.WriteTabs(1);
              Saver.WriteWord("InTan ");
              ValueHandler.Write(Saver, canimatorNode.InTangent);
              Saver.WriteLine(",");
              Saver.WriteTabs();
              Saver.WriteTabs(1);
              Saver.WriteWord("OutTan ");
              ValueHandler.Write(Saver, canimatorNode.OutTangent);
              Saver.WriteLine(",");
              continue;
            default:
              continue;
          }
        }
        Saver.EndGroup();
      }
    }

    private string TypeToString(EInterpolationType Type)
    {
      switch (Type)
      {
        case EInterpolationType.None:
          return "DontInterp";
        case EInterpolationType.Linear:
          return "Linear";
        case EInterpolationType.Bezier:
          return "Bezier";
        case EInterpolationType.Hermite:
          return "Hermite";
        default:
          return "";
      }
    }
  }
}
