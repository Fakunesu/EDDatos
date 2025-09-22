using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ScriptableObjects/ItemSO")]
public class ItemSO : ScriptableObject
{
    public int ID { get; private set; }

    [field: SerializeField] public string ItemName { get; private set; }

    [field: SerializeField] public Sprite Sprite { get; private set; }

    [field: SerializeField] public int Price { get; private set; }

    [field: SerializeField] public string Type { get; private set; }
    public void SetID(int id)
    {
#if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty(this);

#endif
        ID = id;
    }
}
