// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdx.CNode
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using MdxLib.ModelFormats.Mdx.Value;
using System;

namespace MdxLib.ModelFormats.Mdx
{
  internal abstract class CNode : CObject
  {
    public static int LoadNode<T>(CLoader Loader, MdxLib.Model.CModel Model, CNode<T> Node) where T : CNode<T>
    {
      Loader.PushLocation();
      int num1 = Loader.ReadInt32();
      Node.Name = Loader.ReadString(80);
      Loader.ReadInt32();
      Loader.Attacher.AddNode(Model, Node.Parent, Loader.ReadInt32());
      int num2 = Loader.ReadInt32();
      Node.DontInheritTranslation = (num2 & 1) != 0;
      Node.DontInheritRotation = (num2 & 2) != 0;
      Node.DontInheritScaling = (num2 & 4) != 0;
      Node.Billboarded = (num2 & 8) != 0;
      Node.BillboardedLockX = (num2 & 16) != 0;
      Node.BillboardedLockY = (num2 & 32) != 0;
      Node.BillboardedLockZ = (num2 & 64) != 0;
      Node.CameraAnchored = (num2 & 128) != 0;
      int num3 = num1 - Loader.PopLocation();
      if (num3 < 0)
        throw new Exception("Error at location " + (object) Loader.Location + ", too many Node bytes were read!");
      while (num3 > 0)
      {
        Loader.PushLocation();
        string str = Loader.ReadTag();
        switch (str)
        {
          case "KGTR":
            CObject.LoadAnimator<MdxLib.Primitives.CVector3>(Loader, Model, Node.Translation, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdx.Value.CVector3.Instance);
            break;
          case "KGRT":
            CObject.LoadAnimator<MdxLib.Primitives.CVector4>(Loader, Model, Node.Rotation, (IValue<MdxLib.Primitives.CVector4>) MdxLib.ModelFormats.Mdx.Value.CVector4.Instance);
            break;
          case "KGSC":
            CObject.LoadAnimator<MdxLib.Primitives.CVector3>(Loader, Model, Node.Scaling, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdx.Value.CVector3.Instance);
            break;
          default:
            throw new Exception("Error at location " + (object) Loader.Location + ", unknown tag \"" + str + "\"!");
        }
        num3 -= Loader.PopLocation();
        if (num3 < 0)
          throw new Exception("Error at location " + (object) Loader.Location + ", too many Node bytes were read!");
      }
      return num2;
    }

    public static void SaveNode<T>(CSaver Saver, MdxLib.Model.CModel Model, CNode<T> Node, int Flags) where T : CNode<T>
    {
      if (Node.DontInheritTranslation)
        Flags |= 1;
      if (Node.DontInheritRotation)
        Flags |= 2;
      if (Node.DontInheritScaling)
        Flags |= 4;
      if (Node.Billboarded)
        Flags |= 8;
      if (Node.BillboardedLockX)
        Flags |= 16;
      if (Node.BillboardedLockY)
        Flags |= 32;
      if (Node.BillboardedLockZ)
        Flags |= 64;
      if (Node.CameraAnchored)
        Flags |= 128;
      Saver.PushLocation();
      Saver.WriteString(Node.Name, 80);
      Saver.WriteInt32(Node.NodeId);
      Saver.WriteInt32(Node.Parent.NodeId);
      Saver.WriteInt32(Flags);
      CObject.SaveAnimator<MdxLib.Primitives.CVector3>(Saver, Model, Node.Translation, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdx.Value.CVector3.Instance, "KGTR");
      CObject.SaveAnimator<MdxLib.Primitives.CVector4>(Saver, Model, Node.Rotation, (IValue<MdxLib.Primitives.CVector4>) MdxLib.ModelFormats.Mdx.Value.CVector4.Instance, "KGRT");
      CObject.SaveAnimator<MdxLib.Primitives.CVector3>(Saver, Model, Node.Scaling, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdx.Value.CVector3.Instance, "KGSC");
      Saver.PopInclusiveLocation();
    }
  }
}
