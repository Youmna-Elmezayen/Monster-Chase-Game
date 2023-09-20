using UnityEngine;

public class CoinSpawnerFollow : MonoBehaviour
{
    private string PLAYER_TAG = "Player";

    private Transform player;

    private Vector3 tempPosLeftLow;
    private Vector3 tempPosLeftUp;

    private Vector3 tempPosRightLow;
    private Vector3 tempPosRightUp;

    [SerializeField]
    private GameObject leftLowSpawner, rightLowSpawner, leftUpSpawner, rightUpSpawner; // denoting the 2 different spawners on the left and right side

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

        tempPosLeftLow = leftLowSpawner.transform.position;
        tempPosRightLow = rightLowSpawner.transform.position;
        tempPosLeftUp = leftUpSpawner.transform.position;
        tempPosRightUp = rightUpSpawner.transform.position;

        tempPosLeftLow.x = player.position.x - 20;
        tempPosRightLow.x = player.position.x + 20;
        tempPosLeftUp.x = player.position.x - 20;
        tempPosRightUp.x = player.position.x + 20;

        leftLowSpawner.transform.position = tempPosLeftLow;
        rightLowSpawner.transform.position = tempPosRightLow;
        leftUpSpawner.transform.position = tempPosLeftUp;
        rightUpSpawner.transform.position = tempPosRightUp;
    }
}