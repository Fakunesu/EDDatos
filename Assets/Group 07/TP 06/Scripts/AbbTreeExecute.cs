using UnityEngine;
using UnityEngine.UIElements;

public class AbbTreeExecute : MonoBehaviour
{
    private ABB_Tree<int> tree;
    private int[] numbers = { 50, 40, 60, 39, 41, 59, 61 };
    [SerializeField] private NodeVisual prefabNode;
    MyList<NodeVisual> nodes = new MyList<NodeVisual>();

    void Start()
    {
        // Input
        tree = new ABB_Tree<int>();
        for (int i = 0; i < numbers.Length; i++) 
            tree.Insert(numbers[i]);


        // Draw
        CreateNode(tree.Root);


        // Draw Lines

    }

    void CreateNode(BTNode.BTNode<int> node)
    {
        NodeVisual current = Instantiate(prefabNode);
        nodes.Add(current);
        
        bool hasLeft = node.left != null;
        bool hasRight = node.right != null;

     
        current.SetNode(node.ToString(), hasLeft, hasRight);



        int height=tree.GetHeight(node);
        
        // Setear Y en base al Nivel
        // Setear X en base a -1 -1 o 1 -1

        if (node.left != null)
            CreateNode(node.left);
        if (node.right != null)
            CreateNode(node.right);
    }
}
