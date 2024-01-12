using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadFishScript : MonoBehaviour
{
    public LogicScript logic;
    [SerializeField] private float destroyTimer;
    [SerializeField] private PenguinScript penguin;
    
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        penguin = GameObject.FindGameObjectWithTag("Penguin").GetComponent<PenguinScript>();
        Destroy(gameObject, destroyTimer);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Penguin") && penguin.getAlive())
        {
            penguin.isDead();
            logic.GameOver();
        }
    }
}
