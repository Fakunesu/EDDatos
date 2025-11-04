using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planet : MonoBehaviour
{
    public static event Action<Planet> OnPlanetClick;

    [Header("Planetas conectados:")]
    [SerializeField] private List<Planet> conn=new List<Planet>();
    public List<Planet> Conn => conn;
    private Button button;

    public string PlanetName => gameObject.name;

    private void Awake()
    {
        if (conn == null)
            conn = new List<Planet>();
        button = GetComponent<Button>();
        button.onClick.AddListener(PlanetButtonFunction);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveAllListeners();
    }

    public void PlanetButtonFunction() => OnPlanetClick?.Invoke(this);
}