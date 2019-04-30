using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTest : MonoBehaviour
{
    public GameObject player;
    public string playerName;

     
    private void Start()
    {
        playerName = player.name;
    }

    void Update()
    {
        if (Input.GetButtonDown(player.name + "Select"))
        {
            Debug.Log(player.name + " : A");
        }
        if (Input.GetButtonDown(player.name + "Cancel"))
        {
            Debug.Log(player.name + " : B");
        }
        if (Input.GetAxisRaw(playerName + "Horizontal") == 1)
        {
            Debug.Log(player.name + " : right");
        }
        if (Input.GetAxis(playerName + "Horizontal") == -1)
        {
            Debug.Log(player.name + " : left ");
        }
        if (Input.GetAxis(playerName + "Vertical") == 1)
        {
            Debug.Log(player.name + " : up ");
        }
        if (Input.GetAxis(playerName + "Vertical") == -1)
        {
            Debug.Log(player.name + " : down ");
        }
        if (Input.GetButtonDown(player.name + "Start"))
        {
            Debug.Log(player.name + " : Start");
        }

    }
}
