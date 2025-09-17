using System.Collections.Generic;
using TMPro;
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
    private Dictionary<int, int> items = new Dictionary<int, int>(); // ID, Cantidad

    [Header("Configuración")]
    [SerializeField] private int dineroInicial = 10000;

    //En vez de esto, tendria que ir la ItemListSO
    //private ItemsDictionary itemsDB;
    private PlayerInventory playerInventory;
    private int dineroJugador;

    private void Awake()
    {
        //for (int i = 0; i < data.items.Length; i++)
        //    data.items[i].SetID(i);
    }

    void Start()
    {
        dineroJugador = dineroInicial;
        ActualizarDineroUI();

        //itemsDB = new ItemsDictionary(itemVisuals);
        playerInventory = new PlayerInventory(data);

        //Reemplazar por ItemListSO y descomentar

        for (int i = 0; i < data.items.Length; i++)
        {
            ItemSO item = data.items[i];
            GameObject boton = Instantiate(itemButtonPrefab, itemContainer);

            // Texto
            var texto = boton.GetComponentInChildren<TextMeshProUGUI>(true);
            if (texto != null) texto.text = $"{item.ItemName} - ${item.Price}";

            // Imagen (en root o en un hijo)
            var icon = boton.transform.Find("icon").GetComponent<Image>();
            if (icon != null)
            {
                icon.sprite = item.Sprite;
                icon.enabled = (item.Sprite != null);
            }

            ItemSO itemCapturado = item;
            Button btn = boton.GetComponent<Button>();
            if (item.ID < 4)
                items.Add(item.ID, 3); // Agregamos 3 de cada municion
            else
                items.Add(item.ID, 1); // Agregamos 3 de cada otros items


            if (btn != null)
                btn.onClick.AddListener(() => ComprarItem(itemCapturado));
        }
    }

    void ComprarItem(ItemSO item)
    {
        if (dineroJugador >= item.Price)
        {
            dineroJugador -= item.Price;
            ActualizarDineroUI();
            playerInventory.AgregarItem(item);
            Debug.Log($"Inventario ahora: {playerInventory.CantidadItems} items.");
            Debug.Log($"You bought: {item.ItemName}");
        }
        else
        {
            Debug.Log("Not enough cash, stranger!");
        }
    }



    void ActualizarDineroUI()
    {
        if (moneyText != null)
            moneyText.text = $"Money: ${dineroJugador}";
    }
}

