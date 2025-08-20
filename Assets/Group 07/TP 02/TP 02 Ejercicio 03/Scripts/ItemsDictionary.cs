using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDictionary : MyList<IItems>
{
    private MyList<IItems> itemList = new MyList<IItems>();
    private Dictionary<string, IItems> items = new Dictionary<string, IItems>();

    public ItemsDictionary(ItemListSO itemImage)
    {
        AddItem(new Items("SG-09 R", 500, "Epic", "HandGun"), itemImage);
        AddItem(new Items("SR M1903", 3500, "Legendary", "Rifle"), itemImage);
        AddItem(new Items("TMP", 1000, "Epic", "SMG"), itemImage);
        AddItem(new Items("Riot Gun", 5000, "Legendary", "Shotgun"), itemImage);
        AddItem(new Items("HandGun Ammo", 15, "Common", "Ammo"), itemImage);
        AddItem(new Items("Rifle Ammo", 50, "Common", "Ammo"), itemImage);
        AddItem(new Items("Shotgun Ammo", 30, "Common", "Ammo"), itemImage);
        AddItem(new Items("SMG Ammo", 10, "Common", "Ammo"), itemImage);
    }



    private void AddItem(IItems item, ItemListSO itemImage)
    {
        item.AsignarSprite(itemImage);
        items.Add(item.ID, item);
        itemList.Add(item);
    }
    public IItems GetItemById(string id)
    {
        items.TryGetValue(id, out IItems item);
            return item;
        
    }
    public override string ToString()
    {
        string result = "";
        foreach (var kvp in items)
        {
            result += $"{kvp.Key}: {kvp.Value.ToString()}\n";
        }
        return result;

    }


}
