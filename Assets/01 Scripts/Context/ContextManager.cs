using System.Collections.Generic;
using UnityEngine;

public class ContextManager : MonoBehaviour
{
    public static ContextManager Instance { get; private set; }

    public ContextDatabase database;
    private Dictionary<string, Context> contextMap = new();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        LoadDatabase();
    }

    void Start()
    {
        FindObjectOfType<ContextController>().StartContext("intro");
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
            ActionID.Damage10 => () =>
            {
                // tăng 10 dame cho player
            },
            ActionID.LogEscape => () => Debug.Log("Bạn đã trốn thoát."),
            ActionID.NextContext => () =>
            {
                Debug.Log("Chuyển tới context kế");
            },
           
            _ => null
        };
    }
}
