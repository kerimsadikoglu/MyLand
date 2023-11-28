using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LockedUnitController : MonoBehaviour
{   
    
    [SerializeField] private int price;
    [SerializeField] private TextMeshPro priceText;
    [SerializeField] private GameObject lockedUnit;
    [SerializeField] private GameObject unlockedUnit;
    private bool isPurhased;
    
    // Start is called before the first frame update
    void Start()
    {
        priceText.text = price.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !isPurhased)
        {
            UnLockedUnit();
        }
    }

    private void UnLockedUnit()
    {
        if (CashManager.instance.TryBuyThisUnit(price))
        {
            Unlocked();
        }
    }
    private void Unlocked()
    {
        isPurhased = true;
        lockedUnit.SetActive(false);
        unlockedUnit.SetActive(true);
    }
}
