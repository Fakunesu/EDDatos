using System;
using TMPro;
using UnityEngine;

public class AbbTreeExecute : MonoBehaviour
{
    private ABB_Tree<int> tree;

    private int[] numbers = { 20, 10, 1, 26, 35, 40, 18, 12, 15, 14, 30, 23 };

    [SerializeField] private GameObject prefabNode;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text outputText;

    [Header("Layout")]
    public Vector2 startPosition;
    public float spaceX = 40f;   
    public float spaceY = -40f; 

    private MyList<GameObject> nodeList = new MyList<GameObject>();

    void Start()
    {
        startPosition = transform.position;

        tree = new ABB_Tree<int>();

        foreach (int n in numbers)
            tree.Insert(n);

        DrawTree();
    }

    public void DrawTree()
    {
        UpdateTree();

        if (tree.Root == null)
            return;

        int totalNodes = tree.CountNodes();
        int index = 0;
        float totalWidth = (totalNodes - 1) * spaceX;

        tree.InOrderWithDepth((node, depth) =>
        {
            float x = startPosition.x - totalWidth / 2f + index * spaceX;
            float y = startPosition.y + depth * spaceY;

            GameObject newNode = Instantiate(prefabNode, transform);
            newNode.transform.position = new Vector2(x, y);
            newNode.GetComponentInChildren<TextMeshProUGUI>().text = node.data.ToString();

            nodeList.Add(newNode);
            index++;
        });
    }

    public void ClearTree()
    {
        tree = new ABB_Tree<int>();
        UpdateTree();
        outputText.text = "";
    }

    private void UpdateTree()
    {
        for (int i = 0; i < nodeList.Count; i++)
        {
            if (nodeList[i] != null)
                Destroy(nodeList[i].gameObject);
        }

        nodeList.Clear();
    }

    public void InputNewNode()
    {
        string stringNode = inputField.text;

        if (int.TryParse(stringNode, out int nodeNumber))
        {
            tree.Insert(nodeNumber);
            outputText.text = "";
            DrawTree(); 
        }
        else
        {
            outputText.text = "INGRESE UN NUEMERO VALIDO, PORFAVOR";
        }
    }



}

