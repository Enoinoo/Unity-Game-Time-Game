using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameRobot : MonoBehaviour
{
    public bool rotating = false;
    public Vector3 rotationDestination;

    public bool endRotation = false;
    private Rewindable rewindable;
    private Transform target;
    private float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rewindable = GetComponent<Rewindable>();
        target = FindObjectOfType<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotating && !rewindable.isRewinding)
        {
            Rotate();
        }
    }

    void Rotate()
    {
        Vector3 targetDir = target.position - transform.position;
        //Debug.Log(targetDir);

        // The step size is equal to speed times frame time.
        float step = speed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        //newDir.z = -newDir.z;
        //Debug.Log(newDir);
        Debug.DrawRay(transform.position, newDir, Color.red);

        // Move our position a step closer to the target.
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    void Rotate2()
    {
        //rotationDestination = FindObjectOfType<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().transform.rotation.eulerAngles;
        //rotationDestination = Quaternion.FromToRotation(transform.forward, FindObjectOfType<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().transform.forward).eulerAngles;
        Debug.Log(rotationDestination);
        if (Vector3.Distance(transform.eulerAngles, rotationDestination) > 0.01f)
        {
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, rotationDestination, Time.deltaTime);
        }
        else
        {
            transform.eulerAngles = rotationDestination;
            rotating = false;
            endRotation = true;
        }
        
    }
}
