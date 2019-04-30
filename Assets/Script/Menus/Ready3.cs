using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ready3 : MonoBehaviour
{
    public GameObject panel;
    public GameObject text;
    public static bool j3Ready = false;
    public AudioSource clic;

    void Update()
    {
        if (Input.GetButtonDown("Player3Select"))
        {
            clic.Play();
            text.SetActive(false);
            panel.SetActive(true);
            j3Ready = true;

        }
    }
}
