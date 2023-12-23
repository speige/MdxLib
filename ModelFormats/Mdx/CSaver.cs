// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdx.CSaver
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Primitives;
using System.Collections.Generic;
using System.IO;

namespace MdxLib.ModelFormats.Mdx
{
  internal sealed class CSaver
  {
    private string _Name = "";
    private BinaryWriter Writer;
    private LinkedList<int> LocationStack;

    public CSaver(string Name, Stream Stream)
    {
      this._Name = Name;
      this.Writer = new BinaryWriter(Stream, CConstants.SimpleTextEncoding);
      this.LocationStack = new LinkedList<int>();
    }

    public void Write(byte[] Data) => this.Writer.Write(Data);

    public void WriteByte(byte Value) => this.Writer.Write(Value);

    public void WriteInt8(int Value) => this.Writer.Write((byte) Value);

    public void WriteInt16(int Value) => this.Writer.Write((short) Value);

    public void WriteInt32(int Value) => this.Writer.Write(Value);

    public void WriteFloat(float Value) => this.Writer.Write(Value);

    public void WriteDouble(double Value) => this.Writer.Write(Value);

    public void WriteString(string Value, int Length)
    {
      int num = Length - Value.Length;
      this.Writer.Write((Value.Length > Length ? Value.Substring(0, Length) : Value).ToCharArray());
      for (int index = 0; index < num; ++index)
        this.Writer.Write(char.MinValue);
    }

    public void WriteTag(string Value) => this.WriteString(Value, 4);

    public void WriteVector2(CVector2 Value)
    {
      this.WriteFloat(Value.X);
      this.WriteFloat(Value.Y);
    }

    public void WriteVector3(CVector3 Value)
    {
      this.WriteFloat(Value.X);
      this.WriteFloat(Value.Y);
      this.WriteFloat(Value.Z);
    }

    public void WriteVector4(CVector4 Value)
    {
      this.WriteFloat(Value.X);
      this.WriteFloat(Value.Y);
      this.WriteFloat(Value.Z);
      this.WriteFloat(Value.W);
    }

    public void WriteExtent(CExtent Value)
    {
      this.WriteFloat(Value.Radius);
      this.WriteVector3(Value.Min);
      this.WriteVector3(Value.Max);
    }

    public void PushLocation()
    {
      this.LocationStack.AddLast((int) this.Writer.BaseStream.Position);
      this.WriteInt32(0);
    }

    public void PopLocation(int AdditionalSize)
    {
      int position = (int) this.Writer.BaseStream.Position;
      int num = this.LocationStack.Last.Value;
      this.LocationStack.RemoveLast();
      this.Writer.BaseStream.Position = (long) num;
      this.WriteInt32(position - num + AdditionalSize);
      this.Writer.BaseStream.Position = (long) position;
    }

    public void PopInclusiveLocation() => this.PopLocation(0);

    public void PopExclusiveLocation() => this.PopLocation(-4);

    public string Name => this._Name;
  }
}
