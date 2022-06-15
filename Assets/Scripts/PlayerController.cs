<<<<<<< HEAD
﻿using UnityEngine;

public class PlayerController : MonoBehaviour {

    Drive ds;
    float lastTimeMoving = 0.0f;
    Vector3 lastPosition;
    Quaternion lastRotation;

    CheckpointManager cpm;
    float finishSteer;

    void ResetLayer() {

        ds.rb.gameObject.layer = 0;
        this.GetComponent<Ghost>().enabled = false;
    }

    void Start() {

        ds = this.GetComponent<Drive>();
        this.GetComponent<Ghost>().enabled = false;
        lastPosition = ds.rb.gameObject.transform.position;
        lastRotation = ds.rb.gameObject.transform.rotation;
        finishSteer = Random.Range(-1.0f, 1.0f);
    }

    void Update() {

        if (cpm == null) {

            cpm = ds.rb.GetComponent<CheckpointManager>();
        }

        if (cpm.lap == RaceMonitor.totalLaps + 1) {

            ds.highAccel.Stop();
            ds.Go(0.0f, finishSteer, 0.0f);
        }

        float a = Input.GetAxis("Vertical");
        float s = Input.GetAxis("Horizontal");
        float b = Input.GetAxis("Jump");

        if (ds.rb.velocity.magnitude > 1.0f || !RaceMonitor.racing) {

            lastTimeMoving = Time.time;
        }

        RaycastHit hit;
        if (Physics.Raycast(ds.rb.gameObject.transform.position, -Vector3.up, out hit, 10)) {

            if (hit.collider.gameObject.tag == "road") {

                lastPosition = ds.rb.gameObject.transform.position;
                lastRotation = ds.rb.gameObject.transform.rotation;
            }
        }

        if (Time.time > lastTimeMoving + 4 || ds.rb.gameObject.transform.position.y < -5.0f) {


            ds.rb.gameObject.transform.position = cpm.lastCP.transform.position + Vector3.up * 2;
            ds.rb.gameObject.transform.rotation = cpm.lastCP.transform.rotation;
            ds.rb.gameObject.layer = 8;
            this.GetComponent<Ghost>().enabled = true;
            Invoke("ResetLayer", 3);
        }

        if (!RaceMonitor.racing) a = 0.0f;
        ds.Go(a, s, b);

        ds.CheckForSkid();
        ds.CalculateEngineSound();
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    float lastTimeMoving = 0.0f;
    Vector3 lastPosition;
    Quaternion lastRotation;
    CheckpointManager checkpointManager;
    float finishSteer;

    // Start is called before the first frame update
    void Start()
    {
        drive = this.GetComponent<Drive>();
        this.GetComponent<Ghost>().enabled = false;

        lastPosition = drive.rigidBody.gameObject.transform.position;
        lastRotation = drive.rigidBody.gameObject.transform.rotation;

        finishSteer = Random.Range(-0.2f, 0.2f);
    }

    void ResetLayer()
    {
        drive.rigidBody.gameObject.layer = LayerMask.NameToLayer("Default");
        this.GetComponent<Ghost>().enabled = false;
    }

    void Update()
    {
        float acceleration = Input.GetAxis("Vertical");
        float steering     = Input.GetAxis("Horizontal");
        float braking      = Input.GetAxis("Jump");

        if (checkpointManager == null)
        {
            checkpointManager = drive.rigidBody.GetComponent<CheckpointManager>();
        }

        // Game Over condition
        if (checkpointManager.lap == RaceMonitor.totalLaps + 1)
        {
            drive.highAccel.Stop();
            drive.Go(0.0f, steering, 1.0f);
            return;
        }

        RaycastHit hit;
        if (Physics.Raycast(drive.rigidBody.gameObject.transform.position, -Vector3.up, out hit, 10.0f))
        {
            if (hit.collider.gameObject.tag == "road")
            {
                lastPosition = drive.rigidBody.gameObject.transform.position;
                lastRotation = drive.rigidBody.gameObject.transform.rotation;

                if (drive.rigidBody.velocity.magnitude > 1 || !RaceMonitor.racing)
                {
                    lastTimeMoving = Time.time;
                }
            }
        }

        if (Time.time > lastTimeMoving + 4.0f || withinSceneBoundaries())
        {
            Vector3 reSpawnPosition = checkpointManager.lastCP.transform.position +
                Vector3.up * 3 + // place the car 2m above the road
                Vector3.forward * 6 + // 6m forward
                new Vector3(Random.Range(-3, 3), 0, Random.Range(-3, 3)); // randomize the position around the waypoint

            drive.rigidBody.gameObject.transform.position = reSpawnPosition;
            drive.rigidBody.gameObject.transform.rotation = checkpointManager.lastCP.transform.rotation;
            drive.rigidBody.gameObject.layer = LayerMask.NameToLayer("ReSpawn");
            this.GetComponent<Ghost>().enabled = true;
            Invoke("ResetLayer", 3);
        }

        if (!RaceMonitor.racing)
        {
            acceleration = 0.0f;
        }

        drive.Go(acceleration, steering, braking);
        drive.CheckForSkid();
        drive.CalculateEngineSound();
    }
}
>>>>>>> 5d07cb3b5bed478ecb98548a5c7f2f4cda7ef84e
