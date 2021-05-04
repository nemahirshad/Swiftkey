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

	public LoadNewScene loadNextScene;

	public Text typoText;
	public Text comboText;

	public List<BackgroundScoller> backgroundScrollers;

	public List<Word> words;

	public AudioClip[] narratorVoiceLines;

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
		//Skips intro
		if (Input.GetKeyDown(KeyCode.Escape) && intro)
		{
			loadNextScene.LoadNextLevel();				//Loads the next level. 
		}
	}

    public void AddWord()
    {
		//Adds the next sentence to the screen if there are sentences left
		if (sentenceSplitter.words.Count > wordIndex)
        {
			Word word = new Word(sentenceSplitter.words[wordIndex], wordSpawner.SpawnWord());


			AudioSource narratoraudio = GetComponent<AudioSource>();
			narratoraudio.clip = narratorVoiceLines[wordIndex];
			narratoraudio.Play();


			wordIndex++;
			words.Add(word);
		}
		else
		{
			loadNextScene.LoadNextLevel();              //Loads the next level. 
		}
	}

	//Types each letter
	public void TypeLetter(char letter)
	{
		if (hasActiveWord)
		{
			//If you type correctly increase speed and combo
			if (activeWord.GetNextLetter() == letter)
			{
				activeWord.TypeLetter();

				//If It's Not The Intro Scene, increase Player Combo, Player Trail Speed and Background Scroll Speed for every correct letter typed =)
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

				//If next letter is a space skip it
				if (activeWord.NextLetterAvailable())
                {
					if (activeWord.GetNextLetter() == ' ')
					{
						activeWord.TypeLetter();
						return;
					}
				}
			}
			//If you didn't type correctly then decrease speed and reset combo
			else if (activeWord.GetNextLetter() != letter && letter != ' ')
			{
				activeWord.Typo();

				//If It's Not The Intro Scene, decrease Player Combo, Player Trail Speed and Background Scroll Speed for every correct letter typed =)
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
		//If there is no sentence available get the next one in the list
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
		//If finished sentence get next one
		if (hasActiveWord && activeWord.WordTyped())
		{
			hasActiveWord = false;
			words.Remove(activeWord);
			AddWord();
		}
	}
}
