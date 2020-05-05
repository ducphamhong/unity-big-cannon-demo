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

    public Slider GUISlider;

    public float MinForce = 300.0f;
    public float MaxForce = 700.0f;

    public float RotateSpeed = 20.0f;
    public float ShootAngle = 0.0f;

    public float ShootForceRatio = 0.0f;
    public float ShootForceSpeed = 0.1f;

    public float MaxChargeScale = 1.5f;
    public float MaxShakeAmount = 0.015f;
    public float MaxShakeSpeed = 40.0f;

    public GameObject Ball;

    private float cannonScale = 1.0f;
    private float cannonTargetScale = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void ResetState()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetBool("AIM", true);

        ShootForceRatio = 0.0f;
        if (GUISlider != null)
        {
            GUISlider.gameObject.SetActive(false);
        }

        // reset scale
        SetScale(1.0f, false);

        GameState.Instance.SetActiveMainCamera();
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

    // Update is called once per frame
    void Update()
    {
        cannonScale = cannonScale + (cannonTargetScale - cannonScale) * Time.deltaTime * 3.0f;
        if (CannonScale != null)
            CannonScale.localScale = new Vector3(cannonScale, cannonScale, cannonScale);
    }
}
