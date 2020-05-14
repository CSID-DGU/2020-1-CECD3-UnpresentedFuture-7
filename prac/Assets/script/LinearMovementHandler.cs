using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovementHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public SpeedCapacity TargetMovement;
    // if set true, it forcefully modifies target transform.
    public bool NailedDestination;

    private bool active = false;
    private Vector3 destination;
    private Vector3 direction;
    public void Fire(Vector3 Destination)
    {
        active = true;
        destination = Destination;
        TargetMovement.Apply(Destination - TargetMovement.TargetSpeed.CurrentState());
        direction = (Destination - TargetMovement.TargetSpeed.CurrentState()).normalized;
    }
    void Reset()
    {
        TargetMovement = GetComponent<SpeedCapacity>();
    }

    void end()
    {

        TargetMovement.Abort();
        if (TargetMovement.Acceleration == 0)
        {
            if (NailedDestination)
                TargetMovement.TargetSpeed.SetState(destination, this);
        }
        else
        {
            if (NailedDestination)
            {
                TargetMovement.TargetSpeed.SetState(destination, this);
                TargetMovement.TargetSpeed.acceleration *= 0;
            }
        }
        active = false;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 displacement = destination - TargetMovement.TargetSpeed.CurrentState();
        bool destinationPassed = Vector3.Dot(displacement, direction) < 0;

        if (active)
            if (destinationPassed)
                end();
            else
            {
                float dt;
                float Vi = TargetMovement.TargetSpeed.speed.magnitude;
                float breakdistance;
                dt= (TargetMovement.isDirectionDefined()?
                    Vector3.Dot(TargetMovement.CapacityDirection, TargetMovement.TargetSpeed.speed):Vi)
                    /TargetMovement.Decceleration;
                 breakdistance = Vi* dt-0.5f*TargetMovement.Decceleration*dt*dt;
                if (TargetMovement.Acceleration != 0)
                    if (displacement.magnitude < breakdistance)
                        TargetMovement.Apply(-displacement);

            }



    }
}
