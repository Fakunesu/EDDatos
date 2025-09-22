using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using System;
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
            UnityEngine.Debug.Log(item.ToString());
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

        public void AddRange(T[] collection)
        {
            for (int i = 0; i < collection.Length; i++)
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

        public bool RemoveAt(int position)
        {
            for (int i = 0; i < count; i++)
            {
                if (i == position)
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

    public void BubbleSort(Comparison<T> comparison)
    {
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count - 1 - i; j++)
            {
                if (comparison (array[j], array[j+1])>0)
                {
                    var aux = array[j+1];
                    array[j+1] = array[j];
                    array[j] = aux;
                }
            }
        }
    }





    public void SelectionSort(Comparison<T> comparison)
    {
        
        for (int i = 0; i < count; i++)
        {
            var m = i;
            for (int j = m + 1; j < count; j++)
            {
                if (comparison(array[j], array[m]) == -1)  //array[j] < array[m]
                {
                    var aux = array[j];
                    array[j] = array[m];
                    array[m] = aux;
                }
            }
        }
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
