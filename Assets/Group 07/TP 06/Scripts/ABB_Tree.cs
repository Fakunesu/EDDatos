using System;

public class ABB_Tree<T> where T : IComparable<T>
{
    private BTNode<T> root;
    private int heigth = 0;

    public BTNode<T> Root => root;

    public void Insert(T value)
    {
        root = RecursiveInsert(root, value, (a, b) => a.CompareTo(b));
    }

    public BTNode<T> RecursiveInsert(BTNode<T> current, T value, Comparison<T> comparison)
    {
        BTNode<T> nodeIndex = new BTNode<T>(value);

        if (current == null)
        {
            return new BTNode<T>(value);
        }
        else
        {
            if (comparison(value, current.data) < 0)
            {
                current.left = RecursiveInsert(current.left, value, comparison);
            }
            else if (comparison(value, current.data) > 0)
            {
                current.right = RecursiveInsert(current.right, value, comparison);
            }
        }
        return current;
    }

    //  public int GetHeight(T value, BTNode<T> current, Comparison<T> comparison)
    //  {
    //
    //      if (current == null)
    //      {
    //          heigth = 0;
    //          return 0;
    //      }
    //      else
    //      {
    //          if (comparison(current.data, value) == 0)
    //          {
    //              heigth++;
    //              Debug.Log(heigth);
    //              return heigth;
    //          }
    //          else if (comparison(current.data, value) > 0)
    //          {
    //              heigth++;
    //              return GetHeight(value, current.left, comparison);
    //          }
    //          else if (comparison(current.data, value) < 0)
    //          {
    //              heigth++;
    //              return GetHeight(value, current.right, comparison);
    //          }
    //          else
    //          {
    //               throw new System.IndexOutOfRangeException();
    //          
    //          }
    //
    //      }
    //
    //  }

    public int GetHeight(BTNode<T> node)
    {
        if (node == null)
            return 0;

        int leftHeight = GetHeight(node.left);
        int rightHeight = GetHeight(node.right);

        return Math.Max(leftHeight, rightHeight) + 1;
    }

    public int GetNode(T value)
    {
        var node = Find(root, value, (a, b) => a.CompareTo(b));
        return GetHeight(node);
    }

    private BTNode<T> Find(BTNode<T> current, T value, Comparison<T> comparison)
    {
        if (current == null)
            return null;

        if (comparison(value, current.data) == 0)
            return current;

        if (comparison(value, current.data) < 0)
            return Find(current.left, value, comparison);

        return Find(current.right, value, comparison);
    }

    public int GetBalanceFactor(BTNode<T> node)
    {
        if (node == null)
            return 0;
        else
            return GetHeight(node.left) - GetHeight(node.right);
    }


    public void InOrder(BTNode<T> node)
    {
        if (node == null) return;

        InOrder(node.left);
        node.Execute();
        InOrder(node.right);
    }


    public void PreOrder(BTNode<T> node)
    {
        if (node == null) return;
        node.Execute();
        PreOrder(node.left);
        PreOrder(node.right);
    }


    public void PostOrder(BTNode<T> node)
    {
        if (node == null) return;
        PostOrder(node.left);
        PostOrder(node.right);
        node.Execute();
    }


    public void LevelOrder()
    {
        if (root == null) return;

        MyQueue<BTNode<T>> queue = new MyQueue<BTNode<T>>();
        queue.Enqueue(root);

        while (queue.count > 0)
        {
            BTNode<T> current = queue.Dequeue();
            current.Execute();

            if (current.left != null)
                queue.Enqueue(current.left);
            if (current.right != null)
                queue.Enqueue(current.right);
        }
    }
}