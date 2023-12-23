// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.CAttachment
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.ModelFormats.Xml.Value;
using System.Xml;

namespace MdxLib.ModelFormats.Xml
{
  internal sealed class CAttachment : CNode
  {
    private CAttachment()
    {
    }

    public void Load(CLoader Loader, XmlNode Node, MdxLib.Model.CModel Model, MdxLib.Model.CAttachment Attachment)
    {
      this.LoadNode<MdxLib.Model.CAttachment>(Loader, Node, Model, Attachment);
      Attachment.Path = this.ReadString(Node, "path", Attachment.Path);
      Attachment.AttachmentId = this.ReadInteger(Node, "attachment_id", Attachment.AttachmentId);
      this.LoadAnimator<float>(Loader, Node, Model, Attachment.Visibility, (IValue<float>) CFloat.Instance, "visibility");
    }

    public void Save(CSaver Saver, XmlNode Node, MdxLib.Model.CModel Model, MdxLib.Model.CAttachment Attachment)
    {
      this.SaveNode<MdxLib.Model.CAttachment>(Saver, Node, Model, Attachment);
      this.WriteString(Node, "path", Attachment.Path);
      this.WriteInteger(Node, "attachment_id", Attachment.AttachmentId);
      this.SaveAnimator<float>(Saver, Node, Model, Attachment.Visibility, (IValue<float>) CFloat.Instance, "visibility");
    }

    public static CAttachment Instance => CAttachment.CSingleton.Instance;

    private static class CSingleton
    {
      public static CAttachment Instance = new CAttachment();
    }
  }
}
