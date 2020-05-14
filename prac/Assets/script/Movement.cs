using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    public abstract Vector3 CurrentState();
    public abstract void SetState(Vector3 state, MonoBehaviour caller);
    public Vector3 speed;
    public Vector3 acceleration;
    public Transform TargetTransform;
    public bool ApplyAsLocalSpeed = false;
    void Reset()
    {
        TargetTransform = GetComponent<Transform>();
    }
}
