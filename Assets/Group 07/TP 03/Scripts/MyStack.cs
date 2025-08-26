using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class MyStack<T>
{
    public int count { get; private set; }
    private SimpleList<T> array;

    public MyStack()
    {
        array = new SimpleList<T>();
    }

    public void Push(T item)
    {
        array.Add(item);
        count++;
    }

    public T Pop()
    {
        if (count == 0)
            throw new InvalidOperationException("La pila está vacía");
        T itemToReturn = array[count - 1];
        array.RemoveAt(count - 1);
        count--;
        return itemToReturn;

    }

    public T Peek()
    {
        if (count == 0)
            throw new InvalidOperationException("La pila está vacía");
        T itemToReturn = array[count - 1];
        return itemToReturn;

    }

    public void Clear()
    {
        array = new SimpleList<T>();
        count = 0;
    }

    public T[] ToArray()
    {
        T[] arrayCopy= new T[count];
        for (int i = 0; i < count; i++)
        {
            arrayCopy[i] = array[i];
        }
        return arrayCopy;
    }

    public override string ToString()
    {
        return array.ToString();
    }

    public bool TryPop(out T item)
    {
        if (array.Count == 0)
        {
            item = default(T);
            return false;
        }
        else
        {
            item = array[count - 1];
            array.RemoveAt(count - 1);
            count--;
            //Debug.Log($"{item} Popped.");
            return true;
        }
    }

   public bool TryPeek(out T item)
    {
        if (count == 0)
        {
            item = default(T);
            return false;
        }
        else
        {
            item = array[count - 1];
            return true;
        }
    }

}
