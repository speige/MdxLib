// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Xml.CModel
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System.Xml;

namespace MdxLib.ModelFormats.Xml
{
  internal sealed class CModel : CObject
  {
    private CModel()
    {
    }

    public void Load(CLoader Loader, XmlNode Node, MdxLib.Model.CModel Model)
    {
      Model.Version = this.ReadInteger(Node, "version", Model.Version);
      Model.BlendTime = this.ReadInteger(Node, "blend_time", Model.BlendTime);
      Model.Name = this.ReadString(Node, "name", Model.Name);
      Model.AnimationFile = this.ReadString(Node, "animation_file", Model.AnimationFile);
      Model.Extent = this.ReadExtent(Node, "extent", Model.Extent);
      foreach (XmlNode selectNode in Node.SelectNodes("sequence"))
      {
        MdxLib.Model.CSequence csequence = new MdxLib.Model.CSequence(Model);
        CSequence.Instance.Load(Loader, selectNode, Model, csequence);
        Model.Sequences.Add(csequence);
      }
      foreach (XmlNode selectNode in Node.SelectNodes("global_sequence"))
      {
        MdxLib.Model.CGlobalSequence cglobalSequence = new MdxLib.Model.CGlobalSequence(Model);
        CGlobalSequence.Instance.Load(Loader, selectNode, Model, cglobalSequence);
        Model.GlobalSequences.Add(cglobalSequence);
      }
      foreach (XmlNode selectNode in Node.SelectNodes("material"))
      {
        MdxLib.Model.CMaterial cmaterial = new MdxLib.Model.CMaterial(Model);
        CMaterial.Instance.Load(Loader, selectNode, Model, cmaterial);
        Model.Materials.Add(cmaterial);
      }
      foreach (XmlNode selectNode in Node.SelectNodes("texture"))
      {
        MdxLib.Model.CTexture ctexture = new MdxLib.Model.CTexture(Model);
        CTexture.Instance.Load(Loader, selectNode, Model, ctexture);
        Model.Textures.Add(ctexture);
      }
      foreach (XmlNode selectNode in Node.SelectNodes("texture_animation"))
      {
        MdxLib.Model.CTextureAnimation ctextureAnimation = new MdxLib.Model.CTextureAnimation(Model);
        CTextureAnimation.Instance.Load(Loader, selectNode, Model, ctextureAnimation);
        Model.TextureAnimations.Add(ctextureAnimation);
      }
      foreach (XmlNode selectNode in Node.SelectNodes("geoset"))
      {
        MdxLib.Model.CGeoset cgeoset = new MdxLib.Model.CGeoset(Model);
        CGeoset.Instance.Load(Loader, selectNode, Model, cgeoset);
        Model.Geosets.Add(cgeoset);
      }
      foreach (XmlNode selectNode in Node.SelectNodes("geoset_animation"))
      {
        MdxLib.Model.CGeosetAnimation cgeosetAnimation = new MdxLib.Model.CGeosetAnimation(Model);
        CGeosetAnimation.Instance.Load(Loader, selectNode, Model, cgeosetAnimation);
        Model.GeosetAnimations.Add(cgeosetAnimation);
      }
      foreach (XmlNode selectNode in Node.SelectNodes("bone"))
      {
        MdxLib.Model.CBone cbone = new MdxLib.Model.CBone(Model);
        CBone.Instance.Load(Loader, selectNode, Model, cbone);
        Model.Bones.Add(cbone);
      }
      foreach (XmlNode selectNode in Node.SelectNodes("light"))
      {
        MdxLib.Model.CLight clight = new MdxLib.Model.CLight(Model);
        CLight.Instance.Load(Loader, selectNode, Model, clight);
        Model.Lights.Add(clight);
      }
      foreach (XmlNode selectNode in Node.SelectNodes("helper"))
      {
        MdxLib.Model.CHelper chelper = new MdxLib.Model.CHelper(Model);
        CHelper.Instance.Load(Loader, selectNode, Model, chelper);
        Model.Helpers.Add(chelper);
      }
      foreach (XmlNode selectNode in Node.SelectNodes("attachment"))
      {
        MdxLib.Model.CAttachment cattachment = new MdxLib.Model.CAttachment(Model);
        CAttachment.Instance.Load(Loader, selectNode, Model, cattachment);
        Model.Attachments.Add(cattachment);
      }
      foreach (XmlNode selectNode in Node.SelectNodes("particle_emitter"))
      {
        MdxLib.Model.CParticleEmitter cparticleEmitter = new MdxLib.Model.CParticleEmitter(Model);
        CParticleEmitter.Instance.Load(Loader, selectNode, Model, cparticleEmitter);
        Model.ParticleEmitters.Add(cparticleEmitter);
      }
      foreach (XmlNode selectNode in Node.SelectNodes("particle_emitter_2"))
      {
        MdxLib.Model.CParticleEmitter2 cparticleEmitter2 = new MdxLib.Model.CParticleEmitter2(Model);
        CParticleEmitter2.Instance.Load(Loader, selectNode, Model, cparticleEmitter2);
        Model.ParticleEmitters2.Add(cparticleEmitter2);
      }
      foreach (XmlNode selectNode in Node.SelectNodes("ribbon_emitter"))
      {
        MdxLib.Model.CRibbonEmitter cribbonEmitter = new MdxLib.Model.CRibbonEmitter(Model);
        CRibbonEmitter.Instance.Load(Loader, selectNode, Model, cribbonEmitter);
        Model.RibbonEmitters.Add(cribbonEmitter);
      }
      foreach (XmlNode selectNode in Node.SelectNodes("camera"))
      {
        MdxLib.Model.CCamera ccamera = new MdxLib.Model.CCamera(Model);
        CCamera.Instance.Load(Loader, selectNode, Model, ccamera);
        Model.Cameras.Add(ccamera);
      }
      foreach (XmlNode selectNode in Node.SelectNodes("event"))
      {
        MdxLib.Model.CEvent cevent = new MdxLib.Model.CEvent(Model);
        CEvent.Instance.Load(Loader, selectNode, Model, cevent);
        Model.Events.Add(cevent);
      }
      foreach (XmlNode selectNode in Node.SelectNodes("collision_shape"))
      {
        MdxLib.Model.CCollisionShape ccollisionShape = new MdxLib.Model.CCollisionShape(Model);
        CCollisionShape.Instance.Load(Loader, selectNode, Model, ccollisionShape);
        Model.CollisionShapes.Add(ccollisionShape);
      }
      XmlNode node = Node.SelectSingleNode("meta");
      if (node == null || node.ChildNodes.Count <= 0)
        return;
      XmlNode newChild = Model.MetaData.ImportNode(node, true);
      Model.MetaData.ReplaceChild(newChild, (XmlNode) Model.MetaDataRoot);
    }

    public void Save(CSaver Saver, XmlNode Node, MdxLib.Model.CModel Model)
    {
      this.WriteInteger(Node, "version", Model.Version);
      this.WriteInteger(Node, "blend_time", Model.BlendTime);
      this.WriteString(Node, "name", Model.Name);
      this.WriteString(Node, "animation_file", Model.AnimationFile);
      this.WriteExtent(Node, "extent", Model.Extent);
      if (Model.HasSequences)
      {
        foreach (MdxLib.Model.CSequence sequence in Model.Sequences)
        {
          XmlElement Node1 = this.AppendElement(Node, "sequence");
          CSequence.Instance.Save(Saver, (XmlNode) Node1, Model, sequence);
        }
      }
      if (Model.HasGlobalSequences)
      {
        foreach (MdxLib.Model.CGlobalSequence globalSequence in Model.GlobalSequences)
        {
          XmlElement Node2 = this.AppendElement(Node, "global_sequence");
          CGlobalSequence.Instance.Save(Saver, (XmlNode) Node2, Model, globalSequence);
        }
      }
      if (Model.HasMaterials)
      {
        foreach (MdxLib.Model.CMaterial material in Model.Materials)
        {
          XmlElement Node3 = this.AppendElement(Node, "material");
          CMaterial.Instance.Save(Saver, (XmlNode) Node3, Model, material);
        }
      }
      if (Model.HasTextures)
      {
        foreach (MdxLib.Model.CTexture texture in Model.Textures)
        {
          XmlElement Node4 = this.AppendElement(Node, "texture");
          CTexture.Instance.Save(Saver, (XmlNode) Node4, Model, texture);
        }
      }
      if (Model.HasTextureAnimations)
      {
        foreach (MdxLib.Model.CTextureAnimation textureAnimation in Model.TextureAnimations)
        {
          XmlElement Node5 = this.AppendElement(Node, "texture_animation");
          CTextureAnimation.Instance.Save(Saver, (XmlNode) Node5, Model, textureAnimation);
        }
      }
      if (Model.HasGeosets)
      {
        foreach (MdxLib.Model.CGeoset geoset in Model.Geosets)
        {
          XmlElement Node6 = this.AppendElement(Node, "geoset");
          CGeoset.Instance.Save(Saver, (XmlNode) Node6, Model, geoset);
        }
      }
      if (Model.HasGeosetAnimations)
      {
        foreach (MdxLib.Model.CGeosetAnimation geosetAnimation in Model.GeosetAnimations)
        {
          XmlElement Node7 = this.AppendElement(Node, "geoset_animation");
          CGeosetAnimation.Instance.Save(Saver, (XmlNode) Node7, Model, geosetAnimation);
        }
      }
      if (Model.HasBones)
      {
        foreach (MdxLib.Model.CBone bone in Model.Bones)
        {
          XmlElement Node8 = this.AppendElement(Node, "bone");
          CBone.Instance.Save(Saver, (XmlNode) Node8, Model, bone);
        }
      }
      if (Model.HasLights)
      {
        foreach (MdxLib.Model.CLight light in Model.Lights)
        {
          XmlElement Node9 = this.AppendElement(Node, "light");
          CLight.Instance.Save(Saver, (XmlNode) Node9, Model, light);
        }
      }
      if (Model.HasHelpers)
      {
        foreach (MdxLib.Model.CHelper helper in Model.Helpers)
        {
          XmlElement Node10 = this.AppendElement(Node, "helper");
          CHelper.Instance.Save(Saver, (XmlNode) Node10, Model, helper);
        }
      }
      if (Model.HasAttachments)
      {
        foreach (MdxLib.Model.CAttachment attachment in Model.Attachments)
        {
          XmlElement Node11 = this.AppendElement(Node, "attachment");
          CAttachment.Instance.Save(Saver, (XmlNode) Node11, Model, attachment);
        }
      }
      if (Model.HasParticleEmitters)
      {
        foreach (MdxLib.Model.CParticleEmitter particleEmitter in Model.ParticleEmitters)
        {
          XmlElement Node12 = this.AppendElement(Node, "particle_emitter");
          CParticleEmitter.Instance.Save(Saver, (XmlNode) Node12, Model, particleEmitter);
        }
      }
      if (Model.HasParticleEmitters2)
      {
        foreach (MdxLib.Model.CParticleEmitter2 ParticleEmitter2 in Model.ParticleEmitters2)
        {
          XmlElement Node13 = this.AppendElement(Node, "particle_emitter_2");
          CParticleEmitter2.Instance.Save(Saver, (XmlNode) Node13, Model, ParticleEmitter2);
        }
      }
      if (Model.HasRibbonEmitters)
      {
        foreach (MdxLib.Model.CRibbonEmitter ribbonEmitter in Model.RibbonEmitters)
        {
          XmlElement Node14 = this.AppendElement(Node, "ribbon_emitter");
          CRibbonEmitter.Instance.Save(Saver, (XmlNode) Node14, Model, ribbonEmitter);
        }
      }
      if (Model.HasCameras)
      {
        foreach (MdxLib.Model.CCamera camera in Model.Cameras)
        {
          XmlElement Node15 = this.AppendElement(Node, "camera");
          CCamera.Instance.Save(Saver, (XmlNode) Node15, Model, camera);
        }
      }
      if (Model.HasEvents)
      {
        foreach (MdxLib.Model.CEvent Event in Model.Events)
        {
          XmlElement Node16 = this.AppendElement(Node, "event");
          CEvent.Instance.Save(Saver, (XmlNode) Node16, Model, Event);
        }
      }
      if (Model.HasCollisionShapes)
      {
        foreach (MdxLib.Model.CCollisionShape collisionShape in Model.CollisionShapes)
        {
          XmlElement Node17 = this.AppendElement(Node, "collision_shape");
          CCollisionShape.Instance.Save(Saver, (XmlNode) Node17, Model, collisionShape);
        }
      }
      if (!Model.HasMetaData)
        return;
      XmlNode newChild = Node.OwnerDocument.ImportNode((XmlNode) Model.MetaDataRoot, true);
      Node.OwnerDocument.DocumentElement.AppendChild(newChild);
    }

    public static CModel Instance => CModel.CSingleton.Instance;

    private static class CSingleton
    {
      public static CModel Instance = new CModel();
    }
  }
}
