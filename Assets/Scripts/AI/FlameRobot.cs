using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameRobot : MonoBehaviour
{
    public bool rotateTowards = false;

    private Vector3 startDirection;
    private Rewindable rewindable;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        rewindable = GetComponent<Rewindable>();
        target = FindObjectOfType<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().transform;
        startDirection = transform.position + transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateTowards && !rewindable.isRewinding)
        {
            Rotate(target.position);
        }
        else if (!rotateTowards && !rewindable.isRewinding)
        {
            Rotate(startDirection);
        }
    }

    void Rotate(Vector3 targetPos)
    {
        Vector3 targetDir = targetPos - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, Time.deltaTime, 0.0f);

        // Move our position a step closer to the target.
        transform.rotation = Quaternion.LookRotation(newDir);
    }

}
