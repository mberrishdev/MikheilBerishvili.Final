using System;

namespace MikheilBerishvili.Final.Domain.Primitives;

[Serializable]
public abstract class Entity<TId>
{
    public virtual TId Id { get; set; }
}