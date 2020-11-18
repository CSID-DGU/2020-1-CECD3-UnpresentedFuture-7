using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    //게임 종료
    public void Game_End()
    {
        Application.Quit();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "hand")
        {
            hitsound_start.hitSound();
            Invoke("Game_End", 0.3f);
        }
    }
}