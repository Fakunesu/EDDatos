using MyLinkedList;
using System.Collections;
using System.Collections.Generic;

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
    public bool IsEmpty()
    {
        if(count == 0)
            return true;
        else return false;
    }
}
