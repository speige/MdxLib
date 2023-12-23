// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CParticleEmitter2
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Animator;
using MdxLib.Animator.Animatable;
using MdxLib.Primitives;

namespace MdxLib.Model
{
  public sealed class CParticleEmitter2 : CNode<CParticleEmitter2>
  {
    private EParticleEmitter2FilterMode _FilterMode;
    private int _Rows = 1;
    private int _Columns = 1;
    private int _PriorityPlane;
    private int _ReplaceableId = -1;
    private float _Time;
    private float _LifeSpan;
    private float _TailLength;
    private bool _SortPrimitivesFarZ;
    private bool _LineEmitter;
    private bool _ModelSpace;
    private bool _Unshaded;
    private bool _Unfogged;
    private bool _XYQuad;
    private bool _Squirt;
    private bool _Head;
    private bool _Tail;
    private CSegment _Segment1 = CConstants.DefaultSegment;
    private CSegment _Segment2 = CConstants.DefaultSegment;
    private CSegment _Segment3 = CConstants.DefaultSegment;
    private CInterval _HeadLife = CConstants.DefaultInterval;
    private CInterval _HeadDecay = CConstants.DefaultInterval;
    private CInterval _TailLife = CConstants.DefaultInterval;
    private CInterval _TailDecay = CConstants.DefaultInterval;
    private CAnimator<float> _Speed;
    private CAnimator<float> _Variation;
    private CAnimator<float> _Latitude;
    private CAnimator<float> _Gravity;
    private CAnimator<float> _EmissionRate;
    private CAnimator<float> _Width;
    private CAnimator<float> _Length;
    private CAnimator<float> _Visibility;
    private CObjectReference<CTexture> _Texture;

    public CParticleEmitter2(CModel Model)
      : base(Model)
    {
    }

    public override string ToString() => "Particle Emitter 2 #" + (object) this.ObjectId;

    public override int NodeId => this.Model.GetParticleEmitter2NodeId(this);

    public EParticleEmitter2FilterMode FilterMode
    {
      get => this._FilterMode;
      set
      {
        this.AddSetObjectFieldCommand<EParticleEmitter2FilterMode>("_FilterMode", value);
        this._FilterMode = value;
      }
    }

    public int Rows
    {
      get => this._Rows;
      set
      {
        this.AddSetObjectFieldCommand<int>("_Rows", value);
        this._Rows = value;
      }
    }

    public int Columns
    {
      get => this._Columns;
      set
      {
        this.AddSetObjectFieldCommand<int>("_Columns", value);
        this._Columns = value;
      }
    }

    public int PriorityPlane
    {
      get => this._PriorityPlane;
      set
      {
        this.AddSetObjectFieldCommand<int>("_PriorityPlane", value);
        this._PriorityPlane = value;
      }
    }

    public int ReplaceableId
    {
      get => this._ReplaceableId;
      set
      {
        this.AddSetObjectFieldCommand<int>("_ReplaceableId", value);
        this._ReplaceableId = value;
      }
    }

    public float Time
    {
      get => this._Time;
      set
      {
        this.AddSetObjectFieldCommand<float>("_Time", value);
        this._Time = value;
      }
    }

    public float LifeSpan
    {
      get => this._LifeSpan;
      set
      {
        this.AddSetObjectFieldCommand<float>("_LifeSpan", value);
        this._LifeSpan = value;
      }
    }

    public float TailLength
    {
      get => this._TailLength;
      set
      {
        this.AddSetObjectFieldCommand<float>("_TailLength", value);
        this._TailLength = value;
      }
    }

    public bool SortPrimitivesFarZ
    {
      get => this._SortPrimitivesFarZ;
      set
      {
        this.AddSetObjectFieldCommand<bool>("_SortPrimitivesFarZ", value);
        this._SortPrimitivesFarZ = value;
      }
    }

    public bool LineEmitter
    {
      get => this._LineEmitter;
      set
      {
        this.AddSetObjectFieldCommand<bool>("_LineEmitter", value);
        this._LineEmitter = value;
      }
    }

    public bool ModelSpace
    {
      get => this._ModelSpace;
      set
      {
        this.AddSetObjectFieldCommand<bool>("_ModelSpace", value);
        this._ModelSpace = value;
      }
    }

    public bool Unshaded
    {
      get => this._Unshaded;
      set
      {
        this.AddSetObjectFieldCommand<bool>("_Unshaded", value);
        this._Unshaded = value;
      }
    }

    public bool Unfogged
    {
      get => this._Unfogged;
      set
      {
        this.AddSetObjectFieldCommand<bool>("_Unfogged", value);
        this._Unfogged = value;
      }
    }

    public bool XYQuad
    {
      get => this._XYQuad;
      set
      {
        this.AddSetObjectFieldCommand<bool>("_XYQuad", value);
        this._XYQuad = value;
      }
    }

    public bool Squirt
    {
      get => this._Squirt;
      set
      {
        this.AddSetObjectFieldCommand<bool>("_Squirt", value);
        this._Squirt = value;
      }
    }

    public bool Head
    {
      get => this._Head;
      set
      {
        this.AddSetObjectFieldCommand<bool>("_Head", value);
        this._Head = value;
      }
    }

    public bool Tail
    {
      get => this._Tail;
      set
      {
        this.AddSetObjectFieldCommand<bool>("_Tail", value);
        this._Tail = value;
      }
    }

    public CSegment Segment1
    {
      get => this._Segment1;
      set
      {
        this.AddSetObjectFieldCommand<CSegment>("_Segment1", value);
        this._Segment1 = value;
      }
    }

    public CSegment Segment2
    {
      get => this._Segment2;
      set
      {
        this.AddSetObjectFieldCommand<CSegment>("_Segment2", value);
        this._Segment2 = value;
      }
    }

    public CSegment Segment3
    {
      get => this._Segment3;
      set
      {
        this.AddSetObjectFieldCommand<CSegment>("_Segment3", value);
        this._Segment3 = value;
      }
    }

    public CInterval HeadLife
    {
      get => this._HeadLife;
      set
      {
        this.AddSetObjectFieldCommand<CInterval>("_HeadLife", value);
        this._HeadLife = value;
      }
    }

    public CInterval HeadDecay
    {
      get => this._HeadDecay;
      set
      {
        this.AddSetObjectFieldCommand<CInterval>("_HeadDecay", value);
        this._HeadDecay = value;
      }
    }

    public CInterval TailLife
    {
      get => this._TailLife;
      set
      {
        this.AddSetObjectFieldCommand<CInterval>("_TailLife", value);
        this._TailLife = value;
      }
    }

    public CInterval TailDecay
    {
      get => this._TailDecay;
      set
      {
        this.AddSetObjectFieldCommand<CInterval>("_TailDecay", value);
        this._TailDecay = value;
      }
    }

    public CAnimator<float> Speed => this._Speed ?? (this._Speed = new CAnimator<float>(this.Model, (CAnimatable<float>) new CFloat(0.0f)));

    public CAnimator<float> Variation => this._Variation ?? (this._Variation = new CAnimator<float>(this.Model, (CAnimatable<float>) new CFloat(0.0f)));

    public CAnimator<float> Latitude => this._Latitude ?? (this._Latitude = new CAnimator<float>(this.Model, (CAnimatable<float>) new CFloat(0.0f)));

    public CAnimator<float> Gravity => this._Gravity ?? (this._Gravity = new CAnimator<float>(this.Model, (CAnimatable<float>) new CFloat(0.0f)));

    public CAnimator<float> EmissionRate => this._EmissionRate ?? (this._EmissionRate = new CAnimator<float>(this.Model, (CAnimatable<float>) new CFloat(0.0f)));

    public CAnimator<float> Width => this._Width ?? (this._Width = new CAnimator<float>(this.Model, (CAnimatable<float>) new CFloat(0.0f)));

    public CAnimator<float> Length => this._Length ?? (this._Length = new CAnimator<float>(this.Model, (CAnimatable<float>) new CFloat(0.0f)));

    public CAnimator<float> Visibility => this._Visibility ?? (this._Visibility = new CAnimator<float>(this.Model, (CAnimatable<float>) new CFloat(1f)));

    public CObjectReference<CTexture> Texture => this._Texture ?? (this._Texture = new CObjectReference<CTexture>(this.Model));
  }
}
