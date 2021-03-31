using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScoller : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public Rigidbody2D rb;
    
    public float scrollSpeed = -2f;
    
    public int teleport;

    public bool stopped;

    private float width;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        width = boxCollider.size.x;
        boxCollider.enabled = false;

        rb.velocity = new Vector2(scrollSpeed, 0);
    }

    void Update()
    {
        if (transform.position.x < -width* 3)
        {
            Vector2 resetPosition = new Vector2(width * teleport, 0);
            transform.position = (Vector2)transform.position + resetPosition;
        }
    }

    public void ChangeSpeed(float newSpeed)
    {
        scrollSpeed += newSpeed;

        if (scrollSpeed >= 0)
        {
            scrollSpeed = 0;
            stopped = true;
        }

        if (scrollSpeed <= -15f)
        {
            scrollSpeed = -15f;
        }

        rb.velocity = new Vector2(scrollSpeed, 0);
    }
}
