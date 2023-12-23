// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CMaterialLayer
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Animator;
using MdxLib.Animator.Animatable;

namespace MdxLib.Model
{
  public sealed class CMaterialLayer : CObject<CMaterialLayer>
  {
    private EMaterialLayerFilterMode _FilterMode;
    private int _CoordId;
    private bool _Unshaded;
    private bool _Unfogged;
    private bool _TwoSided;
    private bool _SphereEnvironmentMap;
    private bool _NoDepthTest;
    private bool _NoDepthSet;
    private CAnimator<int> _TextureId;
    private CAnimator<float> _Alpha;
    private CObjectReference<CTexture> _Texture;
    private CObjectReference<CTextureAnimation> _TextureAnimation;

    public CMaterialLayer(CModel Model)
      : base(Model)
    {
    }

    public override string ToString() => "Material Layer #" + (object) this.ObjectId;

    public EMaterialLayerFilterMode FilterMode
    {
      get => this._FilterMode;
      set
      {
        this.AddSetObjectFieldCommand<EMaterialLayerFilterMode>("_FilterMode", value);
        this._FilterMode = value;
      }
    }

    public int CoordId
    {
      get => this._CoordId;
      set
      {
        this.AddSetObjectFieldCommand<int>("_CoordId", value);
        this._CoordId = value;
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

    public bool TwoSided
    {
      get => this._TwoSided;
      set
      {
        this.AddSetObjectFieldCommand<bool>("_TwoSided", value);
        this._TwoSided = value;
      }
    }

    public bool SphereEnvironmentMap
    {
      get => this._SphereEnvironmentMap;
      set
      {
        this.AddSetObjectFieldCommand<bool>("_SphereEnvironmentMap", value);
        this._SphereEnvironmentMap = value;
      }
    }

    public bool NoDepthTest
    {
      get => this._NoDepthTest;
      set
      {
        this.AddSetObjectFieldCommand<bool>("_NoDepthTest", value);
        this._NoDepthTest = value;
      }
    }

    public bool NoDepthSet
    {
      get => this._NoDepthSet;
      set
      {
        this.AddSetObjectFieldCommand<bool>("_NoDepthSet", value);
        this._NoDepthSet = value;
      }
    }

    public CAnimator<int> TextureId => this._TextureId ?? (this._TextureId = new CAnimator<int>(this.Model, (CAnimatable<int>) new CInteger(-1)));

    public CAnimator<float> Alpha => this._Alpha ?? (this._Alpha = new CAnimator<float>(this.Model, (CAnimatable<float>) new CFloat(1f)));

    public CObjectReference<CTexture> Texture => this._Texture ?? (this._Texture = new CObjectReference<CTexture>(this.Model));

    public CObjectReference<CTextureAnimation> TextureAnimation => this._TextureAnimation ?? (this._TextureAnimation = new CObjectReference<CTextureAnimation>(this.Model));
  }
}
