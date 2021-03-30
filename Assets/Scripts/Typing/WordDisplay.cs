using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordDisplay : MonoBehaviour
{
	public Text text;

	public float moveSpeed;

	public void SetWord(string word)
	{
		text.text = word;
	}

	public void RemoveLetter()
	{
		text.text = text.text.Remove(0, 1);
		text.color = Color.red;
	}

	public void RemoveWord()
	{
		Destroy(gameObject);
	}

	private void Update()
	{
		transform.Translate(-moveSpeed * Time.deltaTime, 0f, 0f);
	}

}