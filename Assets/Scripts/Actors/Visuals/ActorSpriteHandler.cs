using Assets.Scripts.Actors;
using Assets.Scripts.Actors.ActorStates;
using Assets.Scripts.Actors.Interfaces;
using UnityEngine;

public class ActorSpriteHandler : MonoBehaviour
{
    public GameObject front;
    public GameObject back;
    public GameObject right;
    public GameObject left;
    private IActor actor;

    private void Start()
    {
        actor = GetComponentInParent<IActor>();
    }

    private void Update()
    {
        if (actor.CurrentState is IdleState)
        {
            front.SetActive(true);
            back.SetActive(false);
            right.SetActive(false);
            left.SetActive(false);
            return;
        }

        float angle;
        if (actor.CurrentState is MeleeState)
        {
            angle = GetAngle(actor.CurrentMeleeTarget.transform.position - gameObject.transform.position);
        }
        else
        {
            angle = GetAngle(actor.AstarAI.velocity);
        }
         
        if (angle <= 90f)
        {
            front.SetActive(false);
            back.SetActive(false);
            right.SetActive(true);
            left.SetActive(false);
        }
        else if (angle <= 180f)
        {
            front.SetActive(false);
            back.SetActive(true);
            right.SetActive(false);
            left.SetActive(false);
        }
        else if (angle <= 270f)
        {
            front.SetActive(false);
            back.SetActive(false);
            right.SetActive(false);
            left.SetActive(true);
        }
        else
        {
            front.SetActive(true);
            back.SetActive(false);
            right.SetActive(false);
            left.SetActive(false);
        }
    }

    private float GetAngle(Vector3 target)
    {
        return Quaternion.FromToRotation(new Vector3(1f, -1f, 0f), target.normalized).eulerAngles.z;
    }

    public void SetSprite(Sprite sprite, SpriteOrientation orientation, BodyPartType bodyPartType)
    {
        switch (orientation)
        {
            case SpriteOrientation.Front:
                front.GetComponent<SpriteSetter>().SetSprite(sprite, bodyPartType);
                break;
            case SpriteOrientation.Back:
                back.GetComponent<SpriteSetter>().SetSprite(sprite, bodyPartType);
                break;
            case SpriteOrientation.LeftSide:
                left.GetComponent<SpriteSetter>().SetSprite(sprite, bodyPartType);
                break;
            case SpriteOrientation.RightSide:
                right.GetComponent<SpriteSetter>().SetSprite(sprite, bodyPartType);
                break;
        }
    }

    public void EnableRenderBodyPart(BodyPartType bodyPartType)
    {
        front.GetComponent<SpriteSetter>().ActivateRenderer(bodyPartType);
        back.GetComponent<SpriteSetter>().ActivateRenderer(bodyPartType);
        right.GetComponent<SpriteSetter>().ActivateRenderer(bodyPartType);
        left.GetComponent<SpriteSetter>().ActivateRenderer(bodyPartType);
    }
}
