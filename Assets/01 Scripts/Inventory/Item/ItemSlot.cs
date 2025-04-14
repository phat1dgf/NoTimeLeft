using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : M_MonoBehaviour, IPointerClickHandler
{
    //======ITEM DATA========/
    public string _itemName;
    public int _quantity;
    public Sprite _itemSprite;
    public string _itemDescription;
    public Sprite blankSprite;

    //======ITEM SLOT========/
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image itemImage;

    //======ITEM DESCRIPTION SLOT========/
    public Image itemDescriptionImage;
    public TMP_Text itemDescriptionNameText;
    public TMP_Text itemDescriptionText;

    public GameObject selectedShader;
    public bool isItemSelected;

    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        this._itemName = itemName;
        this._quantity = quantity;
        this._itemSprite = itemSprite;
        this._itemDescription = itemDescription;

        quantityText.text = quantity.ToString();
        quantityText.enabled = true;
        itemImage.sprite = itemSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    private void OnRightClick()
    {
        throw new NotImplementedException();
    }

    private void OnLeftClick()
    {
        if (isItemSelected)
        {
            bool usable = InventoryManager.Instance.UseItem(_itemName);
            if (usable)
            {
                this._quantity -= 1;
                quantityText.text = _quantity.ToString();
                if (this._quantity <= 0)
                {
                    EmptySlot();
                }
            }

        }
        else
        {
            InventoryManager.Instance.DeselectAllSlots();
            selectedShader.SetActive(true);
            isItemSelected = true;
            itemDescriptionNameText.text = _itemName;
            itemDescriptionText.text = _itemDescription;
            itemDescriptionImage.sprite = _itemSprite;
            if(itemDescriptionImage.sprite == null)
            {
                itemDescriptionImage.sprite = blankSprite;
            }
        }
        
    }

    private void EmptySlot()
    {
        quantityText.enabled = false;
        itemImage.sprite = blankSprite;

        itemDescriptionNameText.text = "";
        itemDescriptionText.text = "";
        itemDescriptionImage.sprite = blankSprite;
    }
}
