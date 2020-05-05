using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    public Transform OriginalScorePosition;

    private float flyTime;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        flyTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float dis = (transform.position - OriginalScorePosition.position).magnitude;
        GameState.Instance.FlyScore = dis;

        flyTime += Time.deltaTime;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb.velocity.magnitude == 0.0f && flyTime > 3.0f)
        {
            // this ball is stuck
            GameState.Instance.GameOver();
        }
    }
}
