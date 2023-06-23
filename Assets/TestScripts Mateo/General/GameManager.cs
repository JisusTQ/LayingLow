using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject alien;
    // Start is called before the first frame update
    void Start()
    {
        alien = GameObject.FindGameObjectWithTag("alien");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void TimeCorpse(){
        
    }
}
