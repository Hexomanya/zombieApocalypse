using TMPro;
using UnityEngine;

public class PopupCollectedHandler : MonoBehaviour
{
    private TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = GetComponentInChildren<TextMeshProUGUI>();
        textMesh.text = "Collected Body Parts:";
        foreach (var item in Inventory.instance.newParts)
        {
            textMesh.text += $"\n+1 {item.name}";
        }
    }
}
