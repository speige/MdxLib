// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Attacher.CAttacherContainer
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using System.Collections;
using System.Collections.Generic;

namespace MdxLib.ModelFormats.Attacher
{
  internal class CAttacherContainer : IEnumerable<IAttacher>, IEnumerable
  {
    private LinkedList<IAttacher> AttacherList;

    public CAttacherContainer() => this.AttacherList = new LinkedList<IAttacher>();

    public void Clear() => this.AttacherList.Clear();

    public void Add(IAttacher Attacher) => this.AttacherList.AddLast(Attacher);

    public void AddObject<T>(CObjectContainer<T> Container, CObjectReference<T> Reference, int Id) where T : CObject<T>
    {
      if (Id == -1)
        return;
      this.Add((IAttacher) new CObjectAttacher<T>(Container, Reference, Id));
    }

    public void AddNode(CModel Model, CNodeReference Reference, int Id)
    {
      if (Id == -1)
        return;
      this.Add((IAttacher) new CNodeAttacher(Model, Reference, Id));
    }

    public void Attach()
    {
      foreach (IAttacher attacher in this.AttacherList)
        attacher.Attach();
    }

    public IEnumerator<IAttacher> GetEnumerator() => (IEnumerator<IAttacher>) this.AttacherList.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.AttacherList.GetEnumerator();
  }
}
