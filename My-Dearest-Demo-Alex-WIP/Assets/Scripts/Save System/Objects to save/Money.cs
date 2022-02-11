using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    [Header("The amount of money")]
    [SerializeField] private float money;
    [Header("Text")]
    [SerializeField] private Text moneyText;

    private SaveData saveData;

    private void OnEnable()
    {
        player.MoneyChanged += AmountOfMoneyChanged;
        Pickup.ItemPrice += PriceChange;
    }

    private void OnDisable()
    {
        player.MoneyChanged -= AmountOfMoneyChanged;
        Pickup.ItemPrice -= PriceChange;
    }

    public float MoneyAmount
    {
        get { return money; }
    }

    private void Awake()
    {
        saveData = SaveSystem.Load();

        money = saveData.Money;
        moneyText.text = $"${money}";
    }

    private void AmountOfMoneyChanged(float moneyAmount)
    {
        money = moneyAmount;
       
        moneyText.text = $"${money}";
        
    }

    private void PriceChange(float price)
    {      
        money -= price;
        saveData.Money = money;
        moneyText.text = $"${money}";
    }

    /// <summary> Save the money. </summary>
    private void SaveMoney()
    {
        saveData.Money = money;
        SaveSystem.Save(saveData);
    }

    #region For Testing
    private void OnValidate()
    {
        moneyText.text = $"${money}";
    }
    #endregion
}


