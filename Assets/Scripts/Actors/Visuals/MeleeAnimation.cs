using Assets.Scripts.Actors.Interfaces;
using UnityEngine;

public class MeleeAnimation : StateMachineBehaviour
{
    private Vector3 targetPos;
    private Vector3 dir;
    private float playTime = 0f;
    private float velocity = 4f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.parent.localPosition = Vector3.zero;
        targetPos = animator.transform.parent.parent.parent.GetComponent<IActor>().CurrentMeleeTarget.transform.position;
        dir = targetPos - animator.transform.parent.position;
        dir = dir.normalized;
        playTime = 0f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playTime * stateInfo.speed >= stateInfo.length / 2f)
        {
            return;
        }

        if (playTime * stateInfo.speed >= stateInfo.length / 4f)
        {
            dir *= -1f;
        }

        animator.transform.parent.position += dir * Time.deltaTime * velocity;
        playTime += Time.deltaTime;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.parent.localPosition = Vector3.zero;
    }
}
