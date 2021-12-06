using TMPro;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    public TMP_Text caption;
    public TMP_Text content;

    public static Tooltip instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More then one Tooltip instance has been found!");
            return;
        }
        instance = this;
    }

    private void Start()
    {
        HideTooltip();
    }

    public void ShowTooltip(string _caption, string _content)
    {
        caption.text = _caption;
        content.text = _content;
        transform.position = Input.mousePosition;
        gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }
}
