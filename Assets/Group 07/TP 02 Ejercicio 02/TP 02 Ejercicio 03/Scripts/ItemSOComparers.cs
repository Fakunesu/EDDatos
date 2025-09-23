using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSOComparers : MonoBehaviour
{
    public static int ByID(ItemSO a, ItemSO b)
    {
        return a.ID.CompareTo(b.ID);
    }

    public static int ByName(ItemSO a, ItemSO b)
    {
        return string.Compare(a.ItemName, b.ItemName, StringComparison.OrdinalIgnoreCase);
    }

    public static int ByLowerPrice(ItemSO a, ItemSO b)
    {
        return a.Price.CompareTo(b.Price);
    }

    public static int ByGreatestPrice(ItemSO a, ItemSO b)
    {
        return b.Price.CompareTo(a.Price);
    }
}
