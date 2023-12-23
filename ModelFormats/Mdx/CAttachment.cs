// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdx.CAttachment
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using MdxLib.ModelFormats.Mdx.Value;
using System;

namespace MdxLib.ModelFormats.Mdx
{
  internal sealed class CAttachment : CNode
  {
    private CAttachment()
    {
    }

    public void LoadAll(CLoader Loader, MdxLib.Model.CModel Model)
    {
      int num = Loader.ReadInt32();
      while (num > 0)
      {
        Loader.PushLocation();
        MdxLib.Model.CAttachment cattachment = new MdxLib.Model.CAttachment(Model);
        this.Load(Loader, Model, cattachment);
        Model.Attachments.Add(cattachment);
        num -= Loader.PopLocation();
        if (num < 0)
          throw new Exception("Error at location " + (object) Loader.Location + ", too many Attachment bytes were read!");
      }
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, MdxLib.Model.CAttachment Attachment)
    {
      Loader.PushLocation();
      int num1 = Loader.ReadInt32();
      CNode.LoadNode<MdxLib.Model.CAttachment>(Loader, Model, (CNode<MdxLib.Model.CAttachment>) Attachment);
      Attachment.Path = Loader.ReadString(260);
      Attachment.AttachmentId = Loader.ReadInt32();
      int num2 = num1 - Loader.PopLocation();
      if (num2 < 0)
        throw new Exception("Error at location " + (object) Loader.Location + ", too many Attachment bytes were read!");
      while (num2 > 0)
      {
        Loader.PushLocation();
        string str = Loader.ReadTag();
        switch (str)
        {
          case "KATV":
            CObject.LoadAnimator<float>(Loader, Model, Attachment.Visibility, (IValue<float>) CFloat.Instance);
            num2 -= Loader.PopLocation();
            if (num2 < 0)
              throw new Exception("Error at location " + (object) Loader.Location + ", too many Attachment bytes were read!");
            continue;
          default:
            throw new Exception("Error at location " + (object) Loader.Location + ", unknown Attachment tag \"" + str + "\"!");
        }
      }
    }

    public void SaveAll(CSaver Saver, MdxLib.Model.CModel Model)
    {
      if (!Model.HasAttachments)
        return;
      Saver.WriteTag("ATCH");
      Saver.PushLocation();
      foreach (MdxLib.Model.CAttachment attachment in Model.Attachments)
        this.Save(Saver, Model, attachment);
      Saver.PopExclusiveLocation();
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, MdxLib.Model.CAttachment Attachment)
    {
      Saver.PushLocation();
      CNode.SaveNode<MdxLib.Model.CAttachment>(Saver, Model, (CNode<MdxLib.Model.CAttachment>) Attachment, 2048);
      Saver.WriteString(Attachment.Path, 260);
      Saver.WriteInt32(Attachment.AttachmentId);
      CObject.SaveAnimator<float>(Saver, Model, Attachment.Visibility, (IValue<float>) CFloat.Instance, "KATV");
      Saver.PopInclusiveLocation();
    }

    public static CAttachment Instance => CAttachment.CSingleton.Instance;

    private static class CSingleton
    {
      public static CAttachment Instance = new CAttachment();
    }
  }
}
