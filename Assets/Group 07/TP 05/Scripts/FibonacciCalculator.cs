using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FibonacciCalculator : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text outputText;

    public void MostrarFibonacci()
    {
        int n;
        if (int.TryParse(inputField.text, out n))
        {
            string resultado = "";
            for (int i = 0; i < n; i++)
            {
                resultado += Fibonacci(i) + " ";
            }
            outputText.text = resultado;
        }
        else
        {
            outputText.text = "Ingrese un número válido.";
        }
    }


    public int Fibonacci(int ingresedNumber)
    {
        if (ingresedNumber <=1)
        {
            return ingresedNumber;
        }
        else
        {
            return Fibonacci (ingresedNumber- 1) + Fibonacci(ingresedNumber - 2);
        }
    }
}
