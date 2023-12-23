// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CNodeDetacher
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

namespace MdxLib.Model
{
  internal sealed class CNodeDetacher : CDetacher
  {
    private INode Node;
    private CNodeReference Reference;

    public CNodeDetacher(CNodeReference NodeReference)
    {
      this.Reference = NodeReference;
      this.Node = this.Reference.Node;
    }

    public override void Detach()
    {
      if (this.Node == null)
        return;
      this.Reference.ForceDetach();
    }

    public override void Attach()
    {
      if (this.Node == null)
        return;
      this.Reference.ForceAttach(this.Node);
    }
  }
}
