using TMPro;
using UnityEngine;

public class GraphExecuter : MonoBehaviour
{
    private string firstPlanet;
    private string finalPlanet;

    public TMP_Text outputText;


    [SerializeField] private RouteManager routeManager;

    public void MarkRoute(string planetName)
    {
        //if (firstPlanet == null && finalPlanet == null)
        //{
        //    firstPlanet = planetName;
        //}
        //else if (firstPlanet != null && finalPlanet == null)
        //{
        //    finalPlanet = planetName;
        //    outputText.text = (routeManager.GetRoute(firstPlanet, finalPlanet).ToString());
        //    firstPlanet = null;
        //    finalPlanet = null;
        //    Debug.Log(routeManager.GetRoute(firstPlanet, finalPlanet));
        //}

    }
}