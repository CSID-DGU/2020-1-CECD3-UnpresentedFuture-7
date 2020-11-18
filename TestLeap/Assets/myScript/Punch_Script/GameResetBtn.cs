﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResetBtn : MonoBehaviour
{
    public void Game_Reset()
    {
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
