using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDictionary
{
    //                 ID, cantidad
    private Dictionary<int, int> items = new Dictionary<int, int>();

    public ItemsDictionary(ItemListSO itemImage)
    {
        
        //AddItem(new Items(001, 1));
        /*
        AddItem(new Items("SG-09 R", 500, "Epic", "HandGun"),01 , itemImage);
        AddItem(new Items("SR M1903", 3500, "Legendary", "Rifle"), itemImage);
        AddItem(new Items("TMP", 1000, "Epic", "SMG"), itemImage);
        AddItem(new Items("Riot Gun", 5000, "Legendary", "Shotgun"), itemImage);
        AddItem(new Items("HandGun Ammo", 15, "Common", "Ammo"), itemImage);
        AddItem(new Items("Rifle Ammo", 50, "Common", "Ammo"), itemImage);
        AddItem(new Items("Shotgun Ammo", 30, "Common", "Ammo"), itemImage);
        AddItem(new Items("SMG Ammo", 10, "Common", "Ammo"), itemImage);*/
    }

    private void AddItem(IItems item, ItemListSO itemImage)
    {
        //item.AsignarSprite(itemImage);       // setea Icon
        //items[item.ID] = item;               // lookup por ID
        //Add(item);                           // *** clave: cargar la lista base ***
    }

    /*
    public IItems GetItemById(string id)
    {
        return items.TryGetValue(id, out var item) ? item : null;
    }
    */
}
