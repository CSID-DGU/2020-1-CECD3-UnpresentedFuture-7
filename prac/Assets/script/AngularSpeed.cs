using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngularSpeed : Movement
{
    void Reset()
    {
        TargetTransform = gameObject.transform;
    }

    // Update is called once per frame
    public override Vector3 CurrentState()
    {
        if (ApplyAsLocalSpeed)
            return TargetTransform.localRotation.eulerAngles;
        else
            return TargetTransform.rotation.eulerAngles;
    }
    public override void SetState(Vector3 state, MonoBehaviour caller)
    {
        if (ApplyAsLocalSpeed)
            TargetTransform.localRotation = Quaternion.Euler(state);
        else
            TargetTransform.rotation= Quaternion.Euler( state);
    }
    void Update()
    {
        if (ApplyAsLocalSpeed)
        {
            TargetTransform.localRotation *= Quaternion.Euler(TargetTransform.forward * speed.z * Time.deltaTime);
            TargetTransform.localRotation *= Quaternion.Euler(TargetTransform.up * speed.y * Time.deltaTime);
            TargetTransform.localRotation *= Quaternion.Euler(TargetTransform.right * speed.x * Time.deltaTime);
        }
        else
        {
            TargetTransform.rotation *= Quaternion.Euler(TargetTransform.forward * speed.z * Time.deltaTime);
            TargetTransform.rotation *= Quaternion.Euler(TargetTransform.up * speed.y * Time.deltaTime);
            TargetTransform.rotation *= Quaternion.Euler(TargetTransform.right * speed.x * Time.deltaTime);
        }
        speed += acceleration * Time.deltaTime;
    }
}
