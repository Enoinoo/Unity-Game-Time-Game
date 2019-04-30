using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeDoor : MonoBehaviour
{
    public float rate = .01f;
    public bool open = false;
    public bool openToRightSide = false;
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

        if (open)
        {
            if (openToRightSide && rotation.y < .7f)
            {
                rotation.y += rate;
                Debug.Log(rotation.y);
                transform.SetPositionAndRotation(transform.position, rotation);
            }
            else if (!openToRightSide && rotation.y > -.7f)
            {
                rotation.y -= rate;

                transform.SetPositionAndRotation(transform.position, rotation);
            }
        }
        else
        {
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
}
