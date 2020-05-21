using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public GameObject Target;

    float offsetX;
    float offsetY;
     float offsetZ;
    // Start is called before the first frame update
    void Start()
    {
        offsetX = transform.position.x - Target.transform.position.x;
        offsetY = transform.position.y - Target.transform.position.y;
        offsetZ = transform.position.z - Target.transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 FixedPos =
            new Vector3(
            Target.transform.position.x + offsetX,
            Target.transform.position.y + offsetY,
            Target.transform.position.z + offsetZ);
        transform.position = FixedPos;
        //transform.position = Vector3.Lerp(transform.position, FixedPos, Time.deltaTime * DelayTime);
            



    }
}
