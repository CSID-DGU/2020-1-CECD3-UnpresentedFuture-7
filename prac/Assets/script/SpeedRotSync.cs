using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedRotSync : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform follower;
    public Speed target;
    void Start()
    {
        
    }
    void Reset()
    {
        target = gameObject.GetComponent<Speed>();
        follower=gameObject.GetComponent<Transform>();
        follower.rotation = Quaternion.LookRotation(target.speed);
    }

    // Update is called once per frame
    void Update()
    {
        follower.rotation = Quaternion.LookRotation(target.speed);
    }
}
