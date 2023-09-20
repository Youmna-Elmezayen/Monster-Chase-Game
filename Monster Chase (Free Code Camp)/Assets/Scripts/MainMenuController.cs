using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{ 
    public void PlayerSelection() // function to execute on click of button is required to be public void
    {
        int selected = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

        GameManager.instance.CharIndex = selected; // GameManager is responsible for instantiating the selected character in the Gameplay scene
        SceneManager.LoadScene("Gameplay"); // load scene with given name argument
    }
}
