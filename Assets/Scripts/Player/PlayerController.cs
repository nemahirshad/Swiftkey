using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public TypingManager typingManager;
    public RhythmManager rhythmManager;

    public LoadNewScene loadScene;

    public Slider slider;

    public float jumpVelocity = 5f;

    public string getActiveScene;

    [SerializeField] 
    private LayerMask GroundLayerMask;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;


    private void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    public void GetCurrentScene()
    {
        getActiveScene = SceneManager.GetActiveScene().name;
    }

    private void Update()
    {
        //Checks whether we have a typing manager or a rhythm manager to control the backgrounds and the HP
        if (typingManager)
        {
            slider.value = typingManager.backgroundScrollers[0].scrollSpeed * -1;
            
            if (typingManager.backgroundScrollers[0].stopped)
            {
                IsDead();
            }
        }
        if (rhythmManager)
        {
            slider.value = rhythmManager.backgroundScrollers[0].scrollSpeed * -1;

            if (rhythmManager.backgroundScrollers[0].stopped)
            {
                IsDead();
            }
        }

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, 1f, GroundLayerMask);
        return raycastHit2d.collider != null;
    }

    //Loads the Game over scene
    public void IsDead()
    {
        loadScene.LoadGameOverScene();             //Loads the Game Over Scene and ends the game.
    }
}
