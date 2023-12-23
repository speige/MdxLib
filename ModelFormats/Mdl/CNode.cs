// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdl.CNode
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using MdxLib.ModelFormats.Mdl.Token;
using MdxLib.ModelFormats.Mdl.Value;
using System;

namespace MdxLib.ModelFormats.Mdl
{
  internal abstract class CNode : CObject
  {
    public bool LoadNode<T>(CLoader Loader, MdxLib.Model.CModel Model, CNode<T> Node, string Tag) where T : CNode<T>
    {
      switch (Tag)
      {
        case "translation":
          this.LoadAnimator<MdxLib.Primitives.CVector3>(Loader, Model, Node.Translation, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdl.Value.CVector3.Instance);
          return true;
        case "rotation":
          this.LoadAnimator<MdxLib.Primitives.CVector4>(Loader, Model, Node.Rotation, (IValue<MdxLib.Primitives.CVector4>) MdxLib.ModelFormats.Mdl.Value.CVector4.Instance);
          return true;
        case "scaling":
          this.LoadAnimator<MdxLib.Primitives.CVector3>(Loader, Model, Node.Scaling, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdl.Value.CVector3.Instance);
          return true;
        case "objectid":
          this.LoadInteger(Loader);
          return true;
        case "parent":
          Loader.Attacher.AddNode(Model, Node.Parent, this.LoadId(Loader));
          return true;
        case "billboarded":
          Node.Billboarded = this.LoadBoolean(Loader);
          return true;
        case "billboardedlockx":
          Node.BillboardedLockX = this.LoadBoolean(Loader);
          return true;
        case "billboardedlocky":
          Node.BillboardedLockY = this.LoadBoolean(Loader);
          return true;
        case "billboardedlockz":
          Node.BillboardedLockZ = this.LoadBoolean(Loader);
          return true;
        case "cameraanchored":
          Node.CameraAnchored = this.LoadBoolean(Loader);
          return true;
        case "dontinherit":
          Loader.ExpectToken(EType.CurlyBracketLeft);
          while (Loader.PeekToken() != EType.CurlyBracketRight)
          {
            if (Loader.PeekToken() == EType.Separator)
            {
              int num1 = (int) Loader.ReadToken();
            }
            else
            {
              Tag = Loader.ReadWord();
              switch (Tag)
              {
                case "translation":
                  Node.DontInheritTranslation = true;
                  continue;
                case "rotation":
                  Node.DontInheritRotation = true;
                  continue;
                case "scaling":
                  Node.DontInheritScaling = true;
                  continue;
                default:
                  throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + Tag + "\"!");
              }
            }
          }
          int num2 = (int) Loader.ReadToken();
          Loader.ExpectToken(EType.Separator);
          return true;
        default:
          return false;
      }
    }

    public bool LoadStaticNode<T>(CLoader Loader, MdxLib.Model.CModel Model, CNode<T> Node, string Tag) where T : CNode<T>
    {
      switch (Tag)
      {
        case "translation":
          this.LoadStaticAnimator<MdxLib.Primitives.CVector3>(Loader, Model, Node.Translation, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdl.Value.CVector3.Instance);
          return true;
        case "rotation":
          this.LoadStaticAnimator<MdxLib.Primitives.CVector4>(Loader, Model, Node.Rotation, (IValue<MdxLib.Primitives.CVector4>) MdxLib.ModelFormats.Mdl.Value.CVector4.Instance);
          return true;
        case "scaling":
          this.LoadStaticAnimator<MdxLib.Primitives.CVector3>(Loader, Model, Node.Scaling, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdl.Value.CVector3.Instance);
          return true;
        default:
          return false;
      }
    }

    public void SaveNode<T>(CSaver Saver, MdxLib.Model.CModel Model, CNode<T> Node) where T : CNode<T>
    {
      int num1 = 0;
      this.SaveId(Saver, "ObjectId", Node.NodeId, ECondition.NotInvalidId);
      this.SaveId(Saver, "Parent", Node.Parent.NodeId, ECondition.NotInvalidId);
      if (Node.DontInheritTranslation)
        ++num1;
      if (Node.DontInheritRotation)
        ++num1;
      if (Node.DontInheritScaling)
        ++num1;
      if (num1 > 0)
      {
        Saver.WriteTabs();
        Saver.WriteWord("DontInherit { ");
        if (Node.DontInheritTranslation)
        {
          --num1;
          Saver.WriteWord("Translation");
          Saver.WriteWord(num1 > 0 ? ", " : "");
        }
        if (Node.DontInheritRotation)
        {
          --num1;
          Saver.WriteWord("Rotation");
          Saver.WriteWord(num1 > 0 ? ", " : "");
        }
        if (Node.DontInheritScaling)
        {
          int num2 = num1 - 1;
          Saver.WriteWord("Scaling");
          Saver.WriteWord(num2 > 0 ? ", " : "");
        }
        Saver.WriteLine(" },");
      }
      this.SaveBoolean(Saver, "Billboarded", Node.Billboarded);
      this.SaveBoolean(Saver, "BillboardedLockX", Node.BillboardedLockX);
      this.SaveBoolean(Saver, "BillboardedLockY", Node.BillboardedLockY);
      this.SaveBoolean(Saver, "BillboardedLockZ", Node.BillboardedLockZ);
      this.SaveBoolean(Saver, "CameraAnchored", Node.CameraAnchored);
      this.SaveAnimator<MdxLib.Primitives.CVector3>(Saver, Model, Node.Translation, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdl.Value.CVector3.Instance, "Translation", ECondition.NotZero);
      this.SaveAnimator<MdxLib.Primitives.CVector4>(Saver, Model, Node.Rotation, (IValue<MdxLib.Primitives.CVector4>) MdxLib.ModelFormats.Mdl.Value.CVector4.Instance, "Rotation", ECondition.NotDefaultQuaternion);
      this.SaveAnimator<MdxLib.Primitives.CVector3>(Saver, Model, Node.Scaling, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdl.Value.CVector3.Instance, "Scaling", ECondition.NotOne);
    }
  }
}
