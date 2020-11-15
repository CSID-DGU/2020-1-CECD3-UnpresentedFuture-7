using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputNickNameSceneManager : MonoBehaviour
{
    // Start 씬으로 이동
    public void Game_Start()
    {
        SceneManager.LoadScene("Start_Scene");
    }
}