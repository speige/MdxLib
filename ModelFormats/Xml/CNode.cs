// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.CNode
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using MdxLib.ModelFormats.Xml.Value;
using System.Xml;

namespace MdxLib.ModelFormats.Xml
{
  internal abstract class CNode : CObject
  {
    public void LoadNode<T>(CLoader Loader, XmlNode Node, MdxLib.Model.CModel Model, T ModelNode) where T : CNode<T>
    {
      ModelNode.Name = this.ReadString(Node, "name", ModelNode.Name);
      ModelNode.DontInheritTranslation = this.ReadBoolean(Node, "dont_inherit_translation", ModelNode.DontInheritTranslation);
      ModelNode.DontInheritRotation = this.ReadBoolean(Node, "dont_inherit_rotation", ModelNode.DontInheritRotation);
      ModelNode.DontInheritScaling = this.ReadBoolean(Node, "dont_inherit_scaling", ModelNode.DontInheritScaling);
      ModelNode.Billboarded = this.ReadBoolean(Node, "billboarded", ModelNode.Billboarded);
      ModelNode.BillboardedLockX = this.ReadBoolean(Node, "billboarded_lock_x", ModelNode.BillboardedLockX);
      ModelNode.BillboardedLockY = this.ReadBoolean(Node, "billboarded_lock_y", ModelNode.BillboardedLockY);
      ModelNode.BillboardedLockZ = this.ReadBoolean(Node, "billboarded_lock_z", ModelNode.BillboardedLockZ);
      ModelNode.CameraAnchored = this.ReadBoolean(Node, "camera_anchored", ModelNode.CameraAnchored);
      ModelNode.PivotPoint = this.ReadVector3(Node, "pivot_point", ModelNode.PivotPoint);
      Loader.Attacher.AddNode(Model, ModelNode.Parent, this.ReadInteger(Node, "parent", -1));
      this.LoadAnimator<MdxLib.Primitives.CVector3>(Loader, Node, Model, ModelNode.Translation, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Xml.Value.CVector3.Instance, "translation");
      this.LoadAnimator<MdxLib.Primitives.CVector4>(Loader, Node, Model, ModelNode.Rotation, (IValue<MdxLib.Primitives.CVector4>) MdxLib.ModelFormats.Xml.Value.CVector4.Instance, "rotation");
      this.LoadAnimator<MdxLib.Primitives.CVector3>(Loader, Node, Model, ModelNode.Scaling, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Xml.Value.CVector3.Instance, "scaling");
    }

    public void SaveNode<T>(CSaver Saver, XmlNode Node, MdxLib.Model.CModel Model, T ModelNode) where T : CNode<T>
    {
      this.WriteString(Node, "name", ModelNode.Name);
      this.WriteBoolean(Node, "dont_inherit_translation", ModelNode.DontInheritTranslation);
      this.WriteBoolean(Node, "dont_inherit_rotation", ModelNode.DontInheritRotation);
      this.WriteBoolean(Node, "dont_inherit_scaling", ModelNode.DontInheritScaling);
      this.WriteBoolean(Node, "billboarded", ModelNode.Billboarded);
      this.WriteBoolean(Node, "billboarded_lock_x", ModelNode.BillboardedLockX);
      this.WriteBoolean(Node, "billboarded_lock_y", ModelNode.BillboardedLockY);
      this.WriteBoolean(Node, "billboarded_lock_z", ModelNode.BillboardedLockZ);
      this.WriteBoolean(Node, "camera_anchored", ModelNode.CameraAnchored);
      this.WriteVector3(Node, "pivot_point", ModelNode.PivotPoint);
      this.WriteInteger(Node, "parent", ModelNode.Parent.NodeId);
      this.SaveAnimator<MdxLib.Primitives.CVector3>(Saver, Node, Model, ModelNode.Translation, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Xml.Value.CVector3.Instance, "translation");
      this.SaveAnimator<MdxLib.Primitives.CVector4>(Saver, Node, Model, ModelNode.Rotation, (IValue<MdxLib.Primitives.CVector4>) MdxLib.ModelFormats.Xml.Value.CVector4.Instance, "rotation");
      this.SaveAnimator<MdxLib.Primitives.CVector3>(Saver, Node, Model, ModelNode.Scaling, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Xml.Value.CVector3.Instance, "scaling");
    }
  }
}
