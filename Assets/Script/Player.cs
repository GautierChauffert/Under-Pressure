using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public float returnSpeed = 1f;
    public float baseSpeed = 100f;
    public float currentSpeed ;
    public float speedMax = 200f;
    public float  speedMin = 0f;
    [HideInInspector]
    public List<Card> cards = new List<Card>();
    [HideInInspector]
    public bool speedPermit = true;
    [HideInInspector]
    public bool untouchable = false;
    public PoolCards bankCard;
    private float distance;
    public int playerName;
    public PlayerUI playerUI;
    public ListSoundEffect audioProducer;

    public Sprite playerIcon;
    

    private void Start()
    {
        currentSpeed = baseSpeed;
        distance = 0f;

    }


    private void Update()
    {
       if(speedPermit)
       {
             ReturnBase();
       }

        ModifyDistance();
    }


    

    void ReturnBase()
    {

        if(currentSpeed < baseSpeed)
        {
           currentSpeed += Time.deltaTime * returnSpeed;

        }
        else if (currentSpeed > baseSpeed)
        {
            currentSpeed -= Time.deltaTime * returnSpeed;

        }

    }

  public void AddCard(Card c)
    {
        cards.Add(c);
        playerUI.AddCard(c);
        audioProducer.PlaySlide();
        if(cards.Count > 3)
        {
            RemoveCard (cards[Random.Range(0,cards.Count)]) ;
        }

    }

    void RemoveCard(Card c)
    {
        bankCard.DisposeCard(c);
        cards.Remove(c);
        playerUI.RemoveCard(c);
    }


    private void ModifyDistance()
    {
        distance += currentSpeed * Time.deltaTime;

    }

    public float getDistance() { return distance; }

    public void PlayCard(int cardIndex, Player target)
    {
        if (cards.Count > 0 && !target.untouchable)
        {
            cards[cardIndex].PlayCard(target);
            audioProducer.PlaySoundOfCard(cards[cardIndex]);
                
            RemoveCard(cards[cardIndex]);
        }

    }


    

}
