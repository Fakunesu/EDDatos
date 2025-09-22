using MyLinkedList;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public enum SortOption
{
    ID,
    Name,
    Price
}
public class StoreManager : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Transform itemContainer;
    [SerializeField] private GameObject itemButtonPrefab;
    [SerializeField] private DataBaseSO itemVisuals;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private DataBaseSO data;
    [SerializeField] private PlayerInventory playerInventory;
    private Dictionary<int, int> items = new Dictionary<int, int>(); // ID, Cantidad
    private Dictionary<int, GameObject> itemButton = new Dictionary<int, GameObject>();


    void Start()
    {

        

        Debug.Log($"{playerInventory.dineroJugador}");


        for (int i = 0; i < data.items.Length; i++)
        {
            ItemSO item = data.items[i];
            GameObject boton = Instantiate(itemButtonPrefab, itemContainer);


            if (item.ID < 4)
                items.Add(item.ID, 5); // Agregamos 5 de cada municion
            else
                items.Add(item.ID, 1); // Agregamos 1 de cada otros items
            // Texto
            var texto = boton.GetComponentInChildren<TextMeshProUGUI>(true);
            items.TryGetValue(item.ID, out int amount);
            if (texto != null) texto.text = $"{item.ItemName} \n x{items[item.ID]} \n -${item.Price}";

            // Imagen (en root o en un hijo)
            var icon = boton.transform.Find("icon").GetComponent<Image>();
            if (icon != null)
            {
                icon.sprite = item.Sprite;
                icon.enabled = (item.Sprite != null);
            }

            itemButton.Add(item.ID, boton);
            ItemSO itemCapturado = item;
            Button btn = boton.GetComponent<Button>();

            if (btn != null)
                btn.onClick.AddListener(() => ComerciarItem(itemCapturado));
        }
    }

    public void ComerciarItem(ItemSO item)
    {
        Debug.Log($"el jugador tiene {playerInventory.dineroJugador}");
        if (playerInventory.dineroJugador >= item.Price)
        {
            playerInventory.PlayerComproItem(item);
            EliminarItem(item);
            Debug.Log($"Inventario ahora: {playerInventory.CantidadItems} items.");
            Debug.Log($"You bought: {item.ItemName}");
        }
        else
        {
            Debug.Log("Not enough cash, stranger!");
        }
    }



    public void AgregarItem(ItemSO item)
    {
        if (items.ContainsKey(item.ID))
        {
            items[item.ID]++;
            if (itemButton.ContainsKey(item.ID))
            {
                ActualizarTextoUI(item);
            }
        }
        else
        {
            items.Add(item.ID, 1);
            GameObject boton = Instantiate(itemButtonPrefab, itemContainer);
            var texto = boton.GetComponentInChildren<TextMeshProUGUI>(true);
            if (texto != null) texto.text = $"{item.ItemName} \n x{items[item.ID]} \n -${item.Price}";

            var icon = boton.transform.Find("icon").GetComponent<Image>();
            if (icon != null)
            {
                icon.sprite = item.Sprite;
                icon.enabled = (item.Sprite != null);
            }

            Button btn = boton.GetComponent<Button>();
            if (btn != null)
            {
                ItemSO itemCapturado = item;
                btn.onClick.AddListener(() => ComerciarItem(itemCapturado));
            }

            itemButton.Add(item.ID, boton);

        }
    }

    public void EliminarItem(ItemSO item)
    {
        if (items.ContainsKey(item.ID))
        {
            items[item.ID]--;
            ActualizarTextoUI(item);
            Debug.Log($"Cantidad de {item.ID} = {items[item.ID]}");
            if (items[item.ID] < 1)
            {
                items.Remove(item.ID);
                if (itemButton.ContainsKey(item.ID))
                {
                    Destroy(itemButton[item.ID]);
                    itemButton.Remove(item.ID);
                }
            }
            Debug.Log($"{items}");
        }
        else
        {
            Debug.Log($"{item.ItemName} no encontrado en el inventario");
        }

    }

    public void SortStore(SortOption option)
    {
        // 1. Pasar items actuales a MyList
        MyList<ItemSO> lista = new MyList<ItemSO>();
        foreach (var kvp in items)
        {
            ItemSO item = data.items[kvp.Key];
            lista.Add(item);
        }

        // 2. Elegir comparador
        Comparison<ItemSO> comp = ItemSOComparers.ByID;
        if (option == SortOption.Name) comp = ItemSOComparers.ByName;
        else if (option == SortOption.Price) comp = ItemSOComparers.ByPrice;

        // 3. Ordenar
        lista.SelectionSort(comp);

        // 4. Reordenar en la UI
        int i = 0;
        MyNode<ItemSO> current = lista.node; // primer nodo
        while (current != null)
        {
            ItemSO item = current.Value;
            if (itemButton.ContainsKey(item.ID))
            {
                itemButton[item.ID].transform.SetSiblingIndex(i);
            }
            current = current.Next;
            i++;
        }
    }

    //  public void OrdenarInventario(Dictionary<int, string> lista)
    //  {
    //      ItemSO item;
    //  }

    void ActualizarTextoUI(ItemSO item)
    {
            var texto = itemButton[item.ID].GetComponentInChildren<TextMeshProUGUI>(true);
            if (texto != null) texto.text = $"{item.ItemName} \n x{items[item.ID]} \n -${item.Price}"; 
    }

    public void SortStoreByID() { SortStore(SortOption.ID); }
    public void SortStoreByName() { SortStore(SortOption.Name); }
    public void SortStoreByPrice() { SortStore(SortOption.Price); }
}

