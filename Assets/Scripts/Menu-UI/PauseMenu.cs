using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOver;
    [SerializeField] PlayerMovement player;
    bool isPaused;

    void Start()
    {

        isPaused = false;

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P) && !gameOver.activeSelf)
        {

            if (!isPaused)
            {

                pauseMenu.SetActive(true);
                player.enabled = false;
                Time.timeScale = 0;
                isPaused = true;


            }
            else
            {

                continueGame();

            }
        

        }

        
        
    }

    public void continueGame()
    {

        isPaused = false;
        pauseMenu.SetActive(false);
        player.enabled = true;
        Time.timeScale = 1;

    }

    public void exitGame()
    {

        Time.timeScale = 1;
        SceneManager.LoadScene(0);

    }

    public void restartGame()
    {

        Time.timeScale = 1;
        SceneManager.LoadScene(1);

    }


}
