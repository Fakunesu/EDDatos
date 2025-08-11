using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestSimpleList : MonoBehaviour
{
    public TMP_Text textoLista;
    public SimpleList<string> list = new SimpleList<string>();
    public SimpleListTestCaller caller;

    public void AddElement()
    {
        list.Add("Elemento " + list.Count);
        Update();
    }

    public void RemoveElement()
    {
        list.Remove("Elemento " + (list.Count - 1));
        Update();
    }

    public void ClearList()
    {
        list.Clear();
        Update();
    }

    void Start()
    {
        caller = GameObject.FindGameObjectWithTag("Text2").GetComponent<SimpleListTestCaller>();
        list.array[2] = "holaa";
    }

    private void Update()
    { 
        textoLista.text = list.ToString();
        caller.Hola();
        Debug.Log("exito");
    }
}

