using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WatchManager : MonoBehaviour
{
    public Animator watchAnimator;

    public GameObject watchMainMenuCanvas;
    public GameObject watchMyTicketsCanvas;
    public GameObject watchMyScoreCanvas;

    public bool isOpen = false;

    public Text cyberShardTotal;
    public Text totalScore;

    TradeManager tradeMgr;

    private void Awake()
    {
        tradeMgr = FindObjectOfType<TradeManager>();
    }

    public void Start()
    {
        FillTextFieldsInWatch();
        DontDestroyOnLoad(gameObject);
    }

    public void OnButtonPress()
    {
        if (!isOpen)
        {
            watchMyTicketsCanvas.SetActive(false);
            watchMainMenuCanvas.SetActive(true);
            FillTextFieldsInWatch();
            watchAnimator.SetBool("isOpen", true);
            isOpen = true;
        }
        else
        {
            watchAnimator.SetBool("isOpen", false);
            isOpen = false;
        }
    }

    public void FillTextFieldsInWatch()
    {
        if(tradeMgr != null)
        {
            cyberShardTotal.text = tradeMgr.totalCyberShards.ToString();
            tradeMgr.CalculateTotal();
            totalScore.text = tradeMgr.totalScoreForAllGames.ToString();
        }
        else
        {
            cyberShardTotal.text = "No Data Found";
            totalScore.text = "No Data Found";
        }
    }

    public void OnMyTicketsButtonPress()
    {
        watchMainMenuCanvas.SetActive(false);
        watchAnimator.SetBool("isOpen", false);
        StartCoroutine(DelayScreenAppearingForMyTickets());
    }

    public void OnBackButtonPress()
    {
        watchMyTicketsCanvas.SetActive(false);
        watchMyScoreCanvas.SetActive(false);
        watchAnimator.SetBool("isOpen", false);
        StartCoroutine(DelayScreenAppearingForBack());
    }

    public void OnMyScoreButtonPress()
    {
        watchMainMenuCanvas.SetActive(false);
        watchAnimator.SetBool("isOpen", false);
        StartCoroutine(DelayScreenAppearingForMyScore());
    }

    IEnumerator DelayScreenAppearingForMyTickets()
    {
        yield return new WaitForSeconds(1.1f);
        watchMyTicketsCanvas.SetActive(true);
        watchAnimator.SetBool("isOpen", true);
    }

    IEnumerator DelayScreenAppearingForBack()
    {
        yield return new WaitForSeconds(1.1f);
        watchMainMenuCanvas.SetActive(true);
        watchAnimator.SetBool("isOpen", true);
    }

    IEnumerator DelayScreenAppearingForMyScore()
    {
        yield return new WaitForSeconds(1.1f);
        watchMyScoreCanvas.SetActive(true);
        watchAnimator.SetBool("isOpen", true);
    }

    public void OnQuitButtonPress()
    {
        Application.Quit();
    }
}
