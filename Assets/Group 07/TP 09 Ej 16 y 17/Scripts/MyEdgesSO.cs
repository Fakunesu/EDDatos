using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Edge", menuName= "Edges")]
public class MyEdgesSO : ScriptableObject
{
    public MyPlanetsSO toPlanet;
    public int force;
}
