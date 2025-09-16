using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Palindromo : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_Text outputText;
    char[] arrayPalabra;
    int index = 0;

    public void MostrarPalindromo()
    {
        outputText.text = PalindromoFunction(StringToCharArray(inputField.text), index);
    }

    public char[] StringToCharArray(string palabra)
    {
        arrayPalabra=palabra.ToCharArray();
        return palabra.ToCharArray();
        
    }

    public string PalindromoFunction(char[] palabra, int index)
    {
        Debug.Log(arrayPalabra[index]);
        Debug.Log(index);
        if (index >= arrayPalabra.Length - 1 - index)
        {
            Debug.Log("Es palíndromo");
            return "Es palíndromo";
        }
        else
        {
            if (arrayPalabra[index] == arrayPalabra[arrayPalabra.Length-1-index])
            {
                Debug.Log("Ta viendo si es palindromo");
                return PalindromoFunction(palabra, index + 1);
            }
            else 
            {
                Debug.Log("No es palíndromo");
                return "No es palíndromo";
            }   
        }

    }
}
