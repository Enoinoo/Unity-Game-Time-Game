using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPositionOverTime : MonoBehaviour
{
    public Vector3 targetPos;
    public float timeToReachTarget;
    private Vector3 startPos;
    private float t;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != targetPos)
        {
            t += Time.deltaTime / timeToReachTarget;
            transform.position = Vector3.Lerp(startPos, targetPos, t);
        }
    }
}
