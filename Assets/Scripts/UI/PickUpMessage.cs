using TMPro;
using UnityEngine;

public class PickUpMessage : MonoBehaviour
{
    public float Height { get; set; }
    public float TTL = 10f;
    public TextMeshProUGUI TextMeshProUGUI;

    public void SetText(string text)
    {
        TextMeshProUGUI.text = $"+1 {text}";
    }
}
