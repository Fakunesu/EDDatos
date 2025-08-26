using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyQueue<T>
{
    public int count { get; private set; }
    SimpleList<T> queue;

    public MyQueue()
    {
        queue = new SimpleList<T>();
    }
    public void Enqueue(T item)
    {
        queue.Add(item);
        count++;

    }

    public T Dequeue()
    {
        if (count == 0) 
            throw new InvalidOperationException("La cola está vacía");
        T itemToReturn = queue[0];
        queue.RemoveAt(0);
        count--;
        return itemToReturn;

    }

    public T Peek()
    {
        if (count == 0) 
            throw new InvalidOperationException("La cola está vacía");
        T itemToReturn = queue[0];
        return itemToReturn;

    }

    public void Clear()
    {
        queue = new SimpleList<T>();
        count = 0;
    }

    public T[] ToArray()
    {
        T[] arrayCopy = new T[queue.Count];
        for (int i = 0; i < queue.Count; i++)
        {
            arrayCopy[i] = queue[i];
        }
        return arrayCopy;
    }

    public override string ToString()
    {
        return queue.ToString();
    }

    public bool TryDequeue(out T item)
    {
        if (queue.Count == 0)
        {
            item = default(T);
            return false;
        }
        else
        {
            item = queue[0];
            queue.RemoveAt(0);
            count--;
            Debug.Log($"{item} Dequeued.");
            return true;
        }
    }

     public bool TryPeek(out T item)
     {
         if (queue.Count == 0)
         {
             item = default(T);
             return false;
         }
         else
         {
             item = queue[0];
             return true;
         }
     }

}
