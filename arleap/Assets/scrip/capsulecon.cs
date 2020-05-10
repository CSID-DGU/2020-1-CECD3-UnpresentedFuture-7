using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capsulecon : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rigid;
    float a,b;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        a = Input.GetAxis("Horizontal");
        b = Input.GetAxis("Vertical");
        rigid.AddForce(new Vector3(a*0.05f, 0, b * 0.05f), ForceMode.Impulse);
    }
    /* private void OnCollisionEnter(Collision collision)
     {
       if (gameObject.name == "Capsule" && collision.gameObject.name == "Cube")
         {
             Debug.Log("collsion with cube!!!");
         }
         else if (gameObject.name == "Cube" && collision.gameObject.name == "Capsule")
             Debug.Log("collision with capsule!!!");
     }*/


   // void OnTriggerStay(Collider other)
   // {/*
   //     Debug.Log("collision!");
   //     if (other.gameObject.name == "Capsule")
   //     {
   //         Debug.Log("cube hit capsule");
   //     }else if (other.gameObject.name == "Cube")
   //     {
   //         Debug.Log("capsule hit cube");
   //     }
    
   //// 지금 얘는 is trigger 체크한 capsule 이나 cube와 접촉하면 콘솔에 창이 뜨게 됩니다
         
   //      */

   // }
}
