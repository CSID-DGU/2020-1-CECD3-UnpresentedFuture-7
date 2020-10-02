using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuButton : MonoBehaviour
{
        public Text mode_text;
    
    // Start is called before the first frame update
    void Start()
    {
          controller.mode=0;
          mode_text.text="easy";
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
    public void easy_mode(){
        controller.mode=0;
        mode_text.text="easy";
    }
      public void normal_mode(){
        controller.mode=1;
        mode_text.text="normal";
    }
      public void hard_mode(){
        controller.mode=2;
        mode_text.text="hard";
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
