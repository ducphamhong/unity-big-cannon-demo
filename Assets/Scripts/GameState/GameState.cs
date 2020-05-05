using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance;

    public Cannon Cannon;

    public GameObject MainCamera;
    public GameObject POVCamera;

    public float DistanceScored = 0.0f;
    public float FlyScore = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        Instance = this;

        Application.targetFrameRate = 60;
    }

    public void StartGame()
    {
        if (Cannon != null)
        {
            Cannon.GetComponent<Animator>().SetBool("AIM", true);
        }

        DistanceScored = 0.0f;
        FlyScore = 0.0f;
    }

    public void SetActiveMainCamera()
    {
        if (MainCamera != null)
            MainCamera.gameObject.SetActive(true);

        if (POVCamera != null)
            POVCamera.gameObject.SetActive(false);
    }

    public void SetActivePOVCamera()
    {
        if (MainCamera != null)
            MainCamera.gameObject.SetActive(false);

        if (POVCamera != null)
            POVCamera.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
