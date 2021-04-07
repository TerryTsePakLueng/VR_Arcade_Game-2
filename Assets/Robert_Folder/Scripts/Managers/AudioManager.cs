using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Audio[] sfxAudioClips;
    public Audio[] backGroundMusic;

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
            audio.audioSource.spatialBlend = 0.8f;
            audio.audioSource.maxDistance = 50;
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
        audio.audioSource.playOnAwake = false;
    }

    public void PlayAudio(string name)
    {
        Audio a = Array.Find(sfxAudioClips, audio => audio.name == name);
    
        if(a == null)
        {
            Debug.Log("<color=red>Incorrect audio name!</color>");
            return;
        }
        Debug.Log("Sound " + a.name);
        a.audioSource.Play();
    }

    public void StopAudio(string name)
    {
        Audio a = Array.Find(sfxAudioClips, audio => audio.name == name);

        if (a == null)
        {
            Debug.Log("<color=red>Incorrect audio name!</color>");
            return;
        }
        a.audioSource.Stop();
    }

    public void PlayRadio()
    {

    }
}
