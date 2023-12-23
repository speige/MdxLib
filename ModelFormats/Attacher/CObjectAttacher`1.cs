// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Attacher.CObjectAttacher`1
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;

namespace MdxLib.ModelFormats.Attacher
{
  internal class CObjectAttacher<T> : IAttacher where T : CObject<T>
  {
    private CObjectContainer<T> _Container;
    private CObjectReference<T> _Reference;
    private int _Id = -1;

    public CObjectAttacher(CObjectContainer<T> Container, CObjectReference<T> Reference, int Id)
    {
      this._Container = Container;
      this._Reference = Reference;
      this._Id = Id;
    }

    public void Attach()
    {
      if (this._Id == -1)
        return;
      this._Reference.Attach(this._Container[this._Id]);
    }
  }
}
