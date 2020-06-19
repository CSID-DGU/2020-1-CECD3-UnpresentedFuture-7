using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

    public void PointerDown()
    // 포인터가 다운될 떄 호출된다. 
    // 즉, 이 스크립트가 버튼에 들어 있다면 버튼이 눌리는 순간 한번 호출되는 함수
    // eventData에는 PointerEventData형이 콜백되는데 유용하게 사용되니 살펴보는 것을 추천한다.
    {
        transform.position = Vector3.MoveTowards(transform.position, target_box, 3f);
    }

    public void PointerUp()
    // 포인터가 Up될 때 호출된다. 버튼이라면 버튼이 올라오는 순간 한번 호출되는 함수
    {
        transform.position = Vector3.MoveTowards(transform.position, origin, 3f);
    }
}