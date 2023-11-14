using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeDoor : MonoBehaviour
{
    private int keyCount = 0;
    private bool canUnlock;

    // Start is called before the first frame update
    void Start()
    {
        canUnlock = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (keyCount == 2)
        {
            canUnlock = true;
        }
    }

    //Destroy the gate since it's not needed anymore.
    public void UnlockDoor()
    {
        Destroy(gameObject);
    }

    //Adds to the key count.
    public void CheckForKey(int invCount)
    {
        keyCount += invCount;
    }

    //Lets another script know if the gate can be unlocked without needing to be public all the time.
    public bool CanUnlock()
    {
        return canUnlock;
    }
}
