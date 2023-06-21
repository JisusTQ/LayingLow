using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportRing : MonoBehaviour
{
    public bool movingRing;
    public TeleportRing otherRing;
    public float boostFactor=1f;
    
    public Transform bottom;
    public GameObject teleportingParticles;

    float enterVelocity;
    GameObject enteringGameObject;
    Rigidbody enteringRigidbody;
    Vector3 exitPosition;
    Vector3 direction;

    public bool teleportInProcess;
    void Start()
    {
        exitPosition = transform.position;
        direction = Vector3.Normalize(transform.position-bottom.position);
    }


    void Update()
    {


    }

    public void ColliderEntersDetector(Collider c)
    {

        Rigidbody r = c.GetComponent<Rigidbody>();
        if (r != null)
        {
            TeleportIn(c.gameObject,r);
        }
    }

    public void TeleportIn(GameObject g,Rigidbody r)
    {

        enteringGameObject = g;
        enteringRigidbody = r;
        enterVelocity = Vector3.Magnitude(enteringRigidbody.velocity);
        enteringGameObject.SetActive(false);
        teleportingParticles.transform.position = enteringGameObject.transform.position;
        teleportingParticles.SetActive(true);
        otherRing.TeleportOut(enteringGameObject,enteringRigidbody, enterVelocity);

    }
    public void TeleportOut(GameObject g, Rigidbody r,float enterVelocity)
    {
        if (movingRing)
        {
            exitPosition = transform.position; //if ring is moving
            direction = Vector3.Normalize(transform.position - bottom.position);
        }
        teleportInProcess = true;
        r.velocity = direction * enterVelocity * boostFactor;
        g.SetActive(true);
        g.transform.position = exitPosition;
        teleportingParticles.transform.position = g.transform.position;
        teleportingParticles.SetActive(true);
    }

    public void TelefortFinished()
    {
        teleportInProcess = false;
    }
}
