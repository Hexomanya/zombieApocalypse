using Assets.Scripts.Actors.Interfaces;
using UnityEngine;

public class MeleeAnimation : StateMachineBehaviour
{
    private Vector3 targetPos;
    private Vector3 dir;
    private Vector3 startPos;
    private float playTime = 0f;
    private float velocity = 10f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        startPos = animator.transform.position;
        targetPos = animator.transform.parent.parent.GetComponent<IActor>().CurrentMeleeTarget.transform.position;
        dir = targetPos - animator.transform.position;
        dir = dir.normalized;
        playTime = 0f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(playTime >= stateInfo.length / 2f)
        {
            dir *= -1f;
        }

        animator.gameObject.transform.position += dir * Time.deltaTime * velocity;
        playTime += Time.deltaTime;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = startPos;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
