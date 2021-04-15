using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public RhythmManager rhythmManager;

    public KeyCode keyToPress;

    public Color pressedColor;
    public Color defaultColor;

    GameObject note;

    SpriteRenderer spriteRenderer;

    bool pressed;
    bool canBePressed;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = defaultColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            spriteRenderer.color = pressedColor;

            if (!canBePressed)
            {
                rhythmManager.NoteMissed();
            }

            if (canBePressed)
            {
                Destroy(note);

                rhythmManager.NoteHit();
            }
        }

        if (Input.GetKeyUp(keyToPress))
        {
            spriteRenderer.color = defaultColor;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Note"))
        {
            note = collision.gameObject;

            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Note"))
        {
            canBePressed = false;
        }
    }
}
