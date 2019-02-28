using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    public GameObject flameThrower;
    public float fieldOfViewAngle = 110f;

    private FlameRobot flameRobot;
    private bool playerInSight;

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

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            Vector3 direction = col.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);

            if (angle < fieldOfViewAngle * 0.5f)
            {
                //RaycastHit hit;
                //if (Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, GetComponent<SphereCollider>().radius))
                //{
                //if (hit.collider.tag == "Player" && !flameThrower.activeInHierarchy)
                    if(!flameThrower.activeInHierarchy)
                    {
                        Fire();
                    }

                //}
            }
            else if (flameThrower.activeInHierarchy)
            {
                StopFire();
            }
        }

    }

    void Fire()
    {
        flameThrower.SetActive(true);
    }

    void StopFire()
    {
        flameThrower.SetActive(false);
    }
}
