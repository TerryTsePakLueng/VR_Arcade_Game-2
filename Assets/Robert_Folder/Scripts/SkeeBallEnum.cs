using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SkeeballTriggers
{
    points10,
    points20,
    points30,
    points40,
    points50,
    points100
}
public class SkeeBallEnum : MonoBehaviour
{
    public SkeeballTriggers skeeBallTriggers;

    public int pointsToAward;
}
