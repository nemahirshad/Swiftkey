using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingManager : MonoBehaviour
{
    public SentenceSplitter sentenceSplitter;

	public WordSpawner wordSpawner;

	public List<Word> words;

	private Word activeWord;

	private int wordIndex;

	private bool hasActiveWord;

	// Start is called before the first frame update
	void Start()
    {
		AddWord();
    }

    public void AddWord()
    {
		if (sentenceSplitter.words.Count > wordIndex)
        {
			Word word = new Word(sentenceSplitter.words[wordIndex], wordSpawner.SpawnWord());

			wordIndex++;
			words.Add(word);
		}
    }

	public void TypeLetter(char letter)
	{
		if (hasActiveWord)
		{
			if (activeWord.GetNextLetter() == letter)
			{
				activeWord.TypeLetter();
			}
		}
		else
		{
			foreach (Word word in words)
			{
				if (word.GetNextLetter() == letter)
				{
					activeWord = word;
					hasActiveWord = true;
					word.TypeLetter();
					break;
				}
			}
		}

		if (hasActiveWord && activeWord.WordTyped())
		{
			hasActiveWord = false;
			words.Remove(activeWord);
			AddWord();
		}
	}
}
