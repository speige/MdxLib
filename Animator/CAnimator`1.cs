// Decompiled with JetBrains decompiler
// Type: MdxLib.Animator.CAnimator`1
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using MdxLib.Command;
using MdxLib.Command.Animator;
using MdxLib.Model;
using System.Collections;
using System.Collections.Generic;

namespace MdxLib.Animator
{
  public sealed class CAnimator<T> : 
    IList<CAnimatorNode<T>>,
    ICollection<CAnimatorNode<T>>,
    IEnumerable<CAnimatorNode<T>>,
    IEnumerable
    where T : new()
  {
    private CModel _Model;
    private CAnimatable<T> _Animatable;
    private CObjectReference<CGlobalSequence> _GlobalSequence;
    private bool _Animated;
    private EInterpolationType _Type;
    private T _StaticValue = default (T);
    private List<CAnimatorNode<T>> NodeList;

    internal CAnimator(CModel Model, CAnimatable<T> Animatable)
    {
      this._Model = Model;
      this._Animatable = Animatable;
      this._StaticValue = Animatable.DefaultValue;
      this.NodeList = new List<CAnimatorNode<T>>();
    }

    public T GetValue() => this._StaticValue;

    public T GetValue(CTime Time) => !this._Animated ? this._StaticValue : this._Animatable.Interpolate(this._Type, Time, this.GetLowerNodeAtTime(Time), this.GetUpperNodeAtTime(Time));

    public CAnimatorNode<T> GetLowerNodeAtTime(CTime Time)
    {
      for (int index = this.NodeList.Count - 1; index >= 0; --index)
      {
        CAnimatorNode<T> node = this.NodeList[index];
        if (node.Time < Time.IntervalStart)
          return (CAnimatorNode<T>) null;
        if (node.Time <= Time.Time)
          return node;
      }
      return (CAnimatorNode<T>) null;
    }

    public CAnimatorNode<T> GetUpperNodeAtTime(CTime Time)
    {
      for (int index = 0; index < this.NodeList.Count; ++index)
      {
        CAnimatorNode<T> node = this.NodeList[index];
        if (node.Time > Time.IntervalEnd)
          return (CAnimatorNode<T>) null;
        if (node.Time >= Time.Time)
          return node;
      }
      return (CAnimatorNode<T>) null;
    }

    public void MakeStatic(T StaticValue)
    {
      this.AddSetAnimatorFieldCommand<T>("_StaticValue", StaticValue);
      this._StaticValue = StaticValue;
      this.AddSetAnimatorFieldCommand<bool>("_Animated", false);
      this._Animated = false;
    }

    public void MakeAnimated()
    {
      this.AddSetAnimatorFieldCommand<bool>("_Animated", true);
      this._Animated = true;
    }

    public void Clear()
    {
      if (this.NodeList.Count <= 0)
        return;
      if (this.CanAddCommand)
      {
        ICommand Command = (ICommand) new CClear<T>(this);
        Command.Do();
        this.AddCommand(Command);
      }
      else
        this.NodeList.Clear();
    }

    public void Add(CAnimatorNode<T> Node)
    {
      int insertIndex = this.GetInsertIndex(Node);
      if (this.CanAddCommand)
      {
        ICommand Command = (ICommand) new CInsert<T>(this, insertIndex, Node);
        Command.Do();
        this.AddCommand(Command);
      }
      else
        this.NodeList.Insert(insertIndex, Node);
    }

    public void Insert(int Index, CAnimatorNode<T> Node)
    {
      int insertIndex = this.GetInsertIndex(Node);
      if (this.CanAddCommand)
      {
        ICommand Command = (ICommand) new CInsert<T>(this, insertIndex, Node);
        Command.Do();
        this.AddCommand(Command);
      }
      else
        this.NodeList.Insert(insertIndex, Node);
    }

    public void Set(int Index, CAnimatorNode<T> Node)
    {
      if (!this.ContainsIndex(Index))
        return;
      CAnimatorNode<T> Node1 = new CAnimatorNode<T>(this.NodeList[Index].Time, Node.Value, Node.InTangent, Node.OutTangent);
      if (this.CanAddCommand)
      {
        ICommand Command = (ICommand) new CSet<T>(this, Index, Node1);
        Command.Do();
        this.AddCommand(Command);
      }
      else
        this.NodeList[Index] = Node1;
    }

    public bool Remove(CAnimatorNode<T> Node)
    {
      int num = this.NodeList.IndexOf(Node);
      if (!this.ContainsIndex(num))
        return false;
      if (this.CanAddCommand)
      {
        ICommand Command = (ICommand) new CRemoveAt<T>(this, num);
        Command.Do();
        this.AddCommand(Command);
      }
      else
        this.NodeList.RemoveAt(num);
      return true;
    }

    public void RemoveAt(int Index)
    {
      if (!this.ContainsIndex(Index))
        return;
      if (this.CanAddCommand)
      {
        ICommand Command = (ICommand) new CRemoveAt<T>(this, Index);
        Command.Do();
        this.AddCommand(Command);
      }
      else
        this.NodeList.RemoveAt(Index);
    }

    public CAnimatorNode<T> Get(int Index) => !this.ContainsIndex(Index) ? (CAnimatorNode<T>) null : this.NodeList[Index];

    public int IndexOf(CAnimatorNode<T> Node) => this.NodeList.IndexOf(Node);

    public bool Contains(CAnimatorNode<T> Node) => this.NodeList.Contains(Node);

    public bool ContainsIndex(int Index) => Index >= 0 && Index < this.NodeList.Count;

    public void CopyTo(CAnimatorNode<T>[] Array, int Index) => this.NodeList.CopyTo(Array, Index);

    public IEnumerator<CAnimatorNode<T>> GetEnumerator() => (IEnumerator<CAnimatorNode<T>>) this.NodeList.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.NodeList.GetEnumerator();

    private int GetInsertIndex(CAnimatorNode<T> Node)
    {
      if (this.NodeList.Count > 0 && Node.Time > this.NodeList[this.NodeList.Count - 1].Time)
        return this.NodeList.Count;
      for (int index = 0; index < this.NodeList.Count; ++index)
      {
        if (Node.Time < this.NodeList[index].Time)
          return index;
      }
      return this.NodeList.Count;
    }

    internal void AddCommand(ICommand Command)
    {
      if (this._Model.CommandGroup == null)
        return;
      this._Model.CommandGroup.Add(Command);
    }

    internal void AddSetAnimatorFieldCommand<T2>(string FieldName, T2 Value)
    {
      if (this._Model.CommandGroup == null)
        return;
      this._Model.CommandGroup.Add((ICommand) new CSetAnimatorField<T, T2>(this, FieldName, Value));
    }

    public bool Static => !this._Animated;

    public bool Animated => this._Animated;

    public EInterpolationType Type
    {
      get => this._Type;
      set
      {
        this.AddSetAnimatorFieldCommand<EInterpolationType>("_Type", value);
        this._Type = value;
      }
    }

    public int Count => this.NodeList.Count;

    public bool IsReadOnly => false;

    public CAnimatorNode<T> this[int Index]
    {
      get => this.Get(Index);
      set
      {
        if (value != null)
          this.Set(Index, value);
        else
          this.RemoveAt(Index);
      }
    }

    public CModel Model => this._Model;

    public CObjectReference<CGlobalSequence> GlobalSequence => this._GlobalSequence ?? (this._GlobalSequence = new CObjectReference<CGlobalSequence>(this.Model));

    internal bool CanAddCommand => this._Model.CommandGroup != null;

    internal List<CAnimatorNode<T>> InternalNodeList
    {
      get => this.NodeList;
      set => this.NodeList = value;
    }
  }
}
