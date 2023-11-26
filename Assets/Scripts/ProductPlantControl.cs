using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductPlantControl : MonoBehaviour
{
    private bool isReadyToPick;
    private Vector3 originalScale;
    // Start is called before the first frame update
    void Start()
    {
        isReadyToPick = true;
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isReadyToPick)
        {
            Debug.Log("fideye dokundu");
            isReadyToPick = false;
            StartCoroutine(ProductPicked());
            
        }
    }
    IEnumerator ProductPicked()
    {
        
        transform.localScale = originalScale / 3;
        yield return new WaitForSeconds(3f);
        transform.localScale = originalScale;
        isReadyToPick = true;

    }
}
