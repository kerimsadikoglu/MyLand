using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProductType { tomato, cabbage }
[CreateAssetMenu(fileName = "Product Data", menuName = "Scriptable Object/Product Data", order = 0)]
public class ProductData : ScriptableObject
{
    public GameObject productPrefab;
    public ProductType productType;
    public int productPrice;
}
