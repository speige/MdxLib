// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CDetacher
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System.Collections.Generic;

namespace MdxLib.Model
{
  internal abstract class CDetacher
  {
    public abstract void Detach();

    public abstract void Attach();

    public static void DetachAllDetachers(IEnumerable<CDetacher> DetacherList)
    {
      foreach (CDetacher detacher in DetacherList)
        detacher.Detach();
    }

    public static void AttachAllDetachers(IEnumerable<CDetacher> DetacherList)
    {
      foreach (CDetacher detacher in DetacherList)
        detacher.Attach();
    }
  }
}
