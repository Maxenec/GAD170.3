using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverBox;
    public GameObject healthBar;
    public GameObject player;
    public GameObject pauseMenu;
    public GameObject tutorialScreen1;
    public GameObject tutorialScreen2;
    public GameObject tutorialScreen3;
    private int tutorialNumber;
    public TextDisplay textDisplay;

    // Start is called before the first frame update
    private void Start()
    {
        //Checks if the UI exists to not get errors.
        if (gameOverBox != null || pauseMenu != null)
        {
            gameOverBox.SetActive(false);
            pauseMenu.SetActive(false);
        }
        HideTutorialScreen();
        textDisplay = GetComponent<TextDisplay>();
        DisplayTitle();
    }

    // Update is called once per frame
    void Update()
    {
        PauseMenu();
    }

    public void StartGame()
    {
        Debug.Log("Game has started.");
        //Skips the tutorial level and goes ahead.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        //Checks for healthbar's existence and sets it active.
        if (healthBar != null)
        {
            healthBar.SetActive(true);
        }

    }

    public void StartTutorial()
    {
        Debug.Log("Tutorial has started");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel()
    {
        Debug.Log("The level has restarted");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        gameOverBox.SetActive(true);
        healthBar.SetActive(false);

        if (pauseMenu.activeSelf && gameOverBox.activeSelf)
        {
            pauseMenu.SetActive(false);
            Debug.Log("Pause Menu cannot be opened.");
        }

    }

    public void ShowTutorialScreen(int type)
    {
        if (type == 1)
        {
            tutorialScreen1.SetActive(true);
            tutorialNumber = 1;
        }
        else if (type == 2)
        {
            tutorialScreen1.SetActive(false);
            tutorialScreen2.SetActive(true);
            tutorialNumber = 2;
        }
        else
        {
            tutorialScreen2.SetActive(false);
            tutorialScreen3.SetActive(false);
            tutorialScreen3.SetActive(true);
            tutorialNumber = 3;
        }
    }

    public void HideTutorialScreen()
    {
        if (tutorialScreen1 != null || tutorialScreen2 != null || tutorialScreen3 != null)
        {
            if (tutorialNumber == 1)
            {
                tutorialScreen1.SetActive(false);
            }
            else if (tutorialNumber == 2)
            {
                tutorialScreen2.SetActive(false);
            }
            else if (tutorialNumber == 3)
            {
                tutorialScreen3.SetActive(false);
            }
            else
            {
                tutorialScreen1.SetActive(false);
                tutorialScreen2.SetActive(false);
                tutorialScreen3.SetActive(false);
            }
        }
        else
        {
            Debug.Log("No tutorial screens exists in this scene to be disabled.");
        }
    }

    public void ProgressLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MenuScreen");
    }

    public void QuitGame()
    {
        //Adjusts to end the game for both the developer and a normal player.
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void PauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu != null)
        {
            //To make sure pause menu does not overlap with the game over prompt at any time.
            if (!pauseMenu.activeSelf && !gameOverBox.activeSelf)
            {
                pauseMenu.SetActive(true);
            }
            else
            {
                pauseMenu.SetActive(false);
            }
        }
    }

    public void DisplayTitle()
    {
        if (textDisplay != null)
        {
            textDisplay.AddText("Chicken Escape");
        }
    }
}
