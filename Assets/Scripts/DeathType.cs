using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathType : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TypeOfDeath()
    {
        int typeOfDeath = player.GetComponent<PlayerStat>().DeathType();
        if (typeOfDeath == 1)
        {
            print("You drowned in acid.");
        }
    }
}
