using BTNode;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.Rendering.DebugUI;



public class ABB_Tree<T> where T : IComparable<T>
{
    private BTNode<T> root;
    private int heigth=0;

    public void Insert(T value)
    {
        root = RecursiveInsert(root, value, (a, b) => a.CompareTo(b));
    }
  
    public BTNode<T> RecursiveInsert(BTNode<T> current, T value, Comparison<T> comparison)
    { 
        BTNode<T> node = new BTNode<T>(value);
  
        if (current == null)
        {
            return new BTNode<T>(value);
        }
        else
        {
            if (comparison (current.data, value)>0)
            {
                current.left= RecursiveInsert(current.left, value, comparison);
            }
            else if (comparison(current.data, value) < 0)
            {
                current.right = RecursiveInsert(current.right, value, comparison);
            }
        }
        return current;
    } 

    public int GetHeight(T value, BTNode<T> current, Comparison<T> comparison)
    {

        if (current == null)
        {
            heigth = 0;
            return 0;
        }
        else
        {
            if (comparison(current.data, value) == 0)
            {
                heigth++;
                Debug.Log(heigth);
                return heigth;
            }
            else if (comparison(current.data, value) > 0)
            {
                heigth++;
                return GetHeight(value, current.left, comparison);
            }
            else if (comparison(current.data, value) < 0)
            {
                heigth++;
                return GetHeight(value, current.right, comparison);
            }
            else
            {
                 throw new System.IndexOutOfRangeException();
            
            }

        }

    }

    public void GetBalanceFactor()
    {
        
    }
}



