using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SetsManager : MonoBehaviour
{
    public MySetList<ItemSets> inventory1;
    public MySetList<ItemSets> inventory2;
    public MySetList<ItemSets> inventory3;

    public MySetArray<ItemSets> items;

    private void Awake()
    {
        inventory1 = new MySetList<ItemSets>();
        inventory2 = new MySetList<ItemSets>();
        inventory3 = new MySetList<ItemSets>();
        items = new MySetArray<ItemSets>();
        
    }
    void Start()
    {
        SetItems(10);
    }

 
    void Update()
    {
        
    }

    void SetItems(int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            items.Add(new ItemSets($"Item Nº{i}", Random.Range(0, 100)));
            Debug.Log(items.array[i].price);
        }
    }

    void SetInventories(int quantity)
    {
        for(int i=0; i<quantity; i++)
        {
            if (Random.Range(0, 99) < 69) inventory1.Add(items.array[Random.Range(0, items.Cardinality())]);
        }
        for (int i = 0; i < quantity; i++)
        {
            if (Random.Range(0, 99) < 69) inventory2.Add(items.array[Random.Range(0, items.Cardinality())]);
        }
    }

    MySet<ItemSets> UnionInventories()
    {

        return inventory1.Union(inventory2);
    }

    MySet<ItemSets> IntersectInventories()
    {
        return inventory1.Intersect(inventory2);
    }

    void DifferenceInventories(MySetList<ItemSets> playerInventory)
    {
        playerInventory.Difference(inventory2);
    }

    void notUsed()
    {
        ItemSets[] result = items.Difference(UnionInventories()).Elements;
        
        for (int i = 0; result.Length > 0; i++)
        {
            inventory3.Add(result[i]);
        }
    }
}
