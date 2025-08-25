using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MyStack<T>
{
 public int count {  get; private set; }
    private T[] array;

    public void Push (T item)
    {
        if (count == array.Length)
        {
            T[] newArray = new T[array.Length * 2];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            array = newArray;
        }

        array[count] = item;
        count++;

    }

    public void Pop(T item)
    {

    }

    public void peek(T item)
    { 
    
    
    }

    public void clear()
    {

    }
}
