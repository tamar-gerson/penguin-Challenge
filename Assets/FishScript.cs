using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    private LogicScript logic;
    private PenguinScript penguin;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        penguin = GameObject.FindGameObjectWithTag("Penguin").GetComponent<PenguinScript>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Penguin") && penguin.getAlive())
        {
            Debug.Log("Fish eaten");
            logic.addScore();
            Debug.Log("Score: " + logic.getScore());
            Destroy(gameObject);
        }
    }
    
}
