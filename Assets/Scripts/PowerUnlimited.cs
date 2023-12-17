using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerUnlimited : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int price;
    

    [Header("Objects")]
    [SerializeField] private TextMeshPro priceText;
    

    [SerializeField] private GameObject lockedUnit;
    [SerializeField] private GameObject unlockedUnit;
    [SerializeField] private PowerUpData powerUpData;



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
        if (other.CompareTag("Player") && CashManager.instance.TryBuyThisUnit(price))
        {
            if (powerUpData.powerUpType == PowerUpType.speedBooster)
            {
                PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
                playerMovement.IncreaseSpeed(powerUpData.boostCount);
                AudioManager.instance.PlayAudio(AudioClipType.grabClip);
                price += 5; // price de�erini 5 art�r
                priceText.text = price.ToString(); // priceText'i g�ncelle
            }
            //UnlockUnit();
            // �r�n� paran yetere a�
        }
    }

    private void UnlockUnit()
    {
        if (CashManager.instance.TryBuyThisUnit(price))
        {
            AudioManager.instance.PlayAudio(AudioClipType.shopClip);
            Unlock();
            
        }
        // paras� var m� kontrol et
        // varsa �r�n� a�
    }

    private void Unlock()
    {
        
        lockedUnit.SetActive(true);
        unlockedUnit.SetActive(false);
    }


}
