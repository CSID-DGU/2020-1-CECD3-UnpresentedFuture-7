using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private AudioSource sound;
    private bool isPlay;
    // Start is called before the first frame update
    void Start()
    {
        isPlay = true;
        sound = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Start_Scene")
        {
            if (isPlay == false)
            {
                isPlay = true;
                sound.Play();
                Debug.Log("브금 시작");
            }
        }
        else if (SceneManager.GetActiveScene().name == "punch")
        {
            isPlay = false;
            sound.Stop();
            Debug.Log("브금 정지");
        }
        // else if (SceneManager.GetActiveScene().name == "Ranking_Scene")
        // {
        //     GameObject.Destroy(gameObject);
        // }
    }
}
