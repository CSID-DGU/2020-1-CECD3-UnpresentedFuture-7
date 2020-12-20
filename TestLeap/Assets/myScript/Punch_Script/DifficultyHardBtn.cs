﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyHardBtn : MonoBehaviour
{
    public void HardGame_Start()
    {
        Time.timeScale = 1f;
        controller.heart = 30f;
        controller.mode = 0;
        controller.score = 0;
        controller.level = 1;
        
        SceneManager.LoadScene("punch");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "hand")
        {
            HardGame_Start();
        }
    }
}