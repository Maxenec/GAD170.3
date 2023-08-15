using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    private int playerHealth = 100;
    private Renderer renderObject;
    public Material deathMat;
    public Camera chickenCamera;
    public GameObject gameController;
    private int deathType = 0;
    private bool onObject = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth > 100)
        {
            playerHealth = 100;
        }
        else if (playerHealth < 1)
        {
            PlayerDeath();
        }
    }

    private void PlayerDeath()
    {
        playerHealth = 0;
        gameController.GetComponent<GameManager>().GameOver();
        Destroy(gameObject.GetComponent<PlayerMovement>());
        Destroy(gameObject.GetComponent<CharacterController>());
        renderObject = GetComponent<Renderer>();
        renderObject.material = deathMat;
        chickenCamera.transform.SetParent(null);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Hazard")
        {
            playerHealth--;
        }
        else if (other.gameObject.tag == "TimedMaze")
        {
            StartCoroutine(DelayCoroutine());
            onObject = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "TimedMaze")
        {
            onObject = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ProgressDoor")
        {
            gameController.GetComponent<GameManager>().ProgressLevel();
        }
    }

    public int PlayerHealth()
    {
        return playerHealth;
    }

    public int DeathType()
    {
        return deathType;
    }

    private IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(5);
        if (onObject)
        {
            PlayerDeath();
        }
    }
}
