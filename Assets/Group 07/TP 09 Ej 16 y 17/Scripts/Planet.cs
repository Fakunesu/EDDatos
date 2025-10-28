using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planet : MonoBehaviour
{
    public static event Action<Planet> OnPlanetClick;

    public List<Planet> conn { get; protected set; }
    private Button button;

    public string PlanetName => gameObject.name;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(PlanetButtonFunction);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveAllListeners();
    }

    public void PlanetButtonFunction() => OnPlanetClick?.Invoke(this);
}