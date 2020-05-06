using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public Collider RoofCollide;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetPhysicMaterial(PhysicMaterial m)
    {
        RoofCollide.material = m;
    }
}
