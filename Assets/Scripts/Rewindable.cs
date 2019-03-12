using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewindable : MonoBehaviour
{
    public bool isRewinding = false;

    List<PointInTime> pointsInTime;

    private float speed = .5f;
    private float journeyLength;
    private float startTime;
    private bool isRB;
    private bool shouldRecord = false;
    Rigidbody rb;

    private UnityStandardAssets.ImageEffects.Grayscale grayscale;

    // Start is called before the first frame update
    void Start()
    { 
        pointsInTime = new List<PointInTime>();
        if (GetComponent<Rigidbody>())
        {
            isRB = true;
            rb = GetComponent<Rigidbody>();
        }
        else isRB = false;
        grayscale = FindObjectOfType<UnityStandardAssets.ImageEffects.Grayscale>();
        Record();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            StartRewind();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopRewind();
        }
        else if (isRewinding) { Rewind(); }
        else if (shouldRecord)
        {
            Record();
            shouldRecord = false;
        }
        else shouldRecord = true;
    }

    void Rewind()
    {
        if (grayscale._Strength > 0){
            grayscale._Strength -= .05f;
        }

        if (pointsInTime.Count > 0)
        {
            PointInTime pointInTime = pointsInTime[0];

            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            pointsInTime.RemoveAt(0);
        }
        else
        {
            transform.position = transform.position;
            transform.rotation = transform.rotation;
        }
    }

    void Record()
    {
        PointInTime current = new PointInTime(transform.position, transform.rotation);
        if (pointsInTime.Count > 0 && (current.position != pointsInTime[0].position || current.rotation.normalized != pointsInTime[0].rotation.normalized))
        {
            Debug.Log("hi");
            pointsInTime.Insert(0, current);
        }
        else if (pointsInTime.Count == 0)
            pointsInTime.Insert(0, current);
    }

    void StartRewind()
    {
        if (Time.timeScale != 1) Time.timeScale = 1;
        isRewinding = true;
        if (isRB) rb.isKinematic = true;
        Rewind();
    }
    void StopRewind()
    {
        isRewinding = false;
        if (isRB) rb.isKinematic = false;
    }
}
