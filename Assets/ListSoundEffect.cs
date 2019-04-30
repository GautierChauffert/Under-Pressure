using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListSoundEffect : MonoBehaviour
{
   public List<AudioSource> soundeffects;

   public AudioSource victorySound;

   public AudioSource invincibility;
  
   public AudioSource frozen;

    public AudioSource slideSound;


   public void PlaySoundOfCard(Card c)
    {
        if (c.IntouchableCard == true)
        {
            invincibility.Play();
        }
        else if (c.Freeze == true)
        {
            frozen.Play();
        }
        else
        {
            soundeffects[Mathf.FloorToInt(Random.Range(0, soundeffects.Count - 1))].Play();
        }

    }

    public void PlayVictory()
    {
        victorySound.Play();
    }

    public void PlaySlide()
    {
        slideSound.Play();
    }



}
