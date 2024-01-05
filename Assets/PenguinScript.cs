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
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            moveHorz = Input.GetAxisRaw("Horizontal");
            moveVert = Input.GetAxisRaw("Vertical");
            if (moveHorz < 0 && isAlive)
            {
                //Debug.Log("change scale");
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (moveHorz > 0 && isAlive)
            {
                // If moving right, you might want to reset the scale to its original state.
                // If not, the scale will keep accumulating.
                //Debug.Log("change scale");
                transform.localScale = new Vector3(1, 1, 1);
            }
            // if (moveHorz < 0 && isAlive)
            // {
            //     transform.localScale = new Vector3(-1, 1, 1);
            //     transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            // }
            // else if (moveHorz > 0 && isAlive)
            // {
            //     transform.localScale = new Vector3(1, 1, 1);
            //     transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            // }
            // if(moveVert < 0 && isAlive)
            // {
            //     transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            // }
            // else if(moveVert > 0 && isAlive)
            // {
            //     transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            // }
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
