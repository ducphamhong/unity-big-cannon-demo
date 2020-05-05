using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSBegin : GSBase
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPlayButton()
    {
        GUI.Instance.ChangeState(EState.Gameplay);
        GameState.Instance.StartGame();
    }
}
