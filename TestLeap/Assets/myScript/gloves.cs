using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gloves : MonoBehaviour
{       private Vector3 LastPos;
    public Vector3 CurrentSpeed;
    // Start is called before the first frame update
    void Start()
    {
        LastPos = transform.position;
        CurrentSpeed = transform.position;
      
        //Offset = transform.position - hand.transform.position;
       // Offset =  hand.transform.position-transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
Vector3 displacement = transform.position - LastPos;
        CurrentSpeed = displacement / Time.deltaTime;
        // Debug.Log(CurrentSpeed.magnitude);
        LastPos = transform.position;
         
    
    }
        //  if (collision.gameObject.tag == "hand")
        // {
        //   hand=collision.gameObject;
        //   transform.position=hand.transform.position;
        //         glovein=true;
        //        Debug.Log("인식 완료 ");  

        // }
        
        private void OnCollisionEnter(Collision collision)
    {
       GameObject a=collision.gameObject;
       target tar=a.GetComponent<target>();
       

        // Hand 객체와 충돌 시 타격 오브젝트 파괴
        if (collision.gameObject.tag == "target")
        {

            Debug.Log("coll speed in target script : " + CurrentSpeed.magnitude);

            switch (controller.mode)
            {
                case 1:
                    if (CurrentSpeed.magnitude > 4)
                    {
                               tar.hp-=1;
                      controller.ishit=true;
                      controller.myAudio.Play(); 
                        Debug.Log("----------------------------------------------------5 이상 성공 normal " + CurrentSpeed.magnitude);
                    }
                    break;
                case 2:
                    if (CurrentSpeed.magnitude > 6)
                    {    controller.myAudio.Play(); 
                              tar.hp-=1;
                        Debug.Log("------------------------------------------------------------7이상 성공 hard  " + CurrentSpeed.magnitude);
                    }
                    break;
                default:    controller.myAudio.Play(); 
                       tar.hp-=1;
                    Debug.Log("------------------------------------------------------------ 성공 easy  " + CurrentSpeed.magnitude);
                  
                    break;
            }






            Debug.Log("collision : " + collision.gameObject.tag);
        }
    }

}
