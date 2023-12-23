// Decompiled with JetBrains decompiler
// Type: MdxLib.ModelFormats.Mdl.CUnknown
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.ModelFormats.Mdl.Token;
using MdxLib.Primitives;

namespace MdxLib.ModelFormats.Mdl
{
  internal abstract class CUnknown
  {
    public int LoadId(CLoader Loader)
    {
      int num = Loader.ReadId();
      Loader.ExpectToken(EType.Separator);
      return num;
    }

    public bool LoadBoolean(CLoader Loader)
    {
      Loader.ExpectToken(EType.Separator);
      return true;
    }

    public int LoadInteger(CLoader Loader)
    {
      int num = Loader.ReadInteger();
      Loader.ExpectToken(EType.Separator);
      return num;
    }

    public float LoadFloat(CLoader Loader)
    {
      float num = Loader.ReadFloat();
      Loader.ExpectToken(EType.Separator);
      return num;
    }

    public string LoadString(CLoader Loader)
    {
      string str = Loader.ReadString();
      Loader.ExpectToken(EType.Separator);
      return str;
    }

    public string LoadWord(CLoader Loader)
    {
      string str = Loader.ReadWord();
      Loader.ExpectToken(EType.Separator);
      return str;
    }

    public CVector2 LoadVector2(CLoader Loader)
    {
      CVector2 cvector2 = Loader.ReadVector2();
      Loader.ExpectToken(EType.Separator);
      return cvector2;
    }

    public CVector3 LoadVector3(CLoader Loader)
    {
      CVector3 cvector3 = Loader.ReadVector3();
      Loader.ExpectToken(EType.Separator);
      return cvector3;
    }

    public CVector4 LoadVector4(CLoader Loader)
    {
      CVector4 cvector4 = Loader.ReadVector4();
      Loader.ExpectToken(EType.Separator);
      return cvector4;
    }

    public CVector3 LoadColor(CLoader Loader)
    {
      CVector3 cvector3 = Loader.ReadColor();
      Loader.ExpectToken(EType.Separator);
      return cvector3;
    }

    public void SaveId(CSaver Saver, string Name, int Value) => this.SaveId(Saver, Name, Value, ECondition.Always, false);

    public void SaveId(CSaver Saver, string Name, int Value, ECondition Condition) => this.SaveId(Saver, Name, Value, Condition, false);

    public void SaveId(CSaver Saver, string Name, int Value, bool UseMultipleAsNone) => this.SaveId(Saver, Name, Value, ECondition.Always, UseMultipleAsNone);

    public void SaveId(
      CSaver Saver,
      string Name,
      int Value,
      ECondition Condition,
      bool UseMultipleAsNone)
    {
      if (Condition == ECondition.NotInvalidId && Value == -1)
        return;
      Saver.WriteTabs();
      Saver.WriteWord(Name + " ");
      Saver.WriteWord(Value != -1 ? Value.ToString() : (UseMultipleAsNone ? "Multiple" : "None"));
      Saver.WriteLine(",");
    }

    public void SaveBoolean(CSaver Saver, string Name, bool Value)
    {
      if (!Value)
        return;
      Saver.WriteTabs();
      Saver.WriteLine(Name + ",");
    }

    public void SaveInteger(CSaver Saver, string Name, int Value) => this.SaveInteger(Saver, Name, Value, ECondition.Always);

    public void SaveInteger(CSaver Saver, string Name, int Value, ECondition Condition)
    {
      switch (Condition)
      {
        case ECondition.NotZero:
          if (Value == 0)
            return;
          break;
        case ECondition.NotOne:
          if (Value == 1)
            return;
          break;
      }
      Saver.WriteTabs();
      Saver.WriteWord(Name + " ");
      Saver.WriteInteger(Value);
      Saver.WriteLine(",");
    }

    public void SaveFloat(CSaver Saver, string Name, float Value) => this.SaveFloat(Saver, Name, Value, ECondition.Always);

    public void SaveFloat(CSaver Saver, string Name, float Value, ECondition Condition)
    {
      switch (Condition)
      {
        case ECondition.NotZero:
          if ((double) Value == 0.0)
            return;
          break;
        case ECondition.NotOne:
          if ((double) Value == 1.0)
            return;
          break;
      }
      Saver.WriteTabs();
      Saver.WriteWord(Name + " ");
      Saver.WriteFloat(Value);
      Saver.WriteLine(",");
    }

    public void SaveString(CSaver Saver, string Name, string Value) => this.SaveString(Saver, Name, Value, ECondition.Always);

    public void SaveString(CSaver Saver, string Name, string Value, ECondition Condition)
    {
      if (Condition == ECondition.NotEmpty && Value == "")
        return;
      Saver.WriteTabs();
      Saver.WriteWord(Name + " ");
      Saver.WriteString(Value);
      Saver.WriteLine(",");
    }

    public void SaveVector2(CSaver Saver, string Name, CVector2 Value) => this.SaveVector2(Saver, Name, Value, ECondition.Always);

    public void SaveVector2(CSaver Saver, string Name, CVector2 Value, ECondition Condition)
    {
      switch (Condition)
      {
        case ECondition.NotZero:
          if ((double) Value.X == 0.0 && (double) Value.Y == 0.0)
            return;
          break;
        case ECondition.NotOne:
          if ((double) Value.X == 1.0 && (double) Value.Y == 1.0)
            return;
          break;
      }
      Saver.WriteTabs();
      Saver.WriteWord(Name + " ");
      Saver.WriteVector2(Value);
      Saver.WriteLine(",");
    }

    public void SaveVector3(CSaver Saver, string Name, CVector3 Value) => this.SaveVector3(Saver, Name, Value, ECondition.Always);

    public void SaveVector3(CSaver Saver, string Name, CVector3 Value, ECondition Condition)
    {
      switch (Condition)
      {
        case ECondition.NotZero:
          if ((double) Value.X == 0.0 && (double) Value.Y == 0.0 && (double) Value.Z == 0.0)
            return;
          break;
        case ECondition.NotOne:
          if ((double) Value.X == 1.0 && (double) Value.Y == 1.0 && (double) Value.Z == 1.0)
            return;
          break;
      }
      Saver.WriteTabs();
      Saver.WriteWord(Name + " ");
      Saver.WriteVector3(Value);
      Saver.WriteLine(",");
    }

    public void SaveVector4(CSaver Saver, string Name, CVector4 Value) => this.SaveVector4(Saver, Name, Value, ECondition.Always);

    public void SaveVector4(CSaver Saver, string Name, CVector4 Value, ECondition Condition)
    {
      switch (Condition)
      {
        case ECondition.NotZero:
          if ((double) Value.X == 0.0 && (double) Value.Y == 0.0 && (double) Value.Z == 0.0 && (double) Value.W == 0.0)
            return;
          break;
        case ECondition.NotOne:
          if ((double) Value.X == 1.0 && (double) Value.Y == 1.0 && (double) Value.Z == 1.0 && (double) Value.W == 1.0)
            return;
          break;
        case ECondition.NotDefaultQuaternion:
          if ((double) Value.X == 0.0 && (double) Value.Y == 0.0 && (double) Value.Z == 0.0 && (double) Value.W == 1.0)
            return;
          break;
      }
      Saver.WriteTabs();
      Saver.WriteWord(Name + " ");
      Saver.WriteVector4(Value);
      Saver.WriteLine(",");
    }

    public void SaveColor(CSaver Saver, string Name, CVector3 Value) => this.SaveColor(Saver, Name, Value, ECondition.Always);

    public void SaveColor(CSaver Saver, string Name, CVector3 Value, ECondition Condition)
    {
      switch (Condition)
      {
        case ECondition.NotZero:
          if ((double) Value.X == 0.0 && (double) Value.Y == 0.0 && (double) Value.Z == 0.0)
            return;
          break;
        case ECondition.NotOne:
          if ((double) Value.X == 1.0 && (double) Value.Y == 1.0 && (double) Value.Z == 1.0)
            return;
          break;
      }
      Saver.WriteTabs();
      Saver.WriteWord(Name + " ");
      Saver.WriteColor(Value);
      Saver.WriteLine(",");
    }
  }
}
