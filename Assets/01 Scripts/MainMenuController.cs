using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : M_MonoBehaviour
{
    [SerializeField] private Button _start;
    [SerializeField] private Button _exit;

    private void Start()
    {
        _start.onClick.AddListener(()=>
        {
            GameManager.Instance.StartGame();
        });
        _exit.onClick.AddListener(() =>
        {
            GameManager.Instance.ExitGame();
        });
    }
}
