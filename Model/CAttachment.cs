// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CAttachment
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Animator;
using MdxLib.Animator.Animatable;

namespace MdxLib.Model
{
  public sealed class CAttachment : CNode<CAttachment>
  {
    private string _Path = "";
    private int _AttachmentId = -1;
    private CAnimator<float> _Visibility;

    public CAttachment(CModel Model)
      : base(Model)
    {
    }

    public override string ToString() => "Attachment #" + (object) this.ObjectId;

    public override int NodeId => this.Model.GetAttachmentNodeId(this);

    public string Path
    {
      get => this._Path;
      set
      {
        this.AddSetObjectFieldCommand<string>("_Path", value);
        this._Path = value;
      }
    }

    public int AttachmentId
    {
      get => this._AttachmentId;
      set
      {
        this.AddSetObjectFieldCommand<int>("_AttachmentId", value);
        this._AttachmentId = value;
      }
    }

    public CAnimator<float> Visibility => this._Visibility ?? (this._Visibility = new CAnimator<float>(this.Model, (CAnimatable<float>) new CFloat(1f)));
  }
}
