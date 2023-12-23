// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdx.CModel
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using MdxLib.Primitives;
using System.Collections.Generic;
using System.IO;

namespace MdxLib.ModelFormats.Mdx
{
  internal sealed class CModel
  {
    private CModel()
    {
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model)
    {
      List<CVector3> PivotPointList = new List<CVector3>();
      Loader.ExpectTag("MDLX");
      while (true)
      {
        string str;
        try
        {
          if (!Loader.Eof())
            str = Loader.ReadTag();
          else
            break;
        }
        catch (EndOfStreamException ex)
        {
          break;
        }
        switch (str)
        {
          case "VERS":
            CModelVersion.Instance.Load(Loader, Model);
            continue;
          case "MODL":
            CModelInfo.Instance.Load(Loader, Model);
            continue;
          case "SEQS":
            CSequence.Instance.LoadAll(Loader, Model);
            continue;
          case "GLBS":
            CGlobalSequence.Instance.LoadAll(Loader, Model);
            continue;
          case "TEXS":
            CTexture.Instance.LoadAll(Loader, Model);
            continue;
          case "MTLS":
            CMaterial.Instance.LoadAll(Loader, Model);
            continue;
          case "TXAN":
            CTextureAnimation.Instance.LoadAll(Loader, Model);
            continue;
          case "GEOS":
            CGeoset.Instance.LoadAll(Loader, Model);
            continue;
          case "GEOA":
            CGeosetAnimation.Instance.LoadAll(Loader, Model);
            continue;
          case "BONE":
            CBone.Instance.LoadAll(Loader, Model);
            continue;
          case "LITE":
            CLight.Instance.LoadAll(Loader, Model);
            continue;
          case "HELP":
            CHelper.Instance.LoadAll(Loader, Model);
            continue;
          case "ATCH":
            CAttachment.Instance.LoadAll(Loader, Model);
            continue;
          case "PIVT":
            CPivotPoint.Instance.Load(Loader, Model, (ICollection<CVector3>) PivotPointList);
            continue;
          case "PREM":
            CParticleEmitter.Instance.LoadAll(Loader, Model);
            continue;
          case "PRE2":
            CParticleEmitter2.Instance.LoadAll(Loader, Model);
            continue;
          case "RIBB":
            CRibbonEmitter.Instance.LoadAll(Loader, Model);
            continue;
          case "EVTS":
            CEvent.Instance.LoadAll(Loader, Model);
            continue;
          case "CAMS":
            CCamera.Instance.LoadAll(Loader, Model);
            continue;
          case "CLID":
            CCollisionShape.Instance.LoadAll(Loader, Model);
            continue;
          case "META":
            CMetaData.Instance.Load(Loader, Model);
            continue;
          default:
            Loader.Skip(Loader.ReadInt32());
            continue;
        }
      }
      this.SetPivotPoints(Model, (ICollection<CVector3>) PivotPointList);
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model, string Info)
    {
      List<CVector3> PivotPointList = new List<CVector3>();
      this.GetPivotPoints(Model, (ICollection<CVector3>) PivotPointList);
      Saver.WriteTag("MDLX");
      Saver.WriteTag("INFO");
      Saver.PushLocation();
      Saver.WriteString(Info, Info.Length);
      Saver.PopExclusiveLocation();
      CModelVersion.Instance.Save(Saver, Model);
      CModelInfo.Instance.Save(Saver, Model);
      CSequence.Instance.SaveAll(Saver, Model);
      CGlobalSequence.Instance.SaveAll(Saver, Model);
      CTexture.Instance.SaveAll(Saver, Model);
      CMaterial.Instance.SaveAll(Saver, Model);
      CTextureAnimation.Instance.SaveAll(Saver, Model);
      CGeoset.Instance.SaveAll(Saver, Model);
      CGeosetAnimation.Instance.SaveAll(Saver, Model);
      CBone.Instance.SaveAll(Saver, Model);
      CLight.Instance.SaveAll(Saver, Model);
      CHelper.Instance.SaveAll(Saver, Model);
      CAttachment.Instance.SaveAll(Saver, Model);
      CPivotPoint.Instance.Save(Saver, Model, (ICollection<CVector3>) PivotPointList);
      CParticleEmitter.Instance.SaveAll(Saver, Model);
      CParticleEmitter2.Instance.SaveAll(Saver, Model);
      CRibbonEmitter.Instance.SaveAll(Saver, Model);
      CEvent.Instance.SaveAll(Saver, Model);
      CCamera.Instance.SaveAll(Saver, Model);
      CCollisionShape.Instance.SaveAll(Saver, Model);
      CMetaData.Instance.Save(Saver, Model);
    }

    private void SetPivotPoints(MdxLib.Model.CModel Model, ICollection<CVector3> PivotPointList)
    {
      int Index = 0;
      int count = Model.Nodes.Count;
      foreach (CVector3 pivotPoint in (IEnumerable<CVector3>) PivotPointList)
      {
        if (Index >= count)
          break;
        Model.Nodes[Index].PivotPoint = pivotPoint;
        ++Index;
      }
    }

    private void GetPivotPoints(MdxLib.Model.CModel Model, ICollection<CVector3> PivotPointList)
    {
      foreach (INode node in Model.Nodes)
        PivotPointList.Add(node.PivotPoint);
    }

    public static CModel Instance => CModel.CSingleton.Instance;

    private static class CSingleton
    {
      public static CModel Instance = new CModel();
    }
  }
}
