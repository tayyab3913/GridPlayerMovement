using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManagerScript;

    // Update is called once per frame
    void Update()
    {
        MovementCheck();
    }

    public void SetGameManager(GameManager gameManagerScript)
    {
        this.gameManagerScript = gameManagerScript;
    }

    void MovementCheck()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameManagerScript.MovePlayer("Left");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gameManagerScript.MovePlayer("Right");
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gameManagerScript.MovePlayer("Forward");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            gameManagerScript.MovePlayer("Backward");
        }
    }
}
