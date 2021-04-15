using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TypingManager : MonoBehaviour
{
    public SentenceSplitter sentenceSplitter;

	public WordSpawner wordSpawner;

	public PlayerTrail playerTrail;

	public Text typoText;
	public Text comboText;

	public List<BackgroundScoller> backgroundScrollers;

	public List<Word> words;

	public string sceneName;

	public bool intro;

	Word activeWord;

	float comboPower;

	int comboCount;
	int wordIndex;
	int typoCounter;

	bool hasActiveWord;

	// Start is called before the first frame update
	void Start()
    {
		AddWord();
    }

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape) && intro)
		{
			SceneManager.LoadScene(sceneName);
		}
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
					comboCount++;
					comboText.text = "Combo: " + comboCount;

					comboPower = -0.0005f * comboCount;

					playerTrail.velocity.x += 0.01f;

					for (int i = 0; i < backgroundScrollers.Count; i++)
					{
						backgroundScrollers[i].ChangeSpeed(-0.01f + comboPower);
					}
				}

				if (activeWord.NextLetterAvailable())
                {
					if (activeWord.GetNextLetter() == ' ')
					{
						activeWord.TypeLetter();
						return;
					}
				}
			}
			else if (activeWord.GetNextLetter() != letter && letter != ' ')
			{
				activeWord.Typo();

				if (!intro)
				{
					for (int i = 0; i < backgroundScrollers.Count; i++)
					{
						backgroundScrollers[i].ChangeSpeed(0.1f);
					}

					playerTrail.velocity.x -= 0.1f;

					comboCount = 0;
					comboText.text = "Combo: " + comboCount;

					typoCounter++;
					typoText.text = "Typo Counter: " + typoCounter;
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
