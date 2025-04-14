using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RemainingTimeUI : M_MonoBehaviour
{
    [SerializeField] private TMP_Text _time;
    private void Update()
    {
        _time.text = GameManager.Instance.CountdownToDie.ToString();
    }
}
