using TMPro;
using UnityEngine;



public class TestMyList : MonoBehaviour
{
    private TMP_Text textoLista;
    private TMP_Text textoCount;
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

    public void RemoveAt()
    {
        string userInput = inputField.text;
        if (int.TryParse(userInput, out int result))
        {
            list.RemoveAt(result);
           UpdateText();
        }
        else
        {
            Debug.LogWarning("Entrada no válida. Por favor ingresa un número entero.");
        }
    }

    private void Start()
    {
        textoLista = GameObject.FindGameObjectWithTag("ListaText").GetComponent<TMP_Text>();
        textoCount = GameObject.FindGameObjectWithTag("CountText").GetComponent<TMP_Text>();
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
