// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdl.CSaver
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Primitives;
using System;
using System.IO;
using System.Text;

namespace MdxLib.ModelFormats.Mdl
{
  internal sealed class CSaver
  {
    private string _Name = "";
    private int TabDepth;
    private Stream OutputStream;
    private StringBuilder OutputBuilder;

    public CSaver(string Name, Stream Stream)
    {
      this._Name = Name;
      this.OutputStream = Stream;
      this.OutputBuilder = new StringBuilder();
    }

    public void WriteToStream()
    {
      using (StreamWriter streamWriter = new StreamWriter(this.OutputStream, CConstants.TextEncoding))
        streamWriter.Write(this.OutputBuilder.ToString());
    }

    public void WriteTabs()
    {
      for (int index = 0; index < this.TabDepth; ++index)
        this.OutputBuilder.Append("\t");
    }

    public void WriteTabs(int NrOfTabs)
    {
      for (int index = 0; index < NrOfTabs; ++index)
        this.OutputBuilder.Append("\t");
    }

    public void WriteInteger(int Value) => this.OutputBuilder.Append(Value);

    public void WriteFloat(float Value) => this.OutputBuilder.Append(Value.ToString((IFormatProvider) CConstants.NumberFormat));

    public void WriteCharacter(char Value) => this.OutputBuilder.Append(Value);

    public void WriteWord(string Value) => this.OutputBuilder.Append(Value);

    public void WriteLine() => this.OutputBuilder.AppendLine();

    public void WriteLine(string Value) => this.OutputBuilder.AppendLine(Value);

    public void WriteString(string Value) => this.OutputBuilder.Append("\"" + Value.Replace("\"", "\\\"") + "\"");

    public void WriteVector2(CVector2 Value)
    {
      this.WriteWord("{ ");
      this.WriteFloat(Value.X);
      this.WriteWord(", ");
      this.WriteFloat(Value.Y);
      this.WriteWord(" }");
    }

    public void WriteVector3(CVector3 Value)
    {
      this.WriteWord("{ ");
      this.WriteFloat(Value.X);
      this.WriteWord(", ");
      this.WriteFloat(Value.Y);
      this.WriteWord(", ");
      this.WriteFloat(Value.Z);
      this.WriteWord(" }");
    }

    public void WriteVector4(CVector4 Value)
    {
      this.WriteWord("{ ");
      this.WriteFloat(Value.X);
      this.WriteWord(", ");
      this.WriteFloat(Value.Y);
      this.WriteWord(", ");
      this.WriteFloat(Value.Z);
      this.WriteWord(", ");
      this.WriteFloat(Value.W);
      this.WriteWord(" }");
    }

    public void WriteColor(CVector3 Value)
    {
      this.WriteWord("{ ");
      this.WriteFloat(Value.Z);
      this.WriteWord(", ");
      this.WriteFloat(Value.Y);
      this.WriteWord(", ");
      this.WriteFloat(Value.X);
      this.WriteWord(" }");
    }

    public void BeginGroup(string Group)
    {
      this.WriteTabs();
      this.OutputBuilder.AppendLine(Group + " {");
      ++this.TabDepth;
    }

    public void BeginGroup(string Group, string Name)
    {
      this.WriteTabs();
      this.OutputBuilder.AppendLine(Group + " \"" + Name + "\" {");
      ++this.TabDepth;
    }

    public void BeginGroup(string Group, int Size)
    {
      this.WriteTabs();
      this.OutputBuilder.AppendLine(Group + " " + (object) Size + " {");
      ++this.TabDepth;
    }

    public void BeginGroup(string Group, int Size1, int Size2)
    {
      this.WriteTabs();
      this.OutputBuilder.AppendLine(Group + " " + (object) Size1 + " " + (object) Size2 + " {");
      ++this.TabDepth;
    }

    public void EndGroup()
    {
      --this.TabDepth;
      this.WriteTabs();
      this.OutputBuilder.AppendLine("}");
    }

    public void EndGroup(string ExtraString)
    {
      --this.TabDepth;
      this.WriteTabs();
      this.OutputBuilder.AppendLine("}" + ExtraString);
    }

    public string Name => this._Name;
  }
}
