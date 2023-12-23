// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Attacher.CNodeAttacher
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;

namespace MdxLib.ModelFormats.Attacher
{
  internal class CNodeAttacher : IAttacher
  {
    private CModel _Model;
    private CNodeReference _Reference;
    private int _Id = -1;

    public CNodeAttacher(CModel Model, CNodeReference Reference, int Id)
    {
      this._Model = Model;
      this._Reference = Reference;
      this._Id = Id;
    }

    public void Attach()
    {
      if (this._Id == -1)
        return;
      this._Reference.Attach(this._Model.Nodes[this._Id]);
    }
  }
}
