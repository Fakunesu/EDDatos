using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RouteManager : MonoBehaviour
{
    MyALGraph<Planet> MyALGraph = new MyALGraph<Planet>();

    [SerializeField] private List<Planet> allPlanets = new List<Planet>();
    [SerializeField] private TMP_Text outputRouteText;

    [Header("Debug:")]
    [SerializeField] private List<Planet> clickedPlanets = new List<Planet>();

    private void Awake()
    {
        Planet.OnPlanetClick += Planet_OnPlanetClick;
    }

    private void Start()
    {
        // MyALGraph
        foreach (Planet planet in allPlanets)
        {
            foreach(Planet planet2 in planet.conn)
            {

            }
        }
    }

    private void OnDestroy()
    {
        Planet.OnPlanetClick -= Planet_OnPlanetClick;
    }

    private void Planet_OnPlanetClick(Planet planet)
    {
        if (clickedPlanets.Contains(planet))
            clickedPlanets.Remove(planet);
        else
            clickedPlanets.Add(planet);
    }
}