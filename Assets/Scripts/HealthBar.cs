using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider health;
    public GameObject player;

    //Updates the UI health bar.
    void Update()
    {
        health.value = player.GetComponent<PlayerStat>().PlayerHealth();
    }
}
