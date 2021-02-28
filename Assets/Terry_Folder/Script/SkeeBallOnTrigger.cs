using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum holeAmount { Hole10, Hole20, Hole30, Hole40, Hole50, Hole100}
public class SkeeBallOnTrigger : MonoBehaviour
{
    public holeAmount holeCategory;
    public SkiBallManager skeeballMgr;

    private void Awake()
    {
        skeeballMgr = FindObjectOfType<SkiBallManager>();
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(this.holeCategory == holeAmount.Hole10)
    //    {
    //        RewardManager.instance.SkeeBallPointSystem(10);
    //        //if(skeeballMgr.ballsThrown)
    //    }
    //    else if(this.holeCategory == holeAmount.Hole20)
    //    {
    //        RewardManager.instance.SkeeBallPointSystem(20);
    //    }
    //    else if (this.holeCategory == holeAmount.Hole30)
    //    {
    //        RewardManager.instance.SkeeBallPointSystem(30);
    //    }
    //    else if (this.holeCategory == holeAmount.Hole40)
    //    {
    //        RewardManager.instance.SkeeBallPointSystem(40);
    //    }
    //    else if (this.holeCategory == holeAmount.Hole50)
    //    {
    //        RewardManager.instance.SkeeBallPointSystem(50);
    //    }
    //    else if (this.holeCategory == holeAmount.Hole100)
    //    {
    //        RewardManager.instance.SkeeBallPointSystem(100);
    //    }
    //}
}
