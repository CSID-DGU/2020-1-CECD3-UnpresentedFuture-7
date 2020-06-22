using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void goto_start_scene(){
        
        SceneManager.LoadScene("Start_Scene_YGC");
    }
    public void levelup_bt(){
        controller.score+=5;
        controller.level++;
    }
    public void leveldown_bt(){
         controller.score-=5;
        controller.level--;
    }

    public  void  reStart()
    {   Time.timeScale = 1f;
    controller.heart=30f;
        Debug.Log("why not react...");
        controller.score=0;
        controller.level=1;

        SceneManager.LoadScene("punch");
    }
}
