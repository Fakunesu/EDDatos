using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class TestSimpleList : MonoBehaviour
{
    private TMP_Text textoLista;
    public SimpleList<string> list = new SimpleList<string>();
    private SimpleListTestCaller caller;

    public void AddElement()
    {
        //TODO: hacer que agregue lo que esta en el InputField
        list.Add("Elemento " + list.Count);
        UpdateText();
    }

    public void RemoveElement()
    {
        //TODO: hacer que remueva lo que esta en el InputField
        list.Remove("Elemento " + (list.Count - 1));
        UpdateText();
    }

    public void ClearList()
    {
        list.Clear();
        UpdateText();
    }

    private void Start()
    {
        //caller = GameObject.FindGameObjectWithTag("Text2").GetComponent<SimpleListTestCaller>();
        textoLista = GameObject.FindGameObjectWithTag("Text2").GetComponent<TMP_Text>();
        list.array[2] = "holaa";
    }

    private void Update()
    {
        
        // caller.Hola();
        // Debug.Log(caller);
    }

    private void UpdateText()
    {
        textoLista.text = list.ToString();
    }
}

