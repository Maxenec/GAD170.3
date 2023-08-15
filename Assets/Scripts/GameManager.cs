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

    // Start is called before the first frame update
    private void Start()
    {
        gameOverBox.SetActive(false);
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf)
            {
                pauseMenu.SetActive(false);
            }
            else
            {
                pauseMenu.SetActive(true);
            }
        }
    }

    public void StartGame()
    {
        Debug.Log("Game has started.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        gameOverBox.SetActive(false);
        healthBar.SetActive(true);
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
        //Adjusts for both the developer and a normal player.
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
