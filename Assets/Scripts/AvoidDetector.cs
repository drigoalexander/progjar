<<<<<<< HEAD
﻿using UnityEngine;

public class AvoidDetector : MonoBehaviour {

    public float avoidPath = 0.0f;
    public float avoidTime = 0.0f;
    public float wanderDistance = 4.0f;
    public float avoidLength = 1.0f;

    private void OnCollisionExit(Collision collision) {

        if (collision.gameObject.tag != "car") return;
        avoidTime = 0.0f;
    }

    private void OnCollisionStay(Collision collision) {

        if (collision.gameObject.tag != "car") return;

        Rigidbody otherCar = collision.rigidbody;
        avoidTime = Time.time + avoidLength;

        Vector3 otherCarLocalTarget = transform.InverseTransformPoint(otherCar.gameObject.transform.position);
        float otherCarAngle = Mathf.Atan2(otherCarLocalTarget.x, otherCarLocalTarget.z);
        avoidPath = wanderDistance * -Mathf.Sign(otherCarAngle);
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidDetector : MonoBehaviour
{
    public float avoidPath = 0.0f;
    public float avoidTime = 0.0f;
    public float wanderDistance = 4.0f; // avoiding distance
    public float avoidLength = 0.2f;

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag != "car")
        {
            return;
        }

        avoidTime = 0;
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag != "car")
        {
            return;
        }

        Rigidbody otherCar = other.rigidbody;
        avoidTime = Time.time + avoidLength;

        Vector3 otherCarLocalTarget = transform.InverseTransformPoint(otherCar.gameObject.transform.position);
        float otherCarAngle = Mathf.Atan2(otherCarLocalTarget.x, otherCarLocalTarget.z);
        avoidPath = wanderDistance * -Mathf.Sin(otherCarAngle);
    }
}
>>>>>>> 5d07cb3b5bed478ecb98548a5c7f2f4cda7ef84e
