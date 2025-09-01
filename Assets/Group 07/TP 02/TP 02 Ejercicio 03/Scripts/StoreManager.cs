using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MyLinkedList;

public class StoreManager : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Transform itemContainer;
    [SerializeField] private GameObject itemButtonPrefab;
    [SerializeField] private ItemListSO itemVisuals;
    [SerializeField] private TextMeshProUGUI moneyText;

    [Header("Configuración")]
    [SerializeField] private int dineroInicial = 10000;

    private ItemsDictionary itemsDB;
    private PlayerInventory playerInventory;
    private int dineroJugador;

    void Start()
    {
        dineroJugador = dineroInicial;
        ActualizarDineroUI();

        itemsDB = new ItemsDictionary(itemVisuals);
        playerInventory = new PlayerInventory();

        for (int i = 0; i < itemsDB.Count; i++)
        {
            IItems item = itemsDB[i];

            GameObject boton = Instantiate(itemButtonPrefab, itemContainer);

            // Texto
            var texto = boton.GetComponentInChildren<TextMeshProUGUI>(true);
            if (texto != null) texto.text = $"{item.Name} - ${item.Price}";

            // Imagen (en root o en un hijo)
            var icon = boton.transform.Find("icon").GetComponent<Image>();
            if (icon != null)
            {
                icon.sprite = item.Icon;
                icon.enabled = (item.Icon != null);
            }

            IItems itemCapturado = item;
            var btn = boton.GetComponent<Button>();
            if (btn != null) btn.onClick.AddListener(() => ComprarItem(itemCapturado));
        }
    }

    void ComprarItem(IItems item)
    {
        if (dineroJugador >= item.Price)
        {
            dineroJugador -= item.Price;
            ActualizarDineroUI();
            playerInventory.AgregarItem(item);
            Debug.Log($"Inventario ahora: {playerInventory.CantidadItems} items.");
            Debug.Log($"You bought: {item.Name}");
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

