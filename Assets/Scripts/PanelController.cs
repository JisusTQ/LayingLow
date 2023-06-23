using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField] GameObject panelAD;
    [SerializeField] GameObject panelC;
    [SerializeField] GameObject panelX;
    [SerializeField] GameObject panelZ;
    [SerializeField] Animator fade;
    // Start is called before the first frame update
    void Start()
    {
        //sceneTransition = FindAnyObjectByType<SceneTransition>();
    }
    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal")==-1 || Input.GetAxisRaw("Horizontal") == 1)
        {
            Invoke("FadeOutPanel",2);
            panelAD.SetActive(false);
            panelC.SetActive(true);
            if (Input.GetKeyDown(KeyCode.C))
            {
                Invoke("FadeOutPanel", 2);
                panelC.SetActive(false);
                panelX.SetActive(true);
                if (Input.GetKeyDown(KeyCode.X))
                {
                    Invoke("FadeOutPanel", 2);
                    panelX.SetActive(false);
                    panelZ.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Z))
                    {
                        Invoke("FadeOutPanel", 2);
                        panelZ.SetActive(false);
                    }
                }
            }
        }
    }
}
