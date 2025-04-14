using UnityEngine;

[System.Serializable]
public class ContextOptionData
{
    public string text;
    public string nextContextId;
    public bool endsContext;
    public ActionID actionId; 
}
public enum ActionID
{
    NextContext,
    Drive,
    Refuel,
    Inventory,
    Sleep,
    Take,
    MainMenu,
    AddItem_Bottle,
    AddItem_Candy,
    AddItem_ChocoBar,
    AddItem_Cigar,
    AddItem_EnergyDrink,
    AddItem_Hamburger,
    Drive1,
    Drive2,
    Drive3,
    Drive4,
}