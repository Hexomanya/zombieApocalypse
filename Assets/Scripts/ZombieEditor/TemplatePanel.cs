using UnityEngine;

public class TemplatePanel : MonoBehaviour
{
    public GameObject uiBodyPart;

    public BodyPartType bodyPartType;

    public void InitializeUI(BodyPartManager zombie)
    {
        UpdateUI(zombie);
    }

    public void UpdateUI(BodyPartManager zombie)
    {
        ClearUI();
        if(zombie.currentBodyParts[(int) bodyPartType] != null)
        {
            Instantiate(uiBodyPart, transform);
        }
    }

    public void ClearUI()
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);
    }
}
