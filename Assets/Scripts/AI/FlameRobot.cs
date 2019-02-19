using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameRobot : MonoBehaviour
{
    public Quaternion rotationDestination;

    private Quaternion currentRotation;

    // Start is called before the first frame update
    void Start()
    {
        currentRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
