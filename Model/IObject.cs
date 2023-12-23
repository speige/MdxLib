// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.IObject
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

namespace MdxLib.Model
{
  public interface IObject : IUnknown
  {
    int ObjectId { get; }

    CModel Model { get; }

    bool HasReferences { get; }
  }
}
