using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class MySetList<T> : MySet<T>
{
    private MyList<T> list;
    public override void Add(T value)
    {
        if (!Contains(value))
        {
            list.Add(value);
        }
    }
    public override void Remove(T value)
    {
        list.Remove(value);
    }
    public override void Clear()
    {
        list.Clear();
    }

    public override bool Contains(T value)
    {
        for(int i = 0; i<list.Count; i++)
        {
            if (Equals(list[i], value))
            { 
                return true;
            }

        }
        return false;
    }
    public override void Show()
    {
        Debug.Log(ToString());
    }

    public override string ToString()
    {
        return list.ToString();
    }
    public override int Cardinality()
    {
        return list.Count;
    }
    public override bool IsEmpty()
    {
        return list.IsEmpty();
    }
    public override MySet<T> Union(MySet<T> other)
    {
        MySetList<T> unionList = new MySetList<T>();

        for (int i = 0; i < list.Count; i++)
        {
            unionList.Add(list[i]);
        }

        MySetList<T> otherList = (MySetList<T>)other;
        for (int i = 0; i < otherList.list.Count; i++)
        {
            unionList.Add(otherList.list[i]);
        }

        return unionList;
    }
    public override MySet<T> Intersect(MySet<T> other)
    {
        MySetList<T> intersectList = new MySetList<T>();
        MySetList<T> otherList = (MySetList<T>)other;

        for (int i = 0; i < list.Count; i++)
        {
            if (otherList.Contains(list[i]))
                intersectList.Add(list[i]);
        }

        return intersectList;
    }
    public override MySet<T> Difference(MySet<T> other)
    {
        MySetList<T> differenceList = new MySetList<T>();
        MySetList<T> otherList = (MySetList<T>)other;

        for (int i = 0; i < list.Count; i++)
        {
            if (!otherList.Contains(list[i]))
                differenceList.Add(list[i]);
        }

        return differenceList;
    }

    public override T[] Elements()
    {
        T[] arrayResult = new T[list.Count];

        for (int i = 0;i < list.Count; i++)
        {
            arrayResult[i] = list[i];
        }
            return arrayResult;
    }
}
