using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TypingManager : MonoBehaviour
{
    public SentenceSplitter sentenceSplitter;

	public WordSpawner wordSpawner;

	public List<BackgroundScoller> backgroundScollers;

	public List<Word> words;

	public string sceneName;

	public bool intro;

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
		else
		{
			SceneManager.LoadScene(sceneName);
		}
    }

	public void TypeLetter(char letter)
	{
		if (hasActiveWord)
		{
			if (activeWord.GetNextLetter() == letter)
			{
				activeWord.TypeLetter();

				if (!intro)
				{
					for (int i = 0; i < backgroundScollers.Count; i++)
					{
						backgroundScollers[i].ChangeSpeed(-0.01f);
					}
				}
			}
			else if (activeWord.GetNextLetter() != letter)
			{
				if (!intro)
				{
					for (int i = 0; i < backgroundScollers.Count; i++)
					{
						backgroundScollers[i].ChangeSpeed(0.1f);
					}
				}
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
