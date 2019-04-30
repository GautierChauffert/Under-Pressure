using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Ready : MonoBehaviour
{
    public GameObject panel;
    public GameObject text;
    public static bool j1Ready= false;
    public AudioSource clic;
    

    void Update()
    {
        if (Input.GetButtonDown("Player1Select"))
        {
            clic.Play();
            text.SetActive(false);
            panel.SetActive(true);
            j1Ready = true;
            
        }
    }
}
