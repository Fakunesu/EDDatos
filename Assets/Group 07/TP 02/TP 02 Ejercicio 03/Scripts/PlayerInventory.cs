using MyLinkedList;
using UnityEngine;

public class PlayerInventory
{
    private MyList<IItems> items;

    public PlayerInventory()
    {
        items = new MyList<IItems>();
    }

    public void AgregarItem(IItems item)
    {
        items.Add(item);
        Debug.Log($"Inventario: {items.ToString()}");
    }

    public void EliminarItem(IItems item)
    {
        if (items.Remove(item))
        {
            Debug.Log($"{item.Name} eliminado del inventario");
        }
        else
        {
            Debug.Log($"{item.Name} no encontrado en el inventario");
        }
    }

    public int CantidadItems => items.Count;

    public IItems GetItem(int index)
    {
        return items[index];
    }
}

