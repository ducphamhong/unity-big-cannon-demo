using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GSGamePlay : GSBase
{
    public Text Score;
    private float scored;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnEnable()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameState gs = GameState.Instance;

        float currentScored = gs.DistanceScored + gs.FlyScore;
        if (Score != null && scored != currentScored)
        {
            Score.text = string.Format("{0:0.00}", currentScored);
            scored = gs.DistanceScored;
        }
    }
}
