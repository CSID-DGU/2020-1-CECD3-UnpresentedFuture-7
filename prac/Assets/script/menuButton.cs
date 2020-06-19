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
    public void levelup_bt(){
        controller.level++;
    }
    public void leveldown_bt(){
        controller.level--;
    }

    public  void  reStart()
    {   Time.timeScale = 1f;
        Debug.Log("why not react...");
        SceneManager.LoadScene("punch");
    }
}
