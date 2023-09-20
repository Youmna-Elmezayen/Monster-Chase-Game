using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject coinReference; // coin reference to spawn with
    private GameObject coin; // the current spawned coin

    [SerializeField]
    private Transform leftLower, rightLower, leftUpper, rightUpper; // denoting the 2 different spawners on the left and right side

    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn()); // start coroutine once
    }

    IEnumerator Spawn()
    {
        while (true) // while loop to keep the coroutine running 
        {
            yield return new WaitForSeconds(Random.Range(0, 3)); // with this yield return, the while loop will wait from 0 to 5 seconds before reexecuting
            randomSide = Random.Range(0, 4); // get random side either 0 or 1, 0 for left and 1 for right

            coin = Instantiate(coinReference); // create instance of selected enemy with index

            switch(randomSide)
            {
                case 0:
                    coin.transform.position = leftLower.position; // make the enemy spawn at desired side
                    break;
                case 1:
                    coin.transform.position = rightLower.position; // make the enemy spawn at desired side
                    break;
                case 2:
                    coin.transform.position = leftUpper.position; // make the enemy spawn at desired side
                    break;
                case 3:
                    coin.transform.position = rightUpper.position; // make the enemy spawn at desired side
                    break;
                default:
                    break;
            }
        }

    }

}