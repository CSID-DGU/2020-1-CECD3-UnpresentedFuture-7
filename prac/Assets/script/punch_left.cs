using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punch_left : MonoBehaviour
{
    Rigidbody r;
    Vector3 target_box;
    Vector3 origin;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
        origin = transform.position;

        target_box = new Vector3(-1.0f, 5.0f, 2.0f);

        //target_box = new Vector3(origin.x + 0.0001f, origin.y, origin.z);
    }

    // Update is called once per frame
    void Update()
    {
        // 왼쪽 키를 누르면 목표한 위치로 Sphere_left 객체 이동
        // 왼쪽 키를 누르면 목표한 위치로 Sphere_left 객체 이동
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // transform.position = target_box;
            transform.position = Vector3.MoveTowards(transform.position, target_box, 3f);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            transform.position = Vector3.MoveTowards(transform.position, origin, 3f);
            // transform.position = origin;
        }
    }
}