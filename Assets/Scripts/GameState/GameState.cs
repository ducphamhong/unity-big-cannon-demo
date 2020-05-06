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

    public TreeSpawner TreeSpawner;
    public BallSpawner BallSpawner;

    public float DistanceScored = 0.0f;
    public float FlyScore = 0.0f;

    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        Instance = this;

        Application.targetFrameRate = 60;
    }

    public void NewTurn()
    {
        if (Cannon != null)
        {
            Cannon.ResetState();
        }

        SetActiveMainCamera();
    }

    public void StartGame()
    {
        if (Cannon != null)
        {
            Cannon.ResetState();
        }

        DistanceScored = 0.0f;
        FlyScore = 0.0f;

        if (TreeSpawner != null)
        {
            foreach (Transform child in TreeSpawner.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        if (BallSpawner != null)
        {
            foreach (Transform child in BallSpawner.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        SetActiveMainCamera();

        isGameOver = false;
    }

    public void GameOver()
    {
        isGameOver = true;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void SetActiveMainCamera()
    {
        if (MainCamera != null)
            MainCamera.gameObject.SetActive(true);

        if (POVCamera != null)
            POVCamera.gameObject.SetActive(false);
    }

    public void SetActivePOVCamera(Transform transform)
    {
        if (MainCamera != null)
            MainCamera.gameObject.SetActive(false);

        if (POVCamera != null)
        {
            POVCamera.gameObject.SetActive(true);
            FollowObject follow = POVCamera.GetComponent<FollowObject>();
            if (follow != null)
                follow.SetFollow(transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
