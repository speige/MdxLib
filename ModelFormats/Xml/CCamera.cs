// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.CCamera
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.ModelFormats.Xml.Value;
using System.Xml;

namespace MdxLib.ModelFormats.Xml
{
  internal sealed class CCamera : CObject
  {
    private CCamera()
    {
    }

    public void Load(CLoader Loader, XmlNode Node, MdxLib.Model.CModel Model, MdxLib.Model.CCamera Camera)
    {
      Camera.Name = this.ReadString(Node, "name", Camera.Name);
      Camera.FieldOfView = this.ReadFloat(Node, "field_of_view", Camera.FieldOfView);
      Camera.NearDistance = this.ReadFloat(Node, "near_distance", Camera.NearDistance);
      Camera.FarDistance = this.ReadFloat(Node, "far_distance", Camera.FarDistance);
      Camera.Position = this.ReadVector3(Node, "position", Camera.Position);
      Camera.TargetPosition = this.ReadVector3(Node, "target_position", Camera.TargetPosition);
      this.LoadAnimator<MdxLib.Primitives.CVector3>(Loader, Node, Model, Camera.Translation, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Xml.Value.CVector3.Instance, "source_translation");
      this.LoadAnimator<MdxLib.Primitives.CVector3>(Loader, Node, Model, Camera.TargetTranslation, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Xml.Value.CVector3.Instance, "target_translation");
      this.LoadAnimator<float>(Loader, Node, Model, Camera.Rotation, (IValue<float>) CFloat.Instance, "rotation");
    }

    public void Save(CSaver Saver, XmlNode Node, MdxLib.Model.CModel Model, MdxLib.Model.CCamera Camera)
    {
      this.WriteString(Node, "name", Camera.Name);
      this.WriteFloat(Node, "field_of_view", Camera.FieldOfView);
      this.WriteFloat(Node, "near_distance", Camera.NearDistance);
      this.WriteFloat(Node, "far_distance", Camera.FarDistance);
      this.WriteVector3(Node, "position", Camera.Position);
      this.WriteVector3(Node, "target_position", Camera.TargetPosition);
      this.SaveAnimator<MdxLib.Primitives.CVector3>(Saver, Node, Model, Camera.Translation, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Xml.Value.CVector3.Instance, "source_translation");
      this.SaveAnimator<MdxLib.Primitives.CVector3>(Saver, Node, Model, Camera.TargetTranslation, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Xml.Value.CVector3.Instance, "target_translation");
      this.SaveAnimator<float>(Saver, Node, Model, Camera.Rotation, (IValue<float>) CFloat.Instance, "rotation");
    }

    public static CCamera Instance => CCamera.CSingleton.Instance;

    private static class CSingleton
    {
      public static CCamera Instance = new CCamera();
    }
  }
}
