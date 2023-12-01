using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductPlantControl : MonoBehaviour
{
    private bool isReadyToPick;
    private Vector3 originalScale;
    [SerializeField] private ProductData productData;
    private BagController bagController;
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
            bagController = other.GetComponent<BagController>();

            if (bagController.IsEmptySpace())
            {
                AudioManager.instance.PlayAudio(AudioClipType.grabClip);
                bagController.AddProductToBag(productData);
                Debug.Log("Fideye dokunuldu");
                isReadyToPick = false;
                StartCoroutine(ProductPicked());

            }
        }
    }
    IEnumerator ProductPicked()
    {
        float duration = 1f;
        float timer = 0;

        Vector3 targetScale = originalScale / 3;
        while(timer < duration)
        {
            float t = timer / duration;
            Vector3 newScale = Vector3.Lerp(originalScale, targetScale, t);
            transform.localScale = newScale;
            timer += Time.deltaTime;
            yield return null;

        }
        yield return new WaitForSeconds(5f);
        timer = 0f;
        float growBackDuration = 1f;

        while(timer < growBackDuration)
        {
            float t = timer / growBackDuration;
            Vector3 newScale = Vector3.Lerp(targetScale, originalScale, t);
            transform.localScale = newScale;
            timer += Time.deltaTime;
            yield return null;
        }
        isReadyToPick = true;
        yield return null;

    }
}
