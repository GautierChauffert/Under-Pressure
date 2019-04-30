using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Aide : MonoBehaviour
{
    public GameObject regles;
    public GameObject cartes;
    public GameObject aide;


    void Update()
    {
        if (Input.GetButtonDown("Player1Select") && regles.active)
        {
            cartes.SetActive(true);
            regles.SetActive(false);
        }

        else if (Input.GetButtonDown("Player1Select") && cartes.active)
        {
            aide.SetActive(true);
            cartes.SetActive(false);
        }
        
        else if (Input.GetButtonDown("Player1Select") && aide.active)
        {
            aide.SetActive(false);
            //regles.SetActive(true);
            LoadMenu();
        }


        if (Input.GetButtonDown("Player1Cancel") && cartes.active)
        {
            cartes.SetActive(false);
            regles.SetActive(true);
        }

        else if (Input.GetButtonDown("Player1Cancel") && aide.active)
        {
            aide.SetActive(false);
            cartes.SetActive(true);
        }  
    }



    public void LoadMenu()
    {
        SceneManager.LoadScene("00_Menu");
    }
}
