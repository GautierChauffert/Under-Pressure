using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic2 : MonoBehaviour
{
    public AudioSource _audioSource;
    private void Awake()
    {
        GameObject soundManager = GameObject.FindGameObjectWithTag("Music");
        if (soundManager)
        {
            soundManager.GetComponent<PlayMusic>().StopMusic();
            Destroy(soundManager);
        }
        
        _audioSource.Play();
    }

    public void PlayTheMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }

}