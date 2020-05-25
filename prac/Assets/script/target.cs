using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    Rigidbody r;
    public Transform box;
    public Transform box2;
  //  public GameObject firstprefab;
   // public controller ct;
    Vector3 target_b;
    Vector3 original_p;
    int target_speed;
    // Start is called before the first frame update
    void Start()
    {

        //firstprefab = GetComponent<GameObject>();
        r = GetComponent<Rigidbody>();
        target_b = (box.position + box2.position) / 2;
        original_p = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,target_b , 0.1f);
        if (transform.position == target_b)
        {
            GetComponent<MeshExploder>().Explode(); this.gameObject.SetActive(false);
            Invoke("f", 2f); 

        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        //=Vector3.Dot(); // 내적   // 주먹쥐었니???
        //GetComponent<MeshRenderer>().enabled = false;
        if (collision.gameObject.tag=="hand")
        {
            controller.score++;
            //  GetComponent<Speed>().speed = collision.gameObject.GetComponent<FistSpeed>().CurrentSpeed;
            // speed라는게 원래 있는 건가 보데..?
            /*   Vector3 CurrentSpeed=GetComponent<FistSpeed>().CurrentSpeed;// 이런식으로 가져오는 거구나...
            if (CurrentSpeed.magnitude > 10)
            {
            }
            */
            GetComponent<MeshExploder>().Explode();// 깨지는 이미지 구현한거 
            //  Instantiate<GameObject>(AfterEffect,transform,true); // 폭발 하는거 
            this.gameObject.SetActive(false);
            Debug.Log("score: " + controller.score);
            Invoke("f", 2f);
            Debug.Log("colli : " + collision.gameObject.tag);
        }
       
    }

    private void f()
    {
        
        this.transform.position = original_p;
        this.gameObject.SetActive(true);
        transform.position = Vector3.MoveTowards(transform.position, target_b, 0.1f);
    }
    private void OnDisable()
    {
        //original_p = original_p * Random.Range(0.5f, 1f);
        original_p = new Vector3(original_p.x * Random.Range(0.8f, 1.1f), original_p.y * Random.Range(0f, 2f), original_p.z * Random.Range(0f, 2f));
        r.velocity = new Vector3(0, 0, 0);
        r.ResetInertiaTensor();
        
    }
    private void OnEnable()
    {
        
        target_b = (box.position + box2.position) / 2;
        transform.position = Vector3.MoveTowards(transform.position, target_b, 0.1f);

    }

}
