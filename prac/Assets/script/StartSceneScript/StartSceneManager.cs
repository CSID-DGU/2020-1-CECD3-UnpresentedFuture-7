using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager: MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        
    }

    //게임 화면으로 씬 이동
    public void Game_Start() {
        controller.score=0;
        controller.level=1;
        SceneManager.LoadScene("punch");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="hand") { 
        controller.score=0;
        controller.level=1;
            SceneManager.LoadScene("punch");
        }
       
    }
}