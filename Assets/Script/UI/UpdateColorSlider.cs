using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateColorSlider : MonoBehaviour
{
    [SerializeField]
    private Image img;

    [SerializeField]
    private Slider slid;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slid.value < 40f)
        {
            img.color = Color.blue;
        } else if(slid.value >= 40f && slid.value < 80f) {
            img.color = Color.green;
        }
        else if (slid.value >= 80f && slid.value < 120f)
        {
            img.color = Color.yellow;
        }
        else if (slid.value >= 120f && slid.value < 160f)
        {
            img.color = new Color(1F, 0.4847802F, 0F); 
        } else
        {
            img.color = Color.red;
        }

    }
}
