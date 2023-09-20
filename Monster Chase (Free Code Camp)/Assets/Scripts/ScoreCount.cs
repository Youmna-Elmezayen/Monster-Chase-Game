using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreCount : MonoBehaviour
{
    private string PLAYER_TAG = "Player";
    float currentScore = 0f;
    float startingScore= 0f;

    [SerializeField]
    Text scoreText;
    [SerializeField]
    Text statusText;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        currentScore = startingScore;
        player = GameObject.FindWithTag(PLAYER_TAG);
    }

    // Update is called once per frame
    void Update()
    {
        if(HealthStatus.isAlive && Player.isCoinCollected)
        {
            currentScore += 1;
            scoreText.text = currentScore.ToString();
            Player.isCoinCollected = false;
        }
        else if(!HealthStatus.isAlive)
        {
            Destroy(player.gameObject);
            statusText.text = "New score = " + currentScore.ToString();
            statusText.color = Color.white;
            Invoke("MoveToMainMenu", 5f);
        }
    }

    public void MoveToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
