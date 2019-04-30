using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Card")] 

public class Card : ScriptableObject
{

    public enum Rarety {green, yellow, orange, red };
    public float effectCard;
    public float effetPression;
    public string nameCard;
    public string descriptionCard;
    public float waitTime;
    public bool IntouchableCard = false;
    public bool Freeze = false;
    public Rarety rarety;
    public Sprite cardSprite;
    public Sprite BuffIcon;

    public void PlayCard(Player player)
    {
        if(effetPression !=0)
        {
            player.returnSpeed += effetPression;
           
            player.StartCoroutine(ReturnBaseSpeed(player)); 

        }

        if(IntouchableCard == true)
        {

            player.StartCoroutine(WaitSpeedPermit(player));

        }

        if(Freeze == true)
        {

            player.StartCoroutine(WaitUntouchable(player));

        }

        player.currentSpeed += effectCard;

        if(player.currentSpeed <= player.speedMin)
        {
            player.StartCoroutine(PitSprint(player));

        }
        else if(player.currentSpeed >= player.speedMax)
        {
            player.StartCoroutine(FuryStop(player));
        }

        player.StartCoroutine(BuffControl(player));
    }

    IEnumerator FuryStop(Player player)
    {
        player.currentSpeed = player.speedMin;
        player.speedPermit = false;
        yield return new WaitForSeconds(2f);
        player.currentSpeed = player.baseSpeed;
        player.speedPermit = true;
    }

    IEnumerator PitSprint(Player player)
    {
        player.currentSpeed = player.speedMax;
        player.speedPermit = false;
        yield return new WaitForSeconds(2f);
        player.currentSpeed = player.baseSpeed;
        player.speedPermit = true;
    }

    IEnumerator BuffControl(Player player)
    {
        player.playerUI.AddBuff(this);
        yield return new WaitForSeconds(waitTime);
        player.playerUI.RemoveBuff(this);
    }

    IEnumerator WaitSpeedPermit(Player player)
    {
        player.speedPermit = false;
        yield return new WaitForSeconds(waitTime);
        player.speedPermit = true; 
    }

    IEnumerator WaitUntouchable(Player player)
    {
        player.untouchable = true;
        yield return new WaitForSeconds(waitTime);
        player.untouchable = false;
    }

    IEnumerator ReturnBaseSpeed(Player player)
    {
        yield return new WaitForSeconds(waitTime);
        player.returnSpeed = 1f;
    }
}
