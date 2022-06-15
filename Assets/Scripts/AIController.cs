<<<<<<< HEAD
﻿using UnityEngine;

public class AIController : MonoBehaviour {

    Renderer rend;
    public Circuit circuit;
    public float brakingSensitivity = 1.1f;
    public float steeringSensitivity = 0.01f;
    public float accelSensitivity = 0.3f;
    Drive ds;
    Vector3 target;
    Vector3 nextTarget;
    int currentWP = 0;
    float totalDistanceToTarget;

    GameObject tracker;
    int currentTrackerWP = 0;
    public float lookAhead = 10;

    float lastTimeMoving = 0.0f;

    CheckpointManager cpm;
    float finishSteer;

    void Start() {

        if (circuit == null) {

            circuit = GameObject.FindGameObjectWithTag("circuit").GetComponent<Circuit>();
        }

        for (int i = 0; i < circuit.waypoints.Length; ++i) {

            circuit.waypoints[i].SetActive(false);
        }
        ds = this.GetComponent<Drive>();
        target = circuit.waypoints[currentWP].transform.position;
        nextTarget = circuit.waypoints[currentWP + 1].transform.position;
        totalDistanceToTarget = Vector3.Distance(target, ds.rb.gameObject.transform.position);

        tracker = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        DestroyImmediate(tracker.GetComponent<Collider>());
        tracker.GetComponent<MeshRenderer>().enabled = false;
        tracker.transform.position = ds.rb.gameObject.transform.position;
        tracker.transform.rotation = ds.rb.gameObject.transform.rotation;
        this.GetComponent<Ghost>().enabled = false;
        finishSteer = Random.Range(-1.0f, 1.0f);
    }

    void ProgressTracker() {

        Debug.DrawLine(ds.rb.gameObject.transform.position, tracker.transform.position);

        if (Vector3.Distance(ds.rb.gameObject.transform.position, tracker.transform.position) > lookAhead) {

            return;
        }

        tracker.transform.LookAt(circuit.waypoints[currentTrackerWP].transform.position);
        tracker.transform.Translate(0.0f, 0.0f, 1.0f);  // Speed of the tracker;

        if (Vector3.Distance(tracker.transform.position, circuit.waypoints[currentTrackerWP].transform.position) < 1.0f) {

            currentTrackerWP++;
            if (currentTrackerWP >= circuit.waypoints.Length) {

                currentTrackerWP = 0;
            }
        }
    }

    void ResetLayer() {

        ds.rb.gameObject.layer = 0;
        this.GetComponent<Ghost>().enabled = false;
    }

    void Update() {
        if (!RaceMonitor.racing) {

            lastTimeMoving = Time.time;
            return;
        }


        if (cpm == null) {

            cpm = ds.rb.GetComponent<CheckpointManager>();
        }

        if (cpm.lap == RaceMonitor.totalLaps + 1) {

            ds.highAccel.Stop();
            ds.Go(0, finishSteer, 0);
            return;
        }

        ProgressTracker();

        Vector3 localTarget;
        float targetAngle;

        if (ds.rb.velocity.magnitude > 1.0f) {

            lastTimeMoving = Time.time;
        }

        if (this.transform.position.y < -2.0f) {

            Debug.Log("Off the track");
        }

        if (Time.time > lastTimeMoving + 4 || ds.rb.gameObject.transform.position.y < -5.0f) {


            ds.rb.gameObject.transform.position = cpm.lastCP.transform.position + Vector3.up * 2.0f;
            ds.rb.gameObject.transform.rotation = cpm.lastCP.transform.rotation;
            //circuit.waypoints[currentTrackerWP].transform.position + Vector3.up * 2 +
            //new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(-1.0f, 1.0f));
            tracker.transform.position = cpm.lastCP.transform.position;
            ds.rb.gameObject.layer = 8;
            this.GetComponent<Ghost>().enabled = true;
            Invoke("ResetLayer", 3);
        }

        if (Time.time < ds.rb.GetComponent<AvoidDetector>().avoidTime) {

            localTarget = tracker.transform.right * ds.rb.GetComponent<AvoidDetector>().avoidPath;
        } else {

            localTarget = ds.rb.gameObject.transform.InverseTransformPoint(tracker.transform.position);
        }
        targetAngle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;

        float steer = Mathf.Clamp(targetAngle * steeringSensitivity, -1.0f, 1.0f) * Mathf.Sign(ds.currentSpeed);

        float speedFactor = ds.currentSpeed / ds.maxSpeed;

        float corner = Mathf.Clamp(Mathf.Abs(targetAngle), 0.0f, 90.0f);
        float cornerFactor = corner / 90.0f;

        float brake = 0.0f;
        if (corner > 10 && speedFactor > 0.1f) {

            brake = Mathf.Lerp(0.0f, 1.0f + speedFactor * brakingSensitivity, cornerFactor);
        }

        float accel = 1.0f;
        if (corner > 20.0f && speedFactor > 0.4f) {

            accel = Mathf.Lerp(0.0f, 1.0f * accelSensitivity, 1 - cornerFactor);
        }

        float prevTorque = ds.torque;
        if (speedFactor < 0.3f && ds.rb.gameObject.transform.forward.y > 0.2f) {

            ds.torque *= 3.0f;
            accel = 1.0f;
            brake = 0.0f;
        }

        if (!RaceMonitor.racing) accel = 0.0f;
        ds.Go(accel, steer, brake);

        ds.CheckForSkid();
        ds.CalculateEngineSound();

        ds.torque = prevTorque;
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : BaseController
{
    public Circuit circuit;

    public float brakingSensitivity = 1.0f;
    public float steeringSensitivity = 0.01f;
    public float accelSensitivity = 1.0f;
    public float lookAhead = 24.0f;

    protected Vector3 target;
    protected Vector3 nextTarget;
    protected int currentWaypoint = 0;
    protected int nextWaypoint = 0;
    protected GameObject tracker;
    protected int currentTrackerWP = 0;
    protected float trackerPrevHeight = 0.0f;
    protected float lastTimeMoving = 0.0f;
    protected CheckpointManager checkpointManager;

    private float totalDistanceToTarget;
    float finishSteer;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        if (circuit == null)
        {
            circuit = GameObject.FindGameObjectWithTag("circuit").GetComponent<Circuit>();
        }

        drive = this.GetComponent<Drive>();

        if (checkpointManager == null)
        {
            checkpointManager = drive.rigidBody.GetComponent<CheckpointManager>();
        }

        target = circuit.waypoints[currentWaypoint].transform.position;
        nextTarget = circuit.waypoints[currentWaypoint + 1].transform.position;
        totalDistanceToTarget = Vector3.Distance(target, drive.rigidBody.gameObject.transform.position);

        tracker = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        DestroyImmediate(tracker.GetComponent<Collider>());
        tracker.gameObject.GetComponent<MeshRenderer>().enabled = false;
        tracker.transform.position = drive.rigidBody.transform.position;
        tracker.transform.rotation = drive.rigidBody.transform.rotation;

        this.GetComponent<Ghost>().enabled = false;
        finishSteer = Random.Range(-0.2f, 0.2f);
    }

    protected void ProgressTracker()
    {
        Debug.DrawLine(drive.rigidBody.transform.position, tracker.transform.position);

        if (Vector3.Distance(drive.rigidBody.gameObject.transform.position, tracker.transform.position) > lookAhead)
        {
            return;
        }

        tracker.transform.LookAt(circuit.waypoints[currentTrackerWP].transform.position);
        tracker.transform.Translate(0, 0, 1.0f); // speed of tracker

        if (Vector3.Distance(tracker.transform.position, circuit.waypoints[currentTrackerWP].transform.position) < 1.0f)
        {
            currentTrackerWP++;
            if (currentTrackerWP >= circuit.waypoints.Length)
            {
                currentTrackerWP = 0;
            }
        }
    }

    void ResetLayer()
    {
        drive.rigidBody.gameObject.layer = LayerMask.NameToLayer("Default");
        this.GetComponent<Ghost>().enabled = false;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!RaceMonitor.racing)
        {
            lastTimeMoving = Time.time;
        }

        if (checkpointManager == null)
        {
            Debug.Log("The CheckpointManager property is undefined.");
            return;
        }

        if (circuit == null)
        {
            Debug.Log("The Circuit property is undefined.");
            return;
        }

        // Game Over condition
        if (checkpointManager.lap == RaceMonitor.totalLaps + 1)
        {
            drive.highAccel.Stop();
            drive.Go(0.0f, finishSteer, 1.0f);
            return;
        }

        ProgressTracker();

        Vector3 localTarget;
        float targetAngle;
        float braking = 0.0f;
        float acceleration = 1.0f;
        float speedFactorWeight = 2.8f;
        float targetAngleWeight = 3.6f;
        float steeringSensitivityLocal = steeringSensitivity;

        if (drive.rigidBody.velocity.magnitude > 1.0f)
        {
            lastTimeMoving = Time.time;
        }

        if (Time.time > lastTimeMoving + 4.0f || withinSceneBoundaries())
        {
            Vector3 reSpawnPosition = checkpointManager.lastCP.transform.position +
                Vector3.up * 3 + // place the car 2m above the road
                Vector3.forward * 6 + // 6m forward
                new Vector3(Random.Range(-3, 3), 0, Random.Range(-3, 3)); // randomize the position around the waypoint

            drive.rigidBody.gameObject.transform.position = reSpawnPosition;
            drive.rigidBody.gameObject.transform.rotation = checkpointManager.lastCP.transform.rotation;
            tracker.transform.position = reSpawnPosition;

            lastTimeMoving = Time.time;

            drive.rigidBody.gameObject.layer = LayerMask.NameToLayer("ReSpawn");
            this.GetComponent<Ghost>().enabled = true;
            Invoke("ResetLayer", 3);
        }

        if (Time.time < drive.rigidBody.GetComponent<AvoidDetector>().avoidTime)
        {
            localTarget = tracker.transform.right * drive.rigidBody.GetComponent<AvoidDetector>().avoidPath;
        }
        else
        {
            localTarget = drive.rigidBody.gameObject.transform.InverseTransformPoint(tracker.transform.position);
        }

        if (avoidObstacleMode(out Vector3 avoidDirection))
        {
            localTarget = avoidDirection;
            steeringSensitivityLocal *= 2.0f;
        }

        targetAngle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;

        float steering = Mathf.Clamp(targetAngle * steeringSensitivityLocal, -1, 1) * Mathf.Sign(drive.currentSpeed);

        float speedFactor = (drive.currentSpeed / drive.maxSpeed) * speedFactorWeight;
        float targetAngleFactor = (Mathf.Abs(targetAngle) / 90.0f) * targetAngleWeight;

        // Debug.Log("BRAKING - SPEED: "+ (int)(Mathf.Lerp(0, 1, speedFactor) * 100) +
        //     "%, ANGLE: " + (int)(Mathf.Lerp(0, 1, targetAngleFactor) * 100) + 
        //     "% TOTAL: " + (int)(Mathf.Lerp(0, 1, speedFactor * targetAngleFactor) * 100) + "%");

        braking = Mathf.Lerp(-1.0f, 1.0f, speedFactor * targetAngleFactor);
        acceleration = Mathf.Lerp(accelSensitivity, 1.0f, 1.0f + accelSensitivity - braking);

        if (drive.currentSpeed < 4.0f || drive.IsClimbing)
        {
            // a new approach bellow
            // braking = 0.0f;
            // acceleration = 1.0f;
        }

        float prevTorque = drive.torque;
        if (speedFactor < 0.3f && drive.rigidBody.gameObject.transform.forward.y > 0.1f)
        {
            drive.torque *= 3.0f;
            acceleration = 1.0f;
            braking = 0.0f;
        }
        else
        {
            drive.torque = prevTorque;
        }

        if (!RaceMonitor.racing)
        {
            acceleration = 0.0f;
        }

        // Debug.Log("DRIVE.GO - ACCEL: " + (int)(acceleration * 100) +
        //     "%, BRAKE: " + (int)(Mathf.Clamp(braking, 0, 1) * 100) + "%");

        drive.Go(acceleration, steering, braking);
        drive.CheckForSkid();
        drive.CalculateEngineSound();
    }

    private bool avoidObstacleMode(out Vector3 avoidDirection)
    {
        bool avoidObstacleMode = false;

        float rayLength = 20.0f;

        RaycastHit hit;
        Vector3 raycastOrigin = drive.rigidBody.gameObject.transform.position +
            drive.rigidBody.gameObject.transform.forward * 2 +
            (-drive.rigidBody.gameObject.transform.up * 0.2f);
        Vector3 raycastDirection = drive.rigidBody.gameObject.transform.forward;
        avoidDirection = raycastDirection;

        bool isHit = Physics.Raycast(raycastOrigin, raycastDirection, out hit, rayLength);
        if (isHit)
        {
            if (hit.collider.gameObject.tag == "car")
            {
                avoidObstacleMode = true;
            }
        }

        Vector3 toTracker = drive.rigidBody.gameObject.transform.forward + tracker.transform.forward;
        avoidDirection = Vector3.Reflect(-toTracker, drive.rigidBody.gameObject.transform.forward);

        Debug.DrawRay(raycastOrigin, avoidDirection.normalized * rayLength, Color.green);

        return avoidObstacleMode;
    }
}
>>>>>>> 5d07cb3b5bed478ecb98548a5c7f2f4cda7ef84e
