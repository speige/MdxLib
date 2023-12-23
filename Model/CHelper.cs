// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CHelper
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

namespace MdxLib.Model
{
  public sealed class CHelper : CNode<CHelper>
  {
    public CHelper(CModel Model)
      : base(Model)
    {
    }

    public override string ToString() => "Helper #" + (object) this.ObjectId;

    public override int NodeId => this.Model.GetHelperNodeId(this);
  }
}
