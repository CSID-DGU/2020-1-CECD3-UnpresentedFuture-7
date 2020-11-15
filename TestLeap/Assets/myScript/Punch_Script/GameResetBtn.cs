using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResetBtn : MonoBehaviour
{
    public void Game_Reset()
    {
        Debug.Log("Game Reset...@");
        Time.timeScale = 1f;
        controller.heart = 30f;
        controller.score = 0;
        controller.level = 1;
        
        SceneManager.LoadScene("punch");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "hand")
        {
            Game_Reset();
        }
    }
}
