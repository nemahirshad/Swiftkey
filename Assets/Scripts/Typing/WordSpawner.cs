
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
	public GameObject wordPrefab;

	public Transform wordCanvas;
	public Transform point;

	public Vector3 offset;

	public WordDisplay SpawnWord()
	{
		GameObject wordObj = Instantiate(wordPrefab, point.position, Quaternion.identity, wordCanvas);
		WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();

		return wordDisplay;
	}
}