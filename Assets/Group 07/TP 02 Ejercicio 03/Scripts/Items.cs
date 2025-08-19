using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Items : IItems
{
    public string ID { get; private set; }
    public string Name { get; private set; }
    public int Price { get; private set; }
    public string Rarity { get; private set; }
    public string Type { get; private set; }

    //public Sprite Sprite { get; private set; }
    
    public Items(string id, string name, int price, string rarity, string type/*, Sprite sprite*/)
    {
        ID = id;
        Name = name;
        Price = price;
        Rarity = rarity;
        Type = type;
        //Sprite = sprite;
    }

    public override string ToString()
    {
        return $"{ID} - {Type} ({Rarity}) - ${Price}";
    }
}
