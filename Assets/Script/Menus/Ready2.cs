using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ready2 : MonoBehaviour
{
    public GameObject panel;
    public GameObject text;
    public static bool j2Ready = false;
    public AudioSource clic;

    void Update()
    {
        if (Input.GetButtonDown("Player2Select"))
        {
            clic.Play();
            text.SetActive(false);
            panel.SetActive(true);
            j2Ready = true;

        }
    }
}
