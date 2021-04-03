using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScannerTriggerArea : MonoBehaviour
{
    TradeManager tradeMgr;

    private void Awake()
    {
        tradeMgr = FindObjectOfType<TradeManager>();
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(tradeMgr.scrollingAnimator.GetBool("isScrolled") == false)
            {
                tradeMgr.UpdateTotalPoints();
                tradeMgr.ScrollDownTradingDisplay();
            }
            else if(tradeMgr.scrollingAnimator.GetBool("isScrolled") == true)
            {
                tradeMgr.ScrollUpTradingDisplay();
            }
        }
    }
}
