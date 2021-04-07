using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordDisplay : MonoBehaviour
{
	public Text text;

	public Color wordColor;
	public Color typoColor;

	public void SetWord(string word)
	{
		text.text = word;
	}

	public void RemoveLetter()
	{
		text.text = text.text.Remove(0, 1);
		text.color = wordColor;
	}

	public void RemoveWord()
	{
		Destroy(gameObject);
	}

	public void ChangeColor()
    {
		text.color = typoColor;
    }
}