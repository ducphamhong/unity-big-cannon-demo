using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    private Transform follow;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetFollow(Transform t)
    {
        follow = t;
        if (follow != null)
        {
            this.transform.position = follow.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (follow != null)
        {
            Vector3 followPos = follow.transform.position;
            Vector3 currentPos = this.transform.position;

            this.transform.position = currentPos + (followPos - currentPos) * Time.deltaTime * 2.0f;
        }
    }
}
