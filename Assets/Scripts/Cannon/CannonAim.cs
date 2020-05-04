using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAim : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Cannon cannon = animator.gameObject.GetComponent<Cannon>();
        if (cannon)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                cannon.ShootAngle = cannon.ShootAngle - cannon.RotateSpeed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                cannon.ShootAngle = cannon.ShootAngle + cannon.RotateSpeed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                animator.SetBool("CHARGE", true);
            }

            cannon.ShootAngle = Mathf.Clamp(cannon.ShootAngle, -80.0f, 0.0f);
            cannon.CannonRotate.localRotation = Quaternion.Euler(cannon.ShootAngle, 0.0f, 0.0f);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("AIM", false);
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
