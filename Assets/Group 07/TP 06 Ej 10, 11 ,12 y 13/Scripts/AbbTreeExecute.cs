using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AbbTreeExecute : MonoBehaviour
{
    private ABB_Tree<int> tree;
    private int[] numbers = { 20, 10, 1, 26, 35, 40, 18, 12, 15, 14, 30, 23 };//
    //private int[] numbers = { 50, 30, 70 };
    [SerializeField] private GameObject prefabNode;
    public Vector2 startPosition;
    public float spaceX = 1f;
    public float spaceY = -1.5f;
    public float multiply = -1.5f;
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_Text outputText;
    private MyList<GameObject> nodeList = new MyList<GameObject>();
    [SerializeField] float horizontalMove;

    void Start()
    {
        startPosition = transform.position;
        // Input
        tree = new ABB_Tree<int>();
        for (int i = 0; i < numbers.Length; i++) 
            tree.Insert(numbers[i]);
            

        // Draw
        DrawTree(tree.Root, startPosition);


        // Draw Lines

    }


    void DrawTree(BTNode<int> node, Vector2 position)
    {
        if (node == null) return;

        float height = tree.GetHeight(node);
        float limit = height;

        for (int i = 1; i < limit; i++)
        {
            height += i * multiply;
        }

        GameObject newNode = Instantiate(prefabNode, position, Quaternion.identity);
        nodeList.Add(newNode);
        newNode.GetComponentInChildren<TextMeshProUGUI>().text = node.data.ToString();

        if (node.left != null)
            DrawTree(node.left, position + new Vector2(-spaceX - height, spaceY));

        if (node.right != null)
            DrawTree(node.right, position + new Vector2(spaceX + height, spaceY));
    }

    public void ClearTree()
    {
        tree = new ABB_Tree<int>();
        for(int i=0; i<nodeList.Count; i++)
        {
            Destroy(nodeList[i].gameObject);
        }
            nodeList.Clear();
    }

    private void UpdateTree()
    {
        for (int i = 0; i < nodeList.Count; i++)
        {
            Destroy(nodeList[i].gameObject);
        }
        nodeList.Clear();
    }

    public void InputNewNode()
    {
        string stringNode = inputField.text;
        int nodeNumber;
        
        if (int.TryParse(stringNode, out nodeNumber))
        {
            
            tree.Insert(nodeNumber);
            UpdateTree();
            DrawTree(tree.Root, startPosition);
            outputText.text = "";
        }
        else
        {
            outputText.text = "Ingrese un numero valido porfavor";
        }
        
       
    }


}
