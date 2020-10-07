using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gloves : MonoBehaviour
{   private GameObject hand;
    private bool glovein=false;
    private Vector3 originposition;
    Vector3 Offset;
    // Start is called before the first frame update
    void Start()
    {
        originposition=transform.position;
        
      
        //Offset = transform.position - hand.transform.position;
       // Offset =  hand.transform.position-transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = hand.transform.position+Offset;
       // hand.transform.position=transform.position +Offset;
        if(glovein){ 
            transform.position=hand.transform.position;
            }
         
    
    }
        //  if (collision.gameObject.tag == "hand")
        // {
        //   hand=collision.gameObject;
        //   transform.position=hand.transform.position;
        //         glovein=true;
        //        Debug.Log("인식 완료 ");  

        // }
        
        void OnTriggerStay(Collider other){

    
    hand=other.gameObject;
     Debug.Log("hand : "+hand.tag);
        
        if(hand.tag=="glove"){
        transform.position=originposition;
        return;
        }
         else if(hand.tag=="hand"){ 
             transform.position=hand.transform.position;
             glovein=true;
        }
        }

}
