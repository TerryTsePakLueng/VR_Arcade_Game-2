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

    public void OnButtonPress()
    {
        if (!tradeMgr.scrollingAnimator.GetBool("isScrolled"))
        {
            tradeMgr.ScrollDownTradingDisplay();
            tradeMgr.UpdateTotalPoints();
            LookForLazer.instance.TurnOnOffLazer();
        }
        else if (tradeMgr.scrollingAnimator.GetBool("isScrolled"))
        {
            tradeMgr.ScrollUpTradingDisplay();
            LookForLazer.instance.TurnOnOffLazer();
        }
    }
}
