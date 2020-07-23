using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class levelController : MonoBehaviour
{


    public void ChangeLevel(int levelNumber)
    {
        SceneManager.LoadScene(levelNumber);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
