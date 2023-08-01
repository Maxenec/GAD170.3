using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public int playerHealth = 100;
    private Renderer renderObject;
    public Material deathMat;

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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hazard")
        {
            Debug.Log("You have been overcooked.");
            Destroy(gameObject.GetComponent<PlayerMovement>());
            Destroy(gameObject.GetComponent<CharacterController>());
            renderObject = GetComponent<Renderer>();
            renderObject.material = deathMat;
        }
        if (other.gameObject.tag == "DeathZone")
        {
            Debug.Log("You are losing HP.");
                for (int i = playerHealth; i > 0; i++)
            {

            }
        }
    }
}
