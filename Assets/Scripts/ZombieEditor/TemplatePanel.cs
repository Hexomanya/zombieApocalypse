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
        foreach (var bodyPart in zombie.currentBodyParts)
        {
            if (bodyPart != null && bodyPart.type == bodyPartType)
            {
                var dragHandler = Instantiate(uiBodyPart, transform).GetComponent<DragHandler>();
                dragHandler.bodyPart = bodyPart;
            }
        }
    }

    public void ClearUI()
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);
    }
}
