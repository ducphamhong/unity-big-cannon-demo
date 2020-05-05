using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cannon))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(LineRenderer))]
public class Projectile : MonoBehaviour
{
    public GameObject Ball;

    private int numOfTrajectoryPoints = 50;
    private List<Vector3> trajectoryPoints = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numOfTrajectoryPoints; i++)
        {
            trajectoryPoints.Insert(i, new Vector3());
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Ball != null)
        {
            Animator anim = GetComponent<Animator>();
            Cannon cannon = GetComponent<Cannon>();
            LineRenderer lineRenderer = GetComponent<LineRenderer>();

            if (anim.GetBool("AIM") == true ||
                anim.GetBool("CHARGE") == true)
            {
                Vector3 shootVec = cannon.BulletPosition.forward;
                Vector3 force = shootVec * (cannon.MinForce + (cannon.MaxForce - cannon.MinForce) * cannon.ShootForceRatio);

                UpdateTrajectoryPoints(cannon.BulletPosition.position, force);

                lineRenderer.enabled = true;
                lineRenderer.positionCount = trajectoryPoints.Count;
                lineRenderer.SetPositions(trajectoryPoints.ToArray());
            }
            else
            {
                lineRenderer.enabled = false;
            }
        }
    }

    void UpdateTrajectoryPoints(Vector3 startPosition, Vector3 forceVec)
    {
        Rigidbody rb = Ball.GetComponent<Rigidbody>();

        float timestep = Time.deltaTime / Physics.defaultSolverVelocityIterations;
        Vector3 gravityAccel = Physics.gravity * timestep * timestep;

        float drag = 1.0f - timestep * rb.drag;

        // f = (m * v)/t
        // v = (f * t)/m;
        Vector3 moveStep = forceVec * timestep / rb.mass;

        Vector3 pos = startPosition;
        trajectoryPoints[0] = pos;

        for (int i = 1; i < numOfTrajectoryPoints; i++)
        {
            moveStep += gravityAccel;
            moveStep *= drag;            

            pos += moveStep;

            trajectoryPoints[i] = pos;
        }
    }
}
