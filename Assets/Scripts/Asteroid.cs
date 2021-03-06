﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    float x, y, z;
    bool changeVelocity = false;
    bool alreadyChanged = false;
    Vector3 rotation;
    SkyboxRotation skybox;
    public Rigidbody rb;
    public bool rewindable = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        skybox = FindObjectOfType<SkyboxRotation>();
        x = Random.Range(0f, 1f);
        y = Random.Range(0f, 1f);
        z = Random.Range(0f, 1f);
        rotation = new Vector3(x, y, z);
    }

    // Update is called once per frame
    void Update()
    {
        if (rewindable)
        {
            if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonDown(0))
            {
                ChangeVelocity();
            }
        }
    }

    void FixedUpdate()
    {
        if (!skybox.isRewinding)
        {
            transform.Rotate(rotation);
        }
        if (skybox.isRewinding)
        {
            transform.Rotate(-rotation);
        }
    }

    public void ChangeVelocity()
    {
        rb.velocity = -rb.velocity;
    }

}
