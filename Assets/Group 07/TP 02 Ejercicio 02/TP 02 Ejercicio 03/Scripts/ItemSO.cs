using UnityEngine;


[CreateAssetMenu(fileName = "ItemSO", menuName = "ScriptableObjects/ItemSO")]
public class ItemSO : ScriptableObject
{
    public int ID { get; private set; }

    [field: SerializeField] public string ItemName { get; private set; }

    [field: SerializeField] public Sprite Sprite { get; private set; }

    [field: SerializeField] public int Price { get; private set; }

    [field: SerializeField] public int SellPrice { get; private set; }

    [field: SerializeField] public string Type { get; private set; }


    public MyStack<int> priceStack = new MyStack<int>();
    public void SetID(int id)
    {
#if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty(this);

#endif
        ID = id;
    }


    public void PriceElevate()
    {
        priceStack.Push(Price);
        Price = Mathf.CeilToInt((Price+((Price /100)*25)));
    }

    public void PriceReduction()
    {
        var Price2 = priceStack.Pop();
        Price = Price2;
    }
}
