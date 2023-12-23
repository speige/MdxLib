// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.INode
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Animator;
using MdxLib.Primitives;

namespace MdxLib.Model
{
  public interface INode : IObject, IUnknown
  {
    int NodeId { get; }

    string Name { get; set; }

    bool DontInheritTranslation { get; set; }

    bool DontInheritRotation { get; set; }

    bool DontInheritScaling { get; set; }

    bool Billboarded { get; set; }

    bool BillboardedLockX { get; set; }

    bool BillboardedLockY { get; set; }

    bool BillboardedLockZ { get; set; }

    bool CameraAnchored { get; set; }

    CVector3 PivotPoint { get; set; }

    CAnimator<CVector3> Translation { get; }

    CAnimator<CVector4> Rotation { get; }

    CAnimator<CVector3> Scaling { get; }

    CNodeReference Parent { get; }
  }
}
