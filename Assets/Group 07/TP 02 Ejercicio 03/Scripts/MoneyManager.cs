using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    private TMP_Text textMoney;
    private int playerMoney=1000;

    public int PlayerMoney=>playerMoney;


    private void Start()
    {
        textMoney = GameObject.FindGameObjectWithTag("MoneyCount").GetComponent<TMP_Text>();
        UpdateMoney();
    }

    private void SellItem(int value)
    {
        playerMoney -= value;
        UpdateMoney();
    }

    private void UpdateMoney()
    {
        textMoney.text = PlayerMoney.ToString();
    }
}
