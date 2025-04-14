using System.Collections.Generic;
using UnityEngine;

public class ContextManager : MonoBehaviour
{
    public static ContextManager Instance { get; private set; }

    public ContextDatabase database;
    private Dictionary<string, Context> contextMap = new();

    public ItemSO bottle;
    public ItemSO candy;
    public ItemSO chocoBar;
    public ItemSO cigar;
    public ItemSO energyDrink;
    public ItemSO hamburger;

    public InventoryManager inventory;
    public PlayerStats playerStats;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        LoadDatabase();
    }

    private void LoadDatabase()
    {
        foreach (var data in database.contexts)
        {
            var context = new Context
            {
                contextId = data.contextId,
                contextText = data.contextText,
                themeImage = data.themeImage,
                canvasType = data.canvasType
            };

            foreach (var opt in data.options)
            {
                var option = new ContextOption
                {
                    text = opt.text,
                    nextContextId = opt.nextContextId,
                    endsContext = opt.endsContext,
                    onSelected = GetActionFromID(opt.actionId)
                };
                context.options.Add(option);
            }

            contextMap[context.contextId] = context;
        }
    }

    public Context GetContextById(string id)
    {
        if (contextMap.TryGetValue(id, out var ctx))
            return ctx;

        Debug.LogWarning($"Context ID '{id}' not found.");
        return null;
    }

    private System.Action GetActionFromID(ActionID actionId)
    {
        return actionId switch
        {
            ActionID.NextContext => () => Debug.Log("Chuyển tới context kế"),
            ActionID.Drive1 => () =>
            {
                GameManager.Instance.Drive(3);
                playerStats.ReduceEnergy(1);
                playerStats.ReduceFood(2);
                playerStats.ReduceFuel(2);
                GameManager.Instance.MoveToDriveGame();
            }
            ,
            ActionID.Drive2 => () =>
            {
                GameManager.Instance.Drive(6);
                playerStats.ReduceEnergy(4);
                playerStats.ReduceFood(5);
                playerStats.ReduceFuel(6);
                GameManager.Instance.MoveToDriveGame();
            }
            ,
            ActionID.Drive3 => () =>
            {
                GameManager.Instance.Drive(4);
                playerStats.ReduceEnergy(3);
                playerStats.ReduceFood(4);
                playerStats.ReduceFuel(3);
                GameManager.Instance.MoveToDriveGame();
            }
            ,
            ActionID.Drive4 => () =>
            {
                GameManager.Instance.Drive(3);
                playerStats.ReduceEnergy(3);
                playerStats.ReduceFood(3);
                playerStats.ReduceFuel(2);
                ContextController.Instance.StartContext(CONSTANT.ContextID_ending1);
            }
            ,
            ActionID.Refuel => () =>
            {
                playerStats.AddFuel(5);
                GameManager.Instance.Refuel();
            }
            ,
            ActionID.Sleep => () => 
            {
                playerStats.ReduceFood(3);
                playerStats.AddEnergy(3);
                GameManager.Instance.Sleep();
            },
            ActionID.AddItem_Bottle => () => inventory.AddItem(bottle.itemName,1,bottle.sprite,"+2 Food"),
            ActionID.AddItem_Candy => () => inventory.AddItem(candy.itemName,1,candy.sprite,"+1 Food"),
            ActionID.AddItem_Cigar => () => inventory.AddItem(cigar.itemName,1,cigar.sprite,"+3 Energy"),
            ActionID.AddItem_ChocoBar => () => inventory.AddItem(chocoBar.itemName,1,chocoBar.sprite,"+1 Food"),
            ActionID.AddItem_EnergyDrink => () => inventory.AddItem(energyDrink.itemName,1,energyDrink.sprite, "+3 Energy"),
            ActionID.AddItem_Hamburger => () => inventory.AddItem(hamburger.itemName,1,hamburger.sprite,"+3 Food"),
            ActionID.MainMenu => () => GameManager.Instance.MoveToMainMenu(),
            _ => null
        };
    }
}
