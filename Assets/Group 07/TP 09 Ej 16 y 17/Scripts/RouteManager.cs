using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RouteManager : MonoBehaviour
{
    private MyALGraph<string> planetGraph;
    public List<MyPlanetsCreator> planetsList;

    public TMP_Text outputRouteText;
    public void Start()
    {
        planetGraph = new MyALGraph<string>();
        
        foreach(MyPlanetsCreator planets in planetsList)
        {
            planetGraph.AddVertex(planets.PlanetName);
            foreach(MyEdgesSO routes in planets.planetRoutes)
            {
                planetGraph.AddEdge(planets.PlanetName, (routes.toPlanet.name, routes.force));
            }
        }
    }

    public int? GetRoute(string firstName, string finalName)
    {
        if (planetGraph.ContainsEdge(firstName, finalName))
        {
            Debug.Log($"Ruta sin trasbordos desde: {firstName} hasta {finalName}");
            outputRouteText.text = $"Ruta sin trasbordos desde: {firstName} hasta {finalName}";
            return planetGraph.GetWeight(firstName, finalName);
        }
        else if(Layover(finalName, out string layoverPlanet))
        {
            Debug.Log($"{layoverPlanet} va directo a {finalName}");
            outputRouteText.text = $"{layoverPlanet} va directo a {finalName}";
            return GetRoute(layoverPlanet, finalName) + GetRoute(firstName, layoverPlanet);
        }
        return null;
    }

    public bool Layover(string finalName, out string layoverPlanet)
    {
        for (int i=0; i< planetsList.Count; i++)
        {
            if (planetGraph.ContainsEdge(planetsList[i].PlanetName, finalName))
            {
                layoverPlanet= planetsList[i].PlanetName;
                return true;
            }
        }
        layoverPlanet = null;
        return false;   
    }
}


