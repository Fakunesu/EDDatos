using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TP13_AVL_TraversalsUI : MonoBehaviour
{
    [Header("Salida de texto")]
    [SerializeField] private TMP_Text outputText;
    [SerializeField] private TMP_Text scoreboardText;

    [Header("Input para agregar valores (opcional)")]
    [SerializeField] private TMP_InputField valueInput;

    [Header("Configuración inicial")]
    [SerializeField] private int initialNodes = 15;
    [SerializeField] private int randomMin = 0;
    [SerializeField] private int randomMax = 100;

    int scoreBoardCounter;

    private AVL_Tree<int> tree = new AVL_Tree<int>();

    private void Start()
    {
        scoreBoardCounter = 0;
        InitTree();
        ShowInOrder(); 
    }


    private void InitTree()
    {
        System.Random rnd = new System.Random();

        for (int i = 0; i < initialNodes; i++)
        {
            int value = rnd.Next(randomMin, randomMax + 1);
            tree.Insert(value);
        }
    }

    private bool HasTree()
    {
        if (tree == null || tree.Root == null)
        {
            if (outputText != null)
                outputText.text = "Árbol vacío.";
            return false;
        }
        return true;
    }


    public void ShowPreOrder()
    {
        if (!HasTree()) return;

        List<int> list = new List<int>();
        PreOrder(tree.Root, list);

        if (outputText != null)
            outputText.text = "PreOrder:\n" + string.Join(" ", list);
    }

    public void ShowInOrder()
    {
        if (!HasTree()) return;

        List<int> list = new List<int>();
        InOrder(tree.Root, list);

        if (outputText != null)
            outputText.text = "InOrder:\n" + string.Join(" ", list);
    }

    public void ShowPostOrder()
    {
        if (!HasTree()) return;

        List<int> list = new List<int>();
        PostOrder(tree.Root, list);

        if (outputText != null)
            outputText.text = "PostOrder:\n" + string.Join(" ", list);
    }

    public void ShowLevelOrder()
    {
        if (!HasTree()) return;

        List<int> list = new List<int>();
        LevelOrder(tree.Root, list);

        if (outputText != null)
            outputText.text = "LevelOrder:\n" + string.Join(" ", list);
    }

    public void ClearTree()
    {
        tree = new AVL_Tree<int>();

        if (outputText != null)
            outputText.text = "Árbol vacío.";
    }
    public void AddValueFromInput()
    {
        if (valueInput == null || string.IsNullOrWhiteSpace(valueInput.text))
            return;

        if (int.TryParse(valueInput.text, out int value))
        {
            tree.Insert(value);
            ShowInOrder(); 
            valueInput.text = "";
        }
        else
        {
            if (outputText != null)
                outputText.text = "Valor inválido. Ingresá un entero.";
        }
    }



    private void PreOrder(BTNode<int> node, List<int> result)
    {
        if (node == null) return;

        result.Add(node.data);
        PreOrder(node.left, result);
        PreOrder(node.right, result);
    }

    private void InOrder(BTNode<int> node, List<int> result)
    {
        if (node == null) return;

        InOrder(node.left, result);
        result.Add(node.data);
        InOrder(node.right, result);
    }

    private void PostOrder(BTNode<int> node, List<int> result)
    {
        if (node == null) return;

        PostOrder(node.left, result);
        PostOrder(node.right, result);
        result.Add(node.data);
    }

    private void LevelOrder(BTNode<int> root, List<int> result)
    {
        if (root == null) return;

        Queue<BTNode<int>> q = new Queue<BTNode<int>>();
        q.Enqueue(root);

        while (q.Count > 0)
        {
            var current = q.Dequeue();
            result.Add(current.data);

            if (current.left != null) q.Enqueue(current.left);
            if (current.right != null) q.Enqueue(current.right);
        }
    }
    public void ClearScoreboard()
    {
        scoreBoardCounter = 0;
        if (scoreboardText != null)
            scoreboardText.text = "";
    }

    public void ScoreBoardAddTree()
    {
        if (outputText == null || scoreboardText == null)
            return;

        string current = outputText.text.Trim();
        if (string.IsNullOrEmpty(current))
            return;

        // Opcional: si ya hay cosas, separador
        if (!string.IsNullOrEmpty(scoreboardText.text))
        {
            scoreBoardCounter++;
            scoreboardText.text += $" Arbol Nº{scoreBoardCounter}: {current}";
            scoreboardText.text += "\n";
        }

    }
}
