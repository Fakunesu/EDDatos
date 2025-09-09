using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Piramide : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text outputText;

    string line;
    int renglones;
    public void MostrarPiramide()
    {
        int n;

        if (int.TryParse(inputField.text, out n) && n >= 0)
        {
            PiramideFunction(n);
            outputText.text = line;
            line = null;
            renglones = 0;
        }
        else
        {
            outputText.text = "Ingrese un número entero positivo";
        }
    }
    // line = new string ('X', n)

    public string PiramideFunction(int pisos)
    {
        if (pisos <= 0)
        {
            return new string (" ");

        }
        else
        {
            renglones++;
            line += new string ('X', renglones) + "\n";
            Debug.Log(line);
            return PiramideFunction(pisos - 1); 
        }
    }
}
