using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    //게임 화면으로 씬 이동
    public void Game_Start()
    {
        SceneManager.LoadScene("GameMode_Scene");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "hand")
        {
                      hitsound_start.hitSound();
            Invoke("Game_Start",0.3f);
        }
    }
}