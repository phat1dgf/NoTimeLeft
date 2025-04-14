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

    //void DisplayContext(Context context)
    //{
        
    //    contextTextUI.text = context.contextText;
    //    contextImageUI.sprite = context.themeImage;

    //    foreach (Transform child in optionsParent)
    //        Destroy(child.gameObject);

    //    foreach (var option in context.options)
    //    {
    //        var btn = Instantiate(optionButtonPrefab, optionsParent);
    //        btn.GetComponentInChildren<Text>().text = "> " + option.text;

    //        btn.GetComponent<Button>().onClick.AddListener(() =>
    //        {
    //            ContextController.Instance.SelectOption(option);
    //        });
    //    }
    //}
    void DisplayContext(Context context)
    {
        contextTextUI.text = context.contextText;
        contextImageUI.sprite = context.themeImage;

        foreach (Transform child in optionsParent)
            Destroy(child.gameObject);

        foreach (var option in context.options)
        {
            var btnGO = Instantiate(optionButtonPrefab, optionsParent);
            var btn = btnGO.GetComponent<Button>();
            var btnText = btnGO.GetComponentInChildren<Text>();

            btnText.text = "> " + option.text;

            if (!string.IsNullOrEmpty(option.optionId) && ContextManager.Instance.IsOptionUsed(option.optionId))
            {
                //// Cách 1: XÁM NÚT + VÔ HIỆU HÓA
                //btn.interactable = false;
                //btnText.color = Color.gray;

                //// Cách 2: ẨN HẲN NÚT (nếu bạn muốn)
                Destroy(btnGO);
                continue;
            }
            else
            {
                btn.onClick.AddListener(() =>
                {
                    ContextController.Instance.SelectOption(option);
                });
            }
        }
    }

}
