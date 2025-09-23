using MyLinkedList;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class PlayerInventory : MonoBehaviour
{
    private DataBaseSO data;
    [SerializeField] private StoreManager storeManager;

    [Header("Panel")]
    [SerializeField] private Transform itemContainer;

    [Header("Prefab")]
    [SerializeField] private GameObject itemButtonPrefab;
    [SerializeField] private DataBaseSO itemVisuals;

    [Header("Money")]
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private int dineroInicial = 10000;
    public int dineroJugador {private set; get; }

    private Dictionary<int, int> items = new Dictionary<int, int>();// id(key), cantidad(value)
    private Dictionary<int, GameObject> itemButton = new Dictionary<int, GameObject>();//id(key), prefab/item

    public int CantidadItems => items.Count;



    private void Awake()
    {
        dineroJugador = dineroInicial;
        ActualizarDineroUI();
        
    }


    public void VenderItem(ItemSO item)
    {
        if (!items.ContainsKey(item.ID))
            return;
        else
        {
            dineroJugador += item.SellPrice;
            ActualizarDineroUI();
            item.PriceReduction();
            EliminarItem(item);

            if (storeManager != null)
            {
                storeManager.AgregarItem(item);
                Debug.Log($"Vendiste: {item.ItemName}");
            }
        }
    }

    public void PlayerComproItem(ItemSO item)
    {
        dineroJugador -= item.Price;
        AgregarItem(item);
        ActualizarDineroUI();
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
            if (texto != null) texto.text = $"{item.ItemName} x1";

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
                btn.onClick.AddListener(() => VenderItem(itemCapturado));
            }

            itemButton.Add(item.ID, boton);

        }
    }
    public void EliminarItem(ItemSO item)
    {
        if (items.ContainsKey(item.ID))
        {
            items[item.ID]--;

            if (items[item.ID] < 1)
            {
                items.Remove(item.ID);

                if (itemButton.ContainsKey(item.ID))
                {
                    Destroy(itemButton[item.ID]);
                    itemButton.Remove(item.ID);    
                }
            }
            else
            {
                ActualizarTextoUI(item);
            }

                Debug.Log($"{item.ItemName} eliminado del inventario");
        }
        else
        {
            Debug.Log($"{item.ItemName} no encontrado en el inventario");
        }

    }

    public void OrdenarInventario(SortOption option)
    {
        MyList<ItemSO> lista = new MyList<ItemSO>();

        foreach (var kvp in items)
        {
            ItemSO item = itemVisuals.items[kvp.Key];
            lista.Add(item);
        }

        Comparison<ItemSO> comp = ItemSOComparers.ByID;
        if (option == SortOption.Name) comp = ItemSOComparers.ByName;
        else if (option == SortOption.LowerPrice) comp = ItemSOComparers.ByLowerPrice;
        else if (option == SortOption.GreatestPrice) comp = ItemSOComparers.ByGreatestPrice;

        lista.SelectionSort(comp);

        int i = 0;
        MyNode<ItemSO> current = lista.Root;
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

    void ActualizarTextoUI(ItemSO item)
    {
      
        
            var texto = itemButton[item.ID].GetComponentInChildren<TextMeshProUGUI>(true);
            if (texto != null) texto.text = $"{item.ItemName} x{items[item.ID]}";
        
    }
    void ActualizarDineroUI()
    {
        if (moneyText != null)
            moneyText.text = $"Money: ${dineroJugador}";
    }
}

