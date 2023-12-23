// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.IModelFormat
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using System.IO;

namespace MdxLib.ModelFormats
{
  public interface IModelFormat
  {
    void Load(string Name, Stream Stream, CModel Model);

    void Save(string Name, Stream Stream, CModel Model);
  }
}
