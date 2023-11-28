using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashManager : MonoBehaviour
{
    public static CashManager instance;
    private int coins;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else {
            Destroy(instance);
        }
    }
    public void ExchangeProduct(ProductData productData)
    {
        AddCoin(productData.productPrice);
    }
    public void AddCoin(int price)
    {
        coins += price;
        DisplayCoins();
    }
    private void SpendCoins(int price)
    {
        coins -= price;
        DisplayCoins();
    }
    public bool TryBuyThisUnit(int price)
    {
        if(GetCoins()>= price)
        {
            SpendCoins(price);
            return true;
        }
        return false;
    }
    private int GetCoins()
    {
        return coins;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void DisplayCoins()
    {
        UIManager.instance.ShowCoinOnScreen(coins);
    }
}
