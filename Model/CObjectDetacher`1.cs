// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CObjectDetacher`1
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

namespace MdxLib.Model
{
  internal sealed class CObjectDetacher<T> : CDetacher where T : CObject<T>
  {
    private T Object = default (T);
    private CObjectReference<T> Reference;

    public CObjectDetacher(CObjectReference<T> ObjectReference)
    {
      this.Reference = ObjectReference;
      this.Object = this.Reference.Object;
    }

    public override void Detach()
    {
      if ((object) this.Object == null)
        return;
      this.Reference.ForceDetach();
    }

    public override void Attach()
    {
      if ((object) this.Object == null)
        return;
      this.Reference.ForceAttach(this.Object);
    }
  }
}
