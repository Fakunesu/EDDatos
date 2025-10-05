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

  //  public void Insert(T value)
  //  {
  //      root = RecursiveInsert(root, value);
  //  }
  //
  //  public BTNode<T> RecursiveInsert(BTNode<T> current, T value, Comparison<T> comparison)
  //  { 
  //      BTNode<T> node = new BTNode<T>(value);
  //
  //      if (current == null)
  //      {
  //          return new BTNode<T>(value);
  //      }
  //      else
  //      {
  //          if (comparison (current.data, value)>0)
  //          {
  //              current.left= RecursiveInsert(current.left, value, comparison);
  //          }
  //          else if (comparison(current.data, value) < 0)
  //          {
  //              current.right = RecursiveInsert(current.right, value, comparison);
  //          }
  //      }
  //  } 
}



