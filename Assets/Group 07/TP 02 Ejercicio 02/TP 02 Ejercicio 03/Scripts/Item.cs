using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item : IItems
{
    private int v1;
    private int v2;

    public string ID { get; private set; }
    public string Name { get; private set; }
    public int Price { get; private set; }
    public string Rarity { get; private set; }
    public string Type { get; private set; }
    public Sprite Icon { get; private set; }

}
