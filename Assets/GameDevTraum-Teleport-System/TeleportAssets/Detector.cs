using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public TeleportRing myTeleportRing;
    public bool firstDetector;
    public Detector otherDetector;
    private Collider detectedCollider;
    void Start()
    {
        myTeleportRing=transform.parent.GetComponent<TeleportRing>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (firstDetector)
        {
            if (!myTeleportRing.teleportInProcess)
            {
                otherDetector.FirstDetectorTrigger(other);
            }
        }
        else
        {
            if (other == detectedCollider)
            {
                myTeleportRing.ColliderEntersDetector(other);
            }
            detectedCollider = null;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (firstDetector)
        {
            myTeleportRing.TelefortFinished();
        }
    }

    public void FirstDetectorTrigger(Collider c)
    {
        detectedCollider = c;
    }

}
