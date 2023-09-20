using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFollow : MonoBehaviour
{
    private string PLAYER_TAG = "Player";

    private Transform player;

    private Vector3 tempPosLeft;

    private Vector3 tempPosRight;

    [SerializeField]
    private GameObject leftSpawner, rightSpawner; // denoting the 2 different spawners on the left and right side

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag(PLAYER_TAG).transform;
    }


    // called once per frame after all update computations are done
    void LateUpdate()
    {

        if (!player)
        {
            return;
        }

        tempPosLeft = leftSpawner.transform.position;
        tempPosRight = rightSpawner.transform.position;

        tempPosLeft.x = player.position.x - 20;
        tempPosRight.x = player.position.x + 20;

       leftSpawner.transform.position = tempPosLeft;
       rightSpawner.transform.position = tempPosRight;
    }
}