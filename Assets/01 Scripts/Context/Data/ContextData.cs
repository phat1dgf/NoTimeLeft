using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ContextData
{
    public string contextId;
    [TextArea(3, 10)] public string contextText;
    public Sprite themeImage;
    public List<ContextOptionData> options;
}
