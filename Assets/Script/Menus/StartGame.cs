using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
 
    public GameObject panelStart;

    void Update()
    {
        if(Ready.j1Ready && Ready2.j2Ready && Ready3.j3Ready && Ready4.j4Ready)
        {
            panelStart.SetActive(true);
        }
        if(Input.GetButtonDown("Player1Start") || Input.GetButtonDown("Player2Start") || Input.GetButtonDown("Player3Start") || Input.GetButtonDown("Player4Start"))
        {
            SceneManager.LoadScene("01_Game");
        }
     }

}
