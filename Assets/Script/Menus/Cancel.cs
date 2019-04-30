using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cancel : MonoBehaviour
{
    public GameObject credits;
    public GameObject menu;
    void Update()
    {
        if (Input.GetButtonDown("Player1Select"))
        {
            credits.SetActive(false);
            menu.SetActive(true);
        }
        
    }
}
