using System.Collections.Generic;
using UnityEngine;
using static ContextData;

public class Context
{
    public string contextId;
    public string contextText;
    public Sprite themeImage;
    public List<ContextOption> options = new();
    public CanvasType canvasType;
}
