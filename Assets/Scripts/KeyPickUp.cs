using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    public GameObject key1;
    public GameObject key2;

    //Checks for collision with the keys, adds it to inventory and destroys the unneeded key.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Key1")
        {
            gameObject.GetComponent<Inventory>().AddToInventory("Key1");
            Destroy(key1);
        }
        else if (collision.gameObject.tag == "Key2")
        {
            gameObject.GetComponent<Inventory>().AddToInventory("Key2");
            Destroy(key2);

        }
    }
}
