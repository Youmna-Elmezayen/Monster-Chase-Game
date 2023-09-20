using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorFollow : MonoBehaviour
{
    private string PLAYER_TAG = "Player";

    private Transform player;

    private Vector3 tempPosLeft;

    private Vector3 tempPosRight;

    [SerializeField]
    private GameObject leftCollector, rightCollector; // denoting the 2 different spawners on the left and right side

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

        tempPosLeft = leftCollector.transform.position;
        tempPosRight = rightCollector.transform.position;

        tempPosLeft.x = player.position.x - 22;
        tempPosRight.x = player.position.x + 23;

        leftCollector.transform.position = tempPosLeft;
        rightCollector.transform.position = tempPosRight;
    }
}