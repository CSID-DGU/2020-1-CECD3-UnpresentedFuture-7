using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RankingSceneManager : MonoBehaviour
{
    //게임 화면으로 씬 이동
    public void Game_Ranking()
    {
        SceneManager.LoadScene("Ranking_Scene");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "hand")
        {
            Game_Ranking();
        }
    }
}