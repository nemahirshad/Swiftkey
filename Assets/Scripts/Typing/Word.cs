using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word
{
	public string word;
	private int typeIndex;

	WordDisplay display;

	public Word(string _word, WordDisplay _display)
	{
		word = _word;
		typeIndex = 0;

		display = _display;
		display.SetWord(word);
	}

	public char GetNextLetter()
	{
		return word[typeIndex];
	}

	public void TypeLetter()
	{
		typeIndex++;
		display.RemoveLetter();
	}

	//Check if the word was typed if yes then delete the word
	public bool WordTyped()
	{
		bool wordTyped = (typeIndex >= word.Length);
		if (wordTyped)
		{
			display.RemoveWord();
		}
		return wordTyped;
	}

	public bool NextLetterAvailable()
    {
		if (typeIndex >= word.Length)
        {
			return false;
        }
		return true;
    }

	public void Typo()
    {
		display.ChangeColor();
    }
}