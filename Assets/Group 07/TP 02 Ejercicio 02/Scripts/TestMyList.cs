using System.Linq;
using TMPro;
using UnityEngine;



public class TestMyList : MonoBehaviour
{
    private TMP_Text textoLista;
    private TMP_Text textoCount;
    private TMP_Text textoError;
    public MyList<string> list = new MyList<string>();
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
    public void RemoveAtElement()
    {
        string userInput = inputField.text;
        if (int.TryParse(userInput, out int result))
        {
            list.RemoveAt(result);
           UpdateText();
        }
        else
        {
            textoError.text = "Entrada no válida. Por favor ingresa un número entero.";
            //Debug.Log("Entrada no válida. Por favor ingresa un número entero.");
        }
    }

    public void InsertElement()
    {
        string [] numsArrays = inputField.text.Split(", ");
        string index=numsArrays[0];
        string value = numsArrays[1];
        int.TryParse(index, out int n);
        if (numsArrays[0].Any(char.IsLetter))
        {
            textoError.text = "Valor no valido para el indice";
            //Debug.Log("Valor no valido para el indice");
        }
        else if (numsArrays.Length > 2)
        {
            textoError.text = "Solo se requieren dos valores";
            //Debug.Log("Solo se requieren dos valores");
        }
        else if (n > list.Count)
        {
            list.Add(value);
        }
        else
        {
            list.Insert(n, value);
        }
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
        textoLista = GameObject.FindGameObjectWithTag("ListaText").GetComponent<TMP_Text>();
        textoCount = GameObject.FindGameObjectWithTag("CountText").GetComponent<TMP_Text>();
        textoError = GameObject.FindGameObjectWithTag("ErrorText").GetComponent<TMP_Text>();
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
