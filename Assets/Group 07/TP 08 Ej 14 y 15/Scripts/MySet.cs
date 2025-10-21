using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MySet<T>
{
    public abstract void Add(T value);
    public abstract void Remove(T value);
    public abstract void Clear();
    public abstract bool Contains(T value);
    public abstract void Show();
    public abstract string ToString();
    public abstract int Cardinality();
    public abstract bool IsEmpty();
    public abstract MySet<T> Union(MySet<T> other);
    public abstract MySet<T> Intersect(MySet<T> other);
    public abstract MySet<T> Difference(MySet<T> other);
    public abstract T[] Elements();
}
