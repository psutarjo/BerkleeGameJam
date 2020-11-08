using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : StateMachineBehaviour
{
    // settings /////////////////////////////////////
    public float backForthSpeed;
    public float leftRightSpeed;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        backForthSpeed = animator.gameObject.GetComponent<MovementInput>().forwardSpeed;
        leftRightSpeed = animator.gameObject.GetComponent<MovementInput>().rightSpeed;
    }

    // on each frame, change player speed according to 
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Rigidbody rb = animator.gameObject.GetComponent<Rigidbody>();
        Vector3 newVelocity = new Vector3(0, rb.velocity.y, 0);
        newVelocity += (animator.GetBool("W")) ? animator.transform.forward * backForthSpeed : Vector3.zero;
        newVelocity -= (animator.GetBool("S")) ? animator.transform.forward * backForthSpeed : Vector3.zero;
        newVelocity += (animator.GetBool("A")) ? animator.transform.TransformPoint(Vector3.left) * leftRightSpeed : Vector3.zero;
        newVelocity += (animator.GetBool("D")) ? animator.transform.TransformPoint(Vector3.right) * leftRightSpeed : Vector3.zero;

        animator.gameObject.GetComponent<Rigidbody>().velocity = newVelocity;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
