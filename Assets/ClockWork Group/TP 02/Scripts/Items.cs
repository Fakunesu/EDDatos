using System.Collections;
using System.Collections.Generic;

public class Items : IItems
{
    public string ID { get; private set; }
    public string Name { get; private set; }
    public int Price { get; private set; }
    public string Rarity { get; private set; }
    public string Type { get; private set; }
    
    public Items(string id, string name, int price, string rarity, string type)
    {
        ID = id;
        Name = name;
        Price = price;
        Rarity = rarity;
        Type = type;
    }

    public override string ToString()
    {
        return $"{ID} - {Type} ({Rarity}) - ${Price}";
    }
}
