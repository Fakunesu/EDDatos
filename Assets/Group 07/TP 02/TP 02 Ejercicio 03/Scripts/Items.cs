using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Items : IItems
{
    private static Dictionary<string, int> idCounter = new Dictionary<string, int>();

    public string ID { get; private set; }
    public string Name { get; private set; }
    public int Price { get; private set; }
    public string Rarity { get; private set; }
    public string Type { get; private set; }
    public Sprite Icon { get; private set; }

    //public Sprite Sprite { get; private set; }
    
    public Items(string name, int price, string rarity, string type)
    {
        if (!idCounter.ContainsKey(name)){
            idCounter[name] = 0;
        }

        int count=idCounter[name];

        ID = $"{name}_{count}";
        idCounter[name]++;
        Name = name;
        Price = price;
        Rarity = rarity;
        Type = type;

        //Sprite = sprite;
    }

    public void AsignarSprite(ItemListSO itemImage)
    {
        Icon = itemImage.GetSprite(this);
    }

    public override string ToString()
    {
        return $"{ID} - {Type} ({Rarity}) - ${Price}";
    }
}
