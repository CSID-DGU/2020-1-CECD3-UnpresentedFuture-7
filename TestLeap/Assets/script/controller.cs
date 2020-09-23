using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controller : MonoBehaviour
{

    public Text score_text;
    public Text level_text;

    public static bool isglovedRight=false;//글러브 추가 성두
    public static bool isglovedLeft=false;//글러브 추가 성두
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
     public Canvas menu_gameover;
     private bool isover=false;

    public float delayTime;

    

    public static int mode=0; // 0/1/2 : 각각 easy/normal/hard
    public Canvas mode_canvas;






    public Renderer display;
    WebCamTexture camTexture;
    private int currentIndex = 0;
// 웹캡
    
    // Start is called before the first frame update


    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
     for (int i = 0; i < devices.Length; i++)
     {
         Debug.Log(i+devices[i].name);
     }


        if (camTexture != null)
        {
            display.material.mainTexture = null;
            camTexture.Stop();
            camTexture = null;
        }
        WebCamDevice device = WebCamTexture.devices[currentIndex];
        Debug.Log(device.name);
        WebCamDevice device2 = devices[currentIndex];

        Debug.Log(device2.name);
        
        camTexture = new WebCamTexture(device.name);
        display.material.mainTexture = camTexture;
        camTexture.Play();



        
        heart = 30f;
        original_p = new Vector3(0.0f, 5.0f, 10f);
        StartCoroutine(continueing());
        delayTime = 3.0f;
        
                menu_gameover.enabled = false;
                 mode_canvas.enabled=false;

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
                mode_canvas.enabled=true;
                Time.timeScale = 0.001f;
                menu.enabled = true;
                //Instantiate(menu);
            }
            else
            {mode_canvas.enabled=false;
                menu.enabled = false;
                Time.timeScale = 1f;
            }
        }
        

        score_text.text = "score : " + score;   // 점수 갱신
        level_text.text = "Lv : " + level;   // 점수 갱신
    }
    

  void instantiate_Prefab(GameObject Prefab){
            Instantiate(Prefab, new Vector3(original_p.x + Random.Range(-15f, 20f),
                                                original_p.y + Random.Range(-5f, 5f),
                                                original_p.z + Random.Range(-40f, 20f)),
                                                Quaternion.identity);
  }

    IEnumerator continueing()
    {
        while (true)
        {float delay=delayTime/level;
            // 랜덤한 위치에 따라 타격 오브젝트 생성
            if(delay<1.5f){ delay=1.5f;}
             instantiate_Prefab(Turtle);
             instantiate_Prefab(Kiwi);
                       
            if(level>4){
            instantiate_Prefab(Chili);
            instantiate_Prefab(Eggy);
            delay=2.0f;
                                  
            } if(level>9){
                instantiate_Prefab(Langsat);
                instantiate_Prefab(Slime);                
                 delay=2.5f;                       
            }
            yield return new WaitForSeconds(delay);
        }
    }
}
