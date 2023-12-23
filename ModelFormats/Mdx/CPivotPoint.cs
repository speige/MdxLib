// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdx.CPivotPoint
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Primitives;
using System;
using System.Collections.Generic;

namespace MdxLib.ModelFormats.Mdx
{
  internal sealed class CPivotPoint : CObject
  {
    private CPivotPoint()
    {
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model, ICollection<CVector3> PivotPointList)
    {
      int num = Loader.ReadInt32();
      while (num > 0)
      {
        Loader.PushLocation();
        PivotPointList.Add(Loader.ReadVector3());
        num -= Loader.PopLocation();
        if (num < 0)
          throw new Exception("Error at location " + (object) Loader.Location + ", too many PivotPoint bytes were read!");
      }
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, ICollection<CVector3> PivotPointList)
    {
      if (PivotPointList.Count <= 0)
        return;
      Saver.WriteTag("PIVT");
      Saver.PushLocation();
      foreach (CVector3 pivotPoint in (IEnumerable<CVector3>) PivotPointList)
        Saver.WriteVector3(pivotPoint);
      Saver.PopExclusiveLocation();
    }

    public static CPivotPoint Instance => CPivotPoint.CSingleton.Instance;

    private static class CSingleton
    {
      public static CPivotPoint Instance = new CPivotPoint();
    }
  }
}
