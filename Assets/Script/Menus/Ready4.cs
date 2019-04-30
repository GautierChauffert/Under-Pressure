using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ready4 : MonoBehaviour
{
    public GameObject panel;
    public GameObject text;
    public static bool j4Ready = false;
    public AudioSource clic;


    void Update()
    {
        if (Input.GetButtonDown("Player4Select"))
        {
            clic.Play();
            text.SetActive(false);
            panel.SetActive(true);
            j4Ready = true;

        }
    }
}
