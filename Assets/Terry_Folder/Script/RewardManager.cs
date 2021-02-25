using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardManager : MonoBehaviour
{
    public int ticketOwned = 0;
    public int totalPoints = 0;
    public int ticketGained;

    public Text totalPointsTextField;
    public Text ticketToBeRewardTextField;

    public static RewardManager instance;

    public void SkeeBallPointSystem(int holeAmount)
    {
        totalPoints += holeAmount;
        totalPointsTextField.text = totalPoints.ToString();
    }

    // After 9 balls (1 frame) has been played
    public void SkeeBallGameOver() 
    {
        ticketGained = Mathf.RoundToInt(totalPoints /20);
        ticketOwned += ticketGained;
        ticketToBeRewardTextField.text = "You won " +ticketGained+ " tickets!";
    }
}
