using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject startScreen;
    public GameObject HUD;

    // Start is called before the first frame update
    private void Start()
    {
        startScreen.SetActive(true);
        HUD.SetActive(false);
        player.SetActive(false);
        Debug.Log("Start screen activated.");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        Debug.Log("Game has started.");
        startScreen.SetActive(false);
        HUD.SetActive(true);
    }

    public void gameOver()
    {
        startScreen.SetActive(true);
    }
}
