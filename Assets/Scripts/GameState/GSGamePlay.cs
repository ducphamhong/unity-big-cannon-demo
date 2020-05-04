using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GSGamePlay : MonoBehaviour
{
    public GameObject Tutorial;
    public float TutorialTime = 5.0f;

    public Text Score;

    private float showTutorialTime;
    private float scored;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnEnable()
    {
        Tutorial.SetActive(true);
        showTutorialTime = TutorialTime;
    }

    // Update is called once per frame
    void Update()
    {
        showTutorialTime = showTutorialTime - Time.deltaTime;

        GameState gs = GameState.Instance;

        if (Score != null && scored != gs.DistanceScored)
        {
            Score.text = string.Format("{0:0.00}", gs.DistanceScored);
            scored = gs.DistanceScored;
        }

        if (Tutorial != null)
        {
            if (showTutorialTime <= 0.0f)
            {
                Tutorial.SetActive(false);
            }
            else if (gs.Cannon != null)
            {
                Animator animator = gs.Cannon.GetComponent<Animator>();
                if (animator.GetBool("AIM") == true)
                {
                    Tutorial.SetActive(true);
                }
                else
                {
                    Tutorial.SetActive(false);
                }
            }
        }
    }
}
