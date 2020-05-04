using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    private Vector3 lastDistance;

    // Start is called before the first frame update
    void Start()
    {
        lastDistance = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dis = transform.position - lastDistance;
        lastDistance = transform.position;

        GameState.Instance.DistanceScored += dis.magnitude;
    }
}
