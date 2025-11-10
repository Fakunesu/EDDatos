using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

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
        foreach (Planet planet in allPlanets)
        {
            MyALGraph.AddVertex(planet);
            foreach(Planet planet2 in planet.Conn)
            {
                float distance = Vector3.Distance(planet.transform.position, planet2.transform.position);
                MyALGraph.AddEdge(planet, (planet2, distance));
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

    public float? GetRoute(Planet from, Planet to)
    {
        return MyALGraph.GetWeight(from, to);
    }

    public float? GetRoute(string fromName, string toName)
    {
        Planet from = allPlanets.Find(p => p.PlanetName == fromName);
        Planet to = allPlanets.Find(p => p.PlanetName == toName);
        return GetRoute(from, to);
    }

    public void CheckRoute()
    {
        
        if (clickedPlanets.Count < 2)
        {
            outputRouteText.text = "Seleccioná al menos dos planetas.";
            return;
        }

        float totalCost = 0f;
        bool validRoute = true;

        
        for (int i = 0; i < clickedPlanets.Count - 1; i++)
        {
            Planet from = clickedPlanets[i];
            Planet to = clickedPlanets[i + 1];

            float? cost = MyALGraph.GetWeight(from, to);

            if (cost == null)
            {
                validRoute = false;
                outputRouteText.text = $"No hay conexión entre {from.PlanetName} y {to.PlanetName}.";
                break;
            }

            totalCost += cost.Value;
        }

        
        if (validRoute)
            outputRouteText.text = $"Ruta válida.\nCosto total: {totalCost:F2}";

        
        clickedPlanets.Clear();
    }
}