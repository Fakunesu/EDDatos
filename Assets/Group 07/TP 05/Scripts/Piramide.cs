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
    int cantX;
    int espacios;
    public void MostrarPiramide()
    {
        int n;

        if (int.TryParse(inputField.text, out n) && n >= 0)
        {
            line = "";
            renglones = 0;
            PiramideFunction(n, 1);
            outputText.text = line;
        }
        else
        {
            outputText.text = "Ingrese un número entero positivo";
        }
    }
    // line = new string ('X', n)

    public string PiramideFunction(int pisos, int nivelActual)
    {
        if (nivelActual>pisos)
        {
            return new string (" ");

        }
        else
        {
            renglones++;      
            cantX = 2* nivelActual - 1;
            espacios = pisos- nivelActual;
            line += new string('-', espacios) + new string('X', cantX) + "\n";
            Debug.Log(line);
            return PiramideFunction(pisos, nivelActual + 1); 
        }
    }
}


//            line += new string ('X', renglones) + "\n";
   