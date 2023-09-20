using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private string PLAYER_TAG = "Player";

    private Transform player;

    private Vector3 tempPos;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag(PLAYER_TAG).transform;
    }


    // called once per frame after all update computations are done
    void LateUpdate()
    {

        if(!player)
        {
            return;
        }

        tempPos = transform.position;
        tempPos.x = player.position.x;

        transform.position = tempPos;
    }
}
