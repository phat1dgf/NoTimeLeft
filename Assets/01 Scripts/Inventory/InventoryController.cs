using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : M_MonoBehaviour
{
    [SerializeField] private GameObject _inventoryMenu;
    [SerializeField] private GameObject _playerStatsUI;
    [SerializeField] private bool _menuActivated;

    protected override void Reset()
    {
        base.Reset();
        _inventoryMenu.SetActive(false);
        _playerStatsUI.SetActive(false);
    }
    private void Update()
    {
        if(InputManager.Instance.IsTabInventory && _menuActivated)
        {
            Time.timeScale = 1;
            _inventoryMenu.SetActive(false);
            _playerStatsUI.SetActive(false);
            _menuActivated = false;
        }
        else if(InputManager.Instance.IsTabInventory && !_menuActivated)
        {
            Time.timeScale = 0;
            _inventoryMenu.SetActive(true);
            _playerStatsUI.SetActive(true);
            _menuActivated = true;
        }
    }
}
