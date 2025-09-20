using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class PlayerInventory : MonoBehaviour
{
    private DataBaseSO data;
    [SerializeField] private StoreManager storeManager;
    public int dineroJugador {private set; get; }

    [Header("Panel")]
    [SerializeField] private Transform itemContainer;

    [Header("Prefab")]
    [SerializeField] private GameObject itemButtonPrefab;
    [SerializeField] private DataBaseSO itemVisuals;

    [Header("Money")]
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private int dineroInicial = 10000;

    private Dictionary<int, int> items = new Dictionary<int, int>();
    private Dictionary<int, GameObject> itemButton = new Dictionary<int, GameObject>();

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
            dineroJugador += item.Price;
            ActualizarDineroUI();
            EliminarItem(item);

            if (storeManager != null)
            {
                storeManager.AgregarItem(item);
                Debug.Log($"Vendiste: {item.ItemName}");
            }
            else 
            {
                
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

