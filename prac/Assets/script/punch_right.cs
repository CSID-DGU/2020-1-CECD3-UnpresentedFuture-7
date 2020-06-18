﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punch_right : MonoBehaviour
{
    Rigidbody r;
    Vector3 target_box;
    Vector3 origin;
    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
        r = GetComponent<Rigidbody>();

        target_box = new Vector3(1.0f, 5.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // 오른쪽 키를 누르면 목표한 위치로 Sphere_right 객체 이동
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            transform.position = Vector3.MoveTowards(transform.position, target_box, 3f);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            transform.position = Vector3.MoveTowards(transform.position, origin, 3f);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 4e70962f62051da42bf81dd1c3a50353552cd376
