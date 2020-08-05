using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gloves : MonoBehaviour
{   public GameObject hand;
    Vector3 Offset;
    // Start is called before the first frame update
    void Start()
    {
        
      
        //Offset = transform.position - hand.transform.position;
        Offset =  hand.transform.position-transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = hand.transform.position+Offset;
        hand.transform.position=transform.position +Offset;
    
    }
}
