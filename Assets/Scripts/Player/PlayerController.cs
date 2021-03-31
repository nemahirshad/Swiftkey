using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public TypingManager typingManager;

    public Slider slider;

    public float jumpVelocity = 5f;

    [SerializeField] 
    private LayerMask GroundLayerMask;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;

    private void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        slider.value = typingManager.backgroundScollers[0].scrollSpeed * -1;

        if (typingManager.backgroundScollers[0].stopped)
        {
            IsDead();
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

    public void IsDead()
    {
        SceneManager.LoadScene("Game Over");
    }
}
