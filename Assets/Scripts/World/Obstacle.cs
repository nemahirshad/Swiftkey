using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public TypingManager typingManager;
    public RhythmManager rhythmManager;

    public float speed = 10f;

    AudioSource audioSource;

    Rigidbody2D rb;

    Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);

        //Get Screen size
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        //Teleport Object to the right
        if (transform.position.x < -screenBounds.x)
        {
            transform.position = new Vector3(screenBounds.x * Random.Range(2, 5), transform.position.y, transform.position.z);
        }
    }
    
    //Damage Player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            audioSource.Play();

            if (typingManager)
            {
                typingManager.playerTrail.velocity.x -= 0.5f;

                for (int i = 0; i < typingManager.backgroundScrollers.Count; i++)
                {
                    typingManager.backgroundScrollers[i].ChangeSpeed(0.5f);
                }
            }

            if (rhythmManager)
            {
                rhythmManager.playerTrail.velocity.x -= 0.5f;

                for (int i = 0; i < rhythmManager.backgroundScrollers.Count; i++)
                {
                    rhythmManager.backgroundScrollers[i].ChangeSpeed(0.5f);
                }
            }            
        }
    }
}
