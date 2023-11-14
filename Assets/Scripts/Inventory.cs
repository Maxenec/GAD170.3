using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<string> inventory = new List<string>();
    public GameObject mazeDoor;

    //Add to inventory what another script gives, and check the count of inventory to see if it needs to be checked.
    public void AddToInventory(string key)
    {
        inventory.Add(key);
        Debug.Log("Added " + key + " to inventory.");
        if (inventory.Count == 2)
        {
            CheckInventory();
        }
    }

    //Check inventory and see if these keys exist, and number how many of them there until the ends are and send it to another script.
    public void CheckInventory()
    {
        Debug.Log("Checking Inventory");
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i] == "Key1" || inventory[i] == "Key2")
            {
                mazeDoor.GetComponent<MazeDoor>().CheckForKey(1);
            }
        }
    }
}
