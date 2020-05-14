using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCapacity : MonoBehaviour
{
    // if CapacityDirection is set, it only handles this direction of speed;
    public Vector3 CapacityDirection;
    // if set to true, it applies same to -CapacityDirection
    public bool AppliedBothWay = true;
    // maxspeed is default speed when accel is set to zero. there is no max speed if it's set to 0
    public float MaxSpeed;
    public float Acceleration;
    // Decceleartion is set to Accelerartion if it's set to zero.
    public float Decceleration;
    public Movement TargetSpeed;
    private bool applying = false;
    private Vector3 lastAppliedDirection = new Vector3();
    private float lastAppliedScalar;
    public void Apply(Vector3 direction = new Vector3())
    {
        if (applying)
            Abort();
        applying = true;
        float scalar;
        float Dot_Ordered_Capacity = Vector3.Dot(direction.normalized, CapacityDirection);
        float Dot_Ordered_speed = Vector3.Dot(direction.normalized, TargetSpeed.speed);
        bool PushOrdered = Dot_Ordered_speed > 0;//
        bool ShouldAccel = (PushOrdered && AppliedBothWay) || (Dot_Ordered_Capacity > 0);
        lastAppliedDirection = isDirectionDefined() ? CapacityDirection : direction.normalized;

        if (Acceleration == 0)
            scalar = (isDirectionDefined()) ? Mathf.Max(MaxSpeed * Dot_Ordered_Capacity, 0) : MaxSpeed;
        else
        {
            scalar = Dot_Ordered_Capacity;
            if (ShouldAccel)
                scalar *= Acceleration;
            else
                scalar *= Decceleration;
        }
        lastAppliedScalar = scalar;

        if (Acceleration == 0)
            TargetSpeed.speed += scalar * lastAppliedDirection;
        else
            TargetSpeed.acceleration += scalar * lastAppliedDirection;
    }
    public void Abort()
    {
        if (applying)
        {
            if (Acceleration == 0)
                TargetSpeed.speed -= lastAppliedScalar * lastAppliedDirection;
            else
                TargetSpeed.acceleration -= lastAppliedScalar * lastAppliedDirection;
            applying = false;
        }
    }
    void Reset()
    {
        TargetSpeed = GetComponent<Movement>();
    }
    void Start()
    {
        if (CapacityDirection.magnitude >= 1)
            CapacityDirection.Normalize();
        Decceleration = Decceleration == 0 ? Acceleration : Decceleration;
    }

    // Update is called once per frame
    void Update()
    {
        if (applying)
        {
            float dot;
            if (isDirectionDefined())
            {
                if (AppliedBothWay)
                {
                    dot = Vector3.Dot(TargetSpeed.speed, CapacityDirection);
                    float direcf = (dot > 0) ? 1 : -1;
                    if (Mathf.Abs(dot) > MaxSpeed)
                        TargetSpeed.speed -= (dot - MaxSpeed) * direcf * CapacityDirection;
                }
                else
                if ((dot = Vector3.Dot(TargetSpeed.speed, CapacityDirection)) > MaxSpeed)
                    TargetSpeed.speed -= (dot - MaxSpeed) * CapacityDirection;
            }
            else
            {
                if ((TargetSpeed.speed.magnitude) > MaxSpeed)
                    TargetSpeed.speed = MaxSpeed / TargetSpeed.speed.magnitude * TargetSpeed.speed;
            }
        }
    }
    public bool isDirectionDefined()
    {
        return CapacityDirection.magnitude < 0.5;
    }
}
