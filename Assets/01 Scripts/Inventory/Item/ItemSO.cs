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

    public bool UseItem(PlayerStats playerStats)
    {
        if (playerStats == null)
        {
            Debug.LogError("PlayerStats is null when using item.");
            return false;
        }

        switch (stat)
        {
            case StatToChange.Food:
                if (playerStats.Food == playerStats.MaxFood) return false;
                playerStats.AddFood(amountToChangeStat);
                return true;
            case StatToChange.Energy:
                if (playerStats.Energy == playerStats.MaxEnergy) return false;
                playerStats.AddEnergy(amountToChangeStat);
                return true;
            case StatToChange.Fuel:
                if (playerStats.Fuel == playerStats.MaxFuel) return false;
                playerStats.AddFuel(amountToChangeStat);
                return true;
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
