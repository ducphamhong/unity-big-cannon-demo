using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Cannon : MonoBehaviour
{
    public Transform CannonRotate;
    public Transform CannonScale;
    public Transform BulletPosition;
    public Transform Roof;

    public float MinForce = 10.0f;
    public float MaxForce = 50.0f;

    public float MinRotate = 10.0f;
    public float MaxRotate = 80.0f;

    public float RotateSpeed = 20.0f;
    public float ShootAngle = 0.0f;

    public float ShootForceRatio = 0.0f;
    public float ShootForceSpeed = 0.4f;

    public float MaxChargeScale = 1.5f;
    public float MaxShakeAmount = 0.015f;
    public float MaxShakeSpeed = 40.0f;

    public BallSpawner BallSpawner;
    public TreeSpawner TreeSpawner;

    public ParticleSystem ExplosionParticle;

    private float cannonScale = 1.0f;
    private float cannonTargetScale = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        ResetRotate();
    }

    public void ResetRotate()
    {
        ShootAngle = 0.0f;
        float min = Mathf.Min(MinRotate, MaxRotate);
        float max = Mathf.Max(MinRotate, MaxRotate);
        ShootAngle = Mathf.Clamp(ShootAngle, -max, -min);
        CannonRotate.localRotation = Quaternion.Euler(ShootAngle, 0.0f, 0.0f);
    }

    public void ResetState()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetBool("AIM", true);
        animator.SetBool("GAME_OVER", false);

        ShootForceRatio = 0.0f;

        ResetRotate();

        SetScale(1.0f, false);
    }

    public void SetScale(float scale, bool force)
    {
        if (force)
        {
            cannonScale = scale;
            cannonTargetScale = scale;
        }
        else
        {
            cannonTargetScale = scale;
        }

        if (CannonScale != null)
            CannonScale.localScale = new Vector3(cannonScale, cannonScale, cannonScale);
    }

    public void PlayExplosiveParticle()
    {
        if (ExplosionParticle != null)
        {
            ExplosionParticle.gameObject.SetActive(true);
            ExplosionParticle.Play(true);
        }
    }

    public float GetCannonScale()
    {
        return cannonScale;
    }

    public void SetShake(float amount, float speed)
    {
        if (CannonScale != null)
        {
            Vector3 pos = CannonScale.localPosition;
            pos.x = Mathf.Sin(Time.time * speed) * amount;
            CannonScale.localPosition = pos;
        }
    }

    public Vector3 GetRoofPosition()
    {
        return Roof.position;
    }

    // Update is called once per frame
    void Update()
    {
        cannonScale = cannonScale + (cannonTargetScale - cannonScale) * Time.deltaTime * 3.0f;
        if (CannonScale != null)
            CannonScale.localScale = new Vector3(cannonScale, cannonScale, cannonScale);
    }
}
