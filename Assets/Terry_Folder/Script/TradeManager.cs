using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradeManager : MonoBehaviour
{
    SkeeballManager skeeballMgr;
    MilkCansManager milkCanMgr;
    BalloonGameManager balloonGameMgr;

    public Animator scrollingAnimator;

    public GameObject mainTradingMenu;
    public GameObject rewardsMenu;

    public int totalCyberShards = 0;
    public int totalScoreForAllGames = 0;

    public Text totalCyberShardsTXT;
    public Text totalScoreTXT;
    public Text totalScoreSkeeballTXT;
    public Text totalMilkCanScoreTXT;
    public Text totalBalloonGameScoreTXT;

    private void Awake()
    {
        scrollingAnimator = GetComponent<Animator>();
        skeeballMgr = FindObjectOfType<SkeeballManager>();
        milkCanMgr = FindObjectOfType<MilkCansManager>();
        balloonGameMgr = FindObjectOfType<BalloonGameManager>();
    }

    private void Start()
    {
        UpdateTotalPoints();
    }

    public void UpdateTotalPoints()
    {
        totalCyberShardsTXT.text = totalCyberShards.ToString();
        totalScoreSkeeballTXT.text = skeeballMgr.skeeBallTotalPoints.ToString();
        totalMilkCanScoreTXT.text = milkCanMgr.milkcansTotalPoints.ToString();
        totalBalloonGameScoreTXT.text = balloonGameMgr.balloonGameTotalPoints.ToString();
        CalculateTotal();
        totalScoreTXT.text = totalScoreForAllGames.ToString();
    }

    public void CalculateTotal()
    {
        totalScoreForAllGames = (skeeballMgr.skeeBallTotalPoints + 
            milkCanMgr.milkcansTotalPoints + balloonGameMgr.balloonGameTotalPoints);
    }

    public void ScrollDownTradingDisplay()
    {
        scrollingAnimator.SetBool("isScrolled", true);
    }

    public void ScrollUpTradingDisplay()
    {
        scrollingAnimator.SetBool("isScrolled", false);
    }

    public void OnTradingButtonPress()
    {
        if (totalScoreForAllGames >= 50)
        {
            int temp = totalScoreForAllGames;
            totalCyberShards = Mathf.RoundToInt(totalScoreForAllGames / 50);
            totalScoreForAllGames = temp - (totalCyberShards * 50);
            totalCyberShardsTXT.text = totalCyberShards.ToString();
            totalScoreTXT.text = totalScoreForAllGames.ToString();
        }
    }

    public void OnRewardsButtonPress()
    {
        mainTradingMenu.SetActive(false);
        rewardsMenu.SetActive(true);
    }

    public void OnBackButtonPressed()
    {
        rewardsMenu.SetActive(false);
        mainTradingMenu.SetActive(true);
    }
}
