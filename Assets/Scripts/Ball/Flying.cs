﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    public Transform OriginalScorePosition;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float dis = (transform.position - OriginalScorePosition.position).magnitude;
        GameState.Instance.FlyScore = dis;
    }
}
