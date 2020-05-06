using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    private Vector3 scorePosition;
    private Vector3 endPosition;

    private float flyTime;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        flyTime = 0.0f;
    }

    public void SetBaseScorePosition(Vector3 p)
    {
        scorePosition = p;
    }

    public void SetEndPosition(Vector3 p)
    {
        endPosition = p;
    }

    public void End()
    {
        transform.position = endPosition;
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float dis = (transform.position - scorePosition).magnitude;
        GameState.Instance.FlyScore = dis;

        flyTime += Time.deltaTime;
    }
}
