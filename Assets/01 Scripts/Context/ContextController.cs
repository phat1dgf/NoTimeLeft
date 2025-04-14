using UnityEngine;
using System;
using System.Collections.Generic;
using static ContextData;

public class ContextController : MonoBehaviour
{
    public static ContextController Instance { get; private set; }

    [Header("Canvas Mapping")]
    public GameObject canvasConservation;
    public GameObject canvasMap;

    private Dictionary<CanvasType, GameObject> canvasMapTable;

    private Context currentContext;
    private Action<Context> onContextUpdated;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;

        // Map canvasType to actual GameObjects
        canvasMapTable = new Dictionary<CanvasType, GameObject>
        {
            { CanvasType.Main, canvasConservation },
            { CanvasType.Map, canvasMap }
        };
    }

    public void RegisterListener(Action<Context> callback)
    {
        onContextUpdated += callback;
    }

    public void UnregisterListener(Action<Context> callback)
    {
        onContextUpdated -= callback;
    }

    public void StartContext(string contextId)
    {
        var ctx = ContextManager.Instance.GetContextById(contextId);
        if (ctx != null)
        {
            ShowCanvas(ctx.canvasType);
            currentContext = ctx;
            onContextUpdated?.Invoke(ctx);
        }
        else
        {
            Debug.LogWarning($"Không tìm thấy context với ID: {contextId}");
        }
    }

    public void SelectOption(ContextOption option)
    {
        option.Select();

        if (!string.IsNullOrEmpty(option.optionId))
            ContextManager.Instance.MarkOptionUsed(option.optionId);

        if (!option.endsContext && !string.IsNullOrEmpty(option.nextContextId))
        {
            StartContext(option.nextContextId);
        }
        else
        {
            Debug.Log("Context kết thúc.");
        }

        // Cập nhật lại UI
        onContextUpdated?.Invoke(currentContext);
    }


    private void ShowCanvas(CanvasType type)
    {
        foreach (var kvp in canvasMapTable)
        {
            kvp.Value.SetActive(kvp.Key == type);
        }
    }
}
