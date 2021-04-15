using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject prefab;

    public float maxRespawnTime;
    public float minRespawnTime;

    float countdown;

    // Start is called before the first frame update
    void Start()
    {
        countdown = Random.Range(minRespawnTime, maxRespawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0)
        {
            GameObject a = Instantiate(prefab);
            a.transform.position = transform.position;
            a.transform.rotation = transform.rotation;
            countdown = Random.Range(minRespawnTime, maxRespawnTime);
        }
        else
        {
            countdown -= Time.deltaTime;
        }
    }
}
