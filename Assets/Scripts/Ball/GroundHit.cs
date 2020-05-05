using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class GroundHit : MonoBehaviour
{
    public Collider Ground;
    public GameObject TreeSpawner;
    public GameObject TreePrefab;
    public Cannon Cannon;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == Ground)
        {
            // hit the ground
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;

            gameObject.SetActive(false);
            if (TreePrefab != null && TreeSpawner != null)
            {
                GameObject newTree = GameObject.Instantiate(TreePrefab);
                newTree.transform.parent = TreeSpawner.transform;
                newTree.transform.position = gameObject.transform.position;

                Animator treeAnimator = newTree.GetComponent<Animator>();
                if (treeAnimator != null)
                {
                    newTree.transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
                    treeAnimator.SetBool("GROW", true);
                }
            }

            if (Cannon != null)
            {
                Cannon.ResetState();
            }

            // recalc score
            GameState gs = GameState.Instance;
            gs.DistanceScored = gs.DistanceScored + gs.FlyScore;
            gs.FlyScore = 0.0f;
        }
    }
}
