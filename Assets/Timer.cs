using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    private float Minute = 0, seconde = 0;
    private float time = 0;
    public Race raceData;

    [SerializeField]
    private TextMeshProUGUI timerText;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>();
        time = raceData.RaceTime;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        calculTime();
    }

    private void calculTime()
    {
        Minute = Mathf.Floor(time / 60);
        seconde = Mathf.Floor(time % 60);
        timerText.SetText(Minute + " : " + seconde);


    }
}
