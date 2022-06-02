using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencySystem : MonoBehaviour
{
    public Text txt_Currency;
    public int defaultCurrency;
    // Current currency value
    public int currency;


    // Set the default values
    public void Init()
    {
        currency = defaultCurrency;
        UpdateCurrencyUI();
    }

    // Gain currency
    public void Gain(int val)
    {
        currency += val;
        UpdateCurrencyUI();
    }
    public bool Use(int val)
    {
        if (CheckCurrency(val))
        {
            currency -= val;
            UpdateCurrencyUI();
            return true;
        }
        else
        {
            return false;
        }
    }
    // Check if the current currency is available to use
    private bool CheckCurrency(int val)
    {
        if (val <= currency)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void UpdateCurrencyUI()
    {
        txt_Currency.text = currency.ToString();
    }
    public void Test_Use()
    {
        Debug.Log(Use(5));
    }
    //  I add this function that is being called from Test_Spawner
    public int EnoughCurrency() 
    { return currency; }
}
