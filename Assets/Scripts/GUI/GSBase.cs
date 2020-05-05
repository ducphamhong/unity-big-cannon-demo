using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSBase : MonoBehaviour
{
    public enum EState
    {
        Null,
        Begin,
        Gameplay
    }

    public EState StateName = EState.Null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
