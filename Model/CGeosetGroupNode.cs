﻿// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CGeosetGroupNode
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

namespace MdxLib.Model
{
  public sealed class CGeosetGroupNode : CObject<CGeosetGroupNode>
  {
    private CNodeReference _Node;

    public CGeosetGroupNode(CModel Model)
      : base(Model)
    {
    }

    public override string ToString() => "Geoset Group Node #" + (object) this.ObjectId;

    public CNodeReference Node => this._Node ?? (this._Node = new CNodeReference(this.Model));
  }
}
