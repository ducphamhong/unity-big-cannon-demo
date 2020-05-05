using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI : MonoBehaviour
{
    enum EState
    {
        Begin,
        Gameplay
    }

    public static GUI Instance;

    public GSBase[] Gamestates;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(this);

        // Start game at begin gui
        ChangeState(GSBase.EState.Begin);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeState(GSBase.EState state)
    {
        foreach (GSBase s in Gamestates)
        {
            if (s.StateName == state)
                s.gameObject.SetActive(true);
            else
                s.gameObject.SetActive(false);
        }
    }
}
