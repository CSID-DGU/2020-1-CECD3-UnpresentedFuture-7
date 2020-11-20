using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rankingMenuMove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform targetPosition;

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, targetPosition.localPosition, speed * Time.deltaTime);
    }
}
