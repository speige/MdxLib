// Decompiled with JetBrains decompiler
// Type: MdxLib.Command.CSetObjectField`2
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using System.Reflection;

namespace MdxLib.Command
{
  internal sealed class CSetObjectField<T1, T2> : ICommand where T1 : CObject<T1>
  {
    private T1 CurrentObject = default (T1);
    private T2 OldValue = default (T2);
    private T2 NewValue = default (T2);
    private FieldInfo FieldInfo;

    public CSetObjectField(T1 Object, string FieldName, T2 Value)
    {
      this.FieldInfo = typeof (T1).GetField(FieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
      this.CurrentObject = Object;
      this.OldValue = (T2) this.FieldInfo.GetValue((object) this.CurrentObject);
      this.NewValue = Value;
    }

    public void Do() => this.FieldInfo.SetValue((object) this.CurrentObject, (object) this.NewValue);

    public void Undo() => this.FieldInfo.SetValue((object) this.CurrentObject, (object) this.OldValue);
  }
}
