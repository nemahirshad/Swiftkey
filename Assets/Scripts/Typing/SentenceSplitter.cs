using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentenceSplitter : MonoBehaviour
{
    //[TextArea(3, 10)]
    //public string sentence;

    public List<string> words;                  //Suggestion: Rename to "sentences" to make things clearer. =)

    // Start is called before the first frame update
    void Awake()
    {
        //words.AddRange(sentence.Split(' '));
    }
}


//Farhan Note: Ask the others if we can move the "Words" List to the Typing Manager and get rid of this script.
//Farhan Note [The Sequel No One Asked For]: Gonna add "=)" to the end of my comments to mark them as mine. Easier than typing "Farhan Note" tbh.