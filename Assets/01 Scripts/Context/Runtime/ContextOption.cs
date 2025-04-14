using System;

public class ContextOption
{
    public string text;
    public string nextContextId;
    public bool endsContext;
    public Action onSelected;
    public string optionId;

    public void Select()
    {
        onSelected?.Invoke();
    }
}
