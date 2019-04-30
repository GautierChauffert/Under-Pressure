using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class flashingText : MonoBehaviour
{
    public float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 0.5f)
        {
            GetComponent<TextMeshProUGUI>().enabled = true;
        }
        if(timer >= 1)
        {
            GetComponent<TextMeshProUGUI>().enabled = false;
            timer = 0;
        }
    }
}
