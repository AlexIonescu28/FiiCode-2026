using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class quitBtn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Debug.Log("quitting game...");
        Application.Quit();
    }
}
