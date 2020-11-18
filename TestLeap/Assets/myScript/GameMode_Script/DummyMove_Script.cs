using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyMove_Script : MonoBehaviour
{
    [SerializeField] Transform[] dummy;
    [SerializeField] Transform[] target;
    [SerializeField] Transform[] text;
    [SerializeField] Transform[] textTarget;

    [SerializeField] float speed;

    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            dummy[i].position = Vector3.MoveTowards(dummy[i].position, target[i].position, speed * Time.deltaTime);
        }

        for (int i = 0; i < 3; i++)
        {
            text[i].position = Vector3.MoveTowards(text[i].position, textTarget[i].position, speed * Time.deltaTime);
        }
    }
}
