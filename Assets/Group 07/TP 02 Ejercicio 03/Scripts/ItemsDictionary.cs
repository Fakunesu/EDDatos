using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDictionary : MyList<IItems>
{
    private MyList<IItems> itemList = new MyList<IItems>();
    private Dictionary<string, IItems> items = new Dictionary<string, IItems>()
    {

        { "1", new Items("01","SG-09 R", 500, "Epic", "HandGun") },
        { "2", new Items("02","SR M1903", 3500, "Legendary", "Rifle") },
        { "3", new Items("03","TMP", 1000, "Epic", "SMG")},
        { "4", new Items("04","Riot Gun", 5000, "Legendary", "Shotgun") },
        { "5", new Items("05", "HandGun Ammo", 15, "common", "Ammo")},
        {"6", new Items("06", "Rifle Ammo", 50, "common", "Ammo")},
        { "7", new Items("07", "Shotgun Ammo", 30, "common", "Ammo")},
        { "8", new Items("08", "SMG Ammo", 10, "common", "Ammo")}
    };


    private void AddItem(IItems item)
    {
        items.Add(item.ID, item);
        itemList.Add(item);
    }
    public IItems GetItemById(string id)
    {
        if (items.TryGetValue(id, out IItems item))
            return item;
        return null;
    }
    public override string ToString()
    {
        return items.ToString();
    }
}
