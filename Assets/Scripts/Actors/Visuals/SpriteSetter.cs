using Assets.Scripts.Actors;
using UnityEngine;

public class SpriteSetter : MonoBehaviour
{
    public SpriteOrientation orientation;

    public SpriteRenderer Head;
    public SpriteRenderer LArm;
    public SpriteRenderer RArm;
    public SpriteRenderer Torso;
    public SpriteRenderer LFoot;
    public SpriteRenderer RFoot;

    public void SetSprite(Sprite sprite, BodyPartType bodyPartType)
    {
        switch (bodyPartType)
        {
            case BodyPartType.Head:
                Head.sprite = sprite;
                break;
            case BodyPartType.LeftArm:
                LArm.sprite = sprite;
                break;
            case BodyPartType.Torso:
                Torso.sprite = sprite;
                break;
            case BodyPartType.RightArm:
                RArm.sprite = sprite;
                break;
            case BodyPartType.LeftFoot:
                LFoot.sprite = sprite;
                break;
            case BodyPartType.RightFoot:
                RFoot.sprite = sprite;
                break;
        }
    }

    public void SetSpriteLayer(int zombieIndex)
    {
        int layer = 2 * zombieIndex;
        Head.sortingOrder += layer;
        LArm.sortingOrder += layer;
        RArm.sortingOrder += layer;
        Torso.sortingOrder += layer;
        LFoot.sortingOrder += layer;
        RFoot.sortingOrder += layer;
    }

    public void ActivateRenderer(BodyPartType bodyPartType)
    {
        switch (bodyPartType)
        {
            case BodyPartType.Head:
                Head.gameObject.SetActive(true);
                break;
            case BodyPartType.LeftArm:
                LArm.gameObject.SetActive(true);
                break;
            case BodyPartType.Torso:
                Torso.gameObject.SetActive(true);
                break;
            case BodyPartType.RightArm:
                RArm.gameObject.SetActive(true);
                break;
            case BodyPartType.LeftFoot:
                LFoot.gameObject.SetActive(true);
                break;
            case BodyPartType.RightFoot:
                RFoot.gameObject.SetActive(true);
                break;
        }
    }
}
