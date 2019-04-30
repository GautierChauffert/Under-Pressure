using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelMusic : MonoBehaviour
{
   
    private void Awake()
    {
        GameObject soundManager = GameObject.FindGameObjectWithTag("Music");
        if (soundManager)
        {
            soundManager.GetComponent<PlayMusic>().StopMusic();
            Destroy(soundManager);
        }

       
    }

}
