using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeSceneManager : MonoBehaviour
{
    //게임 화면으로 씬 이동
    public void Game_Start()
    {
        controller.score = 0;
        controller.level = 1;
        SceneManager.LoadScene("punch");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "hand")
        {
            Game_Start();
        }
    }
}
