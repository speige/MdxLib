// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdl.CLoader
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.ModelFormats.Attacher;
using MdxLib.ModelFormats.Mdl.Token;
using MdxLib.Primitives;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace MdxLib.ModelFormats.Mdl
{
  internal sealed class CLoader
  {
    private const int FirstGroupIndex = 4;
    private int _Line = 1;
    private string _Name = "";
    private bool _Eof;
    private CAttacherContainer _Attacher;
    private string InputString = "";
    private string ExpressionString = "";
    private Regex Expression;
    private bool AlreadyParsed;
    private EType CurrentType;
    private Match CurrentMatch;
    private Group CurrentGroup;

    public CLoader(string Name, Stream Stream)
    {
      this._Name = Name;
      this._Attacher = new CAttacherContainer();
      this.AppendPattern("newline", "\\n");
      this.AppendPattern("whitespace", "[\\t\\r ]+");
      this.AppendPattern("metacomment", "//\\<\\?xml(.|\\n)*?//\\</meta\\>");
      this.AppendPattern("comment", "//.*?\\n|/\\*(.|\\n)*?\\*/");
      this.AppendPattern("colon", ":");
      this.AppendPattern("separator", ",");
      this.AppendPattern("word", "[a-zA-Z_][a-zA-Z0-9_]*");
      this.AppendPattern("float", "[+-]?\\d*\\.\\d+[Ee][+-]?\\d+|[+-]?\\d+[Ee][+-]?\\d+|[+-]?\\d*\\.\\d+");
      this.AppendPattern("integer", "[+-]?\\d+");
      this.AppendPattern("string", "\"([^\"\n\\\\]|\\\\.)*?\"");
      this.AppendPattern("bracket_rl", "\\(");
      this.AppendPattern("bracket_rr", "\\)");
      this.AppendPattern("bracket_sl", "\\[");
      this.AppendPattern("bracket_sr", "\\]");
      this.AppendPattern("bracket_al", "\\<");
      this.AppendPattern("bracket_ar", "\\>");
      this.AppendPattern("bracket_cl", "{");
      this.AppendPattern("bracket_cr", "}");
      this.AppendPattern("unknown", ".+?");
      this.Expression = new Regex(this.ExpressionString);
      using (StreamReader streamReader = new StreamReader(Stream, CConstants.TextEncoding, true))
        this.InputString = streamReader.ReadToEnd();
    }

    public EType ReadToken()
    {
      this.ReadNextToken();
      return this.CurrentType;
    }

    public string ReadMetaData()
    {
      this.ReadNextToken();
      if (this.CurrentType != EType.MetaComment)
        throw new Exception("Syntax error at line " + (object) this.Line + ", expected a meta comment, got \"" + this.CurrentGroup.Value + "\"!");
      StringBuilder stringBuilder = new StringBuilder();
      string str1 = this.CurrentGroup.Value;
      string[] separator = new string[1]{ "\n" };
      foreach (string str2 in str1.Split(separator, StringSplitOptions.None))
      {
        string str3 = str2.Trim();
        if (str3.StartsWith("//"))
          str3 = str3.Remove(0, 2);
        stringBuilder.Append(str3.Trim());
      }
      return stringBuilder.ToString();
    }

    public string ReadWord()
    {
      this.ReadNextToken();
      if (this.CurrentType != EType.Word)
        throw new Exception("Syntax error at line " + (object) this.Line + ", expected a word, got \"" + this.CurrentGroup.Value + "\"!");
      return this.CurrentGroup.Value.ToLower();
    }

    public int ReadId()
    {
      this.ReadNextToken();
      switch (this.CurrentType)
      {
        case EType.Word:
          string lower = this.CurrentGroup.Value.ToLower();
          switch (lower)
          {
            case "none":
            case "multiple":
              return -1;
            default:
              throw new Exception("Syntax error at line " + (object) this.Line + ", unknown ID \"" + lower + "\"!");
          }
        case EType.Integer:
          return int.Parse(this.CurrentGroup.Value);
        default:
          throw new Exception("Syntax error at line " + (object) this.Line + ", expected an ID, got \"" + this.CurrentGroup.Value + "\"!");
      }
    }

    public int ReadInteger()
    {
      this.ReadNextToken();
      if (this.CurrentType != EType.Integer)
        throw new Exception("Syntax error at line " + (object) this.Line + ", expected an integer, got \"" + this.CurrentGroup.Value + "\"!");
      return int.Parse(this.CurrentGroup.Value);
    }

    public float ReadFloat()
    {
      this.ReadNextToken();
      if (this.CurrentType != EType.Integer && this.CurrentType != EType.Float)
        throw new Exception("Syntax error at line " + (object) this.Line + ", expected a float, got \"" + this.CurrentGroup.Value + "\"!");
      return float.Parse(this.CurrentGroup.Value, (IFormatProvider) CConstants.NumberFormat);
    }

    public string ReadString()
    {
      this.ReadNextToken();
      if (this.CurrentType != EType.String)
        throw new Exception("Syntax error at line " + (object) this.Line + ", expected a string, got \"" + this.CurrentGroup.Value + "\"!");
      string str = this.CurrentGroup.Value;
      if (str.StartsWith("\""))
        str = str.Remove(0, 1);
      if (str.EndsWith("\""))
        str = str.Remove(str.Length - 1, 1);
      return str.Replace("\\\"", "\"");
    }

    public CVector2 ReadVector2()
    {
      this.ExpectToken(EType.CurlyBracketLeft);
      float X = this.ReadFloat();
      this.ExpectToken(EType.Separator);
      float Y = this.ReadFloat();
      this.ExpectToken(EType.CurlyBracketRight);
      return new CVector2(X, Y);
    }

    public CVector3 ReadVector3()
    {
      this.ExpectToken(EType.CurlyBracketLeft);
      float X = this.ReadFloat();
      this.ExpectToken(EType.Separator);
      float Y = this.ReadFloat();
      this.ExpectToken(EType.Separator);
      float Z = this.ReadFloat();
      this.ExpectToken(EType.CurlyBracketRight);
      return new CVector3(X, Y, Z);
    }

    public CVector4 ReadVector4()
    {
      this.ExpectToken(EType.CurlyBracketLeft);
      float X = this.ReadFloat();
      this.ExpectToken(EType.Separator);
      float Y = this.ReadFloat();
      this.ExpectToken(EType.Separator);
      float Z = this.ReadFloat();
      this.ExpectToken(EType.Separator);
      float W = this.ReadFloat();
      this.ExpectToken(EType.CurlyBracketRight);
      return new CVector4(X, Y, Z, W);
    }

    public CVector3 ReadColor()
    {
      this.ExpectToken(EType.CurlyBracketLeft);
      float Z = this.ReadFloat();
      this.ExpectToken(EType.Separator);
      float Y = this.ReadFloat();
      this.ExpectToken(EType.Separator);
      float X = this.ReadFloat();
      this.ExpectToken(EType.CurlyBracketRight);
      return new CVector3(X, Y, Z);
    }

    public void ExpectToken(EType ExpectedType)
    {
      EType Type = this.ReadToken();
      if (Type != ExpectedType)
        throw new Exception("Syntax error at line " + (object) this.Line + ", expected " + this.TokenToText(Type) + ", got \"" + this.CurrentGroup.Value + "\"!");
    }

    public void ExpectWord(string ExpectedWord)
    {
      string str = this.ReadWord();
      if (str != ExpectedWord.ToLower())
        throw new Exception("Syntax error at line " + (object) this.Line + ", expected \"" + ExpectedWord + "\", got \"" + str + "\"!");
    }

    public EType PeekToken()
    {
      this.PeekNextToken();
      return this.CurrentType;
    }

    private void ReadNextToken()
    {
      if (!this.ParseNextToken())
        throw new Exception("Unexpected EOF reached at line " + (object) this.Line + "!");
    }

    private void PeekNextToken()
    {
      if (!this.ParseNextToken())
        throw new Exception("Unexpected EOF reached at line " + (object) this.Line + "!");
      this.AlreadyParsed = true;
    }

    private bool ParseNextToken()
    {
      if (this.AlreadyParsed)
      {
        this.AlreadyParsed = false;
        return true;
      }
label_2:
      this.CurrentMatch = this.CurrentMatch != null ? this.CurrentMatch.NextMatch() : this.Expression.Match(this.InputString);
      if (!this.CurrentMatch.Success)
      {
        this._Eof = true;
        this.CurrentType = EType.Unknown;
        this.CurrentMatch = (Match) null;
        this.CurrentGroup = (Group) null;
        return false;
      }
      for (int index = 4; index < this.CurrentMatch.Groups.Count; ++index)
      {
        this.CurrentGroup = this.CurrentMatch.Groups[index];
        if (this.CurrentGroup.Success)
        {
          this.CurrentType = this.PatternNameToType(this.Expression.GroupNameFromNumber(index));
          switch (this.CurrentType)
          {
            case EType.Unknown:
              throw new Exception("Syntax error at line " + (object) this.Line + ", unknown token \"" + this.CurrentGroup.Value + "\"!");
            case EType.MetaComment:
              foreach (char ch in this.CurrentGroup.Value)
              {
                if (ch == '\n')
                  ++this._Line;
              }
              return true;
            case EType.Comment:
              foreach (char ch in this.CurrentGroup.Value)
              {
                if (ch == '\n')
                  ++this._Line;
              }
              goto label_2;
            case EType.NewLine:
              ++this._Line;
              goto label_2;
            case EType.WhiteSpace:
              goto label_2;
            default:
              return true;
          }
        }
      }
      goto label_2;
    }

    private void AppendPattern(string Name, string Pattern)
    {
      if (this.ExpressionString != "")
        this.ExpressionString += "|";
      CLoader cloader = this;
      cloader.ExpressionString = cloader.ExpressionString + "(?<" + Name + ">" + Pattern + ")";
    }

    private EType PatternNameToType(string Name)
    {
      switch (Name)
      {
        case "newline":
          return EType.NewLine;
        case "whitespace":
          return EType.WhiteSpace;
        case "metacomment":
          return EType.MetaComment;
        case "comment":
          return EType.Comment;
        case "colon":
          return EType.Colon;
        case "separator":
          return EType.Separator;
        case "word":
          return EType.Word;
        case "float":
          return EType.Float;
        case "integer":
          return EType.Integer;
        case "string":
          return EType.String;
        case "bracket_rl":
          return EType.RoundBracketLeft;
        case "bracket_rr":
          return EType.RoundBracketRight;
        case "bracket_sl":
          return EType.SquareBracketLeft;
        case "bracket_sr":
          return EType.SquareBracketRight;
        case "bracket_al":
          return EType.AngleBracketLeft;
        case "bracket_ar":
          return EType.AngleBracketRight;
        case "bracket_cl":
          return EType.CurlyBracketLeft;
        case "bracket_cr":
          return EType.CurlyBracketRight;
        case "unknown":
          return EType.Unknown;
        default:
          return EType.Unknown;
      }
    }

    private string TokenToText(EType Type)
    {
      switch (Type)
      {
        case EType.Unknown:
          return "<unknown>";
        case EType.MetaComment:
          return "a meta comment";
        case EType.Comment:
          return "a comment";
        case EType.Word:
          return "a word";
        case EType.Integer:
          return "an integer";
        case EType.Float:
          return "a float";
        case EType.String:
          return "a string";
        case EType.NewLine:
          return "a newline";
        case EType.WhiteSpace:
          return "whitespace";
        case EType.Colon:
          return "\":\"";
        case EType.Separator:
          return "\",\"";
        case EType.RoundBracketLeft:
          return "\"(\"";
        case EType.RoundBracketRight:
          return "\")\"";
        case EType.SquareBracketLeft:
          return "\"[\"";
        case EType.SquareBracketRight:
          return "\"]\"";
        case EType.CurlyBracketLeft:
          return "\"{\"";
        case EType.CurlyBracketRight:
          return "\"}\"";
        case EType.AngleBracketLeft:
          return "\"<\"";
        case EType.AngleBracketRight:
          return "\">\"";
        default:
          return "<unknown>";
      }
    }

    public int Line => this._Line;

    public string Name => this._Name;

    public bool Eof => this._Eof;

    public CAttacherContainer Attacher => this._Attacher;
  }
}
