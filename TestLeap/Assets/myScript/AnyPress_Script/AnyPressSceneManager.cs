using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyPressSceneManager : MonoBehaviour
{
    public void nextScene()
    {
        SceneManager.LoadScene("InputNickName");
    }
}
