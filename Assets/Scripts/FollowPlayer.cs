using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = camera.transform.position;
        targetPos.z -= 0.5f;
        targetPos.x -= .2f;
        transform.position = targetPos;
    }
}
