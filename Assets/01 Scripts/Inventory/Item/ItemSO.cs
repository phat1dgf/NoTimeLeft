using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ItemData", menuName = "Game/ItemSO")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public StatToChange stat = new StatToChange();
    public int amountToChangeStat;
    public Sprite sprite;

    public bool UseItem()
    {
        PlayerStats playerStats = playerController.Instance.PlayerStats;

        if (stat == StatToChange.Food)
        {
            if (playerStats.Food == playerStats.MaxFood) 
                return false;
            else
            {
                playerStats.AddFood(amountToChangeStat);
                return true;
            }
        }
        if (stat == StatToChange.Energy)
        {
            if (playerStats.Energy == playerStats.MaxEnergy)
                return false;
            else
            {
                playerStats.AddEnergy(amountToChangeStat);
                return true;
            }
        }
        if (stat == StatToChange.Fuel)
        {
            if (playerStats.Fuel == playerStats.MaxFuel)
                return false;
            else
            {
                playerStats.AddFuel(amountToChangeStat);
                return true;
            }
        }
        return false;
    }

    public enum StatToChange
    {
        Food,
        Energy,
        Fuel
    }
}
