using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePanel : MonoBehaviour
{
    public GameObject[] gameObjects;

    private MoveToPositionOverTime moveToPositionOverTime;
    private bool startedMoving = false;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        moveToPositionOverTime = GetComponentInParent<MoveToPositionOverTime>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startedMoving)
        {
            timer += Time.deltaTime;
            if(timer >= moveToPositionOverTime.timeToReachTarget)
            {
                StartEvents();
            }
        }
    }

    void StartEvents()
    {
        foreach(GameObject obj in gameObjects)
        {
            MoveToPositionOverTime move = obj.GetComponent<MoveToPositionOverTime>();
            if (move && !move.enabled)
            {
                move.enabled = true;
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player" && !startedMoving)
        {
            moveToPositionOverTime.targetPos = transform.position;
            moveToPositionOverTime.targetPos.y -= .3f;
            moveToPositionOverTime.enabled = true;
            startedMoving = true;
        }
    }
}
