using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controller : MonoBehaviour
{

    public Text score_text;
    public Text level_text;
    public static int level = 1;
    public static int score = 0;
    public static float heart = 0;// 0618 성두 static
    public GameObject firstprefab;
    Vector3 original_p;
    public Canvas menu;
   private bool isopen = false;
     public Canvas menu_gameover;
     private bool isover=false;

    public float delayTime;


    // Start is called before the first frame update
    void Start()
    {
        heart = 30f;
        original_p = new Vector3(0.0f, 5.0f, 10f);
        StartCoroutine(continueing());
        delayTime = 3.0f;
        
                menu_gameover.enabled = false;

    }
    void Update()
    {
        heart -= Time.deltaTime;
        if (heart < 0)
        {
            Time.timeScale = 0;

                menu_gameover.enabled = true;
                //Instantiate(menu);

        }
        if (Input.GetKeyDown("escape"))
        {
            isopen = !isopen;
            if (isopen)
            {
                Time.timeScale = 0.001f;
                menu.enabled = true;
                //Instantiate(menu);
            }
            else
            {
                menu.enabled = false;
                Time.timeScale = 1f;
            }
        }
        

        score_text.text = "score : " + score;   // 점수 갱신
        level_text.text = "level : " + level;   // 점수 갱신
    }
    

  

    IEnumerator continueing()
    {
        while (true)
        {
            // 랜덤한 위치에 따라 타격 오브젝트 생성
            Instantiate(firstprefab, new Vector3(original_p.x + Random.Range(-30f, 30f),
                                                original_p.y + Random.Range(-5f, 5f),
                                                original_p.z + Random.Range(-10f, 10f)),
                                                Quaternion.identity);
            float delay=delayTime/level;
            if(delay<0.8f)
            delay=0.8f;

            yield return new WaitForSeconds(delay);
        }
    }
}
