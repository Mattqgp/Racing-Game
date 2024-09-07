using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableWheelPhysicMat : MonoBehaviour
{
    WheelCollider wheel;
    // Start is called before the first frame update
    void Start()
    {
        wheel = GetComponent<WheelCollider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (wheel.GetGroundHit(out WheelHit hit))
        {
            WheelFrictionCurve fFriction = wheel.forwardFriction;
            fFriction.stiffness = hit.collider.material.staticFriction;
            wheel.forwardFriction = fFriction;
            WheelFrictionCurve sFriction = wheel.sidewaysFriction;
            sFriction.stiffness = hit.collider.material.staticFriction;
            wheel.sidewaysFriction = sFriction;
        }
    }
}
