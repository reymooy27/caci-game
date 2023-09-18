using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGameOver;
    public bool isGamePaused;
    public GameObject pauseMenuUI;
    public AudioSource backsound;
    public KODisplay ko;
    public GameObject restartText;
    public float restartDelay = 10f;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    void Start(){
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isGameOver)
            {
                ReloadScene();
            }
        }
    }


    public void StartGame()
    {
        
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; // Stop the time to pause the game.
        pauseMenuUI.SetActive(true); // Show the pause menu.
        isGamePaused = true;
        backsound.Pause();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume time to unpause the game.
        pauseMenuUI.SetActive(false); // Hide the pause menu.
        isGamePaused = false;
        backsound.Play();
    }

    public void GameOver(bool flag)
    {
        ko.ShowGameOverImage();
        restartText.gameObject.SetActive(true);
        isGameOver = flag;

        //ReloadScene();
    }


    public bool IsGameOver()
    {
        return isGameOver;
    }


    public void RestartGameWithDelay()
    {
        // Delay the scene reload by the specified time
        Invoke("ReloadScene", restartDelay);
    }

    public void ReloadScene()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
