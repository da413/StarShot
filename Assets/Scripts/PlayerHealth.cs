using System;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{
    private int currenthealth;
    private int maxhealth = 4;
    public static event Action onPlayerDeath;

    public Image healthImage;
    [SerializeField] List<Sprite> healthStates = new List<Sprite>();

    void Awake()
    {
        currenthealth = maxhealth;
        healthImage.sprite = healthStates[4];
    }
    
    public void TakeDamage(int damage)
    {
        currenthealth -= damage;
        UpdateHealthBar();
        
        if(currenthealth <= 0)
        {
            onPlayerDeath?.Invoke();
        }
        
    }

    void UpdateHealthBar()
    {
        switch (currenthealth)
        {
            case 4:
            healthImage.sprite = healthStates[4]; //full health
            break;
            case 3: 
            healthImage.sprite = healthStates[3]; //three health
            break;
            case 2:
            healthImage.sprite = healthStates[2]; //two health
            break;
            case 1:
            healthImage.sprite = healthStates[1]; //one health
            break;
            case 0:
            healthImage.sprite = healthStates[0]; //no health
            break;

        }
    }

    
}
