using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static ContextData;

public class ContextUIHandler : MonoBehaviour
{
    [Header("UI Components")]
    public TMP_Text contextTextUI;
    public Image contextImageUI;
    public Transform optionsParent;
    public GameObject optionButtonPrefab;

    public ContextController contextController;

    [Header("This Canvas Type")]
    public CanvasType canvasType;
    
    private void OnEnable()
    {
        contextController.RegisterListener(DisplayContext);
    }

    //private void OnDisable()
    //{
    //    if (ContextController.Instance != null)
    //        ContextController.Instance.UnregisterListener(DisplayContext);
    //}

    void DisplayContext(Context context)
    {
        
        Debug.Log(contextTextUI.text);
        contextTextUI.text = context.contextText;
        contextImageUI.sprite = context.themeImage;
        Debug.Log(contextTextUI.text);

        foreach (Transform child in optionsParent)
            Destroy(child.gameObject);

        foreach (var option in context.options)
        {
            var btn = Instantiate(optionButtonPrefab, optionsParent);
            btn.GetComponentInChildren<Text>().text = "> " + option.text;

            btn.GetComponent<Button>().onClick.AddListener(() =>
            {
                ContextController.Instance.SelectOption(option);
            });
        }
    }
}
