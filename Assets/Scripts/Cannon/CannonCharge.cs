using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonCharge : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Cannon cannon = animator.gameObject.GetComponent<Cannon>();
        if (cannon != null)
            cannon.ShootForceRatio = 0.0f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameState gs = GameState.Instance;

        if (Input.GetKeyUp(KeyCode.Space) == true && gs.IsGameOver() == false)
        {
            animator.SetBool("SHOOT", true);
        }

        Cannon cannon = animator.gameObject.GetComponent<Cannon>();
        if (cannon != null)
        {
            cannon.ShootForceRatio = cannon.ShootForceRatio + Time.deltaTime * cannon.ShootForceSpeed;

            float scale = 1.0f + (cannon.MaxChargeScale - 1.0f) * cannon.ShootForceRatio;
            cannon.SetScale(scale, true);
            cannon.SetShake(cannon.ShootForceRatio * cannon.MaxShakeAmount, cannon.ShootForceRatio * cannon.MaxShakeSpeed);

            if (cannon.ShootForceRatio >= 1.0f)
            {
                cannon.PlayExplosiveParticle();
                cannon.SetScale(1.0f, false);

                animator.SetBool("GAME_OVER", true);
                gs.GameOver();
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("CHARGE", false);
        Cannon cannon = animator.gameObject.GetComponent<Cannon>();
        if (cannon != null)
            cannon.SetShake(0.0f, 0.0f);
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
