using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class SimpleList<T> : ISimpleList<T>
{
    public T[] array;

    private int count;

    public SimpleList()
    {
        array = new T[10];
        count = 0;
    }


    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
                throw new System.IndexOutOfRangeException();
            return array[index];

        }
        set
        {
            if (index < 0 || index >= count)
                throw new System.IndexOutOfRangeException();
            array[index] = value;
        }
    }

    public int Count => count;

    public void Add(T item)
    {
        if (count >= array.Length)
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

    public void AddRange(T[] collection)
    {
        for (int i = 0; i <= collection.Length; i++)
        {
            Add(collection[i]);
        }
    }

    public void Clear()
    {
        array = new T[10];
        count = 0;
    }

    public bool Remove(T item)
    {
        for (int i = 0; i < count; i++)
        {
            if (Equals(array[i], item))
            {
             
                for (int j = i; j < count - 1; j++)
                {
                    array[j] = array[j + 1];
                }

                count--;
                array[count] = default;
                return true;
            }
        }
        return false;
    }

    public override string ToString()
    {
        string resultado = "";

        for (int i = 0; i < count; i++)
        {
            resultado += array[i].ToString();

            if (i < count - 1)
            {
                resultado += ", ";
            }
        }

        return resultado;
    }
}