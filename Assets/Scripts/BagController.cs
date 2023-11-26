using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagController : MonoBehaviour
{

    [SerializeField] private Transform bag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        AddProductToBag(other.gameObject);
    }

    private void AddProductToBag(GameObject cube)
    {
        if (cube.CompareTag("cube"))
        {
            cube.transform.SetParent(bag, true);
            cube.transform.localRotation = Quaternion.identity;
            cube.transform.localPosition = Vector3.zero;
        }
        

    }
}
