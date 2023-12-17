using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUpController : MonoBehaviour
{
    [SerializeField] private PowerUpData powerUpData;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (powerUpData.powerUpType == PowerUpType.speedBooster )
            {
                PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
                playerMovement.IncreaseSpeed(powerUpData.boostCount);
                AudioManager.instance.PlayAudio(AudioClipType.grabClip);
                
            }
        }
    }
}
