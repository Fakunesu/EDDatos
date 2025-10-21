using UnityEngine;

public abstract class MySet<T>
{
    public abstract T[] Elements { get; }

    public override string ToString() => string.Join(", ", Elements);
    public virtual bool IsEmpty() => Elements.Length == 0;
    public virtual void Show() { Debug.Log(ToString()); }

    public abstract void Add(T value);
    public abstract void Remove(T value);
    public abstract void Clear();
    public abstract bool Contains(T value);
    public abstract int Cardinality();
    public abstract MySet<T> Union(MySet<T> other);
    public abstract MySet<T> Intersect(MySet<T> other);
    public abstract MySet<T> Difference(MySet<T> other);
}
