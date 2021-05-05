using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInit : MonoBehaviour
{
    public SceneName sceneName;

    // Start is called before the first frame update
    void Start()
    {
        sceneName.sceneName = SceneManager.GetActiveScene().name;
    }

}
