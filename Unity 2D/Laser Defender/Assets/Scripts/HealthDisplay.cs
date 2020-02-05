using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    Player playerHealth;
    Text healthText;

    void Start()
    {
        playerHealth = FindObjectOfType<Player>();
        healthText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = playerHealth.GetHealth().ToString();   
    }
}
