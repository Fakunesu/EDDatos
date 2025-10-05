using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTNode
{
    public class BTNode<T>
    {
        public T data;
        public BTNode<T> left;
        public BTNode<T> right;

        public BTNode(T data)
        {
            this.data = data;
            left = null;
            right = null;
        }
    }
}
