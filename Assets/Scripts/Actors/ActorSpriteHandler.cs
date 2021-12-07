using Assets.Scripts.Actors.ActorStates;
using Assets.Scripts.Actors.Interfaces;
using UnityEngine;

public class ActorSpriteHandler : MonoBehaviour
{
    public GameObject front;
    public GameObject back;
    public GameObject side;
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
            side.SetActive(false);
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
            side.SetActive(true);
            side.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (angle <= 180f)
        {
            front.SetActive(false);
            back.SetActive(true);
            side.SetActive(false);
        }
        else if (angle <= 270f)
        {
            front.SetActive(false);
            back.SetActive(false);
            side.SetActive(true);
            side.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            front.SetActive(true);
            back.SetActive(false);
            side.SetActive(false);
        }
    }

    private float GetAngle(Vector3 target)
    {
        return Quaternion.FromToRotation(new Vector3(1f, -1f, 0f), target.normalized).eulerAngles.z;
    }
}
