using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GSGameOver : GSBase
{
    public Text Score;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        Animator animtor = GetComponent<Animator>();
        animtor.SetBool("ANIM_IN", true);

        GameState gs = GameState.Instance;
        float currentScored = gs.DistanceScored + gs.FlyScore;
        if (Score != null)
        {
            Score.text = string.Format("Your Score\n{0:0.00}", currentScored);
        }
    }

    public void Retry()
    {
        GameState.Instance.StartGame();
        GUI.Instance.ChangeState(EState.Gameplay);
    }
}
