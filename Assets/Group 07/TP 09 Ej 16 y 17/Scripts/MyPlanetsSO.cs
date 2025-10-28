using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu (fileName="New Planet", menuName = "Planets")]
public class MyPlanetsSO : ScriptableObject
{
    public string planetName { get => name; } 


  //  private void OnValidate()
  //  {
  //      planetName = Path.GetFileNameWithoutExtension(AssetDatabase.GetAssetPath(this));
  //  }

}
