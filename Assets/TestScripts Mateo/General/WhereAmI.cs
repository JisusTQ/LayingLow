using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhereAmI : MonoBehaviour
{

    float[,] rooms = {{-1.0f, 5.5f},{8.0f, 14.5f},{18.0f, 24.5f},{28.5f, 35f},{39.0f, 45.5f},{46,60} };
    public int room;
    void Start(){
        Where();
    }


    void Update()
    {
        Where();
    }

    private void Where(){
        for (int i = 0; i < rooms.GetUpperBound(0)+1; i++)
        {
            if(transform.position.y > rooms[i,0] && transform.position.y < rooms[i,1]){
                room = i;
            }
        }
    }
}
