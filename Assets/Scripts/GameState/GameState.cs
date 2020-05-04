using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance;

    public GSBegin GameStateBegin;
    public GSGamePlay GameStatePlay;

    public Cannon Cannon;

    public float DistanceScored = 0;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        Instance = this;
    }

    internal void StartGame()
    {
        if (GameStateBegin != null)
        {
            GameStateBegin.gameObject.SetActive(false);
        }

        if (GameStatePlay != null)
        {
            GameStatePlay.gameObject.SetActive(true);
        }

        if (Cannon != null)
        {
            Cannon.GetComponent<Animator>().SetBool("AIM", true);
        }

        DistanceScored = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
