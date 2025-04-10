using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContextUIHandler : MonoBehaviour
{
    [Header("UI Components")]
    public TextMeshProUGUI contextTextUI;
    public Image contextImageUI;
    public Transform optionsParent;
    public GameObject optionButtonPrefab;

    private void OnEnable()
    {
        if (ContextController.Instance != null)
            ContextController.Instance.RegisterListener(DisplayContext);
    }

    private void OnDisable()
    {
        if (ContextController.Instance != null)
            ContextController.Instance.UnregisterListener(DisplayContext);
    }

    void DisplayContext(Context context)
    {
        // UI đang không active -> bỏ qua (ví dụ canvas này không dành cho context hiện tại)
        if (!this.gameObject.activeInHierarchy)
            return;

        contextTextUI.text = context.contextText;
        contextImageUI.sprite = context.themeImage;

        foreach (Transform child in optionsParent)
            Destroy(child.gameObject);

        foreach (var option in context.options)
        {
            var btn = Instantiate(optionButtonPrefab, optionsParent);
            btn.GetComponentInChildren<Text>().text = option.text;

            btn.GetComponent<Button>().onClick.AddListener(() =>
            {
                ContextController.Instance.SelectOption(option);
            });
        }
    }
}
