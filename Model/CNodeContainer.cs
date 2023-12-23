// Decompiled with JetBrains decompiler
// Type: MdxLib.Model.CNodeContainer
// Assembly: MdxLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17865964-456C-47B2-99EA-FF370F2E8526
// Assembly location: C:\Users\Devin\Downloads\MdxConverter\MdxLib.dll

using System;
using System.Collections;
using System.Collections.Generic;

namespace MdxLib.Model
{
  public sealed class CNodeContainer : 
    IList<INode>,
    ICollection<INode>,
    IEnumerable<INode>,
    IEnumerable
  {
    private CModel _Model;

    internal CNodeContainer(CModel Model) => this._Model = Model;

    public void Clear()
    {
      if (this._Model.HasBones)
        this._Model.Bones.Clear();
      if (this._Model.HasLights)
        this._Model.Lights.Clear();
      if (this._Model.HasHelpers)
        this._Model.Helpers.Clear();
      if (this._Model.HasAttachments)
        this._Model.Attachments.Clear();
      if (this._Model.HasParticleEmitters)
        this._Model.ParticleEmitters.Clear();
      if (this._Model.HasParticleEmitters2)
        this._Model.ParticleEmitters2.Clear();
      if (this._Model.HasRibbonEmitters)
        this._Model.RibbonEmitters.Clear();
      if (this._Model.HasEvents)
        this._Model.Events.Clear();
      if (!this._Model.HasCollisionShapes)
        return;
      this._Model.CollisionShapes.Clear();
    }

    public void Add(INode Node)
    {
      if (Node == null)
        return;
      if (Node.Model != this._Model)
        throw new InvalidOperationException("The node belongs to another model!");
      if (Node is CBone)
        this._Model.Bones.Add(Node as CBone);
      if (Node is CLight)
        this._Model.Lights.Add(Node as CLight);
      if (Node is CHelper)
        this._Model.Helpers.Add(Node as CHelper);
      if (Node is CAttachment)
        this._Model.Attachments.Add(Node as CAttachment);
      if (Node is CParticleEmitter)
        this._Model.ParticleEmitters.Add(Node as CParticleEmitter);
      if (Node is CParticleEmitter2)
        this._Model.ParticleEmitters2.Add(Node as CParticleEmitter2);
      if (Node is CRibbonEmitter)
        this._Model.RibbonEmitters.Add(Node as CRibbonEmitter);
      if (Node is CEvent)
        this._Model.Events.Add(Node as CEvent);
      if (!(Node is CCollisionShape))
        return;
      this._Model.CollisionShapes.Add(Node as CCollisionShape);
    }

    public void Insert(int Index, INode Node)
    {
      if (Node == null)
        return;
      if (Node.Model != this._Model)
        throw new InvalidOperationException("The node belongs to another model!");
      if (this._Model.HasBones)
      {
        if (Index < 0)
          return;
        if (Index < this._Model.Bones.Count)
          this._Model.Bones.Insert(Index, Node as CBone);
        Index -= this._Model.Bones.Count;
      }
      if (this._Model.HasLights)
      {
        if (Index < 0)
          return;
        if (Index < this._Model.Lights.Count)
          this._Model.Lights.Insert(Index, Node as CLight);
        Index -= this._Model.Lights.Count;
      }
      if (this._Model.HasHelpers)
      {
        if (Index < 0)
          return;
        if (Index < this._Model.Helpers.Count)
          this._Model.Helpers.Insert(Index, Node as CHelper);
        Index -= this._Model.Helpers.Count;
      }
      if (this._Model.HasAttachments)
      {
        if (Index < 0)
          return;
        if (Index < this._Model.Attachments.Count)
          this._Model.Attachments.Insert(Index, Node as CAttachment);
        Index -= this._Model.Attachments.Count;
      }
      if (this._Model.HasParticleEmitters)
      {
        if (Index < 0)
          return;
        if (Index < this._Model.ParticleEmitters.Count)
          this._Model.ParticleEmitters.Insert(Index, Node as CParticleEmitter);
        Index -= this._Model.ParticleEmitters.Count;
      }
      if (this._Model.HasParticleEmitters2)
      {
        if (Index < 0)
          return;
        if (Index < this._Model.ParticleEmitters2.Count)
          this._Model.ParticleEmitters2.Insert(Index, Node as CParticleEmitter2);
        Index -= this._Model.ParticleEmitters2.Count;
      }
      if (this._Model.HasRibbonEmitters)
      {
        if (Index < 0)
          return;
        if (Index < this._Model.RibbonEmitters.Count)
          this._Model.RibbonEmitters.Insert(Index, Node as CRibbonEmitter);
        Index -= this._Model.RibbonEmitters.Count;
      }
      if (this._Model.HasEvents)
      {
        if (Index < 0)
          return;
        if (Index < this._Model.Events.Count)
          this._Model.Events.Insert(Index, Node as CEvent);
        Index -= this._Model.Events.Count;
      }
      if (!this._Model.HasCollisionShapes || Index < 0 || Index >= this._Model.CollisionShapes.Count)
        return;
      this._Model.CollisionShapes.Insert(Index, Node as CCollisionShape);
    }

    public void Set(int Index, INode Node)
    {
      if (Node == null)
        return;
      if (Node.Model != this._Model)
        throw new InvalidOperationException("The node belongs to another model!");
      if (this._Model.HasBones)
      {
        if (Index < 0)
          return;
        if (Index < this._Model.Bones.Count)
          this._Model.Bones.Set(Index, Node as CBone);
        Index -= this._Model.Bones.Count;
      }
      if (this._Model.HasLights)
      {
        if (Index < 0)
          return;
        if (Index < this._Model.Lights.Count)
          this._Model.Lights.Set(Index, Node as CLight);
        Index -= this._Model.Lights.Count;
      }
      if (this._Model.HasHelpers)
      {
        if (Index < 0)
          return;
        if (Index < this._Model.Helpers.Count)
          this._Model.Helpers.Set(Index, Node as CHelper);
        Index -= this._Model.Helpers.Count;
      }
      if (this._Model.HasAttachments)
      {
        if (Index < 0)
          return;
        if (Index < this._Model.Attachments.Count)
          this._Model.Attachments.Set(Index, Node as CAttachment);
        Index -= this._Model.Attachments.Count;
      }
      if (this._Model.HasParticleEmitters)
      {
        if (Index < 0)
          return;
        if (Index < this._Model.ParticleEmitters.Count)
          this._Model.ParticleEmitters.Set(Index, Node as CParticleEmitter);
        Index -= this._Model.ParticleEmitters.Count;
      }
      if (this._Model.HasParticleEmitters2)
      {
        if (Index < 0)
          return;
        if (Index < this._Model.ParticleEmitters2.Count)
          this._Model.ParticleEmitters2.Set(Index, Node as CParticleEmitter2);
        Index -= this._Model.ParticleEmitters2.Count;
      }
      if (this._Model.HasRibbonEmitters)
      {
        if (Index < 0)
          return;
        if (Index < this._Model.RibbonEmitters.Count)
          this._Model.RibbonEmitters.Set(Index, Node as CRibbonEmitter);
        Index -= this._Model.RibbonEmitters.Count;
      }
      if (this._Model.HasEvents)
      {
        if (Index < 0)
          return;
        if (Index < this._Model.Events.Count)
          this._Model.Events.Set(Index, Node as CEvent);
        Index -= this._Model.Events.Count;
      }
      if (!this._Model.HasCollisionShapes || Index < 0 || Index >= this._Model.CollisionShapes.Count)
        return;
      this._Model.CollisionShapes.Set(Index, Node as CCollisionShape);
    }

    public bool Remove(INode Node)
    {
      switch (Node)
      {
        case null:
          return false;
        case CBone _:
          return this._Model.Bones.Remove(Node as CBone);
        case CLight _:
          return this._Model.Lights.Remove(Node as CLight);
        case CHelper _:
          return this._Model.Helpers.Remove(Node as CHelper);
        case CAttachment _:
          return this._Model.Attachments.Remove(Node as CAttachment);
        case CParticleEmitter _:
          return this._Model.ParticleEmitters.Remove(Node as CParticleEmitter);
        case CParticleEmitter2 _:
          return this._Model.ParticleEmitters2.Remove(Node as CParticleEmitter2);
        case CRibbonEmitter _:
          return this._Model.RibbonEmitters.Remove(Node as CRibbonEmitter);
        case CEvent _:
          return this._Model.Events.Remove(Node as CEvent);
        case CCollisionShape _:
          return this._Model.CollisionShapes.Remove(Node as CCollisionShape);
        default:
          return false;
      }
    }

    public void RemoveAt(int Index)
    {
      if (this._Model.HasBones)
      {
        if (Index < 0)
          return;
        if (Index < this._Model.Bones.Count)
          this._Model.Bones.RemoveAt(Index);
        Index -= this._Model.Bones.Count;
      }
      if (this._Model.HasLights)
      {
        if (Index < 0)
          return;
        if (Index < this._Model.Lights.Count)
          this._Model.Lights.RemoveAt(Index);
        Index -= this._Model.Lights.Count;
      }
      if (this._Model.HasHelpers)
      {
        if (Index < 0)
          return;
        if (Index < this._Model.Helpers.Count)
          this._Model.Helpers.RemoveAt(Index);
        Index -= this._Model.Helpers.Count;
      }
      if (this._Model.HasAttachments)
      {
        if (Index < 0)
          return;
        if (Index < this._Model.Attachments.Count)
          this._Model.Attachments.RemoveAt(Index);
        Index -= this._Model.Attachments.Count;
      }
      if (this._Model.HasParticleEmitters)
      {
        if (Index < 0)
          return;
        if (Index < this._Model.ParticleEmitters.Count)
          this._Model.ParticleEmitters.RemoveAt(Index);
        Index -= this._Model.ParticleEmitters.Count;
      }
      if (this._Model.HasParticleEmitters2)
      {
        if (Index < 0)
          return;
        if (Index < this._Model.ParticleEmitters2.Count)
          this._Model.ParticleEmitters2.RemoveAt(Index);
        Index -= this._Model.ParticleEmitters2.Count;
      }
      if (this._Model.HasRibbonEmitters)
      {
        if (Index < 0)
          return;
        if (Index < this._Model.RibbonEmitters.Count)
          this._Model.RibbonEmitters.RemoveAt(Index);
        Index -= this._Model.RibbonEmitters.Count;
      }
      if (this._Model.HasEvents)
      {
        if (Index < 0)
          return;
        if (Index < this._Model.Events.Count)
          this._Model.Events.RemoveAt(Index);
        Index -= this._Model.Events.Count;
      }
      if (!this._Model.HasCollisionShapes || Index < 0 || Index >= this._Model.CollisionShapes.Count)
        return;
      this._Model.CollisionShapes.RemoveAt(Index);
    }

    public INode Get(int Index)
    {
      if (this._Model.HasBones)
      {
        if (Index < 0)
          return (INode) null;
        if (Index < this._Model.Bones.Count)
          return (INode) this._Model.Bones.Get(Index);
        Index -= this._Model.Bones.Count;
      }
      if (this._Model.HasLights)
      {
        if (Index < 0)
          return (INode) null;
        if (Index < this._Model.Lights.Count)
          return (INode) this._Model.Lights.Get(Index);
        Index -= this._Model.Lights.Count;
      }
      if (this._Model.HasHelpers)
      {
        if (Index < 0)
          return (INode) null;
        if (Index < this._Model.Helpers.Count)
          return (INode) this._Model.Helpers.Get(Index);
        Index -= this._Model.Helpers.Count;
      }
      if (this._Model.HasAttachments)
      {
        if (Index < 0)
          return (INode) null;
        if (Index < this._Model.Attachments.Count)
          return (INode) this._Model.Attachments.Get(Index);
        Index -= this._Model.Attachments.Count;
      }
      if (this._Model.HasParticleEmitters)
      {
        if (Index < 0)
          return (INode) null;
        if (Index < this._Model.ParticleEmitters.Count)
          return (INode) this._Model.ParticleEmitters.Get(Index);
        Index -= this._Model.ParticleEmitters.Count;
      }
      if (this._Model.HasParticleEmitters2)
      {
        if (Index < 0)
          return (INode) null;
        if (Index < this._Model.ParticleEmitters2.Count)
          return (INode) this._Model.ParticleEmitters2.Get(Index);
        Index -= this._Model.ParticleEmitters2.Count;
      }
      if (this._Model.HasRibbonEmitters)
      {
        if (Index < 0)
          return (INode) null;
        if (Index < this._Model.RibbonEmitters.Count)
          return (INode) this._Model.RibbonEmitters.Get(Index);
        Index -= this._Model.RibbonEmitters.Count;
      }
      if (this._Model.HasEvents)
      {
        if (Index < 0)
          return (INode) null;
        if (Index < this._Model.Events.Count)
          return (INode) this._Model.Events.Get(Index);
        Index -= this._Model.Events.Count;
      }
      if (this._Model.HasCollisionShapes)
      {
        if (Index < 0)
          return (INode) null;
        if (Index < this._Model.CollisionShapes.Count)
          return (INode) this._Model.CollisionShapes.Get(Index);
      }
      return (INode) null;
    }

    public int IndexOf(INode Node) => Node == null || Node.Model != this._Model ? -1 : Node.NodeId;

    public bool Contains(INode Node)
    {
      switch (Node)
      {
        case null:
          return false;
        case CBone _:
          return this._Model.Bones.Contains(Node as CBone);
        case CLight _:
          return this._Model.Lights.Contains(Node as CLight);
        case CHelper _:
          return this._Model.Helpers.Contains(Node as CHelper);
        case CAttachment _:
          return this._Model.Attachments.Contains(Node as CAttachment);
        case CParticleEmitter _:
          return this._Model.ParticleEmitters.Contains(Node as CParticleEmitter);
        case CParticleEmitter2 _:
          return this._Model.ParticleEmitters2.Contains(Node as CParticleEmitter2);
        case CRibbonEmitter _:
          return this._Model.RibbonEmitters.Contains(Node as CRibbonEmitter);
        case CEvent _:
          return this._Model.Events.Contains(Node as CEvent);
        case CCollisionShape _:
          return this._Model.CollisionShapes.Contains(Node as CCollisionShape);
        default:
          return false;
      }
    }

    public bool ContainsIndex(int Index) => Index >= 0 && Index < this.Count;

    public void CopyTo(INode[] Array, int Index)
    {
      int num = 0;
      if (this._Model.HasBones)
      {
        foreach (CBone bone in this._Model.Bones)
        {
          Array[Index + num] = (INode) bone;
          ++num;
        }
      }
      if (this._Model.HasLights)
      {
        foreach (CLight light in this._Model.Lights)
        {
          Array[Index + num] = (INode) light;
          ++num;
        }
      }
      if (this._Model.HasHelpers)
      {
        foreach (CHelper helper in this._Model.Helpers)
        {
          Array[Index + num] = (INode) helper;
          ++num;
        }
      }
      if (this._Model.HasAttachments)
      {
        foreach (CAttachment attachment in this._Model.Attachments)
        {
          Array[Index + num] = (INode) attachment;
          ++num;
        }
      }
      if (this._Model.HasParticleEmitters)
      {
        foreach (CParticleEmitter particleEmitter in this._Model.ParticleEmitters)
        {
          Array[Index + num] = (INode) particleEmitter;
          ++num;
        }
      }
      if (this._Model.HasParticleEmitters2)
      {
        foreach (CParticleEmitter2 cparticleEmitter2 in this._Model.ParticleEmitters2)
        {
          Array[Index + num] = (INode) cparticleEmitter2;
          ++num;
        }
      }
      if (this._Model.HasRibbonEmitters)
      {
        foreach (CRibbonEmitter ribbonEmitter in this._Model.RibbonEmitters)
        {
          Array[Index + num] = (INode) ribbonEmitter;
          ++num;
        }
      }
      if (this._Model.HasEvents)
      {
        foreach (CEvent cevent in this._Model.Events)
        {
          Array[Index + num] = (INode) cevent;
          ++num;
        }
      }
      if (!this._Model.HasCollisionShapes)
        return;
      foreach (CCollisionShape collisionShape in this._Model.CollisionShapes)
      {
        Array[Index + num] = (INode) collisionShape;
        ++num;
      }
    }

    public IEnumerator<INode> GetEnumerator()
    {
      if (this._Model.HasBones)
      {
        foreach (CBone Bone in this._Model.Bones)
          yield return (INode) Bone;
      }
      if (this._Model.HasLights)
      {
        foreach (CLight Light in this._Model.Lights)
          yield return (INode) Light;
      }
      if (this._Model.HasHelpers)
      {
        foreach (CHelper Helper in this._Model.Helpers)
          yield return (INode) Helper;
      }
      if (this._Model.HasAttachments)
      {
        foreach (CAttachment Attachment in this._Model.Attachments)
          yield return (INode) Attachment;
      }
      if (this._Model.HasParticleEmitters)
      {
        foreach (CParticleEmitter ParticleEmitter in this._Model.ParticleEmitters)
          yield return (INode) ParticleEmitter;
      }
      if (this._Model.HasParticleEmitters2)
      {
        foreach (CParticleEmitter2 ParticleEmitter2 in this._Model.ParticleEmitters2)
          yield return (INode) ParticleEmitter2;
      }
      if (this._Model.HasRibbonEmitters)
      {
        foreach (CRibbonEmitter RibbonEmitter in this._Model.RibbonEmitters)
          yield return (INode) RibbonEmitter;
      }
      if (this._Model.HasEvents)
      {
        foreach (CEvent Event in this._Model.Events)
          yield return (INode) Event;
      }
      if (this._Model.HasCollisionShapes)
      {
        foreach (CCollisionShape CollisionShape in this._Model.CollisionShapes)
          yield return (INode) CollisionShape;
      }
    }

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

    public CModel Model => this._Model;

    public int Count
    {
      get
      {
        int count = 0;
        if (this._Model.HasBones)
          count += this._Model.Bones.Count;
        if (this._Model.HasLights)
          count += this._Model.Lights.Count;
        if (this._Model.HasHelpers)
          count += this._Model.Helpers.Count;
        if (this._Model.HasAttachments)
          count += this._Model.Attachments.Count;
        if (this._Model.HasParticleEmitters)
          count += this._Model.ParticleEmitters.Count;
        if (this._Model.HasParticleEmitters2)
          count += this._Model.ParticleEmitters2.Count;
        if (this._Model.HasRibbonEmitters)
          count += this._Model.RibbonEmitters.Count;
        if (this._Model.HasEvents)
          count += this._Model.Events.Count;
        if (this._Model.HasCollisionShapes)
          count += this._Model.CollisionShapes.Count;
        return count;
      }
    }

    public bool IsReadOnly => false;

    public INode this[int Index]
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
  }
}
