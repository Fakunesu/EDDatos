using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class TestSimpleList : MonoBehaviour
{
    private TMP_Text textoLista;
    public SimpleList<string> list = new SimpleList<string>();
    private SimpleListTestCaller caller;
    [SerializeField] private TMP_InputField inputField;

    public void AddElement()
    {
        //TODO: hacer que agregue lo que esta en el InputField
        list.Add(inputField.text);
        UpdateText();
    }

    public void RemoveElement()
    {
        //TODO: hacer que remueva lo que esta en el InputField
        list.Remove(inputField.text);
        UpdateText();
    }

    public void AddRangeElement()
    {
        string[] range = inputField.text.Split(','); 
        list.AddRange(range);
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

