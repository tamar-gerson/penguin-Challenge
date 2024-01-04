using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadFishScript : MonoBehaviour
{
    [SerializeField] private LogicScript logic;
    [SerializeField] private float destroyTimer;
    [SerializeField] private PenguinScript penguin;
    
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        penguin = GameObject.FindGameObjectWithTag("Penguin").GetComponent<PenguinScript>();
        Destroy(gameObject, destroyTimer);
    }
    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        penguin.isDead();
        logic.GameOver();
        Destroy(gameObject);
    }
}