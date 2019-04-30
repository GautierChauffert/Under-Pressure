using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{

    public AudioSource _audioSource;
    private void Awake()
    {
        
        DontDestroyOnLoad(transform.gameObject);

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
