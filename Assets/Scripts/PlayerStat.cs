using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    private int playerHealth = 100;
    private Renderer renderObject;
    public Material deathMat;
    public Camera chickenCamera;

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
            playerHealth = 0;
            Destroy(gameObject.GetComponent<PlayerMovement>());
            Destroy(gameObject.GetComponent<CharacterController>());
            renderObject = GetComponent<Renderer>();
            renderObject.material = deathMat;
            chickenCamera.transform.SetParent(null);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Hazard")
        {
            playerHealth -= 1;

        }
        if (other.gameObject.tag == "DeathZone")
        {
            Debug.Log("You are losing HP.");
            for (int i = playerHealth; i > 0; i++)
            {

            }
        }
    }

    public int PlayerHealth()
    {
        return playerHealth;
    }
}
