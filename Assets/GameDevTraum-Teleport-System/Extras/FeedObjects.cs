using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedObjects : MonoBehaviour
{
    public GameObject prefab;

    public Transform origin;
    public LookTo lookAtScript;
    void Start()
    {
        CreateObject();
    }

    private void CreateObject()
    {
        GameObject g = Instantiate(prefab,origin.position+Vector3.up*3f,Quaternion.identity);
        
        if (g.GetComponent<Rigidbody>() == null)
        {
            g.AddComponent<Rigidbody>();
        }
        lookAtScript.SetTarget(g.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = origin.position + Vector3.up * 3f;
        other.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

}
