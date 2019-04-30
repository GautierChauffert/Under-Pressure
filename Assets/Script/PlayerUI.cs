using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public Player player;
    private ControlInGame cont;

    public GameObject cardPrefab;
    public GameObject cardHolder;

    public GameObject buffPrefab;
    public GameObject buffHolder;

   // public TextMeshProUGUI playerName;
   // public TextMeshProUGUI score;

    public Slider stressBar;
   
    public void AddCard(Card c)
    {
        GameObject temp = Instantiate(cardPrefab);
        temp.name = c.nameCard;
        temp.transform.SetParent(cardHolder.transform);
        var temp2 = temp.GetComponent<CardsExposer>().GetCard();
        temp2.GetComponent<CardUI>().GetCardSprite(c.cardSprite);
        temp.transform.localScale = Vector3.one;
        if (!cont) cont = player.GetComponent<ControlInGame>();
        cont.HighlightUI(cont.cardIndexSelected);

    }

    public void AddBuff(Card c)
    {
        GameObject temp = Instantiate(buffPrefab);
        temp.name = c.nameCard;
        temp.transform.SetParent(buffHolder.transform);
        temp.GetComponent<CardUI>().GetBuffSprite(c.BuffIcon);
       

    }

    public void RemoveBuff(Card c)
    {
        Destroy(buffHolder.transform.Find(c.nameCard).gameObject);
    }

    public void RemoveCard(Card c)
    {

        Destroy(cardHolder.transform.Find(c.nameCard).gameObject);
    }

    private void Start()
    {
        cont = player.GetComponent<ControlInGame>();
        //playerName.SetText(player.name);
        SetSlider();
    }
    private void Update()
    {
        UpdateSlider();
       // UpdateScore();
    }

   /* private void UpdateScore()
    {
        score.SetText("score : " + Mathf.Floor(player.getDistance()));
    }*/

    private void SetSlider()
    {
        stressBar.maxValue = player.speedMax;
        stressBar.value = player.baseSpeed;
    }
    private void UpdateSlider()
    {
        stressBar.value = Mathf.Floor(player.currentSpeed);
    }
}
