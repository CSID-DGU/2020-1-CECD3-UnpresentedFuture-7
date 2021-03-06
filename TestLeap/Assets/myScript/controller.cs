﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controller : MonoBehaviour
{

    public Text score_text;
    // public Text level_text;

    // public static bool isglovedRight=false;//글러브 추가 성두
    // public static bool isglovedLeft=false;//글러브 추가 성두
    public static int level = 1;
    public static int score = 0;
    public static float heart = 0;// 0618 성두 static
    public GameObject firstprefab;
    public GameObject secondprefab;
    public GameObject thirdprefab;

    public GameObject Chili;
    public GameObject Kiwi;
    public GameObject Eggy;
    public GameObject Langsat;
    public GameObject Slime;
    public GameObject Turtle;

    Vector3 original_p;
    public Canvas menu;

    private bool isopen = false;
    public GameObject menu_gameover;
    private bool isover = false;

    public float delayTime;
    public static int mode = 0; // 0/1/2 : 각각 easy/normal/hard
    [SerializeField] Text modeText;

    public static bool ishit = false;
    // Start is called before the first frame update
    public static AudioClip soundExplosion;
    public static AudioSource myAudio;

    private addNewRank newUser;
    bool turnOff = false;

    void Start()
    {
        newUser = this.GetComponent<addNewRank>();

        myAudio = this.gameObject.GetComponent<AudioSource>();
        myAudio.Stop();
        // oncam();

        heart = 30f;
        original_p = new Vector3(0.0f, 0.0f, 10.0f);
        StartCoroutine(continueing());
        delayTime = 3.0f;

        switch (mode)
        {
            case 0:
                modeText.text = "Easy";
                break;
            case 1:
                modeText.text = "Normal";
                break;
            case 2:
                modeText.text = "Hard";
                break;
            default:
                modeText.text = "There is some ERROR...";
                break;

        }
    }
    void Update()
    {
        heart -= Time.deltaTime;
        if (heart < 0)
        {
            if (turnOff == false)
            {
                turnOff = true;
                newUser.addNew();
                menu_gameover.SetActive(true);
                //Instantiate(menu);
            }
        }
        if (Input.GetKeyDown("escape"))
        {
            isopen = !isopen;
            if (isopen)
            {
                // mode_canvas.enabled = true;
                Time.timeScale = 0.001f;
                menu.enabled = true;
                //Instantiate(menu);
            }
            else
            {
                // mode_canvas.enabled = false;
                menu.enabled = false;
                Time.timeScale = 1f;
            }
        }


        score_text.text = score.ToString();   // 점수 갱신
        // level_text.text = "Lv : " + level;   // 점수 갱신
    }


    void instantiate_Prefab(GameObject Prefab)
    {
        // Instantiate(Prefab, new Vector3(original_p.x + Random.Range(-15f, 15f),
        //                                     original_p.y + Random.Range(-5f, 5f),
        //                                     original_p.z + Random.Range(30f, 40f)),
        //                                     Quaternion.identity);
        Instantiate(Prefab, new Vector3(original_p.x + Random.Range(-20f, 25f),
                                            original_p.y + Random.Range(-5f, 5f),
                                            original_p.z + Random.Range(-0f, 25f)),
                                            Quaternion.identity);
    }

    IEnumerator continueing()
    {
        while (true)
        {
            bool levelparam = level % 2 == 0;
            float delay = delayTime / level;
            // 랜덤한 위치에 따라 타격 오브젝트 생성
            if (delay < 1.5f) { delay = 1.5f; }

            if (levelparam) instantiate_Prefab(Turtle);
            else instantiate_Prefab(Kiwi);

            if (level > 4)
            {
                if (levelparam) instantiate_Prefab(Chili);
                else instantiate_Prefab(Eggy);
                delay = 3.0f;

            }
            if (level > 9)
            {
                if (levelparam) instantiate_Prefab(Langsat);
                else instantiate_Prefab(Slime);
                delay = 5f;
            }
            yield return new WaitForSeconds(delay);
        }
    }

}
