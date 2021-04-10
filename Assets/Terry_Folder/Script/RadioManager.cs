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
        // If radio is on and playNext is true, do PlayNextMusic()
        if(radioOn)
        {
            if(playNext)
            {
                PlayNextMusic();
            }
        }
    }

    /// <summary>
    /// Plays music depending on the music index which can be randomized or starts from index 0.
    /// Turns playNext to false so it doesn't go in an infinite loop.
    /// Comes back when the clip length has ended in the coroutine and turns playNext to true;
    /// </summary>
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

    // Coroutine takes the length of the clip being played and waits until it ends and adds to the index.
    // The if statement is here so the coroutine does not stack up and add to the index, resulting in playing next while
    // the previous track hasn't ended. Stopping the coroutine does not seem to be stopping it when told to.
    IEnumerator WaitForMusicToEnd(int temp)
    {
        yield return new WaitForSeconds(radioOuput.clip.length);
        if(temp == currentMusicIndex || temp == previousIndex)
        {
            IncrementMusicIndex();
            playNext = true;
        }
    }

    // This coroutine is the same as the previous one but doesn't take a parameter as it is only used for 
    // On and Off and plying next where it doesnt need to check if the coroutine is being stacked.
    IEnumerator WaitForMusicToEnd()
    {
        yield return new WaitForSeconds(radioOuput.clip.length);
        IncrementMusicIndex();
        playNext = true;
    }

    // Increments the currentMusicIndex after a song has ended.
    public void IncrementMusicIndex()
    {
        currentMusicIndex++;
        if (currentMusicIndex == playList.Length)
        {
            currentMusicIndex = 0;
        }
    }

    // Method turns off or on the radio
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

    // Plays the next song when the button is pressed.
    public void ForcePlayNext()
    {
        StopCoroutine(WaitForMusicToEnd());
        if(!randomize)
        {
            IncrementMusicIndex();
        }
        playNext = true;
    }

    // Turn on or off randomization when button is pressed.
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
