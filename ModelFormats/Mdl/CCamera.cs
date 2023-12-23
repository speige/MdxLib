// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdl.CCamera
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.ModelFormats.Mdl.Token;
using MdxLib.ModelFormats.Mdl.Value;
using System;

namespace MdxLib.ModelFormats.Mdl
{
  internal sealed class CCamera : CObject
  {
    private CCamera()
    {
    }

    public void LoadAll(CLoader Loader, MdxLib.Model.CModel Model)
    {
      MdxLib.Model.CCamera ccamera = new MdxLib.Model.CCamera(Model);
      this.Load(Loader, Model, ccamera);
      Model.Cameras.Add(ccamera);
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CCamera Camera)
    {
      Camera.Name = Loader.ReadString();
      Loader.ExpectToken(EType.CurlyBracketLeft);
      while (Loader.PeekToken() != EType.CurlyBracketRight)
      {
        string str1 = Loader.ReadWord();
        switch (str1)
        {
          case "static":
            string str2 = Loader.ReadWord();
            switch (str2)
            {
              case "translation":
                this.LoadStaticAnimator<MdxLib.Primitives.CVector3>(Loader, Model, Camera.Translation, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdl.Value.CVector3.Instance);
                continue;
              case "rotation":
                this.LoadStaticAnimator<float>(Loader, Model, Camera.Rotation, (IValue<float>) CFloat.Instance);
                continue;
              default:
                throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + str2 + "\"!");
            }
          case "translation":
            this.LoadAnimator<MdxLib.Primitives.CVector3>(Loader, Model, Camera.Translation, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdl.Value.CVector3.Instance);
            continue;
          case "rotation":
            this.LoadAnimator<float>(Loader, Model, Camera.Rotation, (IValue<float>) CFloat.Instance);
            continue;
          case "position":
            Camera.Position = this.LoadVector3(Loader);
            continue;
          case "fieldofview":
            Camera.FieldOfView = this.LoadFloat(Loader);
            continue;
          case "nearclip":
            Camera.NearDistance = this.LoadFloat(Loader);
            continue;
          case "farclip":
            Camera.FarDistance = this.LoadFloat(Loader);
            continue;
          case "target":
            Loader.ExpectToken(EType.CurlyBracketLeft);
            if (Loader.PeekToken() == EType.CurlyBracketRight)
            {
              int num = (int) Loader.ReadToken();
              continue;
            }
            string str3 = Loader.ReadWord();
            switch (str3)
            {
              case "static":
                string str4 = Loader.ReadWord();
                switch (str4)
                {
                  case "translation":
                    this.LoadStaticAnimator<MdxLib.Primitives.CVector3>(Loader, Model, Camera.TargetTranslation, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdl.Value.CVector3.Instance);
                    continue;
                  default:
                    throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + str4 + "\"!");
                }
              case "translation":
                this.LoadAnimator<MdxLib.Primitives.CVector3>(Loader, Model, Camera.TargetTranslation, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdl.Value.CVector3.Instance);
                continue;
              case "position":
                Camera.TargetPosition = this.LoadVector3(Loader);
                continue;
              default:
                throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + str3 + "\"!");
            }
          default:
            throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + str1 + "\"!");
        }
      }
      int num1 = (int) Loader.ReadToken();
    }

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasCameras)
        return;
      foreach (MdxLib.Model.CCamera camera in Model.Cameras)
        this.Save(Saver, Model, camera);
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CCamera Camera)
    {
      Saver.BeginGroup(nameof (Camera), Camera.Name);
      this.SaveFloat(Saver, "FieldOfView", Camera.FieldOfView);
      this.SaveFloat(Saver, "FarClip", Camera.FarDistance);
      this.SaveFloat(Saver, "NearClip", Camera.NearDistance);
      this.SaveVector3(Saver, "Position", Camera.Position);
      this.SaveAnimator<MdxLib.Primitives.CVector3>(Saver, Model, Camera.Translation, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdl.Value.CVector3.Instance, "Translation", ECondition.NotZero);
      Saver.BeginGroup("Target");
      this.SaveVector3(Saver, "Position", Camera.TargetPosition);
      this.SaveAnimator<MdxLib.Primitives.CVector3>(Saver, Model, Camera.TargetTranslation, (IValue<MdxLib.Primitives.CVector3>) MdxLib.ModelFormats.Mdl.Value.CVector3.Instance, "Translation", ECondition.NotZero);
      this.SaveAnimator<float>(Saver, Model, Camera.Rotation, (IValue<float>) CFloat.Instance, "Rotation", ECondition.NotZero);
      Saver.EndGroup();
      Saver.EndGroup();
    }

    public static CCamera Instance => CCamera.CSingleton.Instance;

    private static class CSingleton
    {
      public static CCamera Instance = new CCamera();
    }
  }
}
