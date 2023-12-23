﻿// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.CMdx
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.ModelFormats.Mdx;
using System;
using System.IO;
using System.Text;

namespace MdxLib.ModelFormats
{
  public sealed class CMdx : IModelFormat
  {
    public void Load(string Name, Stream Stream, MdxLib.Model.CModel Model)
    {
      CLoader Loader = Stream.CanRead ? new CLoader(Name, Stream) : throw new NotSupportedException("Unable to load \"" + Name + "\", the stream does not support reading!");
      MdxLib.ModelFormats.Mdx.CModel.Instance.Load(Loader, Model);
      Loader.Attacher.Attach();
    }

    public void Save(string Name, Stream Stream, MdxLib.Model.CModel Model)
    {
      if (!Stream.CanWrite)
        throw new NotSupportedException("Unable to load \"" + Name + "\", the stream does not support writing!");
      if (!Stream.CanSeek)
        throw new NotSupportedException("Unable to save \"" + Name + "\", the stream does not support seeking!");
      MdxLib.ModelFormats.Mdx.CModel.Instance.Save(new CSaver(Name, Stream), Model, this.BuildHeader(Name));
    }

    private string BuildHeader(string Name)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(Name.Replace("\n", "").Replace("\r", ""));
      stringBuilder.Append(", ");
      stringBuilder.Append("Generated by MdxLib v1.04 (written by Magnus Ostberg, aka Magos)");
      stringBuilder.Append(", ");
      stringBuilder.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
      stringBuilder.Append(", ");
      stringBuilder.Append("http://www.magosx.com");
      return stringBuilder.ToString();
    }
  }
}
