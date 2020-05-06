using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public GameObject TreePrefab;
    public PhysicMaterial TreePhysicMaterial;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnTree(Vector3 position)
    {
        GameObject newTree = GameObject.Instantiate(TreePrefab);
        newTree.transform.parent = this.transform;
        newTree.transform.position = position;

        Tree t = newTree.GetComponent<Tree>();
        if (t != null)
        {
            t.SetPhysicMaterial(TreePhysicMaterial);
        }
    }
}
