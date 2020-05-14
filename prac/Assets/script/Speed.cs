using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : Movement
{
    // Start is called before the first frame update
    public bool init_as_local_speed = false;


    public override Vector3 CurrentState()
    {
        if (ApplyAsLocalSpeed)
            return TargetTransform.localPosition;
        else
            return TargetTransform.position;
    } 
    public override void SetState(Vector3 state, MonoBehaviour caller)
    {
        if (ApplyAsLocalSpeed)
            TargetTransform.localPosition = state;
        else
            TargetTransform.position= state;
    }

    void Awake()
    {
        if (init_as_local_speed)
        {
            speed = TargetTransform.right * speed.x + TargetTransform.up * speed.y + TargetTransform.forward * speed.z;
            acceleration = TargetTransform.right * acceleration.x + TargetTransform.up * acceleration.y + TargetTransform.forward * acceleration.z;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ApplyAsLocalSpeed)
            TargetTransform.localPosition += speed * Time.deltaTime;
        else
            TargetTransform.position += speed * Time.deltaTime;
        speed += acceleration * Time.deltaTime;
    }
}