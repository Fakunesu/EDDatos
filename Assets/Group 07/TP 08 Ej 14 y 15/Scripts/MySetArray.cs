using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySetArray<T> : MySet<T>
{
    public SimpleList<T> array;
    public override void Add(T value)
    {
        if (!Contains(value))
        {
            array.Add(value);
        }
    }     
    public override void Remove(T value)
    {
        array.Remove(value);
    }
    public override void Clear()
    {
        array.Clear();
    }
    public override bool Contains(T value)
    {
        for (int i = 0; i < array.Count; i++) 
        {
            if (Equals(array[i], value))
            {
                return true;
            }
        }
        return false;
    }
    public override void Show()
    {
        Debug.Log(array.ToString());
    }
    public override string ToString()
    {
        return array.ToString();
    }
    public override int Cardinality()
    {
        return array.Count;
    }
    public override bool IsEmpty()
    {
        if (array.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public override MySet<T> Union(MySet<T> other)
    {
        MySetArray<T> unionArray = new MySetArray<T>();

        for (int i = 0;i < array.Count; i++)
        {
            unionArray.Add(array[i]);
        }

        MySetArray<T> otherArray = new MySetArray<T>();
        for (int i = 0; i<otherArray.array.Count; i++)
        {
            unionArray.Add(otherArray.array[i]);
        }

        return unionArray;
    }
    public override MySet<T> Intersect(MySet<T> other)
    {
        MySetArray<T> intersectArray = new MySetArray<T>();
        MySetArray<T> otherArray = (MySetArray<T>)other;

        for (int i = 0; i < array.Count; i++)
            if (otherArray.Contains(array[i]))
                intersectArray.Add(array[i]);

        return intersectArray;
    }

    public override MySet<T> Difference(MySet<T> other)
    {
        MySetArray<T> differenceArray = new MySetArray<T>();
        MySetArray<T> otherArray = (MySetArray<T>)other;

        for (int i = 0; i < array.Count; i++)
            if (!otherArray.Contains(array[i]))
                differenceArray.Add(array[i]);

        return differenceArray;
    }

    public override T[] Elements()
    {
        T[] arrayResult = new T[array.Count];

        for (int i = 0; i < array.Count; i++)
        {
            arrayResult[i] = array[i];
        }
            return arrayResult;
    }
}
