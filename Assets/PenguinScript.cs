using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed;
    private float moveVert;
    private float moveHorz;
    private bool isAlive = true;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = 0.2f;
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
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (moveHorz > 0 && isAlive)
            {
                // If moving right, you might want to reset the scale to its original state.
                // If not, the scale will keep accumulating.
                transform.localScale = new Vector3(1, 1, 1);
            }
            ClampPosition();
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
    
    void ClampPosition()
    {
        void ClampPosition()
        {
            // Get the player's position in the viewport
            Vector3 playerViewportPos = Camera.main.WorldToViewportPoint(transform.position);

            // Clamp the player's position to the screen boundaries
            playerViewportPos.x = Mathf.Clamp(playerViewportPos.x, 0f, 1f);
            playerViewportPos.y = Mathf.Clamp(playerViewportPos.y, 0f, 1f);

            // Set the player's position back in world coordinates
            transform.position = Camera.main.ViewportToWorldPoint(playerViewportPos);
        }
    }

    public void isDead()
    {
        isAlive = false;
    }

    public bool getAlive()
    {
        return isAlive;
    }
}
