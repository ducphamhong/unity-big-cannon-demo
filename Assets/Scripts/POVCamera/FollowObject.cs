using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform Follow;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnEnable()
    {
        if (Follow != null)
        {
            this.transform.position = Follow.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Follow != null)
        {
            Vector3 followPos = Follow.transform.position;
            Vector3 currentPos = this.transform.position;

            this.transform.position = currentPos + (followPos - currentPos) * Time.deltaTime * 2.0f;
        }
    }
}
