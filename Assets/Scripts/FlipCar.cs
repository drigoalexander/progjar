<<<<<<< HEAD
﻿using UnityEngine;

public class FlipCar : MonoBehaviour {

    Rigidbody rb;
    float lastTimeChecked;

    void Start() {

        rb = this.GetComponent<Rigidbody>();
    }

    void RightCar() {

        this.transform.position += Vector3.up;
        this.transform.rotation = Quaternion.LookRotation(this.transform.forward);
    }

    void Update() {

        if (transform.up.y > 0.5f || rb.velocity.magnitude > 1.0f) {

            lastTimeChecked = Time.time;
        }

        if (Time.time > lastTimeChecked + 3.0f) {

            RightCar();
        }
    }
}
=======
﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCar : MonoBehaviour
{
    Rigidbody rigidBody;
    float lastTimeChecked;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void RightCar()
    {
        this.transform.position += Vector3.up;
        this.transform.rotation = Quaternion.LookRotation(this.transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.up.y > 0.5f || rigidBody.velocity.magnitude > 1)
        {
            lastTimeChecked = Time.time;
        }

        if (Time.time > lastTimeChecked + 3)
        {
            RightCar();
        }
    }
}
>>>>>>> 5d07cb3b5bed478ecb98548a5c7f2f4cda7ef84e
