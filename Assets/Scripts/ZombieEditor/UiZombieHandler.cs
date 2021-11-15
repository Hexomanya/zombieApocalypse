using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiZombieHandler : MonoBehaviour
{
    public BodyPartManager BodyPartManager { get; set; }

    public int Index { get; set; } = 0;

    private Image _head;
    private Image _leftArm;
    private Image _torso;
    private Image _rightArm;
    private Image _leftFoot;
    private Image _rightFoot;


    private void Awake()
    {
        var uiBodyPartList = GetComponentsInChildren<UiBodyPart>();
        foreach (var bodyPart in uiBodyPartList)
        {
            switch (bodyPart.type)
            {
                case BodyPartType.Head:
                    _head = bodyPart.GetComponent<Image>();
                    break;

                case BodyPartType.LeftArm:
                    _leftArm = bodyPart.GetComponent<Image>();
                    break;

                case BodyPartType.Torso:
                    _torso = bodyPart.GetComponent<Image>();
                    break;

                case BodyPartType.RightArm:
                    _rightArm = bodyPart.GetComponent<Image>();
                    break;

                case BodyPartType.LeftFoot:
                    _leftFoot = bodyPart.GetComponent<Image>();
                    break;

                case BodyPartType.RightFoot:
                    _rightFoot = bodyPart.GetComponent<Image>();
                    break;
            }
        }
    }

    public void SetAsSelectedZombie()
    {
        Horde.instance.SetSelectedZombie(Index);
    }

    public void UpdateUI()
    {
        ClearUI();
        for (int i = 0; i< BodyPartManager.currentBodyParts.Length; i++)
        {
            if (BodyPartManager.currentBodyParts[i] != null)
            {
                switch (i)
                {
                    case (int)BodyPartType.Head:
                        _head.sprite = BodyPartManager.currentBodyParts[i].sprite;
                        _head.color = new Color(_head.color.r, _head.color.g, _head.color.b, 1);
                        break;

                    case (int)BodyPartType.LeftArm:
                        _leftArm.sprite = BodyPartManager.currentBodyParts[i].sprite;
                        _leftArm.color = new Color(_head.color.r, _head.color.g, _head.color.b, 1);
                        break;

                    case (int)BodyPartType.Torso:
                        _torso.sprite = BodyPartManager.currentBodyParts[i].sprite;
                        _torso.color = new Color(_head.color.r, _head.color.g, _head.color.b, 1);
                        break;

                    case (int)BodyPartType.RightArm:
                        _rightArm.sprite = BodyPartManager.currentBodyParts[i].sprite;
                        _rightArm.color = new Color(_head.color.r, _head.color.g, _head.color.b, 1);
                        break;

                    case (int)BodyPartType.LeftFoot:
                        _leftFoot.sprite = BodyPartManager.currentBodyParts[i].sprite;
                        _leftFoot.color = new Color(_head.color.r, _head.color.g, _head.color.b, 1);
                        break;

                    case (int)BodyPartType.RightFoot:
                        _rightFoot.sprite = BodyPartManager.currentBodyParts[i].sprite;
                        _rightFoot.color = new Color(_head.color.r, _head.color.g, _head.color.b, 1);
                        break;
                }
            }
        }
    }

    public void ClearUI()
    {
        _head.color = new Color(_head.color.r, _head.color.g, _head.color.b, 0);
        _leftArm.color = new Color(_head.color.r, _head.color.g, _head.color.b, 0);
        _torso.color = new Color(_head.color.r, _head.color.g, _head.color.b, 0);
        _rightArm.color = new Color(_head.color.r, _head.color.g, _head.color.b, 0);
        _leftFoot.color = new Color(_head.color.r, _head.color.g, _head.color.b, 0);
        _rightFoot.color = new Color(_head.color.r, _head.color.g, _head.color.b, 0);
    }
}
