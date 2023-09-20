using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private string ENEMY_TAG = "Enemy";
    private string PLAYER_TAG = "Player";


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(ENEMY_TAG) || collision.gameObject.CompareTag(PLAYER_TAG))
        {
            Destroy(collision.gameObject);
        }
    }


}
