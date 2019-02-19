using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private Rewindable rewindable;
    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        rewindable = GetComponent<Rewindable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!rewindable.isRewinding)
        {
            position.z -= .05f;
            transform.SetPositionAndRotation(position, transform.rotation);
        }
        else  position = transform.position;
    }
}
