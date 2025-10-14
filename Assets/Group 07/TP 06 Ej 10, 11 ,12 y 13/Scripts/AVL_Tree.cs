using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AVL_Tree<T> : ABB_Tree<T> where T : IComparable<T>
{

    public new void Insert(T value)
    {
        root = InsertAndBalance(root, value);
    }

    private BTNode<T> InsertAndBalance(BTNode<T> node, T value)
    {

        if (node == null)
            return new BTNode<T>(value);

        if (value.CompareTo(node.data) < 0)
        {
            node.left = InsertAndBalance(node.left, value);
        }
        else if (value.CompareTo(node.data) > 0)
        {
            node.right = InsertAndBalance(node.right, value);
        }
        else
        {
            return node; 
        }

       
        int balance = GetBalanceFactor(node);

        //Izquierda-Izquierda
        if (balance > 1 && value.CompareTo(node.left.data) < 0)
        {
            return RotateRight(node);
        }

        //Derecha-Derecha
        if (balance < -1 && value.CompareTo(node.right.data) > 0)
        {
           return RotateLeft(node);
        }

        //Izquierda-Derecha
        if (balance > 1 && value.CompareTo(node.left.data) > 0)
        {
            node.left = RotateLeft(node.left);
            return RotateRight(node);
        }

        //Derecha-Izquierda
        if (balance < -1 && value.CompareTo(node.right.data) < 0)
        {
            node.right = RotateRight(node.right);
            return RotateLeft(node);
        }

        return node;
    }


    private BTNode<T> RotateRight(BTNode<T> x)
    {
        BTNode<T> y = x.left;
        BTNode<T> T2 = y.right;

        y.right = x;
        x.left = T2;

        return y;
    }

    private BTNode<T> RotateLeft(BTNode<T> x)
    {
        BTNode<T> y = x.right;
        BTNode<T> T2 = y.left;

        y.left = x;
        x.right = T2;

        return y;
    }
}
