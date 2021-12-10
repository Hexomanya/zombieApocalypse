using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationPanel : MonoBehaviour
{
    public float displayTime = 3f;

    public float fadeOutTime = 0.5f;

    public static NotificationPanel instance;

    private TMP_Text _notificationText;

    private Image _image;

    private Color _imageColor;

    private Color _textColor;

    private float _currentDisplayTime;


    private void Awake()
    {
        _notificationText = GetComponentInChildren<TMP_Text>();
        _image = GetComponent<Image>();

        if (instance != null)
        {
            Debug.LogWarning("More then one NotitificationPanel instance has been found!");
            return;
        }
        instance = this;
    }

    void Start()
    {
        _imageColor = _image.color;
        _textColor = _notificationText.color;
        Hide();
    }

    void Update()
    {
        if (_currentDisplayTime > 0)
        {
            _currentDisplayTime -= Time.deltaTime;
            if (_currentDisplayTime < fadeOutTime)
                FadeOut();
        }
        else
            Hide();
    }

    private void FadeOut()
    {
        if (_currentDisplayTime < 0)
            _currentDisplayTime = 0;

        float alpha = 1 - ((fadeOutTime - _currentDisplayTime) / fadeOutTime);
        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, _image.color.a * alpha);
        _notificationText.color = new Color(_textColor.r, _textColor.g, _textColor.b, _textColor.a * alpha);
    }

    private void Hide()
    {
        _notificationText.text = "";
        _image.color = _imageColor;
        _notificationText.color = _textColor; 
        gameObject.SetActive(false);

    }

    public void ShowNotification(string notificationText)
    {
        _currentDisplayTime = displayTime;
        _notificationText.text = notificationText;
        gameObject.SetActive(true);
    }

}
