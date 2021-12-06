using TMPro;
using UnityEngine;

public class NotificationPanel : MonoBehaviour
{
    public float displayTime = 3f;

    public static NotificationPanel instance;

    private TMP_Text _notificationText;

    private float _currentDisplayTime;


    private void Awake()
    {
        _notificationText = GetComponentInChildren<TMP_Text>();
        if (instance != null)
        {
            Debug.LogWarning("More then one NotitificationPanel instance has been found!");
            return;
        }
        instance = this;
    }

    void Start()
    {
        Disapear();
    }

    void Update()
    {
        if (_currentDisplayTime > 0)
            _currentDisplayTime -= Time.deltaTime;
        else
            Disapear();
    }

    private void Disapear()
    {
        _notificationText.text = "";
        gameObject.SetActive(false);
    }

    public void ShowNotification(string notificationText)
    {
        _currentDisplayTime = displayTime;
        _notificationText.text = notificationText;
        gameObject.SetActive(true);
    }

}
