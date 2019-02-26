using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{

    private FlameRobot flameRobot;

    // Start is called before the first frame update
    void Start()
    {
        flameRobot = GetComponentInParent<FlameRobot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (!flameRobot.rotating && !flameRobot.endRotation)
        {
            if (col.tag == "Player") flameRobot.rotating = true;
        }

    }
}
