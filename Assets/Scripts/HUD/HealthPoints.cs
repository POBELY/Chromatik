using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class HealthPoints : MonoBehaviour
{

    public List<HeartHUD> hearts = new List<HeartHUD>();

    private int limitHealth = 5;

    // Start is called before the first frame update
    void Start()
    {
        limitHealth = hearts.Count;
        for (int i = 0; i < GameManager.Instance.player.maxHealth; i++)
        {
            hearts[i].Unlock();
        }
        LifeUpdate();
    }

    public void LifeUpdate()
    {
        for (int i = 0; i < limitHealth; i++)
        {
            if (i < GameManager.Instance.player.health)
            {
                hearts[i].On();
            }
            else if (i < GameManager.Instance.player.maxHealth)
            {
                hearts[i].Off();
            }
        }
    }
}
