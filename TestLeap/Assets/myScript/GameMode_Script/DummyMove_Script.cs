using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyMove_Script : MonoBehaviour
{
    [SerializeField] Transform[] dummy;
    [SerializeField] Transform[] target;
    [SerializeField] float speed;

    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            dummy[i].position = Vector3.MoveTowards(dummy[i].position, target[i].position, speed * Time.deltaTime);
        }
    }
}
