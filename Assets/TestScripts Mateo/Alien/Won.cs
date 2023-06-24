using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Won : MonoBehaviour
{
    AudioManager audiop;
    [SerializeField] GameObject wonScreen;
    // Start is called before the first frame update
    void Start()
    {
        audiop = FindAnyObjectByType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "won")
        {
            wonScreen.SetActive(true);
            audiop.PlayMusic(audiop.victory);
        }
    }
}
