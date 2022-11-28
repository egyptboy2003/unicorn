using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagement : MonoBehaviour
{
    private GameObject pauseMenu;
    private GameObject winMenu;
    private bool isPaused;

    void Start()
    {
        pauseMenu = GameObject.Find("Pause");
        winMenu = GameObject.Find("Win");
        Unpause();
        winMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) Unpause(); else Pause();
        }
    }
    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        isPaused = true;
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void LevelSelect()
    {
        SceneManager.LoadSceneAsync("LevelSelect", LoadSceneMode.Single);
    }

    public void Replay()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    public void toggleWinMenu()
    {
        winMenu.SetActive(true);
    }
}
