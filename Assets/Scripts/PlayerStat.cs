using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerStat : MonoBehaviour
{
    private int playerHealth = 100;
    private Renderer renderObject;
    public Material deathMat;
    public Camera chickenCamera;
    public GameObject gameController;
    private bool onObject = false;
    private bool playerAlive = true;
    private bool Tutorial1Complete = false;
    private bool Tutorial2Complete = false;
    private bool Tutorial3Complete = false;
    public GameObject platformPrefab;
    public GameObject platform;
    public GameObject button;
    public GameObject gate;
    private bool buttonPressed = false;
    private bool gateOpen = false;
    public bool canUnlock = false;

    void Update()
    {
        //Prevents health going above 100.
        if (playerHealth > 100)
        {
            playerHealth = 100;
        }
        //Calls kill function when health is below 0.
        else if (playerHealth < 1 && playerAlive)
        {
            PlayerDeath();
        }
        //Checks if gate can be unlocked only if gate is closed.
        if (gate != null)
        {
            if (gateOpen == false)
            {
                canUnlock = gate.GetComponent<MazeDoor>().CanUnlock();
            }
        }
    }

    //Sets player to dead, destroys gamecontroller to create death effect, and changes material and removes the camera as a child.
    private void PlayerDeath()
    {
        playerHealth = 0;
        playerAlive = false;
        gameController.GetComponent<GameManager>().HideTutorialScreen();
        gameController.GetComponent<GameManager>().GameOver();
        Destroy(gameObject.GetComponent<PlayerMovement>());
        Destroy(gameObject.GetComponent<CharacterController>());
        renderObject = GetComponent<Renderer>();
        renderObject.material = deathMat;
        chickenCamera.transform.SetParent(null);
    }

    private void OnTriggerStay(Collider other)
    {
        //Slowly removes health with this tag if the player is alive.
        if (other.gameObject.tag == "Hazard")
        {
            if (playerAlive)
            {
                playerHealth--;
            }

        }
        //Kills player immediately with this tag if the player is alive.
        else if (other.gameObject.tag == "InstantDeath")
        {
            if (playerAlive)
            {
                PlayerDeath();
            }
        }
        //Kills player immediately with this tag if player is still in the object after the time set and is alive.
        else if (other.gameObject.tag == "TimedMaze")
        {
            if (playerAlive)
            {
                StartCoroutine(DelayCoroutine());
                onObject = true;
            }
        }
        //Checks if button is pressed when pressing E, then changes it and creates a platform for the player and changes material on another script.
        else if (other.gameObject.tag == "Button")
        {
            if (Input.GetKey("e") && buttonPressed == false)
            {
                buttonPressed = true;
                Debug.Log("Platform generated.");
                platform = (Instantiate(platformPrefab, new Vector3(0, 2, 71), Quaternion.identity));
                button.GetComponent<Button>().ButtonPressed();
            }
        }
        //Checks if gate is unlocked when pressing e, and if it can be unlocked. Destroys gate and changes to true.
        else if (other.gameObject.tag == "GateUnlock")
        {
            if (gateOpen == false && Input.GetKey("e") && canUnlock == true)
            {
                gateOpen = true;
                Debug.Log("Gate Opened.");
                Destroy(gate);
            }
        }

    }

    //When player exits the trigger, their status on being in the trigger is turned off.
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "TimedMaze")
        {
            onObject = false;
        }
    }

    //When player collides, function from a different script is enabled.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ProgressDoor")
        {
            gameController.GetComponent<GameManager>().ProgressLevel();
        }
    }

    //When players enters trigger and if they're alive, checks which tutorial and if it's already done.
    private void OnTriggerEnter(Collider other)
    {
        if (playerAlive)
        {
            if (other.gameObject.tag == "Tutorial1" && Tutorial1Complete == false)
            {
                gameController.GetComponent<GameManager>().ShowTutorialScreen(1);
                Tutorial1Complete = true;
            }
            else if (other.gameObject.tag == "Tutorial2" && Tutorial2Complete == false)
            {
                gameController.GetComponent<GameManager>().ShowTutorialScreen(2);
                Tutorial2Complete = true;
            }
            else if (other.gameObject.tag == "Tutorial3" && Tutorial3Complete == false)
            {
                gameController.GetComponent<GameManager>().ShowTutorialScreen(3);
                Tutorial3Complete = true;
            }
        }
    }

    public int PlayerHealth()
    {
        return playerHealth;
    }

    //Counts down and if player is still in trigger, they die.
    private IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(8);
        if (onObject)
        {
            PlayerDeath();
        }
    }
}
