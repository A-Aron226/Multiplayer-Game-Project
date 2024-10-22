using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene(""); //Enter the name or build index of the scene to load first level scene
    }

    public void quitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void backToMain()
    {
        SceneManager.LoadScene(""); //Enter name or build index of scene to load main menu scene
    }
}
