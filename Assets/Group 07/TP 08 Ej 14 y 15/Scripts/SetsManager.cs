using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SetsManager : MonoBehaviour
{
    public MySetList<ItemSets> inventory1;
    public MySetList<ItemSets> inventory2;
    public MySetList<ItemSets> inventory3;

    public MySetList<ItemSets> bottomInventory;

    public MySetArray<ItemSets> items;
    [SerializeField] private GameObject itemPrefab;

    [Header("Inventarios")]
    [SerializeField] private Transform panelInv1;
    [SerializeField] private Transform panelInv2;
    [SerializeField] private Transform panelInv3;

    private void Awake()
    {
        inventory1 = new MySetList<ItemSets>();
        inventory2 = new MySetList<ItemSets>();
        inventory3 = new MySetList<ItemSets>();
        items = new MySetArray<ItemSets>();
        
    }
    void Start()
    {
        SetItems(40);
        SetInventories(20);

        DrawGrid(panelInv1, inventory1);
        DrawGrid(panelInv2, inventory2);
    }

 
    void Update()
    {
        
    }

    void SetItems(int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            items.Add(new ItemSets($"Nº{i}", Random.Range(0, 100)));
        }
            Debug.Log(items.Cardinality());
    }

    void SetInventories(int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            if (Random.Range(0, 100) < 70)
            {
                var elems = items.Elements;
                var item = elems[Random.Range(0, elems.Length)];
                inventory1.Add(item);
            }
        }

        for (int i = 0; i < quantity; i++)
        {
            if (Random.Range(0, 100) < 70)
            {
                var elems = items.Elements;
                var item = elems[Random.Range(0, elems.Length)];
                inventory2.Add(item);
            }
        }
    }

    void ClearGrid(Transform grid)
    {
        for (int i = grid.childCount - 1; i >= 0; i--)
        {
            Destroy(grid.GetChild(i).gameObject);
        }
    }

    void DrawGrid(Transform grid, MySet<ItemSets> set)
    {
        ClearGrid(grid);

        var elems = set.Elements;
        for (int i = 0; i < elems.Length; i++)
        {
            var slotGO = Instantiate(itemPrefab, grid);
            var text = slotGO.GetComponentInChildren<TMPro.TMP_Text>();
            if (text != null)
            {
                text.text = $"{elems[i].name}\n${elems[i].price}";
            }
        }
    }

    public void UnionInventories()
    {

        var result= inventory1.Union(inventory2);
        DrawGrid(panelInv3, result);
    }

    public void IntersectInventories()
    {
        var result= inventory1.Intersect(inventory2);
        DrawGrid(panelInv3, result);
    }

    public void DifferenceInventories1()
    {
        var result= inventory1.Difference(inventory2);
        DrawGrid(panelInv3, result);
    }

    public void DifferenceInventories2()
    {
        var result = inventory2.Difference(inventory1);
        DrawGrid(panelInv3, result);
    }

    public void NotUsed()
    {
        var union = inventory1.Union(inventory2);
        var result = items.Difference(union);
        DrawGrid(panelInv3, result);
    }
}
