using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactorialArray : MonoBehaviour
{
  

    private void Start()
    {
        int[] array = { 1, 2, 3, 4, 5 };
        Debug.Log("El resultado de la suma del array es: " + SumaArray(array.Length - 1, array));

    }

    private void Update()
    {
        
    }

    int SumaArray(int n, int[] array)
    {
        
        if (n <= 0)
        {
            return array[n];
        }
        else
        {
            return array[n] + SumaArray(n-1,array);
        }
        

    }


}
