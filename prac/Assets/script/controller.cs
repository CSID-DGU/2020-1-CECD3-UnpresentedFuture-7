using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controller : MonoBehaviour
{

    public Text score_text;
    public static int score = 0;
    public Text timeText;
    private float time = 0;
    public GameObject firstprefab;
    Vector3 original_p;
    public Canvas menu;
    private bool isopen = false;

    public float delayTime;


    // Start is called before the first frame update
    void Start()
    {
        time = 15f;
        original_p = new Vector3(0.0f, 5.0f, 10f);
        StartCoroutine(continueing());
        delayTime = 2.0f;

    }
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            Time.timeScale = 0;
        }
        //  Debug.Log("heart : " + time);
        timeText.text = Mathf.Ceil(time).ToString();
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
            yield return new WaitForSeconds(delayTime);
        }
    }
}