using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContextController : MonoBehaviour
{
    public TextMeshProUGUI contextTextUI;
    public Image contextImageUI;
    public Transform optionsParent;
    public GameObject optionButtonPrefab;


    private Context currentContext;

    public void StartContext(string contextId)
    {
        Debug.Log("Start " + contextId);
        var context = ContextManager.Instance.GetContextById(contextId);
        if (context == null) return;

        currentContext = context;
        DisplayContext();
    }

    void DisplayContext()
    {
        contextTextUI.text = currentContext.contextText;
        contextImageUI.sprite = currentContext.themeImage;

        foreach (Transform child in optionsParent)
            Destroy(child.gameObject);

        foreach (var option in currentContext.options)
        {
            var btn = Instantiate(optionButtonPrefab, optionsParent);
            btn.GetComponentInChildren<Text>().text = option.text;

            btn.GetComponent<Button>().onClick.AddListener(() =>
            {
                option.Select();
                if (!option.endsContext)
                {
                    StartContext(option.nextContextId);
                }
                else
                {
                    Debug.Log("Kết thúc context.");
                }
            });
        }
    }
}
