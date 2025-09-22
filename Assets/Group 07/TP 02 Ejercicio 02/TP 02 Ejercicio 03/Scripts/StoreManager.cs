using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

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
            if (texto != null) texto.text = $"{item.ItemName} \n x{ amount} \n -${item.Price}";

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

  //  public void OrdenarInventario(Dictionary<int, string> lista)
  //  {
  //      ItemSO item;
  //  }

    void ActualizarTextoUI(ItemSO item)
    {
            var texto = itemButton[item.ID].GetComponentInChildren<TextMeshProUGUI>(true);
            if (texto != null) texto.text = $"{item.ItemName} \n x{items[item.ID]} \n -${item.Price}"; 
    }


}

