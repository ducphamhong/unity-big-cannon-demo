using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Cannon cannon = animator.gameObject.GetComponent<Cannon>();
        Projectile projectile = animator.gameObject.GetComponent<Projectile>();

        if (cannon != null &&
            cannon.BulletPosition != null &&
            cannon.TreeSpawner != null &&
            cannon.BallSpawner != null)
        {
            float s = cannon.GetCannonScale();
            Vector3 startPosition = cannon.BulletPosition.position;
            Vector3 shootVec = cannon.BulletPosition.forward;

            cannon.SetScale(1.0f, false);

            GameObject ball = cannon.BallSpawner.SpawnBall(startPosition);

            ball.SetActive(true);
            ball.transform.localScale = new Vector3(s, s, s);

            Flying fly = ball.GetComponent<Flying>();
            if (fly != null)
                fly.SetBaseScorePosition(startPosition);

            Rigidbody rb = ball.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 force = shootVec * (cannon.MinForce + (cannon.MaxForce - cannon.MinForce) * cannon.ShootForceRatio);
                rb.AddForce(force, ForceMode.VelocityChange);

                if (cannon.TreeSpawner != null)
                {
                    Vector3 treePosition = projectile.CalcTreePosition(startPosition, force, cannon.GetRoofPosition());
                    cannon.TreeSpawner.SpawnTree(treePosition);

                    if (fly != null)
                    {
                        Vector3 endPosition = treePosition + cannon.GetRoofPosition();
                        SphereCollider c = ball.GetComponent<SphereCollider>();
                        if (c != null)
                            endPosition.y += c.radius;

                        fly.SetEndPosition(endPosition);
                    }
                }
            }

            // change POV camera
            GameState.Instance.SetActivePOVCamera(ball.transform);
        }

        cannon.PlayExplosiveParticle();

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
