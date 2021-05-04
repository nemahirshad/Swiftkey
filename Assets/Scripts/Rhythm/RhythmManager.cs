using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RhythmManager : MonoBehaviour
{
	public PlayerTrail playerTrail;

	public Text missedNotesText;
	public Text comboText;

	public List<BackgroundScoller> backgroundScrollers;

	public LoadNewScene loadNextScene;

	float comboPower;

	int comboCount;
	int missedNotesCounter;

	//Increase combo and speed if note hit
	public void NoteHit()
    {
		comboCount++;
		comboText.text = "Combo: " + comboCount;

		comboPower = -0.0005f * comboCount;

		playerTrail.velocity.x += 0.01f;

		for (int i = 0; i < backgroundScrollers.Count; i++)
		{
			backgroundScrollers[i].ChangeSpeed(-0.01f + comboPower);
		}

		if (comboCount == 20)
		{
			loadNextScene.LoadNextLevel();
		}
	}

	//Decrease speed and reset combo if note missed
	public void NoteMissed()
    {
		for (int i = 0; i < backgroundScrollers.Count; i++)
		{
			backgroundScrollers[i].ChangeSpeed(0.1f);
		}

		playerTrail.velocity.x -= 0.1f;

		comboCount = 0;
		comboText.text = "Combo: " + comboCount;

		missedNotesCounter++;
		missedNotesText.text = "Missed Notes: " + missedNotesCounter;
	}
}
