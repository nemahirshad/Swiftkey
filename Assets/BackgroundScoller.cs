using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScoller : MonoBehaviour
{

    public  new BoxCollider2D collider;
    public Rigidbody2D rb;
    private float width;
    private float scrollSpeed = -2f;
    public int teleport;


    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        width = collider.size.x;
        collider.enabled = false;

        rb.velocity = new Vector2(scrollSpeed, 0);

    }

 
    void Update()
    {
        if(transform.position.x < -width* 3)
        {
            Vector2 resetPosition = new Vector2(width * teleport, 0);
            transform.position = (Vector2)transform.position + resetPosition;
        }

    }
}
