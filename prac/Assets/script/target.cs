using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class target : MonoBehaviour
{
<<<<<<< HEAD
    Rigidbody r;
    Vector3 target_b;
    Vector3 original_p;
    int target_speed;
=======
    private Rigidbody r;
    private Vector3 target_b;
    private Vector3 original_p;
    private int target_speed;
>>>>>>> 4e70962f62051da42bf81dd1c3a50353552cd376
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
<<<<<<< HEAD
=======
            //GetComponent<MeshExploder>().Explode();
>>>>>>> 4e70962f62051da42bf81dd1c3a50353552cd376
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
<<<<<<< HEAD
        // Hand 객체와 충돌 시 타격 오브젝트 파괴
        if (collision.gameObject.tag == "hand")
        {
            controller.score++;

=======
        if (collision.gameObject.tag == "hand")
        {
            controller.score++;
            //  GetComponent<Speed>().speed = collision.gameObject.GetComponent<FistSpeed>().CurrentSpeed;
            // speed라는게 원래 있는 건가 보데..?
            /*   Vector3 CurrentSpeed=GetComponent<FistSpeed>().CurrentSpeed;// 이런식으로 가져오는 거구나...
            if (CurrentSpeed.magnitude > 10)
            {
            }
            */
>>>>>>> 4e70962f62051da42bf81dd1c3a50353552cd376
            GetComponent<MeshExploder>().Explode();// 깨지는 이미지 구현한거 
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
            Debug.Log("collision : " + collision.gameObject.tag);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 4e70962f62051da42bf81dd1c3a50353552cd376
