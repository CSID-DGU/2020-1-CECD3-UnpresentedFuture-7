using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controller : MonoBehaviour
{

    public Text score_text;         // 점수 텍스트 객체
    public static int score = 0;    // 게임 점수
    public GameObject firstprefab;  // 타격 오브젝트
    private Vector3 original_p;     // 타격 오브젝트 위치
    public float delaytime;         // 타격 오브젝트 생성 속도

    // Start is called before the first frame update
    void Start()
    {
        original_p = new Vector3(0.0f, 5.0f, 30.0f);     // 처음 타격 오브젝트의 위치
        StartCoroutine(continueing());              // 타격 오브젝트를 delaytime마다 생성
        delaytime = 2.0f;
    }
    void Update()
    {
        score_text.text = "score : " + score;       // 점수 갱신
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
            yield return new WaitForSeconds(delaytime);
        }
    }
}
