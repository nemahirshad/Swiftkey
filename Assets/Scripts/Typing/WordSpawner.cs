
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
	public GameObject wordPrefab;
	public GameObject previousWord;

	public Transform wordCanvas;
	public Transform point;

	public Vector3 offset;

	public WordDisplay SpawnWord()
	{
		if (previousWord != null)
        {
			GameObject wordObj = Instantiate(wordPrefab, previousWord.transform.position + offset, Quaternion.identity, wordCanvas);
			WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();
			previousWord = wordObj;

			return wordDisplay;
		}
		else
        {
			GameObject wordObj = Instantiate(wordPrefab, point.position, Quaternion.identity, wordCanvas);
			WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();
			previousWord = wordObj;

			return wordDisplay;
		}
	}
}