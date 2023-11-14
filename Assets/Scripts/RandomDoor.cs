using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDoor : MonoBehaviour
{
    private int randomDoor;
    public GameObject door0;
    public GameObject door1;

    void Start()
    {
        //Either 1 or 2 chosen randomly, a 50% chance.
        randomDoor = Random.Range(0, 2);
        Debug.Log("Door number " + randomDoor + " is dangerous.");
    }

    void Update()
    {
        //Chooses the door to kill the player depending on the chances and changes its tag.
        if (randomDoor == 0)
        {
            door0.tag = "InstantDeath";
        }
        else
        {
            door1.tag = "InstantDeath";
        }
    }
}
