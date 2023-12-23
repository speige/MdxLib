// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdl.CPivotPoint
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.ModelFormats.Mdl.Token;
using MdxLib.Primitives;
using System.Collections.Generic;

namespace MdxLib.ModelFormats.Mdl
{
  internal sealed class CPivotPoint : CObject
  {
    private CPivotPoint()
    {
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, ICollection<CVector3> PivotPointList)
    {
      Loader.ReadInteger();
      Loader.ExpectToken(EType.CurlyBracketLeft);
      while (Loader.PeekToken() != EType.CurlyBracketRight)
        PivotPointList.Add(this.LoadVector3(Loader));
      int num = (int) Loader.ReadToken();
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, ICollection<CVector3> PivotPointList)
    {
      if (PivotPointList.Count <= 0)
        return;
      Saver.BeginGroup("PivotPoints", PivotPointList.Count);
      foreach (CVector3 pivotPoint in (IEnumerable<CVector3>) PivotPointList)
      {
        Saver.WriteTabs();
        Saver.WriteVector3(pivotPoint);
        Saver.WriteLine(",");
      }
      Saver.EndGroup();
    }

    public static CPivotPoint Instance => CPivotPoint.CSingleton.Instance;

    private static class CSingleton
    {
      public static CPivotPoint Instance = new CPivotPoint();
    }
  }
}
