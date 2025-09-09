using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ScriptableObjects/ItemSO")]
public class ItemSO : ScriptableObject
{
    public int ID { get; private set; }

    public void SetID(int id)
    {
        ID = id;
    }
    [field: SerializeField] public string ItemName { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }

    [field: SerializeField] public int Price { get; private set; }
}
