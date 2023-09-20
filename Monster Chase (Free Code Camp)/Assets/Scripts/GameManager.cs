using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private string GAMEPLAY_SCENE = "Gameplay";
    public static GameManager instance;

    [SerializeField]
    GameObject[] players;

    private int _charIndex; // the index of the selected player (0 for player 1, 1 for player 2)
    public int CharIndex
    {
        get { return _charIndex; }
        set { _charIndex = value; }
    }
    private void Awake()
    {
        if(instance == null) // single instance (singleton)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // used to let the GameManager not be destroyed when moving from main menu to gameplay scene
        }
        else
        {
            Destroy(gameObject); // destory un-needed instance
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading; // subscribe to event of scene loaded and respond with OnLevelFinished
    }

    private void OnDisable() // unsubscribe to event of scene loaded
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == GAMEPLAY_SCENE)
        {
            Instantiate(players[CharIndex]); // upon selection of player using index, we instantiate an instance of this player in the gameplay scene
        }
    }
}
