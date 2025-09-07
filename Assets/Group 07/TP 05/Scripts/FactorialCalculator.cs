using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FactorialCalculator : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text outputText;

    public int Factorial(int ingresedNumber)
    {
        if (ingresedNumber <= 1)
        {
            return 1;
        }
        else
        {
            return ingresedNumber * Factorial(ingresedNumber - 1);
        }
    }

    public void MostrarFactorial()
    {
        int n;

        if (int.TryParse(inputField.text, out n) && n >= 0)
        {
            outputText.text = n + "! = " + Factorial(n);
        }
        else
        {
            outputText.text = "Ingrese un número entero positivo";
        }
    }
}
