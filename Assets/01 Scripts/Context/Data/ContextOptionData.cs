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
    None,
    Damage10,
    LogEscape,
    NextContext,  
}
