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
            boton.GetComponentInChildren<TextMeshProUGUI>().text = $"{item.Name} - ${item.Price}";
            boton.GetComponent<Image>().sprite = item.Icon;

            IItems itemCapturado = item;
            boton.GetComponent<Button>().onClick.AddListener(() => ComprarItem(itemCapturado));
        }
    }

    void ComprarItem(IItems item)
    {
        if (dineroJugador >= item.Price)
        {
            dineroJugador -= item.Price;
            ActualizarDineroUI();
            playerInventory.AgregarItem(item);
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

