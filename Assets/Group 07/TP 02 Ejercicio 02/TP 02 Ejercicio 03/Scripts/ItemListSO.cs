using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ItemListSO", menuName = "ScriptableObjects/ItemList")]
public class ItemListSO : ScriptableObject
{
    [SerializeField] private ItemSO[] items;

    private Dictionary<string, Sprite> spriteLookup;

    private void OnEnable()
    {
        spriteLookup = new Dictionary<string, Sprite>();
        foreach (var so in items)
        {
            if (so != null && !spriteLookup.ContainsKey(so.ItemName))
                spriteLookup.Add(so.ItemName, so.Sprite);
        }
    }

    public Sprite GetSprite(IItems item)
    {
        if (item == null) return null;
        spriteLookup.TryGetValue(item.Name, out Sprite sprite);
        return sprite;
    }
}