using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlanetsCreator : MonoBehaviour
{
    [SerializeField] MyPlanetsSO planet;
    public List<MyEdgesSO> planetRoutes;

    public string PlanetName=>planet.name;
}
