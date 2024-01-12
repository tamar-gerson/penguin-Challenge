using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GummyScript : MonoBehaviour
{
    private LogicScript logic;
    [SerializeField] private int crazyTime ;
    [SerializeField] private float destroyTimer;
    [SerializeField] private PenguinScript penguin;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        penguin = GameObject.FindGameObjectWithTag("Penguin").GetComponent<PenguinScript>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Penguin") && penguin.getAlive())
        {
            Destroy(gameObject);
            logic.crazyMode(crazyTime);
        }
    }
}
