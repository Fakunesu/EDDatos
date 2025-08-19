using MyLinkedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

public class MyList<T>
{
    public int count=0;
    private MyNode<T> root;
    private MyNode<T> tail;
    public T value;

    public MyNode<T> node;
    public MyList()
    {
        
        this.root = null;
        this.tail = null;
        Count = count;
        
    }

    public int Count { get; private set; }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
                throw new System.IndexOutOfRangeException();
            MyNode<T> actual=root;
            for(int i = 0; i < index; i++)
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
            for(int i = 0;i < index; i++)
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
            var newNode=new MyNode<T>(value);
            root = newNode;
            tail = newNode;
            newNode.Prev = null;
            newNode.Next = null;
            count++;
            Count = count;
        }
        else if(IsEmpty()==false)
        {
            var newNode = new MyNode<T>(value);
            newNode.Prev = tail;
            tail.Next = newNode;
            tail = newNode;
            newNode.Next = null;
            count++;
            Count = count;
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
            Count = ListValues.Count;
        }
        else
        {
            tail.Next = ListValues.root;
            ListValues.root.Prev = tail;
            tail = ListValues.tail;
            Count += ListValues.Count;
        }

        ListValues.root = null;
        ListValues.tail = null;
        ListValues.count = 0;
    }

    public void AddRange(T[] collectionValues)
    {
        for (int i = 0; i <= collectionValues.Length; i++)
        {
            Add(collectionValues[i]);
        }
    }

    public bool Remove(T valueRemoved)
    {
        if (IsEmpty() == false)
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
                    current.Prev.Next=current.Next;
                    current.Next.Prev = current.Prev;
                }

                Count--;

                return true;

            }

            current = current.Next;
        }

        return false;
    }

    public void RemoveAt(int index)
    { 
        if (index < 0 || index > Count)
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
        else if (index == Count)
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
            for (int i = 0; i < Count; i++)
            {
                current = current.Next;
            }

            current.Prev.Next=current.Next;
            current.Next.Prev=current.Prev;
        }

        count--;

    }

    public void insert(int index, T value)
    {
        
        if (index < 0 || index > Count){
            throw new System.IndexOutOfRangeException();
        }

        else if (index == 0)
        {
            MyNode<T> newNode = new MyNode<T>(value);
            root.Prev = newNode;
            newNode.Next = root;
            newNode.Prev = null;
            root = newNode;
            count++;
            Count = count;
        }
        else if (index == Count)
        {
            Add(value);
            return;


        }
        else
        {
            MyNode<T> newNode = new MyNode<T>(value);

        }

    }
    public bool IsEmpty()
    {
        if (count == 0)
            return true;
        else return false;
    }
}
