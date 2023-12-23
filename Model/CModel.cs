// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CModel
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Command;
using MdxLib.Primitives;
using System.Xml;

namespace MdxLib.Model
{
  public sealed class CModel
  {
    private object _Tag;
    private int _Version = 800;
    private int _BlendTime = 150;
    private string _Name = "";
    private string _AnimationFile = "";
    private CExtent _Extent = CConstants.DefaultExtent;
    private CObjectContainer<CAttachment> _Attachments;
    private CObjectContainer<CBone> _Bones;
    private CObjectContainer<CCollisionShape> _CollisionShapes;
    private CObjectContainer<CEvent> _Events;
    private CObjectContainer<CHelper> _Helpers;
    private CObjectContainer<CLight> _Lights;
    private CObjectContainer<CParticleEmitter> _ParticleEmitters;
    private CObjectContainer<CParticleEmitter2> _ParticleEmitters2;
    private CObjectContainer<CRibbonEmitter> _RibbonEmitters;
    private CObjectContainer<CCamera> _Cameras;
    private CObjectContainer<CGeoset> _Geosets;
    private CObjectContainer<CGeosetAnimation> _GeosetAnimations;
    private CObjectContainer<CGlobalSequence> _GlobalSequences;
    private CObjectContainer<CMaterial> _Materials;
    private CObjectContainer<CSequence> _Sequences;
    private CObjectContainer<CTexture> _Textures;
    private CObjectContainer<CTextureAnimation> _TextureAnimations;
    private CNodeContainer _Nodes;
    private XmlDocument _MetaData;
    internal CCommandGroup CommandGroup;

    public void BeginUndoRedoSession()
    {
      if (this.CommandGroup != null)
        return;
      this.CommandGroup = new CCommandGroup();
    }

    public ICommand EndUndoRedoSession()
    {
      if (this.CommandGroup == null)
        return (ICommand) null;
      CCommandGroup commandGroup = this.CommandGroup;
      this.CommandGroup = (CCommandGroup) null;
      return (ICommand) commandGroup;
    }

    public override string ToString() => "Model \"" + this.Name + "\"";

    internal void AddSetModelFieldCommand<T>(string FieldName, T Value)
    {
      if (this.CommandGroup == null)
        return;
      this.CommandGroup.Add((ICommand) new CSetModelField<T>(this, FieldName, Value));
    }

    internal int GetAttachmentNodeId(CAttachment Attachment)
    {
      if (this._Attachments == null)
        return -1;
      int attachmentNodeId = this._Attachments.IndexOf(Attachment);
      if (attachmentNodeId == -1)
        return -1;
      if (this._Bones != null)
        attachmentNodeId += this._Bones.Count;
      if (this._Lights != null)
        attachmentNodeId += this._Lights.Count;
      if (this._Helpers != null)
        attachmentNodeId += this._Helpers.Count;
      return attachmentNodeId;
    }

    internal int GetBoneNodeId(CBone Bone)
    {
      if (this._Bones == null)
        return -1;
      int num = this._Bones.IndexOf(Bone);
      return num == -1 ? -1 : num;
    }

    internal int GetCollisionShapeNodeId(CCollisionShape CollisionShape)
    {
      if (this._CollisionShapes == null)
        return -1;
      int collisionShapeNodeId = this._CollisionShapes.IndexOf(CollisionShape);
      if (collisionShapeNodeId == -1)
        return -1;
      if (this._Bones != null)
        collisionShapeNodeId += this._Bones.Count;
      if (this._Lights != null)
        collisionShapeNodeId += this._Lights.Count;
      if (this._Helpers != null)
        collisionShapeNodeId += this._Helpers.Count;
      if (this._Attachments != null)
        collisionShapeNodeId += this._Attachments.Count;
      if (this._ParticleEmitters != null)
        collisionShapeNodeId += this._ParticleEmitters.Count;
      if (this._ParticleEmitters2 != null)
        collisionShapeNodeId += this._ParticleEmitters2.Count;
      if (this._RibbonEmitters != null)
        collisionShapeNodeId += this._RibbonEmitters.Count;
      if (this._Events != null)
        collisionShapeNodeId += this._Events.Count;
      return collisionShapeNodeId;
    }

    internal int GetEventNodeId(CEvent Event)
    {
      if (this._Events == null)
        return -1;
      int eventNodeId = this._Events.IndexOf(Event);
      if (eventNodeId == -1)
        return -1;
      if (this._Bones != null)
        eventNodeId += this._Bones.Count;
      if (this._Lights != null)
        eventNodeId += this._Lights.Count;
      if (this._Helpers != null)
        eventNodeId += this._Helpers.Count;
      if (this._Attachments != null)
        eventNodeId += this._Attachments.Count;
      if (this._ParticleEmitters != null)
        eventNodeId += this._ParticleEmitters.Count;
      if (this._ParticleEmitters2 != null)
        eventNodeId += this._ParticleEmitters2.Count;
      if (this._RibbonEmitters != null)
        eventNodeId += this._RibbonEmitters.Count;
      return eventNodeId;
    }

    internal int GetHelperNodeId(CHelper Helper)
    {
      if (this._Helpers == null)
        return -1;
      int helperNodeId = this._Helpers.IndexOf(Helper);
      if (helperNodeId == -1)
        return -1;
      if (this._Bones != null)
        helperNodeId += this._Bones.Count;
      if (this._Lights != null)
        helperNodeId += this._Lights.Count;
      return helperNodeId;
    }

    internal int GetLightNodeId(CLight Light)
    {
      if (this._Lights == null)
        return -1;
      int lightNodeId = this._Lights.IndexOf(Light);
      if (lightNodeId == -1)
        return -1;
      if (this._Bones != null)
        lightNodeId += this._Bones.Count;
      return lightNodeId;
    }

    internal int GetParticleEmitterNodeId(CParticleEmitter ParticleEmitter)
    {
      if (this._ParticleEmitters == null)
        return -1;
      int particleEmitterNodeId = this._ParticleEmitters.IndexOf(ParticleEmitter);
      if (particleEmitterNodeId == -1)
        return -1;
      if (this._Bones != null)
        particleEmitterNodeId += this._Bones.Count;
      if (this._Lights != null)
        particleEmitterNodeId += this._Lights.Count;
      if (this._Helpers != null)
        particleEmitterNodeId += this._Helpers.Count;
      if (this._Attachments != null)
        particleEmitterNodeId += this._Attachments.Count;
      return particleEmitterNodeId;
    }

    internal int GetParticleEmitter2NodeId(CParticleEmitter2 ParticleEmitter2)
    {
      if (this._ParticleEmitters2 == null)
        return -1;
      int particleEmitter2NodeId = this._ParticleEmitters2.IndexOf(ParticleEmitter2);
      if (particleEmitter2NodeId == -1)
        return -1;
      if (this._Bones != null)
        particleEmitter2NodeId += this._Bones.Count;
      if (this._Lights != null)
        particleEmitter2NodeId += this._Lights.Count;
      if (this._Helpers != null)
        particleEmitter2NodeId += this._Helpers.Count;
      if (this._Attachments != null)
        particleEmitter2NodeId += this._Attachments.Count;
      if (this._ParticleEmitters != null)
        particleEmitter2NodeId += this._ParticleEmitters.Count;
      return particleEmitter2NodeId;
    }

    internal int GetRibbonEmitterNodeId(CRibbonEmitter RibbonEmitter)
    {
      if (this._RibbonEmitters == null)
        return -1;
      int ribbonEmitterNodeId = this._RibbonEmitters.IndexOf(RibbonEmitter);
      if (ribbonEmitterNodeId == -1)
        return -1;
      if (this._Bones != null)
        ribbonEmitterNodeId += this._Bones.Count;
      if (this._Lights != null)
        ribbonEmitterNodeId += this._Lights.Count;
      if (this._Helpers != null)
        ribbonEmitterNodeId += this._Helpers.Count;
      if (this._Attachments != null)
        ribbonEmitterNodeId += this._Attachments.Count;
      if (this._ParticleEmitters != null)
        ribbonEmitterNodeId += this._ParticleEmitters.Count;
      if (this._ParticleEmitters2 != null)
        ribbonEmitterNodeId += this._ParticleEmitters2.Count;
      return ribbonEmitterNodeId;
    }

    public object Tag
    {
      get => this._Tag;
      set => this._Tag = value;
    }

    public int Version
    {
      get => this._Version;
      set
      {
        this.AddSetModelFieldCommand<int>("_Version", value);
        this._Version = value;
      }
    }

    public int BlendTime
    {
      get => this._BlendTime;
      set
      {
        this.AddSetModelFieldCommand<int>("_BlendTime", value);
        this._BlendTime = value;
      }
    }

    public string Name
    {
      get => this._Name;
      set
      {
        this.AddSetModelFieldCommand<string>("_Name", value);
        this._Name = value;
      }
    }

    public string AnimationFile
    {
      get => this._AnimationFile;
      set
      {
        this.AddSetModelFieldCommand<string>("_AnimationFile", value);
        this._AnimationFile = value;
      }
    }

    public CExtent Extent
    {
      get => this._Extent;
      set
      {
        this.AddSetModelFieldCommand<CExtent>("_Extent", value);
        this._Extent = value;
      }
    }

    public bool HasAttachments => this._Attachments != null && this._Attachments.Count > 0;

    public bool HasBones => this._Bones != null && this._Bones.Count > 0;

    public bool HasCollisionShapes => this._CollisionShapes != null && this._CollisionShapes.Count > 0;

    public bool HasEvents => this._Events != null && this._Events.Count > 0;

    public bool HasHelpers => this._Helpers != null && this._Helpers.Count > 0;

    public bool HasLights => this._Lights != null && this._Lights.Count > 0;

    public bool HasParticleEmitters => this._ParticleEmitters != null && this._ParticleEmitters.Count > 0;

    public bool HasParticleEmitters2 => this._ParticleEmitters2 != null && this._ParticleEmitters2.Count > 0;

    public bool HasRibbonEmitters => this._RibbonEmitters != null && this._RibbonEmitters.Count > 0;

    public bool HasCameras => this._Cameras != null && this._Cameras.Count > 0;

    public bool HasGeosets => this._Geosets != null && this._Geosets.Count > 0;

    public bool HasGeosetAnimations => this._GeosetAnimations != null && this._GeosetAnimations.Count > 0;

    public bool HasGlobalSequences => this._GlobalSequences != null && this._GlobalSequences.Count > 0;

    public bool HasMaterials => this._Materials != null && this._Materials.Count > 0;

    public bool HasSequences => this._Sequences != null && this._Sequences.Count > 0;

    public bool HasTextures => this._Textures != null && this._Textures.Count > 0;

    public bool HasTextureAnimations => this._TextureAnimations != null && this._TextureAnimations.Count > 0;

    public bool HasNodes => this._Nodes != null && this._Nodes.Count > 0;

    public bool HasMetaData => this._MetaData != null && this._MetaData.DocumentElement != null && this._MetaData.DocumentElement.ChildNodes.Count > 0;

    public CObjectContainer<CAttachment> Attachments => this._Attachments ?? (this._Attachments = new CObjectContainer<CAttachment>(this));

    public CObjectContainer<CBone> Bones => this._Bones ?? (this._Bones = new CObjectContainer<CBone>(this));

    public CObjectContainer<CCollisionShape> CollisionShapes => this._CollisionShapes ?? (this._CollisionShapes = new CObjectContainer<CCollisionShape>(this));

    public CObjectContainer<CEvent> Events => this._Events ?? (this._Events = new CObjectContainer<CEvent>(this));

    public CObjectContainer<CHelper> Helpers => this._Helpers ?? (this._Helpers = new CObjectContainer<CHelper>(this));

    public CObjectContainer<CLight> Lights => this._Lights ?? (this._Lights = new CObjectContainer<CLight>(this));

    public CObjectContainer<CParticleEmitter> ParticleEmitters => this._ParticleEmitters ?? (this._ParticleEmitters = new CObjectContainer<CParticleEmitter>(this));

    public CObjectContainer<CParticleEmitter2> ParticleEmitters2 => this._ParticleEmitters2 ?? (this._ParticleEmitters2 = new CObjectContainer<CParticleEmitter2>(this));

    public CObjectContainer<CRibbonEmitter> RibbonEmitters => this._RibbonEmitters ?? (this._RibbonEmitters = new CObjectContainer<CRibbonEmitter>(this));

    public CObjectContainer<CCamera> Cameras => this._Cameras ?? (this._Cameras = new CObjectContainer<CCamera>(this));

    public CObjectContainer<CGeoset> Geosets => this._Geosets ?? (this._Geosets = new CObjectContainer<CGeoset>(this));

    public CObjectContainer<CGeosetAnimation> GeosetAnimations => this._GeosetAnimations ?? (this._GeosetAnimations = new CObjectContainer<CGeosetAnimation>(this));

    public CObjectContainer<CGlobalSequence> GlobalSequences => this._GlobalSequences ?? (this._GlobalSequences = new CObjectContainer<CGlobalSequence>(this));

    public CObjectContainer<CMaterial> Materials => this._Materials ?? (this._Materials = new CObjectContainer<CMaterial>(this));

    public CObjectContainer<CSequence> Sequences => this._Sequences ?? (this._Sequences = new CObjectContainer<CSequence>(this));

    public CObjectContainer<CTexture> Textures => this._Textures ?? (this._Textures = new CObjectContainer<CTexture>(this));

    public CObjectContainer<CTextureAnimation> TextureAnimations => this._TextureAnimations ?? (this._TextureAnimations = new CObjectContainer<CTextureAnimation>(this));

    public CNodeContainer Nodes => this._Nodes ?? (this._Nodes = new CNodeContainer(this));

    public XmlDocument MetaData
    {
      get
      {
        if (this._MetaData == null)
        {
          this._MetaData = new XmlDocument();
          this._MetaData.AppendChild((XmlNode) this._MetaData.CreateElement("meta"));
        }
        return this._MetaData;
      }
    }

    public XmlElement MetaDataRoot
    {
      get
      {
        if (this._MetaData == null)
        {
          this._MetaData = new XmlDocument();
          this._MetaData.AppendChild((XmlNode) this._MetaData.CreateElement("meta"));
        }
        return this._MetaData.DocumentElement;
      }
    }
  }
}
