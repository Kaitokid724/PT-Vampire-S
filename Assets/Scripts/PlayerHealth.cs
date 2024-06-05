using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    public float currentHealth, maxHealth;

    public Slider healthSlider;
    private void Awake()
    {
        instance = this;

        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage; 
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }

        healthSlider.value = currentHealth;
    }
}
