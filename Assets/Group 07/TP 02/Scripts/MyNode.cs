using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MyLinkedList
{
    public class MyNode<T>
    {   
        public T Value;
        public MyNode<T> Next;
        public MyNode<T> Prev;
        public MyNode(T value)
        {
            Value = value;
            Next = null;
            Prev= null;
        }
        public override string ToString()
        {
                return Value.ToString();
        }
        public bool IsEquals(T value)
        {
            return EqualityComparer<T>.Default.Equals(Value, value);
        }
    }
}
