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
    GameObject targettmp;//---------------------------------------0618 성두
    int hp;
    int maxhp;
    float target_speed;
    Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        
        target_speed=5f*(1+((float)controller.level/20f));// 원래 10 f

        renderer = gameObject.GetComponent<Renderer>();
        hp = (int)Random.Range(1f, 4f);
        maxhp = hp;
        switch (hp)
        {
            case 1:
                renderer.material.color = Color.white;
                break;
            case 2:
                renderer.material.color = Color.red;
                break;
  
         
            default:
                renderer.material.color = Color.black;
                break;
        }
        r = GetComponent<Rigidbody>();
        target_b = new Vector3(0.0f, 5.0f, 0.1f);

        original_p = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
      //  targettmp = GameObject.FindGameObjectWithTag("target");
    //    target_b = targettmp.transform.position;

        // 타격 오브젝트 이동
        transform.position = Vector3.MoveTowards(transform.position, target_b, target_speed * Time.deltaTime);
        // 지정된 위치에 타격 오브젝트 도착시 객체 소멸
        if (transform.position == target_b)
        {
            this.gameObject.SetActive(false);
            controller.heart -= this.hp;
            Destroy(this.gameObject);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        // Hand 객체와 충돌 시 타격 오브젝트 파괴
        if (collision.gameObject.tag == "hand")
        {
            hp -= 1;
            switch (hp)
            {
                case 1:
                    renderer.material.color = Color.white;
                    break;

                case 2:
                    renderer.material.color = Color.red;
                    break;
                default:
                    renderer.material.color = Color.black;
                    break;
            }

            if (hp <= 0)
            {
                controller.heart += maxhp;
                controller.score += maxhp;

              
                    controller.level = (controller.score / 5) +1;
                    
                
                    GetComponent<MeshExploder>().Explode();// 깨지는 이미지 구현한거 
                this.gameObject.SetActive(false);
                Destroy(this.gameObject);
            }

            Debug.Log("collision : " + collision.gameObject.tag);
        }
    }
}
