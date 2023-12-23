// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdl.CAttachment
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using MdxLib.ModelFormats.Mdl.Token;
using MdxLib.ModelFormats.Mdl.Value;
using System;

namespace MdxLib.ModelFormats.Mdl
{
  internal sealed class CAttachment : CNode
  {
    private CAttachment()
    {
    }

    public void LoadAll(CLoader Loader, MdxLib.Model.CModel Model)
    {
      MdxLib.Model.CAttachment cattachment = new MdxLib.Model.CAttachment(Model);
      this.Load(Loader, Model, cattachment);
      Model.Attachments.Add(cattachment);
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CAttachment Attachment)
    {
      Attachment.Name = Loader.ReadString();
      Loader.ExpectToken(EType.CurlyBracketLeft);
      while (Loader.PeekToken() != EType.CurlyBracketRight)
      {
        string Tag1 = Loader.ReadWord();
        if (!this.LoadNode<MdxLib.Model.CAttachment>(Loader, Model, (CNode<MdxLib.Model.CAttachment>) Attachment, Tag1))
        {
          switch (Tag1)
          {
            case "static":
              string Tag2 = Loader.ReadWord();
              if (!this.LoadStaticNode<MdxLib.Model.CAttachment>(Loader, Model, (CNode<MdxLib.Model.CAttachment>) Attachment, Tag2))
              {
                switch (Tag2)
                {
                  case "visibility":
                    this.LoadStaticAnimator<float>(Loader, Model, Attachment.Visibility, (IValue<float>) CFloat.Instance);
                    continue;
                  default:
                    throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + Tag2 + "\"!");
                }
              }
              else
                continue;
            case "visibility":
              this.LoadAnimator<float>(Loader, Model, Attachment.Visibility, (IValue<float>) CFloat.Instance);
              continue;
            case "attachmentid":
              Attachment.AttachmentId = this.LoadInteger(Loader);
              continue;
            case "path":
              Attachment.Path = this.LoadString(Loader);
              continue;
            default:
              throw new Exception("Syntax error at line " + (object) Loader.Line + ", unknown tag \"" + Tag1 + "\"!");
          }
        }
      }
      int num = (int) Loader.ReadToken();
    }

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasAttachments)
        return;
      foreach (MdxLib.Model.CAttachment attachment in Model.Attachments)
        this.Save(Saver, Model, attachment);
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CAttachment Attachment)
    {
      Saver.BeginGroup(nameof (Attachment), Attachment.Name);
      this.SaveNode<MdxLib.Model.CAttachment>(Saver, Model, (CNode<MdxLib.Model.CAttachment>) Attachment);
      this.SaveId(Saver, "AttachmentID", Attachment.AttachmentId, ECondition.NotInvalidId);
      this.SaveString(Saver, "Path", Attachment.Path, ECondition.NotEmpty);
      this.SaveAnimator<float>(Saver, Model, Attachment.Visibility, (IValue<float>) CFloat.Instance, "Visibility", ECondition.NotOne);
      Saver.EndGroup();
    }

    public static CAttachment Instance => CAttachment.CSingleton.Instance;

    private static class CSingleton
    {
      public static CAttachment Instance = new CAttachment();
    }
  }
}
