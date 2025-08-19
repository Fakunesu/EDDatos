using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDictionary : MyList<IItems>
{
    private Dictionary<string, IItems> items = new Dictionary<string, IItems>();
    private MyList<IItems> itemList = new MyList<IItems>();
    public ItemsDictionary()
    {
        items.Add("1", new Items("01","SG-09 R", 500, "Epic", "HandGun"));
        items.Add("2", new Items("02","SR M1903", 3500, "Legendary", "Rifle"));
        items.Add("3", new Items("03","TMP", 1000, "Epic", "SMG"));
        items.Add("4", new Items("04","Riot Gun", 5000, "Legendary", "Shotgun"));
        items.Add("5", new Items("05", "HandGun Ammo", 15, "common", "Ammo"));
        items.Add("6", new Items("06", "Rifle Ammo", 50, "common", "Ammo"));
        items.Add("7", new Items("07", "Shotgun Ammo", 30, "common", "Ammo"));
        items.Add("8", new Items("08", "SMG Ammo", 10, "common", "Ammo"));
    }


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
