using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Destroy(GameObject.FindGameObjectWithTag("Sound"));
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
