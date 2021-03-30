using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public TypingManager typingManager;

    public float speed = 10f;

    Rigidbody2D rb;

    Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -screenBounds.x)
        {
            transform.position = new Vector3(screenBounds.x * Random.Range(2, 5), transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            for (int i = 0; i < typingManager.backgroundScollers.Count; i++)
            {
                typingManager.backgroundScollers[i].ChangeSpeed(0.5f);
            }
        }
    }
}
