using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Transform CannonRotate;
    public Transform CannonScale;
    public Transform BulletPosition;

    public float MinForce = 100.0f;
    public float MaxForce = 700.0f;

    public float RotateSpeed = 20.0f;
    public float ShootAngle = 0.0f;

    public GameObject Ball;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void ResetState()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetBool("AIM", true);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
