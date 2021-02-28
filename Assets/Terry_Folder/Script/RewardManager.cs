using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardManager : MonoBehaviour
{
    //non-minigame specific variables
    public int ticketOwned = 0;
    public int ticketGained;

    public Text ticketToBeRewardTextField;

    public static RewardManager instance;

    // After 9 balls (1 frame) has been played
    public void SkeeBallGameOver(int totalScore) 
    {
        ticketGained = Mathf.RoundToInt(totalScore /20);
        ticketOwned += ticketGained;
        ticketToBeRewardTextField.text = "You won " +ticketGained+ " tickets!";
        Debug.Log("You won " + ticketGained + " tickets!");
    }

    /// <summary>
    /// Can Knock Down Ticket System
    /// </summary>
    /// <param name="totalKnocked"></param>
    // After 4 rounds/ 4 throws
    public void CanKnockDownGameOver(int totalKnocked)
    {
        ticketGained = totalKnocked;
        ticketOwned += ticketGained;
        ticketToBeRewardTextField.text = "You won " + ticketGained + " tickets!";
        Debug.Log("You won " + ticketGained + " tickets!");
    }

    /// <summary>
    /// Shooting Game Ticket System
    /// </summary>
    /// <param name="totalPopped"></param>
    public void ShootingGameGameOver(int totalPopped)
    {
        ticketGained = totalPopped;
        ticketOwned += ticketGained;
        ticketToBeRewardTextField.text = "You won " + ticketGained + " tickets!";
        Debug.Log("You won " + ticketGained + " tickets!");
    }
}
