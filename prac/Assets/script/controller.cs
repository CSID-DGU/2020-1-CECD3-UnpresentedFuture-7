using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controller : MonoBehaviour
{

    public Text score_text;
    public Text timeText;

    public static int score=0;
    Vector3 original_p;
    private float time=0;

    public GameObject firstprefab;
    public Canvas menu;
    private bool isopen=false;


    // Start is called before the first frame update
    void Start()
    {
        time = 15f;
        original_p = new Vector3(-15f,-3f,-5f);
        Invoke("continueing", 1);
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
    


    }

  
    private void continueing()
    {
        Instantiate(firstprefab, new Vector3(original_p.x*Random.Range(-3f,3f),original_p.y*Random.Range(-5f,5f),original_p.z*Random.Range(-5f,5f)), Quaternion.identity);

        Invoke("continueing", 1);
    }

    // Update is called once per frame
 

}
