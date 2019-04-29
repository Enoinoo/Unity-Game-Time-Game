using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPositionOverTime : MonoBehaviour
{
    public Vector3 targetPos;
    public float timeToReachTarget;
    private Vector3 startPos;
    private float t;
    private Rewindable rewindable;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rewindable = GetComponent<Rewindable>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rewindable)
        {
            if (!rewindable.isRewinding)
            {
                Move();
            }
        }
        else
        {
            Move();
        }
    }

    void Move()
    {
        if (transform.position != targetPos)
        {
            t += Time.deltaTime / timeToReachTarget;
            transform.position = Vector3.Lerp(startPos, targetPos, t);
        }
    }
}
