using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR.Extras;
using System.Linq;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class LazerPointerHandler : MonoBehaviour
{

    private SteamVR_LaserPointer laserPtrRef;
    //private List<SteamVR_LaserPointer> laserPtrRefs;

    private void OnEnable()
    {
        laserPtrRef = FindObjectOfType<SteamVR_LaserPointer>();
        laserPtrRef.PointerClick += PointerClickCallback;

        // laserPtrRefs = FindObjectsOfType<SteamVR_LaserPointer>().ToList(); //convert array to list
        // laserPtrRefs.Foreach(x=>x.PointerClick += PointerClickCallback);
        //alternative to labda
        //foreach(....)
    }


    public void PointerClickCallback(object sender, PointerEventArgs e)
    {
        if (e.target.GetComponent<Button>() != null)
            e.target.GetComponent<Button>().onClick.Invoke(); //invoke the button we just clicked
    }

    private void OnDisable()
    {
        laserPtrRef.PointerClick -= PointerClickCallback;
        laserPtrRef.active = false;
    }
}
