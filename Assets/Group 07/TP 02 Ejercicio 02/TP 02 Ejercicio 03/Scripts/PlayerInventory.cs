using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory
{
    private DataBaseSO data;

    private Dictionary<int, int> items = new Dictionary<int, int>();

    public int CantidadItems => items.Count;

    public PlayerInventory(DataBaseSO data)
    {
        this.data = data;
    }

    public void AgregarItem(ItemSO item)
    {
        if (items.ContainsKey(item.ID))
            items[item.ID]++;
        else
            items.Add(item.ID, 1);

        Debug.Log($"Inventario: {items.ToString()}");
    }

    public void EliminarItem(ItemSO item)
    {
        if (items.ContainsKey(item.ID))
        {
            items[item.ID]--;

            if (items[item.ID] < 1)
                items.Remove(item.ID);
            Debug.Log($"{item.ItemName} eliminado del inventario");
        }
        else
        {
            Debug.Log($"{item.ItemName} no encontrado en el inventario");
        }
    }
}

