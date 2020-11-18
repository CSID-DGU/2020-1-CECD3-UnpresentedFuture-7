using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "punch")
        {
            GameObject.Destroy(gameObject);
        }
        else if (SceneManager.GetActiveScene().name == "Ranking_Scene")
        {
            GameObject.Destroy(gameObject);
        }
    }
}
