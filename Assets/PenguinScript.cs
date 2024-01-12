using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed ;
    private float moveVert;
    private float moveHorz;
    private bool isAlive = true;
    
    
    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            moveHorz = Input.GetAxisRaw("Horizontal");
            moveVert = Input.GetAxisRaw("Vertical");
            if (moveHorz < 0 && isAlive)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (moveHorz > 0 && isAlive)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    void FixedUpdate()
    {
        if (isAlive)
        {
            if (moveHorz != 0)
            {
                rb.AddForce(new Vector2(moveHorz * moveSpeed, 0f), ForceMode2D.Impulse);
            }
        
            if (moveVert != 0)
            {
                rb.AddForce(new Vector2(0f, moveVert * moveSpeed), ForceMode2D.Impulse);
            }
        }
    }
    
    public void isDead()
    {
        Debug.Log("penguin is dead. game over");
        isAlive = false;
    }

    public bool getAlive()
    {
        return isAlive;
    }
}
