using MyLinkedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;

public class MyList<T>
{
    private int count = 0;
    private MyNode<T> root;
    private MyNode<T> tail;
   // public T value;

    public MyNode<T> node;
    public MyList()
    {

        this.root = null;
        this.tail = null;
        //Count = count;

    }
    
    //Opcion 1: get, private set, modificas Count dentro del script
    //Opcion 2: get return count, sin set, y modificas count dentro del script
    public int Count { get { return count; } } //Esto seria la opcion 2

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
                throw new System.IndexOutOfRangeException();
            MyNode<T> actual = root;
            for (int i = 0; i < index; i++)
            {
                actual = actual.Next;
            }
            return actual.Value;

        }
        set
        {
            if (index < 0 || index >= count)
                throw new System.IndexOutOfRangeException();
            MyNode<T> actual = root;
            for (int i = 0; i < index; i++)
            {
                actual = actual.Next;
            }
            actual.Value = value;
        }
    }

    public void Add(T value)
    {
        if (IsEmpty() == true)
        {
            var newNode = new MyNode<T>(value);
            root = newNode;
            tail = newNode;
            newNode.Prev = null;
            newNode.Next = null;
            count++;
        }
        else
        {
            var newNode = new MyNode<T>(value);
            newNode.Prev = tail;
            tail.Next = newNode;
            tail = newNode;
            newNode.Next = null;
            count++;
        }
    }

    public void AddRange(MyList<T> ListValues)
    {
        if (ListValues.IsEmpty() == true)
        {
            return;
        }
        else if (IsEmpty() == true)
        {
            root = ListValues.root;
            tail = ListValues.tail;

        }
        else
        {
            tail.Next = ListValues.root;
            ListValues.root.Prev = tail;
            tail = ListValues.tail;
        }

        count += ListValues.count;
        ListValues.root = null;
        ListValues.tail = null;
        ListValues.count = 0;
    }

    public void AddRange(T[] collectionValues)
    {
        for (int i = 0; i < collectionValues.Length; i++)
        {
            Add(collectionValues[i]);
        }
    }

    public bool Remove(T valueRemoved)
    {
        if (IsEmpty())
        {
            return false;
        }
        MyNode<T> current = root;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, valueRemoved))
            {
                if (current == root)
                {
                    root = current.Next;
                    if (root != null)
                    {
                        root.Prev = null;
                    }
                }
                else if (current == tail)
                {
                    tail = current.Prev;
                    if (tail != null)
                    {
                        tail.Next = null;
                    }
                }
                else
                {
                    current.Prev.Next = current.Next;
                    current.Next.Prev = current.Prev;
                }

                count--;
                return true;

            }

            current = current.Next;
        }

        return false;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new System.IndexOutOfRangeException();
        }

        if (index == 0)
        {
            root = root.Next;
            if (root != null)
            {
                root.Prev = null;
            }
            else
            {
                tail = null;
            }

        }
        else if (index == Count - 1)
        {
            tail = tail.Prev;
            if (tail != null)
            {
                tail.Next = null;
            }
            else
            {
                root = null;
            }
        }
        else
        {
            MyNode<T> current = root;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            current.Prev.Next = current.Next;
            current.Next.Prev = current.Prev;
        }

        count--;

    }

    public void Insert(int index, T value)
    {
        if (index < 0 || index > Count)
            throw new System.IndexOutOfRangeException();

        MyNode<T> newNode = new MyNode<T>(value);

        if (index == 0)
        {

            if (IsEmpty() == true)
            {
                tail = newNode;
                root = newNode;
            }
            else
            {
                root.Prev = newNode;
                newNode.Next = root;
                newNode.Prev = null;
                root = newNode;

            }
        }
        else if (index == Count)
        {
            Add(value);
            return;
        }
        else
        {
            MyNode<T> current = root;
            for (int i = 0; i < index; ++i)
            {
                current = current.Next;
            }
            newNode.Next = current;
            newNode.Prev = current.Prev;
            current.Prev.Next = newNode;
            current.Prev = newNode;
        }
        count++;
    }
    public bool IsEmpty()
    {
        if (count == 0)
            return true;
        else return false;
    }

    public void Clear()
    {
        MyNode<T> current = root;

        while (current != null)
        {

            MyNode<T> next = current.Next;
            current.Next = null;
            current.Prev = null;
            current = next;
        }

        root = null;
        tail = null;
        count = 0;
    }

    public void BubbleSort(Comparison<T> comparison)
    {
        for (int i=0; i<Count -1; i++)
        {
            MyNode<T> current = root;
            MyNode<T> next = root.Next;

            for (int j= 0; j< Count -i -1; j++)
            {
                if (comparison(current.Value, next.Value)>0)
                {
                    T aux = current.Value;
                    current.Value = next.Value;
                    next.Value = aux;
                }

                current = next;
                next = next.Next;
            }
        }
    }

  //    public void SelectionSort(Comparison<T> comparison)
  //    {
  //        for (int i = 0; i < Count - 1; i++)
  //        {
  //            MyNode<T> min = this.root;
  //            for (int k=0; k < i; k++)
  //            {
  //                min = min.Next;
  //            }
  //
  //            MyNode<T> current = min;
  //
  //            for (int j=i +1; j<Count; i++)
  //            {
  //                MyNode<T> runner= this.root;
  //
  //                for (int k= 0; k <j; k++)
  //                {
  //                    runner = runner.Next;
  //                }
  //                if (comparison(runner.Value, min.Value)<0)
  //                {
  //                    min = runner;
  //                }
  //            }
  //
  //            if (min != current)
  //            {
  //                T aux = current.Value;
  //                current.Value= min.Value;
  //                min.Value = aux;
  //            }
  //        }
  //    }

    public void SelectionSort(Comparison<T> comparison)
    {
        if (count < 2 || comparison == null)
            return;

       
        MyNode<T> start = root;

        while (start != null)
        {
            
            MyNode<T> min = start;

           
            MyNode<T> runner = start.Next;
            while (runner != null)
            {
                if (comparison(runner.Value, min.Value) < 0)
                {
                    min = runner;
                }
                runner = runner.Next;
            }

            
            if (min!=start)
            {
                T temp = start.Value;
                start.Value = min.Value;
                min.Value = temp;
            }

            
            start = start.Next;
        }
    }

    public override string ToString()
    {
        if (IsEmpty())
        {
            return "[Vacio]";
        }
        else
        {
            MyNode<T> current = root;
            string result = "[";

            while (current != null)
            {
                result += current.Value.ToString();

                if (current.Next != null)
                {
                    result += ", ";
                }
                current = current.Next;
            }

            result += "]";

            return result;
        }
    }
}