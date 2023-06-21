using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTo : MonoBehaviour
{
    public Transform target;
    public float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {
            if (target.gameObject.activeInHierarchy)
            {
                Quaternion lookOnLook = Quaternion.LookRotation(target.position - transform.position);

                transform.rotation = Quaternion.Slerp(transform.rotation, lookOnLook, Time.deltaTime);
            }
        }


    }

    public void SetTarget(Transform t)
    {
        target = t;
    }

}
