using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class pauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    [SerializeField] Slider volumeSlider;        
    [SerializeField] AudioManager audioManager;  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 0.4f);
        volumeSlider.value = savedVolume;

       
        volumeSlider.onValueChanged.AddListener(audioManager.SetMusicVolume);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        volumeSlider.value = audioManager.GetMusicVolume();
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main menu");
    }
    public void QuitGame()
    {
        Debug.Log("quitting game...");
        Application.Quit();
    }

    public void Restart()
    {

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
