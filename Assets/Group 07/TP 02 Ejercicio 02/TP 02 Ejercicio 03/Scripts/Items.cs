using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Items : IItems
{
    private int v1;
    private int v2;

    public string ID { get; private set; }
    public string Name { get; private set; }
    public int Price { get; private set; }
    public string Rarity { get; private set; }
    public string Type { get; private set; }
    public Sprite Icon { get; private set; }

    //public Sprite Sprite { get; private set; }

    public Items(string name, int price, string rarity, string type, Sprite icon)
    {
        /*
        if (!idCounter.ContainsKey(name)){
            idCounter[name] = 0;
        }

        int count=idCounter[name];

        ID = $"{name}_{count}";
        idCounter[name]++;
        */

        Name = name;
        Price = price;
        Rarity = rarity;
        Type = type;
        Icon = icon;
        //Sprite = sprite;
    }

    /*
    public void AsignarSprite(ItemListSO itemImage)
    {
        Icon = itemImage.GetSprite(this);
        if (Icon == null)
            Debug.LogWarning($"[AsignarSprite] No se encontró sprite para {Name}");
    }
    */

    //Cuando dejen de usar la consola, deberia volar esta funcion
    public override string ToString()
    {
        return $"{ID} - {Type} ({Rarity}) - ${Price}";
    }
}
