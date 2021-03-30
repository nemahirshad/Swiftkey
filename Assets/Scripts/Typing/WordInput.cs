using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInput : MonoBehaviour
{
    public TypingManager tm;

    // Update is called once per frame
    void Update()
    {
        foreach (char letter in Input.inputString)
        {
            tm.TypeLetter(letter);
        }
    }
}