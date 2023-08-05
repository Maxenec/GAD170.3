using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject chicken;
    public GameObject player;
    public GameObject startScreen;
    public GameObject HUD;
    public GameObject mainCamera;
    public GameObject chickenCamera;

    // Start is called before the first frame update
    private void Start()
    {
        startScreen.SetActive(true);
        HUD.SetActive(false);
        Debug.Log("Start screen activated.");
        chickenCamera = GameObject.FindGameObjectWithTag("ChickenCamera");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        Debug.Log("Game has started.");
        Destroy(chickenCamera);
        mainCamera.SetActive(false);
        player = (Instantiate(chicken, new Vector3(0, 2, 0), Quaternion.identity));
        startScreen.SetActive(false);
        HUD.SetActive(true);
    }

    public void gameOver()
    {
        startScreen.SetActive(true);
    }
}
