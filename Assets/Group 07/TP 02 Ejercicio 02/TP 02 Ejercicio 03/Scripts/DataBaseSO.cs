using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ItemListSO", menuName = "ScriptableObjects/ItemList")]
public class DataBaseSO : ScriptableObject
{
    [field: SerializeField] public ItemSO[] items { get; private set; }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (UnityEditor.EditorApplication.isPlaying)
            return;

        //Debug.Log("OnValidate ItemListSO ");
        if (items == null)
            return;
        for (int i = 0; i < items.Length; i++)
            if (items[i] != null)
                items[i].SetID(i);

        UnityEditor.EditorUtility.SetDirty(this);
    }
#endif

    /*
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
    */
}