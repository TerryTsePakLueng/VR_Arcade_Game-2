using System.Collections;
using UnityEngine;

public class RadioManager : MonoBehaviour
{
    public AudioClip[] playList;

    public AudioSource radioOuput;

    public int currentMusicIndex = 0;
    public int previousIndex = 0;
    public bool randomize = false;
    public bool playNext = true;
    public bool radioOn = true;

    private void Update()
    {
        if(radioOn)
        {
            if(playNext)
            {
                PlayNextMusic();
            }
        }
    }

    public void PlayNextMusic()
    {
        playNext = false;
        if(randomize)
        {
            int randomIndex = Random.Range(0, playList.Length);
            while(previousIndex == randomIndex)
            {
                randomIndex = Random.Range(0, playList.Length);
            }
            previousIndex = randomIndex;
            radioOuput.clip = playList[randomIndex];
        }
        else
        {
            radioOuput.clip = playList[currentMusicIndex];
            previousIndex = currentMusicIndex;
        }
        radioOuput.Play();
        int temp = previousIndex;
        StartCoroutine(WaitForMusicToEnd(temp));
    }

    IEnumerator WaitForMusicToEnd(int temp)
    {
        yield return new WaitForSeconds(radioOuput.clip.length);
        if(temp == currentMusicIndex || temp == previousIndex)
        {
            IncrementMusicIndex();
            playNext = true;
        }
    }

    IEnumerator WaitForMusicToEnd()
    {
        yield return new WaitForSeconds(radioOuput.clip.length);
        IncrementMusicIndex();
        playNext = true;
    }

    public void IncrementMusicIndex()
    {
        currentMusicIndex++;
        if (currentMusicIndex == playList.Length)
        {
            currentMusicIndex = 0;
        }
    }

    public void TurnOnOffRadio()
    {
        if (radioOn)
        {
            StopCoroutine(WaitForMusicToEnd());
            radioOuput.Stop();
            radioOn = false;
        }
        else
        {
            radioOn = true;
            playNext = true;
        }
    }

    public void ForcePlayNext()
    {
        StopCoroutine(WaitForMusicToEnd());
        if(!randomize)
        {
            IncrementMusicIndex();
        }
        playNext = true;
    }

    public void RandomizePlaylist()
    {
        if(randomize)
        {
            randomize = false;
        }
        else
        {
            randomize = true;
        }
    }
}
