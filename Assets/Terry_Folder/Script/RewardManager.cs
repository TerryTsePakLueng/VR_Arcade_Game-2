using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardManager : MonoBehaviour
{
    public int ticketOwned = 0;
    public int totalPoints = 0;
    public Text totalPointsTextField;
    public Text ticketToBeRewardTextField;

    public void SkeeBallRewardSystem(int holeAmount)
    {
        totalPoints += holeAmount;
        totalPointsTextField.text = totalPoints.ToString();
    }

    // After 9 balls (1 frame) has been played
    public void SkeeBallGameOver() 
    {
        if (totalPoints >= 100)
        {
            ticketOwned += 5;
            ticketToBeRewardTextField.text = "You won 5 tickets!";
        }
        else if (totalPoints >= 150)
        {
            ticketOwned += 7;
            ticketToBeRewardTextField.text = "You won 7 tickets!";
        }
        else if (totalPoints >= 200)
        {
            ticketOwned += 10;
            ticketToBeRewardTextField.text = "You won 10 tickets!";
        }
        else if (totalPoints >= 300)
        {
            ticketOwned += 13;
            ticketToBeRewardTextField.text = "You won 13 tickets!";
        }
        else if (totalPoints >= 400)
        {
            ticketOwned += 15;
            ticketToBeRewardTextField.text = "You won 15 tickets!";
        }
        else if (totalPoints >= 500)
        {
            ticketOwned += 25;
            ticketToBeRewardTextField.text = "You won 25 tickets!";
        }
        else
        {
            ticketOwned += 1;
            ticketToBeRewardTextField.text = "You won 1 tickets!";
        }         
    }

    //public void SkeeBallGameOver()
    //{
    //    if (totalPoints >= 100)
    //    {
    //        ticketOwned += 5;
    //        ticketToBeRewardTextField.text = "You won 5 tickets!";
    //    }
    //    else if (totalPoints >= 150)
    //    {
    //        ticketOwned += 7;
    //        ticketToBeRewardTextField.text = "You won 7 tickets!";
    //    }
    //    else if (totalPoints >= 200)
    //    {
    //        ticketOwned += 10;
    //        ticketToBeRewardTextField.text = "You won 10 tickets!";
    //    }
    //    else if (totalPoints >= 300)
    //    {
    //        ticketOwned += 13;
    //        ticketToBeRewardTextField.text = "You won 13 tickets!";
    //    }
    //    else if (totalPoints >= 400)
    //    {
    //        ticketOwned += 15;
    //        ticketToBeRewardTextField.text = "You won 15 tickets!";
    //    }
    //    else if (totalPoints >= 500)
    //    {
    //        ticketOwned += 25;
    //        ticketToBeRewardTextField.text = "You won 25 tickets!";
    //    }
    //    else
    //    {
    //        ticketOwned += 1;
    //        ticketToBeRewardTextField.text = "You won 1 tickets!";
    //    }
    //}
}
