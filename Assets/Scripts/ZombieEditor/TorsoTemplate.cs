using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TorsoTemplate : MonoBehaviour
{
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void InitializeUI(BodyPartManager zombie)
    {
        UpdateUI(zombie);
    }

    public void UpdateUI(BodyPartManager zombie)
    {
        foreach (var bodyPart in zombie.currentBodyParts)
        {
            if (bodyPart.type == BodyPartType.Torso)
                image.sprite = bodyPart.sprite;
        }
    }
}
