using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_maincamera : MonoBehaviour
{    Vector3 Offset;
 public GameObject maincam;
 private float rotateDamping=10.0f;
    // Start is called before the first frame update
    void Start()
    {
        Offset = transform.position - maincam.transform.position;
     //   Offset =  maincam.transform.position-transform.position;
    }

    // Update is called once per frame
    void Update()
    {
          transform.position = maincam.transform.position+Offset;
        //  transform.rotation=Quaternion.Slerp(transform.rotation,maincam.transform.rotation,Time.deltaTime*rotateDamping);
         // maincam.transform.LookAt(transform);
       //  transform.LookAt(maincam.transform);
        // transform.rotation=Quaternion.Euler(60,-180,0);
         // maincam.transform.position=transform.position +Offset;
    }
}
