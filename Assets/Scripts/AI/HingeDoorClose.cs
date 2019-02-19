using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeDoorClose : MonoBehaviour
{
    public float rate = .01f;

    private float initialAngle;
    private Rewindable rewindable;

    // Start is called before the first frame update
    void Start()
    {
        initialAngle = transform.rotation.y;
        rewindable = GetComponent<Rewindable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!rewindable.isRewinding)
            Rotate();
    }

    void Rotate()
    {
        Quaternion rotation = transform.rotation;

        if (initialAngle > 0 && rotation.y > 0)
        {
            rotation.y -= rate;

            transform.SetPositionAndRotation(transform.position, rotation);
        }
        else if (initialAngle < 0 && rotation.y < 0)
        {
            rotation.y += rate;

            transform.SetPositionAndRotation(transform.position, rotation);
        }
    }
}
