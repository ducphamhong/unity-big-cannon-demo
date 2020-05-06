using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject BallPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject SpawnBall(Vector3 position)
    {
        if (BallPrefab != null)
        {
            GameObject ball = GameObject.Instantiate(BallPrefab);
            ball.transform.parent = this.transform;
            ball.transform.position = position;
            return ball;
        }

        return null;
    }
}
