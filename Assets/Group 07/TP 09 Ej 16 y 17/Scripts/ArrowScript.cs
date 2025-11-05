using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArrowScript : MonoBehaviour
{
    [Header("Planetas conectados")]
    [SerializeField] private Planet Planet1;
    [SerializeField] private Planet Planet2;

    private TMP_Text distanceText;
    private void Awake()
    {
        
        distanceText = GetComponentInChildren<TMP_Text>();
    }
    void Start()
    {
        if (Planet1 == null|| Planet2 == null)
        {
            Debug.Log("Falta algo");
            return;
        }

        float distance = Vector3.Distance(Planet1.transform.position, Planet2.transform.position);
        distanceText.text = $"{distance:F1}";
    }
}
