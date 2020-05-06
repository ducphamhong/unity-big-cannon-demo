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
    private Vector3[] trajectoryPoints;

    private GameObject throwObject;

    // Start is called before the first frame update
    void Start()
    {
        trajectoryPoints = new Vector3[numOfTrajectoryPoints];
    }

    // Update is called once per frame
    void Update()
    {
        if (Ball != null && Ball.GetComponent<SphereCollider>() != null)
        {
            Animator anim = GetComponent<Animator>();
            Cannon cannon = GetComponent<Cannon>();
            LineRenderer lineRenderer = GetComponent<LineRenderer>();

            if (anim.GetBool("AIM") == true ||
                anim.GetBool("CHARGE") == true)
            {
                Vector3 shootVec = cannon.BulletPosition.forward;
                Vector3 startPos = cannon.BulletPosition.position;

                Vector3 force = shootVec * (cannon.MinForce + (cannon.MaxForce - cannon.MinForce) * cannon.ShootForceRatio);

                UpdateTrajectoryPoints(startPos, force);                

                lineRenderer.enabled = true;
                lineRenderer.positionCount = trajectoryPoints.Length;
                lineRenderer.SetPositions(trajectoryPoints);
            }
            else
            {
                lineRenderer.enabled = false;
            }
        }
    }

    public Vector3 CalcTreePosition(Vector3 startPosition, Vector3 forceVec, Vector3 roofPosOfZero)
    {
        Rigidbody rb = Ball.GetComponent<Rigidbody>();
        SphereCollider collider = Ball.GetComponent<SphereCollider>();

        float treeHeight = roofPosOfZero.y;
        float collisionHeight = treeHeight + collider.radius;

        float timestep = Time.fixedDeltaTime / Physics.defaultSolverVelocityIterations;
        Vector3 gravityAccel = Physics.gravity * timestep * timestep;

        float drag = 1.0f - timestep * rb.drag;

        Vector3 moveStep = forceVec * timestep / rb.mass;
        Vector3 pos = startPosition;
        Vector3 lastPos = startPosition;


        while (pos.y > collisionHeight)
        {
            moveStep += gravityAccel;
            moveStep *= drag;

            lastPos = pos;
            pos += moveStep;
        }

        return pos - roofPosOfZero;
    }

    void UpdateTrajectoryPoints(Vector3 startPosition, Vector3 forceVec)
    {
        Rigidbody rb = Ball.GetComponent<Rigidbody>();

        float timestep = Time.fixedDeltaTime / Physics.defaultSolverVelocityIterations;
        Vector3 gravityAccel = Physics.gravity * timestep * timestep;

        float drag = 1.0f - timestep * rb.drag;

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
