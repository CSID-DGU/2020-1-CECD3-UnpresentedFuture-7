using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject target;

    public float offsetX;
    public float offsetY;
    public float offsetZ;

    public float DelayTime=1;
    // Start is called before the first frame update
    void Start()
    {
        offsetX = transform.position.x;
        offsetY = transform.position.y;
        offsetZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 FixedPos =
            new Vector3(
            target.transform.position.x + offsetX,
            target.transform.position.y + offsetY,
            target.transform.position.z + offsetZ);
        // transform.position = Vector3.Lerp(transform.position, FixedPos, Time.deltaTime * DelayTime);
        transform.position = FixedPos;
    }
}
