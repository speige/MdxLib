// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdl.CModel
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using MdxLib.ModelFormats.Mdl.Token;
using MdxLib.Primitives;
using System;
using System.Collections.Generic;

namespace MdxLib.ModelFormats.Mdl
{
  internal sealed class CModel : CObject
  {
    private CModel()
    {
    }

    public void Load(CLoader Loader, MdxLib.Model.CModel Model)
    {
      List<CVector3> PivotPointList = new List<CVector3>();
      while (true)
      {
        string str;
        try
        {
          str = Loader.PeekToken() != EType.MetaComment ? Loader.ReadWord() : "metacomment";
        }
        catch (Exception ex)
        {
          if (!Loader.Eof)
            throw ex;
          break;
        }
        switch (str)
        {
          case "version":
            CModelVersion.Instance.Load(Loader, Model);
            continue;
          case "model":
            CModelInfo.Instance.Load(Loader, Model);
            continue;
          case "sequences":
            CSequence.Instance.LoadAll(Loader, Model);
            continue;
          case "globalsequences":
            CGlobalSequence.Instance.LoadAll(Loader, Model);
            continue;
          case "textures":
            CTexture.Instance.LoadAll(Loader, Model);
            continue;
          case "materials":
            CMaterial.Instance.LoadAll(Loader, Model);
            continue;
          case "textureanims":
            CTextureAnimation.Instance.LoadAll(Loader, Model);
            continue;
          case "geoset":
            CGeoset.Instance.LoadAll(Loader, Model);
            continue;
          case "geosetanim":
            CGeosetAnimation.Instance.LoadAll(Loader, Model);
            continue;
          case "bone":
            CBone.Instance.LoadAll(Loader, Model);
            continue;
          case "light":
            CLight.Instance.LoadAll(Loader, Model);
            continue;
          case "helper":
            CHelper.Instance.LoadAll(Loader, Model);
            continue;
          case "attachment":
            CAttachment.Instance.LoadAll(Loader, Model);
            continue;
          case "pivotpoints":
            CPivotPoint.Instance.Load(Loader, Model, (ICollection<CVector3>) PivotPointList);
            continue;
          case "particleemitter":
            CParticleEmitter.Instance.LoadAll(Loader, Model);
            continue;
          case "particleemitter2":
            CParticleEmitter2.Instance.LoadAll(Loader, Model);
            continue;
          case "ribbonemitter":
            CRibbonEmitter.Instance.LoadAll(Loader, Model);
            continue;
          case "eventobject":
            CEvent.Instance.LoadAll(Loader, Model);
            continue;
          case "camera":
            CCamera.Instance.LoadAll(Loader, Model);
            continue;
          case "collisionshape":
            CCollisionShape.Instance.LoadAll(Loader, Model);
            continue;
          case "metacomment":
            CMetaData.Instance.Load(Loader, Model);
            continue;
          default:
            continue;
        }
      }
      this.SetPivotPoints(Model, (ICollection<CVector3>) PivotPointList);
    }

    public void Save(CSaver Saver, MdxLib.Model.CModel Model)
    {
      List<CVector3> PivotPointList = new List<CVector3>();
      this.GetPivotPoints(Model, (ICollection<CVector3>) PivotPointList);
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
