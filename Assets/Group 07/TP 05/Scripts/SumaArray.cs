using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SumaArray : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text outputText;



    public void MostrarSuma()
    {
        int n;

        if (int.TryParse(inputField.text, out n) && n >= 0)
        {
            outputText.text = $"{Suma(n)} ";
        }
        else
        {
            outputText.text = "Ingrese un número entero positivo";
        }
    }

    int Suma(int n)
    {
        
        if (n <= 0)
        {
            return n;
        }
        else
        {
            return n + Suma(n-1);
        }
        

    }


}
