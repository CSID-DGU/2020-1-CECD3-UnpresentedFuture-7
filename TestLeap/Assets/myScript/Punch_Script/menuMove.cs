using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuMove : MonoBehaviour
{
    [SerializeField] float speed;

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, new Vector3(0, 0, 10), speed * Time.deltaTime);
    }
}
