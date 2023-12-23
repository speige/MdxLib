// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdx.CObject
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Animator;
using MdxLib.ModelFormats.Mdx.Value;

namespace MdxLib.ModelFormats.Mdx
{
  internal abstract class CObject : CUnknown
  {
    public static void LoadAnimator<T>(
      CLoader Loader,
      MdxLib.Model.CModel Model,
      CAnimator<T> Animator,
      IValue<T> ValueHandler)
      where T : new()
    {
      Animator.MakeAnimated();
      int num1 = Loader.ReadInt32();
      int num2 = Loader.ReadInt32();
      Loader.Attacher.AddObject<MdxLib.Model.CGlobalSequence>(Model.GlobalSequences, Animator.GlobalSequence, Loader.ReadInt32());
      switch (num2)
      {
        case 0:
          Animator.Type = EInterpolationType.None;
          break;
        case 1:
          Animator.Type = EInterpolationType.Linear;
          break;
        case 2:
          Animator.Type = EInterpolationType.Hermite;
          break;
        case 3:
          Animator.Type = EInterpolationType.Bezier;
          break;
      }
      for (int index = 0; index < num1; ++index)
      {
        int Time = Loader.ReadInt32();
        T obj = ValueHandler.Read(Loader);
        if (num2 > 1)
        {
          T InTangent = ValueHandler.Read(Loader);
          T OutTangent = ValueHandler.Read(Loader);
          Animator.Add(new CAnimatorNode<T>(Time, obj, InTangent, OutTangent));
        }
        else
          Animator.Add(new CAnimatorNode<T>(Time, obj));
      }
    }

    public static void SaveAnimator<T>(
      CSaver Saver,
      MdxLib.Model.CModel Model,
      CAnimator<T> Animator,
      IValue<T> ValueHandler,
      string Tag)
      where T : new()
    {
      int num = 0;
      if (Animator.Static)
        return;
      switch (Animator.Type)
      {
        case EInterpolationType.None:
          num = 0;
          break;
        case EInterpolationType.Linear:
          num = 1;
          break;
        case EInterpolationType.Bezier:
          num = 3;
          break;
        case EInterpolationType.Hermite:
          num = 2;
          break;
      }
      Saver.WriteTag(Tag);
      Saver.WriteInt32(Animator.Count);
      Saver.WriteInt32(num);
      Saver.WriteInt32(Animator.GlobalSequence.ObjectId);
      foreach (CAnimatorNode<T> canimatorNode in Animator)
      {
        Saver.WriteInt32(canimatorNode.Time);
        ValueHandler.Write(Saver, canimatorNode.Value);
        if (num > 1)
        {
          ValueHandler.Write(Saver, canimatorNode.InTangent);
          ValueHandler.Write(Saver, canimatorNode.OutTangent);
        }
      }
    }
  }
}
