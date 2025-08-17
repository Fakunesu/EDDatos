using MyLinkedList;
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
        for (int i = 0; i <= Count; i++)
        {
            if (valueRemoved == true)
            {
                valueRemoved.Prev = valueRemoved.Next.Prev;
            }
            else
            {
                return false;
            }
        }
    }
    public bool IsEmpty()
    {
        if (count == 0)
            return true;
        else return false;
    }
}
