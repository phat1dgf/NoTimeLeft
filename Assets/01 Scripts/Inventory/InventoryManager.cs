using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : M_MonoBehaviour
{
    private static InventoryManager _instance;
    public static InventoryManager Instance => _instance;


    [SerializeField] private GameObject _inventoryMenu;
    [SerializeField] private GameObject _playerStatsUI;
    [SerializeField] private bool _menuActivated;

    public ItemSlot[] itemSlot;
    public ItemSO[] itemSOs;

    public PlayerStats playerStats;

    protected override void Awake()
    {
        base.Awake();
        if(_instance == null)
        {
            _instance = this;
            return;
        }
        if(_instance.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
        {
            Destroy(this.gameObject);
        }
        
    }

   

    protected override void Reset()
    {
        base.Reset();
        _inventoryMenu.SetActive(false);
        _playerStatsUI.SetActive(false);
    }
    private void Update()
    {
        if (InputManager.Instance.IsTabInventory && _menuActivated)
        {
            Time.timeScale = 1;
            _inventoryMenu.SetActive(false);
            _playerStatsUI.SetActive(false);
            _menuActivated = false;
        }
        else if (InputManager.Instance.IsTabInventory && !_menuActivated)
        {
            Time.timeScale = 0;
            _inventoryMenu.SetActive(true);
            _playerStatsUI.SetActive(true);
            _menuActivated = true;
        }
    }

    public bool UseItem(string itemName)
    {
        for(int i = 0; i < itemSOs.Length; i++)
        {
            if (itemSOs[i].itemName == itemName)
            {
                bool usable = itemSOs[i].UseItem(playerStats);
                return usable;
            } 
        }
        return false;

    }

    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i]._itemName == itemName && itemSlot[i]._quantity > 0)
            {
                itemSlot[i]._quantity += quantity;
                itemSlot[i].UpdateSlotUI();
                return;
            }
        }

        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i]._quantity <= 0)
            {
                itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription);
                return;
            }
        }
    }


    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].isItemSelected = false;
        }
    }
}
