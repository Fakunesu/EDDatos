using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class TestSimpleList : MonoBehaviour
{
    private TMP_Text textoLista;
    private TMP_Text textoCount;
    public SimpleList<string> list = new SimpleList<string>();
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
        textoLista = GameObject.FindGameObjectWithTag("ArrayText").GetComponent<TMP_Text>();
        textoCount = GameObject.FindGameObjectWithTag("CountText").GetComponent <TMP_Text>();
        list.array[2] = "holaa";
    }

    private void Update()
    {

    }

    private void UpdateText()
    {
        textoLista.text = list.ToString();
        textoCount.text = list.Count.ToString();
    }
}

