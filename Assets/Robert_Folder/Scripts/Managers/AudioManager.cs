using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public List<Audio> sfxAudioClips = new List<Audio>();
    public List<Audio> backGroundMusic = new List<Audio>();

    public AudioSource backGroundNoise;
    public GameObject radio;
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            instance = this;
        }
    }

    private void Start()
    {
        foreach(Audio audio in backGroundMusic)
        {
            SetAudioPeramaters(audio, radio);
            audio.audioSource.maxDistance = 10;
        }

        foreach(Audio audio in sfxAudioClips)
        {
            SetAudioPeramaters(audio, gameObject);
        }

        backGroundNoise.Play();
        PlayRadio();
    }

    public void SetAudioPeramaters(Audio audio, GameObject audioLocation)
    {
        audio.audioSource = audioLocation.AddComponent<AudioSource>();
        audio.audioSource.clip = audio.audioClip;
        audio.audioSource.pitch = audio.pitch;
        audio.audioSource.volume = audio.volume;
    }

    public void PlayAudio(string name)
    {
        Audio a = sfxAudioClips.Find(x => x.name == name);
    
        if(a == null)
        {
            Debug.Log("<color=red>Incorrect audio name!</color>");
            return;
        }
        a.audioSource.Play();
    }

    public void StopAudio(string name)
    {
        Audio a = sfxAudioClips.Find(x => x.name == name);

        if (a == null)
        {
            Debug.Log("<color=red>Incorrect audio name!</color>");
            return;
        }
        a.audioSource.Stop();
    }

    public void PlayRadio()
    {
        for(int i = 0; i < backGroundMusic.Count; i++)
        {
            backGroundMusic[i].audioSource.Play();
        }
    }
}
