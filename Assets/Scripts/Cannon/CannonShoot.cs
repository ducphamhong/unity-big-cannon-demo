using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Cannon cannon = animator.gameObject.GetComponent<Cannon>();
        if (cannon != null && cannon.Ball != null && cannon.BulletPosition != null)
        {
            cannon.Ball.SetActive(true);
            cannon.Ball.transform.position = cannon.BulletPosition.position;

            Vector3 shootVec = cannon.BulletPosition.forward;
            Rigidbody rb = cannon.Ball.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(shootVec * cannon.MaxForce * cannon.ShootForceRatio);
            }
        }

        // change to end state
        animator.SetBool("END", true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("SHOOT", false);
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
