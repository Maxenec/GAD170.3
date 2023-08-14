using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Start screen activated.");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        Debug.Log("Game has started.");
        SceneManager.LoadScene("Level1");
    }

    public void gameOver()
    {
        
    }
}
