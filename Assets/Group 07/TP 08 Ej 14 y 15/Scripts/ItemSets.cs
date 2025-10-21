using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSets : MonoBehaviour
{
    public string name;
    public int price;

    public ItemSets(string name, int price)
    {
        this.name = name;
        this.price= price;
    }

    public override string ToString()
    {
        return $"{name}, Price:{price}";
    }
}
