using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsExposer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject Card;
    [SerializeField]
    GameObject Surbrillance;

    public GameObject GetSurbrillance()
    {
        return Surbrillance;
    }

    public GameObject GetCard()
    {
        return Card;
    }
}
