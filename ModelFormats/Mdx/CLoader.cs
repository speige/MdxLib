// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdx.CLoader
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.ModelFormats.Attacher;
using MdxLib.Primitives;
using System;
using System.Collections.Generic;
using System.IO;

namespace MdxLib.ModelFormats.Mdx
{
  internal sealed class CLoader
  {
    private string _Name = "";
    private CAttacherContainer _Attacher;
    private BinaryReader Reader;
    private LinkedList<int> LocationStack;

    public CLoader(string Name, Stream Stream)
    {
      this._Name = Name;
      this._Attacher = new CAttacherContainer();
      this.Reader = new BinaryReader(Stream, CConstants.SimpleTextEncoding);
      this.LocationStack = new LinkedList<int>();
    }

    public bool Eof() => this.Reader.BaseStream.Position >= this.Reader.BaseStream.Length;

    public byte[] Read(int Size) => this.Reader.ReadBytes(Size);

    public byte ReadByte() => this.Reader.ReadByte();

    public int ReadInt8() => (int) this.Reader.ReadByte();

    public int ReadInt16() => (int) this.Reader.ReadInt16();

    public int ReadInt32() => this.Reader.ReadInt32();

    public float ReadFloat() => this.Reader.ReadSingle();

    public double ReadDouble() => this.Reader.ReadDouble();

    public string ReadString(int Length)
    {
      int length = Length;
      char[] chArray = this.Reader.ReadChars(Length);
      while (length > 0 && chArray[length - 1] == char.MinValue)
        --length;
      return new string(chArray, 0, length);
    }

    public string ReadTag() => this.ReadString(4);

    public CVector2 ReadVector2() => new CVector2(this.ReadFloat(), this.ReadFloat());

    public CVector3 ReadVector3() => new CVector3(this.ReadFloat(), this.ReadFloat(), this.ReadFloat());

    public CVector4 ReadVector4() => new CVector4(this.ReadFloat(), this.ReadFloat(), this.ReadFloat(), this.ReadFloat());

    public CExtent ReadExtent()
    {
      float Radius = this.ReadFloat();
      return new CExtent(this.ReadVector3(), this.ReadVector3(), Radius);
    }

    public void ExpectTag(string ExpectedTag)
    {
      string str = this.ReadTag();
      if (str != ExpectedTag)
        throw new Exception("Error at location " + (object) this.Location + ", expected \"" + ExpectedTag + "\", got \"" + str + "\"!");
    }

    public void Skip(int NrOfBytes) => this.Reader.ReadBytes(NrOfBytes);

    public void PushLocation() => this.LocationStack.AddLast((int) this.Reader.BaseStream.Position);

    public int PopLocation()
    {
      int num = this.LocationStack.Last.Value;
      this.LocationStack.RemoveLast();
      return (int) this.Reader.BaseStream.Position - num;
    }

    public long Location => this.Reader.BaseStream.Position;

    public string Name => this._Name;

    public CAttacherContainer Attacher => this._Attacher;
  }
}
