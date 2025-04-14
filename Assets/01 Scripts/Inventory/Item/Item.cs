using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : M_MonoBehaviour
{
    [SerializeField] private string _itemName;
    [SerializeField] private int _quantity;
    [SerializeField] private Sprite _itemSprite;
    [TextArea]
    [SerializeField] private string itemDescription;
}
