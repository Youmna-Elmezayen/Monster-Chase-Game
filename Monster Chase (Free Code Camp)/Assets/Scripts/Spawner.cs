using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyReference; // array to carry different enemies in and select on of them at random to spawn
    private GameObject spawnedEnemy; // the current spawned enemy

    [SerializeField]
    private Transform leftPos, rightPos; // denoting the 2 different spawners on the left and right side

    private int randomSide, randomIndex; // choosing a random side to spawn enemies, choosing a random index of enemy from array to spawn

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy()); // start coroutine once
    }

    IEnumerator SpawnEnemy()
    {
        while(true) // while loop to keep the coroutine running 
        {
            yield return new WaitForSeconds(Random.Range(0, 6)); // with this yield return, the while loop will wait from 0 to 5 seconds before reexecuting

            randomIndex = Random.Range(0, enemyReference.Length); // get random index 0,1,2 to denote ghost, zombie, red zombie
            randomSide = Random.Range(0, 2); // get random side either 0 or 1, 0 for left and 1 for right

            spawnedEnemy = Instantiate(enemyReference[randomIndex]); // create instance of selected enemy with index

            if (randomSide == 0)
            {
                spawnedEnemy.transform.position = leftPos.position; // make the enemy spawn at desired side
                spawnedEnemy.GetComponent<Enemy>().SetSpeed(Random.Range(4, 11)); // move the enemy towards player
            }
            else
            {
                spawnedEnemy.transform.position = rightPos.position; // make the enemy spawn at desired side
                spawnedEnemy.GetComponent<Enemy>().SetSpeed(-Random.Range(4, 11)); // move the enemy towards player
                spawnedEnemy.transform.localScale = new Vector3(-1f, 1f, 1f); // make enemy look the other way (flip on x)
            }
        }
        
    }
    
}
