using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    WhereAmI alienRoom;
    // Start is called before the first frame update
    void Start()
    {
        alienRoom = GameObject.FindGameObjectWithTag("alien").GetComponent<WhereAmI>();
    }

    // Update is called once per frame
    void Update()
    {
        DefienPos();
    }

    private void DefienPos(){
        switch (alienRoom.room)
        {
            case 0:
                transform.position = new Vector3(0, 2.5f, -5);
            break;
            case 1:
                transform.position = new Vector3(0, 11.5f, -5);
            break;
            case 2:
                transform.position = new Vector3(0, 21.4f, -5);
            break;
            case 3:
                transform.position = new Vector3(0, 32f, -5);
            break;
            case 4:
                transform.position = new Vector3(0, 42.5f, -5);
            break;
        }
    }
}
