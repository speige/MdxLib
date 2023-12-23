// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdx.CCamera
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.ModelFormats.Mdx.Value;
using System;

namespace MdxLib.ModelFormats.Mdx
{
  internal sealed class CCamera : CObject
  {
    private CCamera()
    {
    }

    public void LoadAll(CLoader Loader, MdxLib.Model.CModel Model)
    {
      int num = Loader.ReadInt32();
      while (num > 0)
      {
        Loader.PushLocation();
        MdxLib.Model.CCamera ccamera = new MdxLib.Model.CCamera(Model);
        this.Load(Loader, Model, ccamera);
        Model.Cameras.Add(ccamera);
        num -= Loader.PopLocation();
        if (num < 0)
          throw new Exception("Error at location " + (object) Loader.Location + ", too many Camera bytes were read!");
      }
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CCamera Camera)
    {
      Loader.PushLocation();
      int num1 = Loader.ReadInt32();
      Camera.Name = Loader.ReadString(80);
      Camera.Position = Loader.ReadVector3();
      Camera.FieldOfView = Loader.ReadFloat();
      Camera.FarDistance = Loader.ReadFloat();
      Camera.NearDistance = Loader.ReadFloat();
      Camera.TargetPosition = Loader.ReadVector3();
      int num2 = num1 - Loader.PopLocation();
      if (num2 < 0)
        throw new Exception("Error at location " + (object) Loader.Location + ", too many Camera bytes were read!");
      while (num2 > 0)
      {
        Loader.PushLocation();
        string str = Loader.ReadTag();
        switch (str)
        {
          case "KCTR":
            CObject.LoadAnimator<MdxLib.Primitives.CVector3>(Loader, Model, Camera.Translation, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdx.Value.CVector3.Instance);
            break;
          case "KTTR":
            CObject.LoadAnimator<MdxLib.Primitives.CVector3>(Loader, Model, Camera.TargetTranslation, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdx.Value.CVector3.Instance);
            break;
          case "KCRL":
            CObject.LoadAnimator<float>(Loader, Model, Camera.Rotation, (IValue<float>) CFloat.Instance);
            break;
          default:
            throw new Exception("Error at location " + (object) Loader.Location + ", unknown Camera tag \"" + str + "\"!");
        }
        num2 -= Loader.PopLocation();
        if (num2 < 0)
          throw new Exception("Error at location " + (object) Loader.Location + ", too many Camera bytes were read!");
      }
    }

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasCameras)
        return;
      Saver.WriteTag("CAMS");
      Saver.PushLocation();
      foreach (MdxLib.Model.CCamera camera in Model.Cameras)
        this.Save(Saver, Model, camera);
      Saver.PopExclusiveLocation();
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CCamera Camera)
    {
      Saver.PushLocation();
      Saver.WriteString(Camera.Name, 80);
      Saver.WriteVector3(Camera.Position);
      Saver.WriteFloat(Camera.FieldOfView);
      Saver.WriteFloat(Camera.FarDistance);
      Saver.WriteFloat(Camera.NearDistance);
      Saver.WriteVector3(Camera.TargetPosition);
      CObject.SaveAnimator<MdxLib.Primitives.CVector3>(Saver, Model, Camera.Translation, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdx.Value.CVector3.Instance, "KCTR");
      CObject.SaveAnimator<MdxLib.Primitives.CVector3>(Saver, Model, Camera.TargetTranslation, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdx.Value.CVector3.Instance, "KTTR");
      CObject.SaveAnimator<float>(Saver, Model, Camera.Rotation, (IValue<float>) CFloat.Instance, "KCRL");
      Saver.PopInclusiveLocation();
    }

    public static CCamera Instance => CCamera.CSingleton.Instance;

    private static class CSingleton
    {
      public static CCamera Instance = new CCamera();
    }
  }
}
