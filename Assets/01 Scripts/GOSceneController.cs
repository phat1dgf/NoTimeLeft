using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GOSceneController : M_MonoBehaviour
{
    [SerializeField] private Button mainMenu;

    private void Start()
    {
        mainMenu.onClick.AddListener(() =>
        {
            GameManager.Instance.MoveToMainMenu();
        });
    }
}
