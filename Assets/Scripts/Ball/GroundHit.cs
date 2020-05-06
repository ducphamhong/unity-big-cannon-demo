using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class GroundHit : MonoBehaviour
{
    public Collider Ground;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void StopFlying()
    {
        // hit the ground
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;

        Collider[] colliders = GetComponents<Collider>();
        foreach (Collider c in colliders)
            c.enabled = false;

        Flying fly = GetComponent<Flying>();
        if (fly != null)
            fly.End();
    }

    private void UpdateScored()
    {
        GameState gs = GameState.Instance;
        gs.DistanceScored = gs.DistanceScored + gs.FlyScore;
        gs.FlyScore = 0.0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameState gs = GameState.Instance;

        if (other == Ground)
        {
            StopFlying();
            UpdateScored();

            // game over when this ball hit ground
            gs.GameOver();
        }
        else
        {
            StopFlying();
            UpdateScored();

            // new turn
            gs.NewTurn();
        }
    }
}
