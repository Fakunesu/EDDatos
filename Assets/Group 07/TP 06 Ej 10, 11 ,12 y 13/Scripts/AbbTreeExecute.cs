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
    public float spaceX = 1.5f;
    public float spaceY = -2f;
    public float multiply = -1.2f;
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_Text outputText;
    private MyList<GameObject> nodeList = new MyList<GameObject>();
    [SerializeField] float horizontalMove;

    void Start()
    {
        startPosition = transform.position;
        tree = new ABB_Tree<int>();
        foreach (int n in numbers)
            tree.Insert(n);

        // punto inicial centrado en el Canvas
        
        DrawTree(tree.Root, startPosition);


        // Draw Lines

    }


    void DrawTree(BTNode<int> node, Vector2 anchoredPos, int level = 0, float offsetX = 0)
    {
        if (node == null) return;

        // Si es la raíz, definimos el offset inicial
        if (level == 0)
        {
            int totalHeight = tree.GetHeight(tree.Root);
            offsetX = Mathf.Pow(2, totalHeight - 1) * 1.12f; // 60 píxeles base por nivel
        }

        // Crear el nodo visual dentro del Canvas
        GameObject newNode = Instantiate(prefabNode, transform);
        nodeList.Add(newNode);

        newNode.transform.position = new Vector3(anchoredPos.x, anchoredPos.y, 0);

        // Setear texto
        newNode.GetComponentInChildren<TextMeshProUGUI>().text = node.data.ToString();

        // Reducir el offset horizontal a medida que bajamos
        float childOffsetX = offsetX / 1f;
        float offsetY = -1.112f; // distancia vertical entre niveles

        // Hijo izquierdo
        if (node.left != null)
        {
            Vector2 leftPos = new Vector2(anchoredPos.x - childOffsetX, anchoredPos.y + offsetY);
            DrawTree(node.left, leftPos, level + 1, childOffsetX);
        }

        // Hijo derecho
        if (node.right != null)
        {
            Vector2 rightPos = new Vector2(anchoredPos.x + childOffsetX, anchoredPos.y + offsetY);
            DrawTree(node.right, rightPos, level + 1, childOffsetX);
        }
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
