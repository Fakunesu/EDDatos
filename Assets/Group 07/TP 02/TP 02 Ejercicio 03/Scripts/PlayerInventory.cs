using UnityEngine;
using MyLinkedList;

public class PlayerInventory
{
    private MyList<IItems> inventario = new MyList<IItems>();

    public void AgregarItem(IItems item)
    {
        inventario.Add(item);
        Debug.Log($"Item agregado al inventario: {item.ID}");
    }

    public void VenderItem(IItems item, ref int dineroJugador)
    {
        if (inventario.Remove(item))
        {
            dineroJugador += item.Price;
            Debug.Log($"Vendiste: {item.Name} por ${item.Price}");
        }
        else
        {
            Debug.Log("Ese ítem no está en tu inventario");
        }
    }

    public MyList<IItems> GetInventario()
    {
        return inventario;
    }
}


