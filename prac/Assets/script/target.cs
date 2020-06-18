using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class target : MonoBehaviour
{
    Rigidbody r;
    Vector3 target_b;
    Vector3 original_p;
    int target_speed;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
        target_b = new Vector3(0.0f, 5.0f, 0.1f);
        original_p = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 타격 오브젝트 이동
        transform.position = Vector3.MoveTowards(transform.position, target_b, 10.0f * Time.deltaTime);
        // 지정된 위치에 타격 오브젝트 도착시 객체 소멸
        if (transform.position == target_b)
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        // Hand 객체와 충돌 시 타격 오브젝트 파괴
        if (collision.gameObject.tag == "hand")
        {
            controller.score++;

            GetComponent<MeshExploder>().Explode();// 깨지는 이미지 구현한거 
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
            Debug.Log("collision : " + collision.gameObject.tag);
        }
    }
}