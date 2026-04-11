using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Tutorial()
    {
        SceneManager.LoadSceneAsync(12);
    }

    public void Menu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    

}
