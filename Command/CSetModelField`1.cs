// Decompiled with JetBrains decompiler
// Type: MdxLib.Command.CSetModelField`1
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Model;
using System.Reflection;

namespace MdxLib.Command
{
  internal sealed class CSetModelField<T> : ICommand
  {
    private CModel CurrentModel;
    private T OldValue = default (T);
    private T NewValue = default (T);
    private FieldInfo FieldInfo;

    public CSetModelField(CModel Model, string FieldName, T Value)
    {
      this.FieldInfo = typeof (CModel).GetField(FieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
      this.CurrentModel = Model;
      this.OldValue = (T) this.FieldInfo.GetValue((object) this.CurrentModel);
      this.NewValue = Value;
    }

    public void Do() => this.FieldInfo.SetValue((object) this.CurrentModel, (object) this.NewValue);

    public void Undo() => this.FieldInfo.SetValue((object) this.CurrentModel, (object) this.OldValue);
  }
}
